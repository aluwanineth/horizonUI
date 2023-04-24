using ClosedXML;
using HorizonPollyC.Models;
using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Services.Configuration;
using HorizonPollyC.Services.General;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;

namespace HorizonPollyC.Pages
{
    partial class PolicyDetails
    {
        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }
        [CascadingParameter]
        public GlobalVariables? Globals { get; set; }
        public CustomerPolicyDetail _GetCustomerPolicyDetails { get; set; }
        public MembersDetails _MembersDetails { get; set; }
        public PremiumDetails _PremiumDetails { get; set; }

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
        public List<SelectListItem> SelectTitlesList { get; set; }
        public String? selected_title_str { get; set; }
        
        public List<TelecomType> telecom_types_list { get; set; }
        public List<SelectListItem> SelectTelecomTypesList { get; set; }
        public String? selected_telecom_type_str { get; set; }

        public List<CountryPhone> country_phone_list { get; set; }
        public IEnumerable<SelectListItem> SelectCountryPhoneList { get; set; }
        public List<GenderVM> genders_list { get; set; }
        public List<SelectListItem> SelectGenderList { get; set; }
        public String? selected_gender_str { get; set; }


        public String? MasterContract { get; set; }

        public String? LegacyPolicyNumber { get; set; }
        public Int32? EntityNumber { get; set; }
        public String? AnnualIncrease { get; set; }
        public DateTime? DateofCommencement { get; set; }
        public DateTime? ReinstatementDateofCommencement { get; set; }
        public DateTime? LapsedDate { get; set; }
        public DateTime? CancelledDate { get; set; }
        public String? SalesVenue { get; set; }
        public String? SalesPerson { get; set; }
        public String? CampaignCode { get; set; }
        public Decimal? PolicyFee { get; set; }
        public DateTime? CaptureDate { get; set; }
        public Int32? PreferredCommunicationMethod_ID { get; set; }

        public Int32? Title_ID { get; set; }
        public String? Surname { get; set; }
        public DateTime? DateofBirth { get; set; }
        public String? FaxNumber { get; set; }
        public String? MaskedFaxNumber { get; set; }
        public String? EmailAddress { get; set; }
        public String? PhyAddressLine1 { get; set; }
        public String? PhyAddressLine2 { get; set; }
        public String? PhyAddressLine3 { get; set; }
        public String? PhyTownCity { get; set; }
        public String? PhyPostalCode { get; set; }
        public Int32? Gender_ID {  get; set; }
        public Boolean? Smoker { get; set; }
        //---
        public String? FirstName { get; set; }
        public String? IDNumber { get; set; }
        public String? PassportNumber { get; set; }
        public String? HomeNumber { get; set; }
        public String? MaskedHomeNumber { get; set; }
        public String? CellNumber { get; set; }
        public String? MaskedCellNumber { get; set; }
        public String? PostAddressLine1 { get; set; }
        public String? PostAddressLine2 { get; set; }
        public String? PostAddressLine3 { get; set; }
        public String? PostTownCity { get; set; }
        public String? PostPostalCode { get; set; }

