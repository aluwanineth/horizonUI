using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages.Configuration
{
    public partial class Account
    {
        RadzenDataGrid<AccountVM> accountGrid = null;
        AccountVM accountToInsert = null;
        public IEnumerable<AccountVM> accounts = new List<AccountVM>();
        bool enable = true;
        string errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {

            accounts = await _accountService.GetAccounts();

        }

        public async Task Export(string type)
        {
           await _exportService.ExportData<AccountVM>(accountGrid, type, "Account", "Accounts");
        }

        async Task EditRow(AccountVM account)
        {
           
            await accountGrid.EditRow(account);
        }

        async void OnUpdateRow(AccountVM account)
        {
            if (account == accountToInsert)
            {
                accountToInsert = null;
            }

            //validation
            await _accountService.UpdateAccount(account);

        }

        async Task SaveRow(AccountVM account)
        {
            if (account == accountToInsert)
            {
                accountToInsert = null;
            }

            //Validation

            await accountGrid.UpdateRow(account);
        }

        void CancelEdit(AccountVM account)
        {
            if (account == accountToInsert)
            {
                accountToInsert = null;
            }

            accountGrid.CancelEditRow(account);

        }

        async Task DeleteRow(AccountVM account)
        {
            if (account == accountToInsert)
            {
                accountToInsert = null;
            }

            if (accounts.Contains(account))
            {
                // dbContext.Remove<PortionControl>(portioncontrol);

                // For demo purposes only
                accounts.ToList().Remove(account);

                // For production
                //dbContext.SaveChanges();

                await accountGrid.Reload();
            }
            else
            {
                accountGrid.CancelEditRow(account);
            }
        }



        async Task InsertRow()
        {
            enable = false;
            accountToInsert = new AccountVM();
            await accountGrid.InsertRow(accountToInsert);

        }

        async Task OnCreateRow(AccountVM account)
        {
            // dbContext.Add(order);
            await _accountService.SaveAccount(account);
            // For demo purposes only
            // order.Customer = dbContext.Customers.Find(order.CustomerID);
            //order.Employee = dbContext.Employees.Find(order.EmployeeID);

            // For production
            //dbContext.SaveChanges();
        }
    }
}
