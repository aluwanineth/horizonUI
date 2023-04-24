using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
//using MoreLinq;
using Radzen;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Query = Radzen.Query;

using HorizonPollyC.Models.Configuration;
using Microsoft.AspNetCore.Mvc;
using Radzen.Blazor;

using Microsoft.JSInterop;

namespace HorizonPollyC.Services.General
{
    public class ExportService : IExportService
    {
        private readonly HttpClient httpClient;

        private readonly IConfiguration _configuration;
        private readonly IJSRuntime js;
        string BaseURIConfig;
        public ExportService(IConfiguration Configuration, HttpClient httpClient, IJSRuntime _js)
        {
            this.httpClient = httpClient;

            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
            this.httpClient = httpClient;
            this.js = _js;
        }


        public async Task<IQueryable<T>> ExportData<T>(RadzenDataGrid<T> RadzonGrid, string type ,string Controller, string Action)
        {
 
            if (type == "excel")
            {
                byte[] response = await ExportDataToExcel<T>(Controller, Action, new Query()
                {
                    OrderBy = RadzonGrid.Query.OrderBy,
                    Filter = RadzonGrid.Query.Filter,
                    Select = string.Join(",", RadzonGrid.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
                });

                await js.InvokeVoidAsync("saveAsFile", $"DataFile.xlsx", Convert.ToBase64String(response));
            }
            else
            {
                byte[] response = await ExportProductsToCSV<T>(Controller, Action, new Query()
                {
                    OrderBy = RadzonGrid.Query.OrderBy,
                    Filter = RadzonGrid.Query.Filter,
                    Select = string.Join(",", RadzonGrid.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
                });

                await js.InvokeVoidAsync("saveAsFile", $"DataFile.csv", Convert.ToBase64String(response));
            }

            return await GetData<T>(Controller, Action);

        }



        public async Task<byte[]> ExportDataToExcel<T>(string Controller, string Action, Query query = null)
        {

            var data = await GetData<T>(Controller, Action);

            var result =ApplyQuery<T>(data, query);
            var response = ToExcel(result, Action);
            byte[] PageBytes = new byte[response.FileStream.Length];

            var memoryStream = new MemoryStream();
            response.FileStream.CopyTo(memoryStream);
            PageBytes = memoryStream.ToArray();
            return PageBytes;
        }

        public async Task<byte[]> ExportProductsToCSV<T>(string Controller, string Action, Query query = null)
        {

            var data = await GetData<T>(Controller, Action);

            var result = ApplyQuery<T>(data, query);
            var response = ToCSV(result, Action);
            byte[] PageBytes = new byte[response.FileStream.Length];

            var memoryStream = new MemoryStream();
            response.FileStream.CopyTo(memoryStream);
            PageBytes = memoryStream.ToArray();
            return PageBytes;
        }




        public async Task<IQueryable<T>> GetData<T>(string Controller, string Action) //where T:class
        {
                var data = await httpClient.GetFromJsonAsync<List<T>>(BaseURIConfig + Controller + "/" + Action);
                return data.AsQueryable();
        
        }


        public async Task<IQueryable<T>> GetData<T>(string Controller) //where T:class
        {
            throw new NotImplementedException();
        }



        public IQueryable<T> ApplyQuery<T>(IQueryable<T> items, Query query = null) //where T : class
        {
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy.ToString());
                }

                if (query.Skip != null)
                {
                    items = items.Skip(int.Parse(query.Skip.ToString()));
                }

                if (query.Top != null)
                {
                    items = items.Take(int.Parse(query.Top.ToString()));
                }
            }

            return items;
        }

        public FileStreamResult ToCSV(IQueryable query, string fileName = null)
        {
            var columns = GetProperties(query.ElementType);

            var sb = new StringBuilder();

            foreach (var item in query)
            {
                var row = new List<string>();

                foreach (var column in columns)
                {
                    row.Add($"{GetValue(item, column.Key)}".Trim());
                }

                sb.AppendLine(string.Join(",", row.ToArray()));
            }


            var result = new FileStreamResult(new MemoryStream(UTF8Encoding.Default.GetBytes($"{string.Join(",", columns.Select(c => c.Key))}{System.Environment.NewLine}{sb.ToString()}")), "text/csv");
            result.FileDownloadName = (!string.IsNullOrEmpty(fileName) ? fileName : "Export") + ".csv";

            return result;
        }