        public DateTime? LastBillingDate { get; set; }
        public DateTime? LastPaidDate { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public Decimal? PolicyPremiumAmount { get; set; }
        public Int32? PremiumCount { get; set; }
        public String? PaymentFrequency { get; set; }


        public Int32 temp_selected_telecom_type_int = 0;
        public Int32 temp_selected_title_int = 0;
        public String temp_firstname = "";
        public String temp_surname = "";
        public String temp_faxnumber = "";
        public String temp_homenumber = "";
        public String temp_emailaddress = "";
        public String temp_cellnumber = "";
        public String temp_postaladdress_line1 = "";
        public String temp_postaladdress_line2 = "";
        public String temp_postal_suburb = "";
        public String temp_postal_towncity = "";
        public String temp_postal_postalcode = "";
        public String temp_phyaddress_line1 = "";
        public String temp_phyaddress_line2 = "";
        public String temp_phy_suburb = "";
        public String temp_phy_towncity = "";
        public String temp_phy_postalcode = "";
        public Int32 temp_selected_gender_int = 0;

        public Boolean is_loading = false;
        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private String mask_number(String? the_value, Int32 char_count = 4)
        {
            if (String.IsNullOrWhiteSpace(the_value))
            {
                return "";
            }

            String masked_number = "";
            the_value = the_value.Replace(" ", "");

            if (the_value.Length >= char_count)
            {
                Int32 init_length = the_value.Length;
                masked_number = the_value.Substring(0, (the_value.Length - char_count)).PadRight(init_length, '*');
            }
            else
            {
                masked_number = the_value.PadRight(char_count, '*');
            }

            return masked_number;
        }

        public async Task LoadData()
        {
            Globals.error_msg = string.Empty;
            state_is_editing = false;
            busy_loading = true;

            StateHasChanged();

            IEnumerable<TitlesVM> titles_result = null;
            IEnumerable<TelecomType> telecomtypes_result = null;
            IEnumerable<CountryPhone> countryphone_result = null;
            IEnumerable<GenderVM> genders_result = null;

            SelectTitlesList = new List<SelectListItem>();
            SelectTelecomTypesList = new List<SelectListItem>();
            SelectGenderList = new List<SelectListItem>();

            try
            {

                _GetCustomerPolicyDetails = (await _SCVService.GetCustomerPolicyDetails(userInfo.PolicyNumber.ToString()));
                _MembersDetails = await _SCVService.GetPolicyMemberDetails(userInfo.PolicyNumber.ToString());
                _PremiumDetails = await _SCVService.GetPremiumDetails(userInfo.PolicyNumber.Value);
                
                if (userInfo.SearchedCustomers != null)
                {
                    SearchedCustomers = userInfo.SearchedCustomers.Where(x => x.Policy_NO == userInfo.PolicyNumber).FirstOrDefault();
                }
                

                MasterContract = userInfo.PolicyNumber.ToString();
                LegacyPolicyNumber = _GetCustomerPolicyDetails.Legacy_Pol_No;
                EntityNumber = _MembersDetails.EntityNo;
                AnnualIncrease = _GetCustomerPolicyDetails.AnnualIncrease;
                DateofCommencement = _GetCustomerPolicyDetails.Date_of_Commencement;
                ReinstatementDateofCommencement = _GetCustomerPolicyDetails.ReInstatedDate;
                LapsedDate = _GetCustomerPolicyDetails.LapsedDate;
                CancelledDate = null;
                SalesVenue = _GetCustomerPolicyDetails.Venue;
                SalesPerson = _GetCustomerPolicyDetails.SalesPerson;
                CampaignCode = _GetCustomerPolicyDetails.CampaignCode.ToString();
                PolicyFee = Convert.ToDecimal(_GetCustomerPolicyDetails.PolicyFee);
                CaptureDate = _GetCustomerPolicyDetails.CaptureDate;
                PreferredCommunicationMethod_ID = 0; // !!!!

                Title_ID = _MembersDetails.TitleID;
                Surname = _MembersDetails.Surname;
                DateofBirth = _MembersDetails.DateofBirth;
                FaxNumber = (_MembersDetails.FaxNumber ?? "");
                MaskedFaxNumber = mask_number(FaxNumber);
                EmailAddress = _MembersDetails.EmailAddress;
                PhyAddressLine1 = _MembersDetails.PhysicalAddress1;
                PhyAddressLine2 = _MembersDetails.PhysicalAddress2;
                PhyAddressLine3 = _MembersDetails.PhysicalSuburb;
                PhyTownCity = _MembersDetails.PhysicalTownCity;
                PhyPostalCode = _MembersDetails.PhysicalPostalCode;
                Gender_ID = _MembersDetails.GenderID;
                Smoker = ((_MembersDetails.SmokerCD ?? 0) > 0 ? true : false);

                FirstName = _MembersDetails.FirstName;
                IDNumber = ((_MembersDetails.LegalNoType ?? "").ToLower() == "id number" ? _MembersDetails.IDorPassportNo : "");
                PassportNumber = ((_MembersDetails.LegalNoType ?? "").ToLower() == "id number" ? "" : _MembersDetails.IDorPassportNo);
                HomeNumber = (_MembersDetails.HomeNumber ?? "");
                MaskedHomeNumber = mask_number(HomeNumber);
                CellNumber = (_MembersDetails.CellNumber ?? "");
                MaskedCellNumber = mask_number(CellNumber);
                PostAddressLine1 = _MembersDetails.PostalAddress1;
                PostAddressLine2 = _MembersDetails.PostalAddress2;
                PostAddressLine3 = _MembersDetails.PostalSuburb;
                PostTownCity = _MembersDetails.PostalTownCity;
                PostPostalCode = _MembersDetails.PostalPostalCode;

                LastBillingDate = _PremiumDetails.LastBillingDate;
                LastPaidDate = _PremiumDetails.LastPaidDate;
                NextBillingDate = _PremiumDetails.NextBillingDate;
                PolicyPremiumAmount = _PremiumDetails.PolicyPremiumAmount;
                PremiumCount = _PremiumDetails.PremiumCount;
                PaymentFrequency = _PremiumDetails.PaymentFrequency;



                titles_result = await _TitleService.Get();
                titles_list = new List<TitlesVM>();

                if (!(titles_result == null))
                {
                    for (Int32 x = 0; x < titles_result.Count(); x++)
                    {
                        titles_list.Add(new TitlesVM()
                        {
                            TitleCD = titles_result.ElementAt(x).TitleCD.Value,
                            SDesc = (titles_result.ElementAt(x).SDesc == null ? "" : titles_result.ElementAt(x).SDesc),
                            DispSeq = (titles_result.ElementAt(x).DispSeq == null ? 0 : titles_result.ElementAt(x).DispSeq),
                            EffDate = (titles_result.ElementAt(x).EffDate == null ? DateTime.MinValue : titles_result.ElementAt(x).EffDate),
                            ExpDate = (titles_result.ElementAt(x).ExpDate == null ? DateTime.MaxValue : titles_result.ElementAt(x).ExpDate),
                            IsActive = (titles_result.ElementAt(x).IsActive == null ? true : titles_result.ElementAt(x).IsActive)
                        });

                        SelectTitlesList.Add(new SelectListItem((int)titles_result.ElementAt(x).TitleCD.Value, titles_result.ElementAt(x).SDesc));

                        if ((!(Title_ID == null)) && (Convert.ToInt32(titles_result.ElementAt(x).TitleCD) == Title_ID))
                        {
                            selected_title_str = titles_result.ElementAt(x).SDesc;
                            temp_selected_title_int = Convert.ToInt32(titles_result.ElementAt(x).TitleCD.Value);
                        }

                    }
                }

                if (selected_title_str == null)
                {
                    selected_title_str = "UNDEFINED";
                }


                //telecomtypes_result = await _TelecomTypeService.Get(); no point since only 2 available
                //telecom_types_list = new List<TelecomType>();

                SelectTelecomTypesList.Add(new SelectListItem(1, "Email"));
                SelectTelecomTypesList.Add(new SelectListItem(2, "Mobile No"));
                
                if ((!(_MembersDetails.PreferredCell == null)) && (_MembersDetails.PreferredCell.Value))
                {
                    selected_telecom_type_str = SelectTelecomTypesList[0].item_description;
                    temp_selected_telecom_type_int = SelectTelecomTypesList[0].item_id;
                }
                else if ((!(_MembersDetails.PreferredEmail == null)) && (_MembersDetails.PreferredEmail.Value))
                {
                    selected_telecom_type_str = SelectTelecomTypesList[1].item_description;
                    temp_selected_telecom_type_int = SelectTelecomTypesList[0].item_id;
                }
                else
                {
                    selected_telecom_type_str = "UNDEFINED";
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

                        SelectGenderList.Add(new SelectListItem((Int32)(genders_result.ElementAt(x).GenderCD), genders_result.ElementAt(x).SDesc));

                        if ((!(Gender_ID == null)) && (Convert.ToInt32(genders_result.ElementAt(x).GenderCD) == Gender_ID))
                        {
                            selected_gender_str = genders_result.ElementAt(x).SDesc;
                            temp_selected_gender_int = Convert.ToInt32(genders_result.ElementAt(x).GenderCD);
                        }

                    }
                }

                if (selected_gender_str == null)
                {
                    selected_gender_str = "UNDEFINED";
                }


                temp_firstname = (FirstName ?? "");
                temp_surname = (Surname ?? "");
                temp_faxnumber = (FaxNumber ?? "");
                temp_homenumber = (HomeNumber ?? "");
                temp_emailaddress = (EmailAddress ?? "");
                temp_cellnumber = (CellNumber ?? "");
                temp_postaladdress_line1 = (PostAddressLine1 ?? "");
                temp_postaladdress_line2 = (PostAddressLine2 ?? "");
                temp_postal_suburb = (PostAddressLine3 ?? "");
                temp_postal_towncity = (PostTownCity ?? "");
                temp_postal_postalcode = (PostPostalCode ?? "");
                temp_phyaddress_line1 = (PhyAddressLine1 ?? "");
                temp_phyaddress_line2 = (PhyAddressLine2 ?? "");
                temp_phy_suburb = (PhyAddressLine3 ?? "");
                temp_phy_towncity = (PhyTownCity ?? "");
                temp_phy_postalcode = (PhyPostalCode ?? "");

            }
            catch (Exception ex)
            {
                Globals.error_msg = "Error Loading Data";
            }


            busy_loading = false;
            StateHasChanged();

        }

