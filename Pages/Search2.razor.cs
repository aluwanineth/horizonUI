using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using HorizonPollyC.Models;
using HorizonPollyC.Pages.Components;
using HorizonPollyC.Services;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Radzen;
using Radzen.Blazor;
using System.Text;
using static HorizonPollyC.Pages.Search2;

namespace HorizonPollyC.Pages
{
    partial class Search2
    {
        
        public class ScreenControls
        {
            public String PersonName = "";
            public String PersonSurname = "";
            public String PolicyNo = "";
            public String IFANo = "";
            public String IDPassportNo = "";
            public String ClientNo = "";
            public String ClaimNo = "";
            public String CellphoneNo = "";

            public String LegacyPolicyNo = "";
            public String ApplicationFormNo = "";
            public String EmailAddress = "";
            public String BusinessName = "";
        }
        
        public ScreenControls _screencontrols;
        public Boolean is_loading = false;
        public Boolean error_raised = false;
        public String last_error_description = "";
        public Boolean showing_advanced_search = false;

        public RadzenDataGrid<PersonSearch> ClientsResultsGrid;
        public List<PersonSearch> ClientsModel;
        public IList<PersonSearch> SelectedClients;

        [CascadingParameter]
        public GlobalVariables? Globals { get; set; }
               
        protected override async Task OnInitializedAsync()
        {
            error_raised = false;
            last_error_description = "";
            is_loading = false;

            try
            {

                _screencontrols = new ScreenControls();

                var tempValue = await _localStorageService.GetItemAsStringAsync("LoggedInUser");

                if (Globals.ClientSearchResults != null)
                {
                    ClientsModel = Globals.ClientSearchResults;
                    PersonSearch? item = ClientsModel.FirstOrDefault(p => p.Policy_NO == Globals.PolicyNumber);
                    if (item != null)
                    {
                        ClientsResultsGrid?.SelectRow(item);
                        ClientsResultsGrid?.GoToPage(Globals.SelectedItemPage);
                        SetSelectedPersonItem(item);
                    }

                }
                StateHasChanged();

            } 
            catch (Exception ex)
            {
                Globals.error_msg = "Error on page initialize";
            }

        }

        public void toggle_show_advanced_search(Boolean _new_value)
        {
            showing_advanced_search = _new_value;
            StateHasChanged();

        }

        private Boolean get_are_all_empty(String[] all_vars)
        {

            for (Int32 x = 0; x < all_vars.Length; x++)
            {
                if (!(String.IsNullOrWhiteSpace(all_vars[x])))
                {
                    return false;
                }
            }

            return true;
        }