        public FileStreamResult ToExcel(IQueryable query, string fileName = null)
        {
            var columns = GetProperties(query.ElementType);
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                GenerateWorkbookStylesPartContent(workbookStylesPart);

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                var headerRow = new Row();

                foreach (var column in columns)
                {
                    headerRow.Append(new Cell()
                    {
                        CellValue = new CellValue(column.Key),
                        DataType = new EnumValue<CellValues>(CellValues.String)
                    });
                }

                sheetData.AppendChild(headerRow);

                foreach (var item in query)
                {
                    var row = new Row();

                    foreach (var column in columns)
                    {
                        var value = GetValue(item, column.Key);
                        var stringValue = $"{value}".Trim();

                        var cell = new Cell();

                        var underlyingType = column.Value.IsGenericType &&
                            column.Value.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                            Nullable.GetUnderlyingType(column.Value) : column.Value;

                        var typeCode = Type.GetTypeCode(underlyingType);

                        if (typeCode == TypeCode.DateTime)
                        {
                            if (stringValue != string.Empty)
                            {
                                
                                cell.CellValue = new CellValue() { Text = DateTime.Parse(stringValue).ToOADate().ToString() };
                                cell.StyleIndex = (UInt32Value)1U;
                            }
                        }
                        else if (typeCode == TypeCode.Boolean)
                        {
                            cell.CellValue = new CellValue(stringValue.ToLower());
                            cell.DataType = new EnumValue<CellValues>(CellValues.Boolean);
                        }
                        else if (IsNumeric(typeCode))
                        {
                            cell.CellValue = new CellValue(stringValue);
                            cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                        }
                        else
                        {
                            cell.CellValue = new CellValue(stringValue);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }

                        row.Append(cell);
                    }

                    sheetData.AppendChild(row);
                }


                workbookPart.Workbook.Save();
            }

            if (stream?.Length > 0)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = (!string.IsNullOrEmpty(fileName) ? fileName : "Export") + ".xlsx";

            return result;
        }

        public static object GetValue(object target, string name)
        {
            return target.GetType().GetProperty(name).GetValue(target);
        }

        public static IEnumerable<KeyValuePair<string, Type>> GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && IsSimpleType(p.PropertyType)).Select(p => new KeyValuePair<string, Type>(p.Name, p.PropertyType));
        }

        public static bool IsSimpleType(Type type)
        {
            var underlyingType = type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                Nullable.GetUnderlyingType(type) : type;

            var typeCode = Type.GetTypeCode(underlyingType);

            switch (typeCode)
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.String:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsNumeric(TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }

        private static void GenerateWorkbookStylesPartContent(WorkbookStylesPart workbookStylesPart1)
        {
            Stylesheet stylesheet1 = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac x16r2 xr" } };
            stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            stylesheet1.AddNamespaceDeclaration("x16r2", "http://schemas.microsoft.com/office/spreadsheetml/2015/02/main");
            stylesheet1.AddNamespaceDeclaration("xr", "http://schemas.microsoft.com/office/spreadsheetml/2014/revision");

            Fonts fonts1 = new Fonts() { Count = (UInt32Value)1U, KnownFonts = true };

            Font font1 = new Font();
            FontSize fontSize1 = new FontSize() { Val = 11D };
            Color color1 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName1 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontScheme1);

            fonts1.Append(font1);

            Fills fills1 = new Fills() { Count = (UInt32Value)2U };

            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            fills1.Append(fill1);
            fills1.Append(fill2);

            Borders borders1 = new Borders() { Count = (UInt32Value)1U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();
            DiagonalBorder diagonalBorder1 = new DiagonalBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);

            borders1.Append(border1);

            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };

            cellStyleFormats1.Append(cellFormat1);

            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)2U };
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };
            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)14U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true };

            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);

            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

            cellStyles1.Append(cellStyle1);
            DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };
            TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleLight16" };

            StylesheetExtensionList stylesheetExtensionList1 = new StylesheetExtensionList();

            StylesheetExtension stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };
            stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");

            StylesheetExtension stylesheetExtension2 = new StylesheetExtension() { Uri = "{9260A510-F301-46a8-8635-F512D64BE5F5}" };
            stylesheetExtension2.AddNamespaceDeclaration("x15", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");

            OpenXmlUnknownElement openXmlUnknownElement4 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<x15:timelineStyles defaultTimelineStyle=\"TimeSlicerStyleLight1\" xmlns:x15=\"http://schemas.microsoft.com/office/spreadsheetml/2010/11/main\" />");

            stylesheetExtension2.Append(openXmlUnknownElement4);

            stylesheetExtensionList1.Append(stylesheetExtension1);
            stylesheetExtensionList1.Append(stylesheetExtension2);

            stylesheet1.Append(fonts1);
            stylesheet1.Append(fills1);
            stylesheet1.Append(borders1);
            stylesheet1.Append(cellStyleFormats1);
            stylesheet1.Append(cellFormats1);
            stylesheet1.Append(cellStyles1);
            stylesheet1.Append(differentialFormats1);
            stylesheet1.Append(tableStyles1);
            stylesheet1.Append(stylesheetExtensionList1);

            workbookStylesPart1.Stylesheet = stylesheet1;
        }
    }
}
