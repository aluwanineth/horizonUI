using HorizonPollyC.Models;
using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class PortionControl
    {
        RadzenDataGrid<PortionControlVM> portioncontrolGrid = null;
        PortionControlVM portioncontrolToInsert = null;
        public IEnumerable<PortionControlVM> portioncontrols = new List<PortionControlVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            portioncontrols = await _portioncontrolService.GetPortionControls();

        }


        public async Task Export(string type)
        {
            await _exportService.ExportData<PortionControlVM>(portioncontrolGrid, type, "PortionControl", "PortionControl");
        }


        async Task EditRow(PortionControlVM portioncontrol)
        {
            await portioncontrolGrid.EditRow(portioncontrol);
        }

        async void OnUpdateRow(PortionControlVM portioncontrol)
        {
            if (portioncontrol == portioncontrolToInsert)
            {
                portioncontrolToInsert = null;
            }


            await _portioncontrolService.UpdatePortionControl(portioncontrol);

        }

        async Task SaveRow(PortionControlVM portioncontrol)
        {
            if (portioncontrol == portioncontrolToInsert)
            {
                portioncontrolToInsert = null;
            }


            await portioncontrolGrid.UpdateRow(portioncontrol);
        }

        void CancelEdit(PortionControlVM portioncontrol)
        {
            if (portioncontrol == portioncontrolToInsert)
            {
                portioncontrolToInsert = null;
            }

            portioncontrolGrid.CancelEditRow(portioncontrol);

        }

        async Task DeleteRow(PortionControlVM portioncontrol)
        {
            if (portioncontrol == portioncontrolToInsert)
            {
                portioncontrolToInsert = null;
            }

            if (portioncontrols.Contains(portioncontrol))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                portioncontrols.ToList().Remove(portioncontrol);

                // For production
                //dbContext.SaveChanges();

                await portioncontrolGrid.Reload();
            }
            else
            {
                portioncontrolGrid.CancelEditRow(portioncontrol);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            portioncontrolToInsert = new PortionControlVM();
            await portioncontrolGrid.InsertRow(portioncontrolToInsert);

        }

        async Task OnCreateRow(PortionControlVM portioncontrol)
        {
            // dbContext.Add(order);
            await _portioncontrolService.SavePortionControl(portioncontrol);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
