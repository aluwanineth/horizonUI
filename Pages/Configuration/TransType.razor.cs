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
    public partial class TransType
    {
        RadzenDataGrid<TransTypeVM> transTypeGrid = null;
        TransTypeVM transTypeToInsert = null;
        public IEnumerable<TransTypeVM> transTypes = new List<TransTypeVM>();
        bool enable = true;



        protected override async Task OnInitializedAsync()
        {

            transTypes = await _transTypeService.GetTransType();

        }
        public async Task Export(string type)
        {
            await _exportService.ExportData<TransTypeVM>(transTypeGrid, type, "TransType", "TransType");
        }


        async Task EditRow(TransTypeVM transType)
        {
            await transTypeGrid.EditRow(transType);
        }

        async void OnUpdateRow(TransTypeVM transType)
        {
            if (transType == transTypeToInsert)
            {
                transTypeToInsert = null;
            }


            await _transTypeService.UpdateTransType(transType);

        }

        async Task SaveRow(TransTypeVM transType)
        {
            if (transType == transTypeToInsert)
            {
                transTypeToInsert = null;
            }

            await transTypeGrid.UpdateRow(transType);
        }

        void CancelEdit(TransTypeVM transType)
        {
            if (transType == transTypeToInsert)
            {
                transTypeToInsert = null;
            }

            transTypeGrid.CancelEditRow(transType);

        }

        async Task DeleteRow(TransTypeVM transType)
        {
            if (transType == transTypeToInsert)
            {
                transTypeToInsert = null;
            }

            if (transTypes.Contains(transType))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                transTypes.ToList().Remove(transType);

                // For production
                //dbContext.SaveChanges();

                await transTypeGrid.Reload();
            }
            else
            {
                transTypeGrid.CancelEditRow(transType);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            transTypeToInsert = new TransTypeVM();
            await transTypeGrid.InsertRow(transTypeToInsert);

        }

        async Task OnCreateRow(TransTypeVM transType)
        {
            // dbContext.Add(order);
            await _transTypeService.SaveTransType(transType);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
