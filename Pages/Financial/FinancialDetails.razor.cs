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

namespace HorizonPollyC.Pages.Financial
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
        public IEnumerable<BankGetResult> bankLookup;
        public IEnumerable<BankAccTypeGetResult> accountTypesLookup;
        public IEnumerable<GenderVM> genderLookup;
        public IEnumerable<StatusVM> statusLookup;
        public IEnumerable<TitlesVM> titlesLookup;
        public string bankbranchLookup = string.Empty;
        public List<Debicheck> debiCheckList;
        public string textboxStyle = "width:100%;border-color:transparent;";
        bool hasBankingApp = false;
        bool isEditing = false;
        protected override async Task OnInitializedAsync()
        {
            financialDetails = new FinancialDetailsVM();
            legacyPaymentLookup = await _legacypaymentService.GetLegacyPayments();
            yesNoLookup = await _yesnoService.GetYesNos();
            var bankLookups = await _financialService.GetBankLookups();
            bankLookup = bankLookups.Banks;
            accountTypesLookup = bankLookups.BankAccTypes;
            genderLookup = await _genderService.GetGenders();
            titlesLookup = await _titleService.Get();
            var details = await _financialService.GetFinancialDetails(userInfo);

            if (details != null && details.BankAccNo != null)
            {
                financialDetails = details;
            }

            if (userInfo != null)
            {
                policyLookupbank = userInfo.SearchedCustomers;
                policyLookupdebit = userInfo.SearchedCustomers;
                policyLookup = await _customerPolicyService.GetCustomerPolicyInfo(userInfo.EntityID.GetValueOrDefault(0));
                // statusLookup = await _statusService.Get();
                debiCheckList = new List<Debicheck>();

                foreach (var policy in policyLookup)
                {
                    //var descr = statusLookup.Where(p => p.StatusCD == policy.Policy_Status);
                    var param = new PolicyDebicheckStatus
                    {
                        PolicyNumber = policy.Policy_NO.ToString(),//615114780.ToString(), //
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
                        CurrentStatusDateTime = DateTime.Now
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
            var debicheckStatus = await _financialService.GetDebiCheckStatus(param);
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
                financialDetails.BankAccBranchCode = bankbranchLookup;
                StateHasChanged();
            }
        }


        async void Submit(FinancialDetailsVM args)
        {

            if (args != null)
            {
                // save payer details
                args.UserID = userInfo.LoggedInUser;
                args.EntityID = userInfo.EntityID.HasValue ? userInfo.EntityID.Value : 0;
                args.Title = titlesLookup.Where(t => t.TitleCD == args.TitleCD).FirstOrDefault().SDesc;
                var payerDetails = await _financialService.SavePayerDetails(args);

                //Bank validation
                var result = await ValidateBankDetails(args);

                string errormsg = string.Empty;

                //if (!result.IsValid)
                //{
                //    var msg = "Validation Result: " + result.Message + "|";
                //    errormsg = errormsg != string.Empty ? errormsg + msg : msg;
                //}
                //if (!result.SoftyCompResult.IsValid)
                //{
                //    var msg = "Compliance Result: " + result.SoftyCompResult.Message + "|";
                //    errormsg = errormsg != string.Empty ? errormsg + msg : msg;
                //}
                //if (!result.FraudsterResult.IsValid)
                //{
                //    var msg = "Fraud Result: " + result.FraudsterResult.Message + "|";
                //    errormsg = errormsg != string.Empty ? errormsg + msg : msg;
                //}
                //if (!result.D3BlackListResult.IsValid)
                //{
                //    var msg = "BlaclistREsult: " + result.D3BlackListResult.Message + "|";
                //    errormsg = errormsg != string.Empty ? errormsg + msg : msg;
                //}
                //if (!result.AvsrResult.IsValid)
                //{
                //    var msg = "Avsr Result: " + result.AvsrResult.ErrorDescription + "|";
                //    errormsg = errormsg != string.Empty ? errormsg + msg : msg;
                //}



                if (errormsg != string.Empty && errormsg != "" && errormsg != null)
                {
                    await DialogService.OpenAsync<ErrorMessage>("Error Message", new Dictionary<string, object>() { { "messages", errormsg } }, new DialogOptions() { Width = "480px", Height = "500px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });

                }
                else
                {
                    var genderObj = genderLookup.Where(g => g.GenderCD == args.GenderCD).FirstOrDefault();
                    args.Gender = genderObj != null ? genderObj.SDesc : "N/A";
                    args.EntityID = userInfo.EntityID.HasValue ? userInfo.EntityID.Value : 0;
                    args.UserID = userInfo.LoggedInUser;
                    var save = await _financialService.SaveAccountAndAccountDetails(args);
                    //popup for government oficial
                    var employee = new GovernmentEmployee
                    {
                        EntityID = userInfo.EntityID.HasValue ? userInfo.EntityID.Value : 0,
                        PolicyNumber = userInfo.PolicyNumber.HasValue ? userInfo.PolicyNumber.Value : 0
                    };

                    var governmentofficial = await _financialService.GetGovernmentEmployee(employee);

                    if (governmentofficial == "YES")
                    {
                        string messages = "";
                        await DialogService.OpenAsync<Info>("Information", new Dictionary<string, object>() { { "messages", messages }, { "accountholder", args.BankAccHolder } }, new DialogOptions() { Width = "500px", Height = "980px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });
                        DialogService.Close();
                    }

                    // popup for success??

                    string msgs = "";
                    await DialogService.OpenAsync<SuccessMessage>("Information", new Dictionary<string, object>() { { "messages", msgs } }, new DialogOptions() { Width = "500px", Height = "500px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });
                    DialogService.Close();
                    //Debicheck


                    foreach (var item in debiCheckList)
                    {
                        item.BankName = bankLookup.Where(b => b.BankID == args.BankId).FirstOrDefault().BankName;
                        await GetDebiCheckMandate(item);

                    }
                }

            }

        }

        public async Task<bool> GetDebiCheckMandate(Debicheck item)
        {
            var messages = string.Empty;
            var request = new CanRequestMandate();

            if (item.Checked == true)//&& item.DebiCheckStatus == "Authenticate Now"
            {
                if (item.BankName.Contains("ABSA") | item.BankName.Contains("FNB"))
                {
                    string msgs = "";
                    hasBankingApp = false;
                    var result = await DialogService.OpenAsync<HasBankingApp>("Information", new Dictionary<string, object>() { { "hasBankingApp", hasBankingApp } }, new DialogOptions() { Width = "500px", Height = "500px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });

                    if (result == true)
                    {
                        request.HasBankApp = true;
                    }
                    //DialogService.Close();

                }
                else
                {
                    request.HasBankApp = false;
                }

                request.PolicyNumber = item.Policy_NO.ToString();//615114780.ToString(); //


                var canRequestMandate = await _financialService.GetCanRequestMandate(request);

                var resultMessage = canRequestMandate.Result.Data.MandateType;


                if (resultMessage != "NoMandate")
                {
                    var mandate = new RequestMandate
                    {

                        //existingclient

                        SourceSystemId = 17,
                        PolicyNumber = item.Policy_NO.ToString(),//615114780.ToString(),
                        ApplicationNumber = "",
                        ExistingClient = true
                    };


                    //tested till here
                    if (resultMessage == "Immediate")//
                    {
                        //Fire a TT1
                        await DialogService.OpenAsync<TT1>("TT1 Mandate", new Dictionary<string, object>() { { "messages", messages }, { "policynumber", item.Policy_NO.ToString() } }, new DialogOptions() { Width = "520px", Height = "800px", Resizable = true, Draggable = true, Style = "z-index:1500;", CloseDialogOnEsc = true });

                    }
                    else if (resultMessage == "Delayed")
                    {
                        //var requestAMandate = await _financialService.GetRequestAMandate(mandate);

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

            var accountObj = accountTypesLookup.Where(a => a.BankAccTypeCD == details.BankAccTypeCD).FirstOrDefault();
            accounttype = accountObj != null ? accountObj.BankAccTypeDesc : "N/A";
            string bankname = string.Empty;

            var bank = bankLookup.Where(b => b.BankID == details.BankId).FirstOrDefault();
            bankname = bank != null ? bank.BankName : "N/A";


            var bankValidationOptions = await _financialService.GetBankValidationOptions(details);

            var financialValidation = new FinancialDetailsValidationVM
            {
                AccountNumber = details.BankAccNo,
                BranchCode = Convert.ToInt32(details.BankAccBranchCode),
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


        private void OnStateHasChanged()
        {
            StateHasChanged();
        }
        public async void PolicySelected()
        {
            LoadData();
            //StateHasChanged();
        }

        private void LoadData()
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
            NavManager.NavigateTo("/Search");
        }

        void ShowTooltip(ElementReference elementReference, TooltipOptions options = null) => tooltipService.Open(elementReference, "Debicheck History", options);

    }
}