        private async Task LogSearch(PersonSearchCriteria SearchCriteria, DateTime SearchStart, DateTime SearchEnd, Boolean ExceptionWhileSearching, String ExceptionMessage, Int32 ResultsCount)
        {
            try
            {
                TimeSpan SearchDuration = SearchEnd.Subtract(SearchStart);

                StringBuilder lnb = new StringBuilder();
                lnb.AppendLine(SearchStart.ToString("yyyy-MM-dd HH:mm:ss") + "\t");

                if (!(string.IsNullOrWhiteSpace(SearchCriteria.name)))
                {
                    lnb.Append(" name = '" + SearchCriteria.name + "'");
                }
                if (!(string.IsNullOrWhiteSpace(SearchCriteria.surname)))
                {
                    lnb.Append(" surname = '" + SearchCriteria.surname + "'");
                }
                if (!(string.IsNullOrWhiteSpace(SearchCriteria.policy_no)))
                {
                    lnb.Append(" policy no = '" + SearchCriteria.policy_no + "'");
                }
                if (!(string.IsNullOrWhiteSpace(SearchCriteria.application_form_no)))
                {
                    lnb.Append(" application form no = '" + SearchCriteria.application_form_no + "'");
                }
                if (!(string.IsNullOrWhiteSpace(SearchCriteria.email_address)))
                {
                    lnb.Append(" email address = '" + SearchCriteria.email_address + "'");
                }
                if (!(string.IsNullOrEmpty(SearchCriteria.business_name)))
                {
                    lnb.Append(" business name = '" + SearchCriteria.business_name + "'");
                }

                lnb.Append("\t");
                lnb.Append(SearchDuration.TotalMilliseconds.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\t");
                lnb.Append((ExceptionWhileSearching ? "ERR " + ExceptionMessage + "\t" : "OK\t"));
                lnb.Append(ResultsCount.ToString());

                String LogPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", (DateTime.Now.ToString("yyyy-MM-dd") + ".txt"));
                //await Logger.WriteTextAsync((DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), lnb.ToString());
                //await Logger.WriteTextAsync((@"C:\workings\2023-02-08\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), lnb.ToString());

                byte[] bytesToWrite = Encoding.UTF8.GetBytes(lnb.ToString());

                //using (FileStream fs = new FileStream((@"/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                //{
                //    fs.Write(bytesToWrite, 0, bytesToWrite.Length);
                //    fs.Flush();
                //}

                //using (FileStream fs = System.IO.File.Create(DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
                //{
                //    fs.Write(bytesToWrite, 0, bytesToWrite.Length);
                //}
                String lss = this._localStorageService.ToString();
                DirectoryInfo dir_info = new DirectoryInfo("/home");
                DirectoryInfo[] dirs = dir_info.GetDirectories();
                var finfos = dir_info.GetFiles();

                String cur_dir = System.IO.Directory.GetCurrentDirectory();

                String s1 = AppDomain.CurrentDomain.DynamicDirectory;
                String s2 = AppDomain.CurrentDomain.RelativeSearchPath;
                String s3 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

                Int32 something1 = 0;
            }
            catch (Exception ex)
            {
                Int32 something = 0;
            }
        }

        async Task SearchForPeople()
        {

            DateTime SearchStart = DateTime.Now;
            DateTime SearchEnd = DateTime.Now;
            Boolean ExceptionWhileSearching = false;
            String ExceptionMsg = "";
            Int32 ResultsCount = 0;

            PersonSearchCriteria search_crit = new PersonSearchCriteria();

            try
            {
                Boolean are_all_empty = get_are_all_empty(new string[]
                {
                _screencontrols.PersonName,
                _screencontrols.PersonSurname,
                _screencontrols.PolicyNo,
                _screencontrols.IDPassportNo,
                _screencontrols.ClientNo,
                _screencontrols.CellphoneNo,
                _screencontrols.LegacyPolicyNo,
                _screencontrols.ApplicationFormNo,
                _screencontrols.EmailAddress,
                _screencontrols.BusinessName
                });

                if (are_all_empty)
                {
                    Globals.error_msg = "You must enter at least 1 search parameter";
                    StateHasChanged();
                    return;
                }


                Globals.error_msg = string.Empty;

                is_loading = true;

                StateHasChanged();

                
                //do not send empty strings to the DB for search
                search_crit.name = _screencontrols.PersonName;
                search_crit.surname = _screencontrols.PersonSurname;
                search_crit.policy_no = _screencontrols.PolicyNo;
                search_crit.ID_passport_number = _screencontrols.IDPassportNo;
                search_crit.entity_id = _screencontrols.ClientNo;
                search_crit.cellphone = _screencontrols.CellphoneNo;
                search_crit.legacy_policy_no = _screencontrols.LegacyPolicyNo;
                search_crit.application_form_no = _screencontrols.ApplicationFormNo;
                search_crit.email_address = _screencontrols.EmailAddress;
                search_crit.business_name = _screencontrols.BusinessName;
                
                ClientsModel = await SCVService.GetPersonSearch(search_crit);
                SearchEnd = DateTime.Now;
                ExceptionWhileSearching = false;


                if (ClientsModel == null || ClientsModel.Count() == 0)
                {
                    Globals.error_msg = "No results found";
                    is_loading = false;

                    Globals.EntityID = 0;
                    Globals.PolicyNumber = 0;
                    Globals.ClientSearchResults = null;
                    Globals.SearchedCustomers = null;

                    StateHasChanged();

                    return;
                }

                ResultsCount = ClientsModel.Count;
                is_loading = false;

                Globals.ClientSearchResults = ClientsModel.ToList();


            }
            catch (Exception ex)
            {
                Globals.error_msg = "An error occurred while searching.";
                SearchEnd = DateTime.Now;
                ExceptionWhileSearching = true;
                ExceptionMsg = ex.Message;
                is_loading = false;
            }
            finally
            {
                LogSearch(search_crit, SearchStart, SearchEnd, ExceptionWhileSearching, ExceptionMsg, ResultsCount);
            }

            
            StateHasChanged();
            Globals.SearchedCustomers = null;
        }

        public String selected_name_surname = "";
        public String selected_dob = "";
        public String selected_age = "";
        public String selected_reward_status = "";
        public String selected_status = "";
        public String selected_debicheck_status = "";
        public String selected_sales_person = "";

        public async void ClientSelected(DataGridRowMouseEventArgs<PersonSearch> Arg)
        {
            try 
            { 
                PersonSearch personItem = Arg.Data;
                Globals.EntityID = personItem.EntityID;
                Globals.EntityNO = personItem.EntityNo;
                Globals.CellphoneNumber = personItem.CellphoneNo;
                Globals.EmailAddress = personItem.EmailAddress;
                Globals.PersonFirstName = personItem.PersonFirstName;
                Globals.PersonSurname = personItem.PersonSurname;
                Globals.PolicyNumber = personItem.Policy_NO.Value;
                Globals.SelectedItemPage = ClientsResultsGrid.CurrentPage;


                SetSelectedPersonItem(personItem);

                StateHasChanged();
                NavManager.NavigateTo("Search");
            }
            catch (Exception ex) 
            { 
                Globals.error_msg = $"Error loading details {ex.ToString()}"; StateHasChanged(); 
            }
        }

        private void SetSelectedPersonItem(PersonSearch personItem)
        {
            CustomerPolicies selected_pol = new CustomerPolicies();
            selected_pol.Policy_NO = personItem.Policy_NO.Value;
            selected_pol.IFA_No = 0;
            selected_pol.Product = personItem.PlanTypeDescription;
            selected_pol.Policy_Status = personItem.PlanStatus1;
            selected_pol.Status_Date = personItem.Status_Date.Value;
            selected_pol.DOC = personItem.Date_of_Commencement.Value;
            selected_pol.Payer = personItem.PayerNames;
            selected_pol.Policy_Premium = personItem?.Premium ?? 0;
            selected_pol.EntityID = personItem.EntityID;
            //selected_pol.Billed_to =  new DateTime(2023, 1, 1);
            //selected_pol.Paid_to = new DateTime(2023, 1, 1);
            //selected_pol.Premium_Count = 1;
            //selected_pol.Premium_Frequency = 1;
            //selected_pol.Sales_Person = "Unknown";
            //selected_pol.DebiCheck_Status = "Unknown";
            Globals.EntityNO = personItem.EntityNo;
            Globals.SelectedCustomersPolicy = selected_pol;

            selected_name_surname = (personItem.PersonFirstName ?? "UNSPECIFIED") + " " + (personItem.PersonSurname ?? "UNSPECIFIED");
            selected_dob = personItem.PersonDOB == null ? "UNSPECIFIED" : personItem.PersonDOB.Value.ToString("yyyy/MM/dd");

            if (personItem.PersonDOB != null)
            {
                DateTime dob_to_use = new DateTime(personItem.PersonDOB.Value.Year, personItem.PersonDOB.Value.Month, personItem.PersonDOB.Value.Month == 2 && personItem.PersonDOB.Value.Day == 29 ? 28 : personItem.PersonDOB.Value.Day);
                Int32 year_age_counter = 0;
                DateTime date_iter = new DateTime(dob_to_use.Year + 1, dob_to_use.Month, dob_to_use.Day);
                while (date_iter <= DateTime.Now)
                {
                    year_age_counter++;
                    date_iter = new DateTime(date_iter.Year + 1, date_iter.Month, date_iter.Day);
                }
                selected_age = year_age_counter.ToString();
            }

            selected_reward_status = personItem.RewardStatus ?? "UNSPECIFIED";
            selected_status = personItem.PlanStatus1 ?? "UNSPECIFIED";
            selected_debicheck_status = personItem.DebicheckStatus ?? "UNSPECIFIED";
            selected_sales_person = personItem.SalesPerson ?? "UNSPECIFIED";
        }
        private void OnStateHasChanged()
        {
            try { StateHasChanged(); }
            catch (Exception ex) { Console.WriteLine($"{ex.ToString()}"); }

        }
    }
}
