using DocumentFormat.OpenXml.Spreadsheet;
using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Models;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using HorizonPollyC.Models.Financial;
using System.Linq;

namespace HorizonPollyC.Pages.Financial
{
    public partial class ViewFinancialDetails
    {

        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        public CustomerPolicyDetail _GetCustomerPolicyDetails { get; set; }
        public MembersDetails _MembersDetails { get; set; }
        public DiscountDetails _DiscountDetails { get; set; }

        public CustomerPolicies SearchedCustomers { get; set; }
        public Boolean state_is_editing { get; set; }
        public Boolean busy_loading { get; set; }

        public Boolean show_alert_success { get; set; }
        public Boolean show_alert_warning { get; set; }
        public Boolean show_alert_error { get; set; }
        public String alert_success_msg { get; set; }
        public String alert_warning_msg { get; set; }
        public String alert_error_msg { get; set; }

        public List<TitlesVM> titles_list { get; set; }
        public List<TelecomType> telecom_types_list { get; set; }
        public List<CountryPhone> country_phone_list { get; set; }
        public List<GenderVM> genders_list { get; set; }

        public Int32 temp_TitleID { get; set; }
        public String temp_Firstname { get; set; }
        public String temp_Surname { get; set; }
        public String temp_IdNumber { get; set; }
        public DateTime temp_DateofBirth { get; set; }
        public String temp_PassportNumber { get; set; }
        public String temp_FaxNumber { get; set; }
        public String temp_HomeNumber { get; set; }
        public String temp_CellNumber { get; set; }
        public String temp_EmailAddress { get; set; }


