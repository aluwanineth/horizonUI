using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Attribute
    {
        RadzenDataGrid<AttributeVM> attributeGrid = null;
        AttributeVM attributeToInsert = null;
        public IEnumerable<AttributeVM> attributes = new List<AttributeVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            attributes = await _attributeService.GetAttributes();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<AttributeVM>(attributeGrid, type, "Attribute", "Attributes");
        }


        async Task EditRow(AttributeVM attribute)
        {
            await attributeGrid.EditRow(attribute);
        }

        async void OnUpdateRow(AttributeVM attribute)
        {
            if (attribute == attributeToInsert)
            {
                attributeToInsert = null;
            }


            await _attributeService.UpdateAttribute(attribute);

        }

        async Task SaveRow(AttributeVM attribute)
        {
            if (attribute == attributeToInsert)
            {
                attributeToInsert = null;
            }

            await attributeGrid.UpdateRow(attribute);
        }

        void CancelEdit(AttributeVM attribute)
        {
            if (attribute == attributeToInsert)
            {
                attributeToInsert = null;
            }

            attributeGrid.CancelEditRow(attribute);

        }

        async Task DeleteRow(AttributeVM attribute)
        {
            if (attribute == attributeToInsert)
            {
                attributeToInsert = null;
            }

            if (attributes.Contains(attribute))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                attributes.ToList().Remove(attribute);

                // For production
                //dbContext.SaveChanges();

                await attributeGrid.Reload();
            }
            else
            {
                attributeGrid.CancelEditRow(attribute);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            attributeToInsert = new AttributeVM();
            await attributeGrid.InsertRow(attributeToInsert);

        }

        async Task OnCreateRow(AttributeVM attribute)
        {
            // dbContext.Add(order);
            await _attributeService.SaveAttribute(attribute);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
