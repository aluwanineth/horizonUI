using HorizonPollyC.Models.Configuration;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class DataArtefact
    {
        RadzenDataGrid<DataArtefactVM> dataartefactGrid = null;
        DataArtefactVM dataartefactToInsert = null;
        public IEnumerable<DataArtefactVM> dataartefacts = new List<DataArtefactVM>();
        bool enable = true;
        //[Inject]
        //public IExportService _exportService { get; set; }
        //[Inject]
        //public IAnnIncFactorService _annincfactorService { get; set; }
        //[Inject]
        //public IJSRuntime js { get; set; }


        protected override async Task OnInitializedAsync()
        {

            dataartefacts = await _dataartefactService.GetDataArtefacts();

        }

        public async Task Export(string type)
        {
            await _exportService.ExportData<DataArtefactVM>(dataartefactGrid, type, "DataArtefact", "DataArtefacts");
        }


        async Task EditRow(DataArtefactVM dataartefact)
        {
            await dataartefactGrid.EditRow(dataartefact);
        }

        async void OnUpdateRow(DataArtefactVM dataartefact)
        {
            if (dataartefact == dataartefactToInsert)
            {
                dataartefactToInsert = null;
            }


            await _dataartefactService.UpdateDataArtefact(dataartefact);

        }

        async Task SaveRow(DataArtefactVM dataartefact)
        {

            if (dataartefact == dataartefactToInsert)
            {
                dataartefactToInsert = null;
            }

            await dataartefactGrid.UpdateRow(dataartefact);
        }

        void CancelEdit(DataArtefactVM dataartefact)
        {
            if (dataartefact == dataartefactToInsert)
            {
                dataartefactToInsert = null;
            }

            dataartefactGrid.CancelEditRow(dataartefact);

        }

        async Task DeleteRow(DataArtefactVM dataartefact)
        {
            if (dataartefact == dataartefactToInsert)
            {
                dataartefactToInsert = null;
            }

            if (dataartefacts.Contains(dataartefact))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                dataartefacts.ToList().Remove(dataartefact);

                // For production
                //dbContext.SaveChanges();

                await dataartefactGrid.Reload();
            }
            else
            {
                dataartefactGrid.CancelEditRow(dataartefact);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            dataartefactToInsert = new DataArtefactVM();
            await dataartefactGrid.InsertRow(dataartefactToInsert);

        }

        async Task OnCreateRow(DataArtefactVM dataartefact)
        {
            // dbContext.Add(order);
            await _dataartefactService.SaveDataArtefact(dataartefact);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