        public PayerDetails payerDetails { get; set; } = new PayerDetails();
        public BankingDetailsVM bankingDetails { get; set; } = new BankingDetailsVM();
        public IEnumerable<BankVM> bankLookup;
        public IEnumerable<AccountTypesVM> accountTypesLookup;
        public IEnumerable<CustomerPolicies> policyLookup;
        public List<Debicheck> debiCheckList;
        public string BankName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string textboxStyle = "width:100%;border-color:transparent;";
        protected override async Task OnInitializedAsync()
        {
            if (userInfo != null)
            {
            
                payerDetails = await _financialService.GetPayerDetails(userInfo.EntityID.Value);
                bankingDetails = await _financialService.GetBankingDetails(userInfo.EntityID.Value);
                bankLookup = await _financialService.GetBanks();
                accountTypesLookup = await _financialService.GetAccountTypes();

                if (bankingDetails != null)
                {
                    BankName =  bankLookup?.Where(b => b.Id == bankingDetails.BankId).FirstOrDefault().Name ;
                    AccountType = accountTypesLookup.Where(a => a.AccountTypeId == bankingDetails.AccountTypeId).FirstOrDefault().Name;
                }
               
                policyLookup = await _customerPolicyService.GetCustomerPolicyInfo(userInfo.EntityID.Value);
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
            //var debicheckStatus = await _financialService.GetDebiCheckStatua(param);
            //return debicheckStatus;
            return null;
        }

        public async void PolicySelected()
        {
            LoadData();
            ///  StateHasChanged();
        }
        void LoadFinancial()
        {
            NavManager.NavigateTo("/BankDetails");
        }


        public async Task LoadData()
        {

            IEnumerable<TitlesVM> titles_result = null;
            IEnumerable<TelecomType> telecomtypes_result = null;
            IEnumerable<CountryPhone> countryphone_result = null;
            IEnumerable<GenderVM> genders_result = null;

            try
            {

                _GetCustomerPolicyDetails = await _SCVService.GetCustomerPolicyDetails(userInfo.PolicyNumber.ToString());
                _MembersDetails = await _SCVService.GetPolicyMemberDetails(userInfo.PolicyNumber.ToString());
                if (_MembersDetails != null)
                {
                    _MembersDetails.DateofBirth = _MembersDetails.DateofBirth;
                }

                _DiscountDetails = await _SCVService.GetPolicyDiscountDetails(userInfo.PolicyNumber.ToString());

                if (userInfo.SearchedCustomers != null)
                    SearchedCustomers = userInfo.SearchedCustomers.Where(x => x.Policy_NO == userInfo.PolicyNumber).FirstOrDefault();


                titles_result = await _TitleService.Get();
                titles_list = new List<TitlesVM>();

                if (!(titles_result == null))
                {
                    for (Int32 x = 0; x < titles_result.Count(); x++)
                    {
                        titles_list.Add(new TitlesVM()
                        {
                            TitleCD = titles_result.ElementAt(x).TitleCD,
                            SDesc = (titles_result.ElementAt(x).SDesc == null ? "" : titles_result.ElementAt(x).SDesc),
                            DispSeq = (titles_result.ElementAt(x).DispSeq == null ? 0 : titles_result.ElementAt(x).DispSeq),
                            EffDate = (titles_result.ElementAt(x).EffDate == null ? DateTime.MinValue : titles_result.ElementAt(x).EffDate),
                            ExpDate = (titles_result.ElementAt(x).ExpDate == null ? DateTime.MaxValue : titles_result.ElementAt(x).ExpDate),
                            IsActive = (titles_result.ElementAt(x).IsActive == null ? true : titles_result.ElementAt(x).IsActive)
                        });
                    }
                }


                telecomtypes_result = await _TelecomTypeService.Get();
                telecom_types_list = new List<TelecomType>();

                if (!(telecomtypes_result == null))
                {
                    for (Int32 x = 0; x < telecomtypes_result.Count(); x++)
                    {
                        telecom_types_list.Add(new TelecomType()
                        {
                            TelTypeCD = telecomtypes_result.ElementAt(x).TelTypeCD,
                            CountryCode = (telecomtypes_result.ElementAt(x).CountryCode ?? ""),
                            TelTypeCode = telecomtypes_result.ElementAt(x).TelTypeCode,
                            TelTypeDesc = telecomtypes_result.ElementAt(x).TelTypeDesc,
                            TelTypeRegEx = (telecomtypes_result.ElementAt(x).TelTypeRegEx ?? ""),
                            DispSeq = (telecomtypes_result.ElementAt(x).DispSeq ?? 0),
                            IsActive = telecomtypes_result.ElementAt(x).IsActive
                        });
                    }
                }


                countryphone_result = await _CountryPhoneService.Get();
                country_phone_list = new List<CountryPhone>();

                if (!(countryphone_result == null))
                {
                    for (Int32 x = 0; x < countryphone_result.Count(); x++)
                    {
                        country_phone_list.Add(new CountryPhone()
                        {
                            CountryPhoneCD = countryphone_result.ElementAt(x).CountryPhoneCD,
                            CountryName = countryphone_result.ElementAt(x).CountryName,
                            PrefixCode = countryphone_result.ElementAt(x).PrefixCode,
                            NSNLengthMin = countryphone_result.ElementAt(x).NSNLengthMin,
                            NSNLengthMax = countryphone_result.ElementAt(x).NSNLengthMax
                        });
                    }
                }


                genders_result = await _GenderService.GetGenders();
                genders_list = new List<GenderVM>();

                if (!(genders_result == null))
                {
                    for (Int32 x = 0; x < genders_result.Count(); x++)
                    {
                        genders_list.Add(new GenderVM()
                        {
                            GenderCD = genders_result.ElementAt(x).GenderCD,
                            SDesc = genders_result.ElementAt(x).SDesc,
                            DispSeq = genders_result.ElementAt(x).DispSeq,
                            EffDate = genders_result.ElementAt(x).EffDate,
                            ExpDate = genders_result.ElementAt(x).ExpDate,
                            IsActive = genders_result.ElementAt(x).IsActive
                        });
                    }
                }


                //temp_TitleID = _MembersDetails.TitleID;
                //temp_Firstname = _MembersDetails.Firstname;
                //temp_Surname = _MembersDetails.Surname;
                //temp_IdNumber = _MembersDetails.IdNumber;
                //temp_DateofBirth = _MembersDetails.DateofBirth;
                //temp_PassportNumber = _MembersDetails.PassportNumber;
                //temp_FaxNumber = _MembersDetails.FaxNumber;
                //temp_HomeNumber = _MembersDetails.HomeNumber;
                //temp_CellNumber = _MembersDetails.CellNumber;
                //temp_EmailAddress = _MembersDetails.EmailAddress;

                //temp_ph_AddressLine1 = (_MembersDetails.PhysicalAddress.AddressLine1 ?? "");
                //temp_ph_AddressLine2 = (_MembersDetails.PhysicalAddress.AddressLine2 ?? "");
                //temp_ph_suburb = (_MembersDetails.PhysicalAddress.Suburb ?? "");
                //temp_ph_city = (_MembersDetails.PhysicalAddress.City ?? "");
                //temp_ph_PostalCode = (_MembersDetails.PhysicalAddress.PostalCode ?? "");

                //temp_po_AddressLine1 = (_MembersDetails.PostalAddress.AddressLine1 ?? "");
                //temp_po_AddressLine2 = (_MembersDetails.PostalAddress.AddressLine2 ?? "");
                //temp_po_suburb = (_MembersDetails.PostalAddress.Suburb ?? "");
                //temp_po_city = (_MembersDetails.PostalAddress.City ?? "");
                //temp_po_PostalCode = (_MembersDetails.PostalAddress.PostalCode ?? "");

                //temp_PrefTelTypeID = _MembersDetails.PrefTelTypeID;


                //_MembersDetails.PhysicalAddress.AddressLine1 = _MembersDetails.PhysicalAddress.AddressLine1 ?? "";
                //_MembersDetails.PhysicalAddress.AddressLine2 = _MembersDetails.PhysicalAddress.AddressLine2 ?? "";
                //_MembersDetails.PhysicalAddress.Suburb = _MembersDetails.PhysicalAddress.Suburb ?? "";
                //_MembersDetails.PhysicalAddress.City = _MembersDetails.PhysicalAddress.City ?? "";
                //_MembersDetails.PhysicalAddress.PostalCode = _MembersDetails.PhysicalAddress.PostalCode ?? "";

                //_MembersDetails.PostalAddress.AddressLine1 = _MembersDetails.PostalAddress.AddressLine1 ?? "";
                //_MembersDetails.PostalAddress.AddressLine2 = _MembersDetails.PostalAddress.AddressLine2 ?? "";
                //_MembersDetails.PostalAddress.Suburb = _MembersDetails.PostalAddress.Suburb ?? "";
                //_MembersDetails.PostalAddress.City = _MembersDetails.PostalAddress.City ?? "";
                //_MembersDetails.PostalAddress.PostalCode = _MembersDetails.PostalAddress.PostalCode ?? "";

                if (userInfo.SearchedCustomers != null)
                {
                    userInfo.SelectedCustomersPolicy = userInfo.SearchedCustomers.Where(x => x.Policy_NO == userInfo.PolicyNumber).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                Int32 something = 0;
            }


         
            StateHasChanged();

        }

    }
}