        public async void PolicySelected()
        {
            LoadData();
            //StateHasChanged();
        }


        private Boolean get_is_email_address_valid(String _the_email)
        {
            
            if (!(_the_email.Contains("@")))
            {                
                return false;
            }

            String[] email_arr = _the_email.Split(new char[] { '@' });

            if ((String.IsNullOrWhiteSpace(email_arr[0])) || (String.IsNullOrWhiteSpace(email_arr[1])))
            {                
                return false;
            }
            else
            {
                String[] email_arr2 = email_arr[1].Split(new char[] { '.' });

                if ((String.IsNullOrWhiteSpace(email_arr2[0])) || (String.IsNullOrWhiteSpace(email_arr2[1])))
                {                    
                    return false;
                }
                // note: maybe ensure domain & tld arent exclusively numeric?
            }

            return true;
        }

        private Boolean get_is_valid_fax_or_home_number(String the_number)
        {
            if (String.IsNullOrWhiteSpace(the_number))
            {
                return false;
            }

            the_number = the_number.Replace(" ", "");
            if (the_number.Substring(0, 1) == "+")
            {
                the_number = the_number.Replace("+", "");
                if (!(the_number.Length == 11))
                {
                    return false;
                }
            }
            else
            {
                if (!(the_number.Length == 10))
                {
                    return false;
                }
            }

            try
            {
                Int64 the_number_int = Convert.ToInt64(the_number);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private void check_names_are_valid(String _first_name, String _surname, ref List<String> validation_errors)
        {
            String[] disallowed_chars = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            if (String.IsNullOrWhiteSpace(_first_name))
            {
                validation_errors.Add("Invalid First Name");
            }
            else
            {
                for (Int32 x = 0; x < disallowed_chars.Length; x++)
                {
                    if (_first_name.Contains(disallowed_chars[x]))
                    {
                        validation_errors.Add("Invalid First Name");
                        break;
                    }
                }
            }


            if (String.IsNullOrWhiteSpace(_surname))
            {
                validation_errors.Add("Invalid Last Name");
            }
            else
            {
                for (Int32 x = 0; x < disallowed_chars.Length; x++)
                {
                    if (_surname.Contains(disallowed_chars[x]))
                    {
                        validation_errors.Add("Invalid Last Name");
                        break;
                    }
                }
            }

        }

        private Boolean get_cell_number_is_valid(String the_cell_number)
        {
            if ((String.IsNullOrWhiteSpace(the_cell_number)) || (the_cell_number.Length < 2))
            {
                return false;
            }


            Boolean starts_with_plus = false;
            if (the_cell_number.Substring(0, 1) == "+")
            {
                starts_with_plus = true;
            }
            String cell_number_remainder = (starts_with_plus ? the_cell_number.Substring(1, the_cell_number.Length - 1) : the_cell_number);

            try
            {
                Int64 remainder_int = Convert.ToInt64(cell_number_remainder);
                if (remainder_int <= 0)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


            if (starts_with_plus)
            {

                Int32 cc_count = country_phone_list.Count;
                Int32 remainder_str_length = cell_number_remainder.Length;
                for (Int32 x = 0; x < cc_count; x++)
                {
                    String this_prefix_str = country_phone_list[x].PrefixCode.ToString();
                    Int32 this_r_min = (Int32)(country_phone_list[x].NSNLengthMin ?? 1);
                    Int32 this_r_max = (Int32)(country_phone_list[x].NSNLengthMax ?? byte.MaxValue);

                    if (remainder_str_length < (this_prefix_str.Length + this_r_min))
                    {
                        continue;
                    }

                    if (!(cell_number_remainder.Substring(0, this_prefix_str.Length) == this_prefix_str))
                    {
                        continue;
                    }

                    Int32 length_without_prefix = (cell_number_remainder.Substring(this_prefix_str.Length, cell_number_remainder.Length - this_prefix_str.Length)).Length;
                    if ((length_without_prefix < this_r_min) || (length_without_prefix > this_r_max))
                    {
                        continue;
                    }

                    return true;
                }
                return false;
            }
            else
            {
                // assume south african number without country code
                if ((!(cell_number_remainder.Substring(0, 1) == "0")) || (!(cell_number_remainder.Length == 10)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

        private List<String> validate_changes()
        {
            List<String> validation_errors = new List<string>();

            if ((temp_selected_telecom_type_int <= 0) || (temp_selected_telecom_type_int > 2))
            {
                validation_errors.Add("Invalid selection for preferred communication method");
            }

            if (temp_selected_title_int <= 0)
            {
                validation_errors.Add("Invalid selection for title");
            }

            check_names_are_valid(temp_firstname, temp_surname, ref validation_errors);

            if ((!(String.IsNullOrWhiteSpace(CellNumber))) && (String.IsNullOrWhiteSpace(temp_cellnumber)))
            {
                validation_errors.Add("Invalid cellphone number");
            }
            else if (!(String.IsNullOrWhiteSpace(temp_cellnumber)))
            {
                Boolean cell_number_is_valid = get_cell_number_is_valid(temp_cellnumber);
                if (!(cell_number_is_valid))
                {
                    validation_errors.Add("Invalid cellphone number");
                }
            }

            if ((!(String.IsNullOrWhiteSpace(FaxNumber))) && (String.IsNullOrWhiteSpace(temp_faxnumber)))
            {
                validation_errors.Add("Invalid fax number");
            }
            else if (!(String.IsNullOrWhiteSpace(temp_faxnumber)))
            {
                Boolean fax_number_is_valid = get_is_valid_fax_or_home_number(temp_faxnumber);
                if (!(fax_number_is_valid))
                {
                    validation_errors.Add("Invalid fax number");
                }
            }

            if ((!(String.IsNullOrWhiteSpace(HomeNumber))) && (String.IsNullOrWhiteSpace(temp_homenumber)))
            {
                validation_errors.Add("Invalid home number");
            }
            else if (!(String.IsNullOrWhiteSpace(temp_homenumber)))
            {
                Boolean home_number_is_valid = get_is_valid_fax_or_home_number(temp_homenumber);
                if (!(home_number_is_valid))
                {
                    validation_errors.Add("Invalid home number");
                }
            }

            if ((!(String.IsNullOrWhiteSpace(EmailAddress))) && (String.IsNullOrWhiteSpace(temp_emailaddress)))
            {                
                validation_errors.Add("Invalid email address");
            }
            else if (!(String.IsNullOrWhiteSpace(temp_emailaddress)))
            {
                Boolean email_is_valid = get_is_email_address_valid(temp_emailaddress);
                if (!(email_is_valid))
                {
                    validation_errors.Add("Invalid email address");
                }
            }

            if ((!(String.IsNullOrWhiteSpace(PhyAddressLine1))) && (String.IsNullOrWhiteSpace(temp_phyaddress_line1)))
            {
                validation_errors.Add("Invalid physical address line 1");
            }

            if ((!(String.IsNullOrWhiteSpace(PhyAddressLine2))) && (String.IsNullOrWhiteSpace(temp_phyaddress_line2)))
            {
                validation_errors.Add("Invalid physical address line 2");
            }

            if ((!(String.IsNullOrWhiteSpace(PhyAddressLine3))) && (String.IsNullOrWhiteSpace(temp_phy_suburb)))
            {
                validation_errors.Add("Invalid physical suburb");
            }

            if ((!(String.IsNullOrWhiteSpace(PhyTownCity))) && (String.IsNullOrWhiteSpace(temp_phy_towncity)))
            {
                validation_errors.Add("Invalid physical town &#47; city");
            }


            if ((!(String.IsNullOrWhiteSpace(PostAddressLine1))) && (String.IsNullOrWhiteSpace(temp_postaladdress_line1)))
            {
                validation_errors.Add("Invalid postal address line 1");
            }

            if ((!(String.IsNullOrWhiteSpace(PostAddressLine2))) && (String.IsNullOrWhiteSpace(temp_postaladdress_line2)))
            {
                validation_errors.Add("Invalid postal address line 2");
            }

            if ((!(String.IsNullOrWhiteSpace(PostAddressLine3))) && (String.IsNullOrWhiteSpace(temp_postal_suburb)))
            {
                validation_errors.Add("Invalid postal suburb");
            }

            if ((!(String.IsNullOrWhiteSpace(PostTownCity))) && (String.IsNullOrWhiteSpace(temp_postal_towncity)))
            {
                validation_errors.Add("Invalid postal town &#47; city");
            }


            return validation_errors;
        }

        async Task ToggleEdit()
        {

            try
            {

                if (state_is_editing)
                {
                    if (!(EntityNumber == null))
                    {
                        if (!(MaskedCellNumber == mask_number(temp_cellnumber)))
                        {
                            temp_cellnumber = MaskedCellNumber;
                        }
                        if (!(MaskedHomeNumber == mask_number(temp_homenumber)))
                        {
                            temp_homenumber = MaskedHomeNumber;
                        }
                        if (!(MaskedFaxNumber == mask_number(temp_faxnumber)))
                        {
                            temp_faxnumber = MaskedFaxNumber;
                        }

                        List<String> validation_errors = validate_changes();

                        if (validation_errors.Count > 0)
                        {
                            Globals.error_msg = "";
                            Int32 validation_error_count = validation_errors.Count;
                            for (Int32 x = 0; x < validation_error_count; x++)
                            {
                                if (x > 4)
                                {
                                    Globals.error_msg += "+ Additional errors";
                                    break;
                                }

                                Globals.error_msg += validation_errors[x] + ((x == (validation_error_count - 1)) ? "" : "~");
                            }

                            StateHasChanged();
                            return;
                        }


                        MembersDetailsUpdate updatedetails = new MembersDetailsUpdate();
                        updatedetails.EntityNo = EntityNumber.Value;
                        updatedetails.PreferredTelTypeCD = temp_selected_telecom_type_int;
                        updatedetails.TitleCD = temp_selected_title_int;
                        updatedetails.FirstName = temp_firstname;
                        updatedetails.LastName = temp_surname;
                        updatedetails.FaxNumber = temp_faxnumber;
                        updatedetails.HomeNumber = temp_homenumber;
                        updatedetails.EmailAddress = temp_emailaddress;
                        updatedetails.CellNumber = temp_cellnumber;
                        updatedetails.PhysicalAddressLine1 = temp_phyaddress_line1;
                        updatedetails.PhysicalAddressLine2 = temp_phyaddress_line2;
                        updatedetails.PhysicalSuburb = temp_phy_suburb;
                        updatedetails.PhysicalTownCity = temp_phy_towncity;
                        updatedetails.PhysicalPostalCode = temp_phy_postalcode;
                        updatedetails.PostalAddressLine1 = temp_postaladdress_line1;
                        updatedetails.PostalAddressLine2 = temp_postaladdress_line2;
                        updatedetails.PostalSuburb = temp_postal_suburb;
                        updatedetails.PostalTownCity = temp_postal_towncity;
                        updatedetails.PostalPostalCode = temp_postal_postalcode;
                        updatedetails.UserID = null;

                        busy_loading = true;
                        StateHasChanged();

                        try
                        {
                            var save_result = await _SCVService.UpdatePolicyMemberDetails(updatedetails);

                            if (save_result == true.ToString())
                            {
                                Globals.error_msg = "";
                                Globals.validation_msg = "Save successful";


                                selected_telecom_type_str = SelectTelecomTypesList.First(i => i.item_id == temp_selected_telecom_type_int).item_description;
                                PreferredCommunicationMethod_ID = temp_selected_telecom_type_int;

                                selected_title_str = SelectTitlesList.First(i => i.item_id == temp_selected_title_int).item_description;
                                Title_ID = temp_selected_title_int;

                                FirstName = temp_firstname;
                                Surname = temp_surname;
                                FaxNumber = temp_faxnumber;
                                HomeNumber = temp_homenumber;
                                EmailAddress = temp_emailaddress;
                                CellNumber = temp_cellnumber;

                                PhyAddressLine1 = temp_phyaddress_line1;
                                PhyAddressLine2 = temp_phyaddress_line2;
                                PhyAddressLine3 = temp_phy_suburb;
                                PhyTownCity = temp_phy_towncity;
                                PhyPostalCode = temp_phy_postalcode;

                                PostAddressLine1 = temp_postaladdress_line1;
                                PostAddressLine2 = temp_postaladdress_line2;
                                PostAddressLine3 = temp_postal_suburb;
                                PostTownCity = temp_postal_towncity;
                                PostPostalCode = temp_postal_postalcode;


                                state_is_editing = !(state_is_editing);

                            }
                            else
                            {
                                Globals.error_msg = "Failed to save";
                            }
                        }
                        catch (Exception ex)
                        {
                            Globals.error_msg = "Internal system error occurred during save";
                        }
                        finally
                        {
                            busy_loading = false;
                            StateHasChanged();
                        }


                    }

                }
                else
                {
                    state_is_editing = !(state_is_editing);
                }

            }
            catch (Exception ex_outer)
            {
                Globals.error_msg = "Error toggling edit state";
            }
            
            StateHasChanged();
        }
        
        void LoadFinancial()
        {
            NavManager.NavigateTo("/BankDetails");
        }
        private void OnStateHasChanged()
        {
            StateHasChanged();
        }

    }

    public class SelectListItem
    {
        public Int32 item_id { get; set; }
        public String item_description { get; set; }
        public SelectListItem(Int32 _item_id, String _item_description)
        {
            item_id = _item_id;
            item_description = _item_description;
        }
    }
}
