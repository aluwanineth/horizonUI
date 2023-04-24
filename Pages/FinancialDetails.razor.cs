using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using HorizonPollyC.Models;
using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Models.Financial;
using HorizonPollyC.Pages.Components;
using HorizonPollyC.Pages.Configuration;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace HorizonPollyC.Pages
{
    public partial class FinancialDetails
    {
        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        public FinancialDetailsVM financialDetails { get; set; }
        public IEnumerable<LegacyPaymentVM> legacyPaymentLookup;
        public IEnumerable<YesNoVM> yesNoLookup;
        public IEnumerable<CustomerPolicies> policyLookupbank;
        public IEnumerable<CustomerPolicies> policyLookupdebit;
        public IEnumerable<CustomerPolicies> policyLookup;
        public IEnumerable<BankVM> bankLookup;
        public IEnumerable<AccountTypesVM> accountTypesLookup;
        public IEnumerable<GenderVM> genderLookup;
        public IEnumerable<StatusVM> statusLookup;
        public string bankbranchLookup = string.Empty;
        public List<Debicheck> debiCheckList;
        public string textboxStyle = "width:100%;border-color:transparent;";
        // RadzenCheckBox<bool> checkbox = null;
        bool checkBox1Value = false;
        bool checkBox2Value = false;
        bool checkBox3Value = false;
        bool checkBox4Value = false;
        bool checkBox5Value = false;
        bool hasBankingApp = false;
        protected override async Task OnInitializedAsync()
        {

         
            financialDetails = new FinancialDetailsVM();
            legacyPaymentLookup = await _legacypaymentService.GetLegacyPayments();
            yesNoLookup = await _yesnoService.GetYesNos();
            bankLookup = await _financialService.GetBanks();
            accountTypesLookup = await _financialService.GetAccountTypes();
            genderLookup = await _genderService.GetGenders();
            var details = await _financialService.GetFinancialDetails(userInfo);

            if (details.AccountNumber != null)
            {
                financialDetails = details;
            }

            if (userInfo != null)
            {
                policyLookupbank = userInfo.SearchedCustomers;
                policyLookupdebit = userInfo.SearchedCustomers;
                policyLookup = await _customerPolicyService.GetCustomerPolicyInfo(userInfo.EntityID.Value);
               // statusLookup = await _statusService.Get();
                debiCheckList = new List<Debicheck>();

                foreach (var policy in policyLookup)
                {
                    //var descr = statusLookup.Where(p => p.StatusCD == policy.Policy_Status);
                    var param = new PolicyDebicheckStatus
                    {
                        PolicyNumber = 615114780.ToString(), //policy.Policy_NO.ToString();
                        ApplicationNumber = "string"
                    };

                    var debicheckStatus = await GetDebiCheckStatus(param);
                    var data = debicheckStatus.Result.Select(s => s.Data).FirstOrDefault();
                    var status = data.Select(s => s.Status).FirstOrDefault();
                    var debiAmount = data.Select(a => a.Amount).FirstOrDefault();
                    var debiCheck = new Debicheck
                    {
                        custPolicies = policy,
                        Policy_NO = policy.Policy_NO,
                        Checked = false,
                        DebiCheckStatus = status,
                        Amount = debiAmount,
                        CurrentStatusDateTime= DateTime.Now
                    };

                    debiCheckList.Add(debiCheck);

                    switch (status)
                    {
                        case "Authenticate Now":
                            textboxStyle = textboxStyle + "background-color:#FFFFFF;";
                            break;
                        case "Already Authenticated":
                            textboxStyle = textboxStyle + "background-color:#008000;";
                            break;
                        case "Pending":
                            textboxStyle = textboxStyle + "background-color:#FFFF00;";
                            break;
                        case "NotAllowed":
                            textboxStyle = textboxStyle + "background-color:#CD5C5C;";
                            break;
                        case "Failed":
                            textboxStyle = textboxStyle + "background-color:#CD5C5C;";
                            break;
                        default:
                            textboxStyle = textboxStyle + "background-color:#FFFFFF;";
                            break;
                    }
                }
              

            }


        }

        public async Task<DebiCheckStatus> GetDebiCheckStatus(PolicyDebicheckStatus param)
        {
            var debicheckStatus = await _financialService.GetDebiCheckStatua(param);
            return debicheckStatus;
        }

       async void OnChange(object value, string name)
        {
            if (value != null)
            {
                var bankId = Convert.ToInt32(value);
                var bankBranch = await _financialService.GetDefaultBankBranch(bankId);
                var defaultBranch = bankBranch.Where(b => b.BankId == bankId).FirstOrDefault();
                bankbranchLookup = defaultBranch != null ? defaultBranch.Code : "N/A";
                financialDetails.BranchCode = bankbranchLookup;
                StateHasChanged();
            }
        }


        async void Submit(FinancialDetailsVM args)
        {
          
        //    if (args != null)
        //    {
        //        var result = await ValidateBankDetails(args);
               
        //        string errormsg = string.Empty;


        //        if (errormsg != string.Empty)
        //        {
        //            await DialogService.OpenAsync<ErrorMessage>("Error Message", new Dictionary<string, object>() { { "messages", errormsg } }, new DialogOptions() { Width = "480px", Height = "500px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });

        //        }
        //        else
        //        {
        //           // var genderObj = genderLookup.Where(g => g.GenderCD == args.GenderCD).FirstOrDefault();
        //           // args.Gender = genderObj != null ? genderObj.SDesc : "N/A";
        //           // args.EntityID = userInfo.EntityID.HasValue ? userInfo.EntityID.Value : 0;
        //           // args.UserID = userInfo.LoggedInUser;
        //           // var save = await _financialService.SaveAccountAndAccountDetails(args);
        //           // //popup for government oficial
        //           // var employee = new GovernmentEmployee
        //           // {
        //           //     EntityID = userInfo.EntityID.HasValue ? userInfo.EntityID.Value : 0,
        //           //     PolicyNumber = userInfo.PolicyNumber.HasValue ? userInfo.PolicyNumber.Value : 0
        //           // };

        //           //var governmentofficial = await _financialService.GetGovernmentEmployee(employee);

        //           // if (governmentofficial == "YES")
        //           // {
        //           //     string messages = "";
        //           //     await DialogService.OpenAsync<Info>("Information", new Dictionary<string, object>() { { "messages", messages },{"accountholder",args.AccountHolder } }, new DialogOptions() { Width = "500px", Height = "980px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });
        //           // }

        //           // // popup for success??

        //           // string msgs = "";
        //           // await DialogService.OpenAsync<SuccessMessage>("Information", new Dictionary<string, object>() { { "messages", msgs } }, new DialogOptions() { Width = "500px", Height = "980px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });
                   
        //           // //Debicheck

        //           // var index = 1;
        //           // foreach (var item in debiCheckList)
        //           // {
        //           //     switch (index)
        //           //     {
        //           //         case 1:
        //           //             item.Checked = checkBox1Value;
        //           //             break;
        //           //         case 2:
        //           //             item.Checked = checkBox2Value;
        //           //             break;
        //           //         case 3:
        //           //             item.Checked = checkBox3Value;
        //           //             break;
        //           //         case 4:
        //           //             item.Checked = checkBox4Value;
        //           //             break;
        //           //         case 5:
        //           //             item.Checked = checkBox5Value;
        //           //             break;
        //           //         default:
        //           //             // code block
        //           //             break;
        //           //     }

                   
        //           //     item.BankName = args.BankName;
        //           //     await GetDebiCheckMandate(item);

        //           //     index = index++;

        //            //}
        //        }

        //}

        }

        public async Task<bool> GetDebiCheckMandate(Debicheck item)
        {
            var messages = string.Empty;
            var request = new CanRequestMandate();

            if (item.Checked == true && item.DebiCheckStatus == "Authenticate Now")
            {
                if (item.BankName == "ABSA"| item.BankName == "FNB")
                {
                    request.HasBankApp = hasBankingApp;
                }
                else
                {
                    request.HasBankApp = false;
                }

                request.PolicyNumber = 615114780.ToString(); //item.Policy_NO.ToString(),
             

                var canRequestMandate = await _financialService.GetCanRequestMandate(request);

                var resultMessage = canRequestMandate.Result.Data.MandateType;


                if (resultMessage != "NoMandate")
                {
                    var mandate = new RequestMandate
                    {
                        //policynumber
                        //existingclient
                        //sourcesystemid
                        SourceSystemId = 17,
                        PolicyNumber = 615114780.ToString(),// item.Policy_NO.ToString(),
                        ExistingClient = true
                    };

                   
                 
                        if (resultMessage == "Immediate")
                        {
                            //Fire a TT1
                            await DialogService.OpenAsync<TT1>("TT1 Mandate", new Dictionary<string, object>() { { "messages", messages }, { "policynumber", item.Policy_NO.ToString() } }, new DialogOptions() { Width = "480px", Height = "500px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });

                        }
                        else if (resultMessage == "Delayed")
                        {
                            var requestAMandate = await _financialService.GetRequestAMandate(mandate);

                            //fire TT2
                            await DialogService.OpenAsync<TT2>("TT2 Mandate", new Dictionary<string, object>() { { "messages", messages } }, new DialogOptions() { Width = "480px", Height = "500px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });

                          
                        }

                }
            }

            return true;
        }

   

        public async Task<BankValidationResultVM> ValidateBankDetails(FinancialDetailsVM details)
        {
            string accounttype = string.Empty;

            var accountObj = accountTypesLookup.Where(a => a.AccountTypeId == details.AccountTypeId).FirstOrDefault();
            accounttype = accountObj != null ? accountObj.Name : "N/A";
            string bankname = string.Empty;

            var bank = bankLookup.Where(b => b.Id == details.BankId).FirstOrDefault();
            bankname = bank != null? bank.Name: "N/A";
            

            var bankValidationOptions = await _financialService.GetBankValidationOptions(details);

            var financialValidation = new FinancialDetailsValidationVM
            {
                AccountNumber = details.AccountNumber,
                BranchCode = Convert.ToInt32(details.BranchCode),
                AccountType = accounttype,
                BankName = bankname,
                BankValidationOptions = bankValidationOptions

            };

            var result = await _financialService.ValidateAccount(financialValidation);
            return result;
        }

        //void OnChangeToggle(bool? value, string name)
        //{
        //    console.Log($"{name} value changed to {value}");
        //}



        void OnChange(bool value, string name)
        {
           

            switch (name)
            {
                case "CheckBox1 CheckBox":
                   
                    checkBox1Value = value;
                    break;
                case "CheckBox2 CheckBox":
                    
                    checkBox2Value = value;
                    break;
                case "CheckBox3 CheckBox":
                    
                    checkBox3Value = value;
                    break;
                case "CheckBox4 CheckBox":
                   
                    checkBox4Value = value;
                    break;
                case "CheckBox5 CheckBox":
                    
                    checkBox5Value = value;
                    break;
                default:
                    // code block
                    break;
            }
        }

      async void Check()
        {
           
        }

      

        async void Add()
        {
            //https://stackoverflow.com/questions/61718000/how-do-you-add-a-new-form-or-div-when-a-onclick-button-is-clicked
            await JS.InvokeVoidAsync("duplicate", "true");
        }

        enum AccountType
        {
            current,
            Savings,
            Transmission

        }

        void Cancel()
        {
            //
        }

        void ShowTooltip(ElementReference elementReference, TooltipOptions options = null) => tooltipService.Open(elementReference, "Debicheck History", options);

    }
}
