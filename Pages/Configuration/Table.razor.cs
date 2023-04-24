using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System.Linq;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Table
    {
        RadzenDataGrid<TableVM> tableGrid = null;
        TableVM tablesToInsert = null;
        public IEnumerable<TableVM> tables = new List<TableVM>();
        bool enable = true;


        protected override async Task OnInitializedAsync()
        {

            tables = await _tablesService.GetTable();

        }


        public async Task Export(string type)
        {
            await _exportService.ExportData<TableVM>(tableGrid, type, "Table", "Table");
        }


        async Task EditRow(TableVM table)
        {
            await tableGrid.EditRow(table);
        }

        async void OnUpdateRow(TableVM table)
        {
            if (table == tablesToInsert)
            {
                tablesToInsert = null;
            }


            await _tablesService.UpdateTable(table);

        }

        async Task SaveRow(TableVM table)
        {
            if (table == tablesToInsert)
            {
                tablesToInsert = null;
            }

            await tableGrid.UpdateRow(table);
        }

        void CancelEdit(TableVM table)
        {
            if (table == tablesToInsert)
            {
                tablesToInsert = null;
            }

            tableGrid.CancelEditRow(table);

        }

        async Task DeleteRow(TableVM table)
        {
            if (table == tablesToInsert)
            {
                tablesToInsert = null;
            }

            if (tables.Contains(table))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                tables.ToList().Remove(table);

                // For production
                //dbContext.SaveChanges();

                await tableGrid.Reload();
            }
            else
            {
                tableGrid.CancelEditRow(table);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            tablesToInsert = new TableVM();
            await tableGrid.InsertRow(tablesToInsert);

        }

        async Task OnCreateRow(TableVM table)
        {
            // dbContext.Add(order);
            await _tablesService.SaveTable(table);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
