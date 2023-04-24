using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Models.Financial;
using HorizonPollyC.Pages.Configuration;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
//using System.Web.Script.Serialization;

namespace HorizonPollyC.Services.Financial
{
    public class FinancialService : IFinancialService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        string BaseURIFinancial;
        string BaseURISCV;
        string BankValidationURI;

        public FinancialService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
            BaseURIFinancial = _configuration["BaseURLFinancial"];
            BaseURISCV = _configuration["BaseURLSCV"];
            BankValidationURI = _configuration["BankValidation:BaseUri"];
        }

        public async Task<IEnumerable<AccountTypesVM>> GetAccountTypes()
        {
            var result = await httpClient.GetFromJsonAsync<List<AccountTypesVM>>($"{BankValidationURI}/AccountTypes");

            if (result != null)
            {
                int x = 1;
                foreach (var item in result)
                {
                    item.AccountTypeId = x++;
                }
            }


            return result;
        }

        public async Task<IEnumerable<BankVM>> GetBanks()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BankVM>>($"{BankValidationURI}/AllBanks");
            return result;
        }

        public async Task<BankLookups> GetBankLookups()
        {
            string url = $"{BaseURIFinancial}/GetBankLookups";

            var result = await httpClient.GetAsync(url);

            var responseBody = await result.Content.ReadAsStringAsync();

            var bankLookups = JsonConvert.DeserializeObject<BankLookups>(responseBody);

            return bankLookups;
        }

        public async Task<IEnumerable<BranchVM>> GetDefaultBankBranch(int bankId)
        {
            string URL = $"{BankValidationURI}/GetDefaultBranch/" + bankId;
            var result = await httpClient.GetFromJsonAsync<IEnumerable<BranchVM>>(URL);
            return result;
        }

        public async Task<string> SaveAccountAndAccountDetails(FinancialDetailsVM financialdetails)
        {

            var bankAccount = new BankAccountVM
            {
                BankAccountTypeCD = (byte)financialdetails.BankAccTypeCD,
                BankID = financialdetails.BankId,
                BankAccNo = financialdetails.BankAccNo,
                BankAccHolder = financialdetails.BankAccHolder,
                BankAccBranchCode = financialdetails.BankAccBranchCode,
                PaymentMethod = financialdetails.PaymentMethod,
                EffFrom = DateTime.Now,
                AudModDate = DateTime.Now,
                AudModUser = financialdetails.UserID
            };

            string url = $"{BaseURIFinancial}/SaveBankAccount";
            BankAccountVM bresult = new BankAccountVM();

            var result = await httpClient.PostAsJsonAsync(url, bankAccount);

            var responseBody = await result.Content.ReadAsStringAsync();

            bresult = JsonConvert.DeserializeObject<BankAccountVM>(responseBody);

            //var url = "financial/getbankaccountId" + bankAccount.BankAccNo;
            //var bankAccId = await httpClient.GetFromJsonAsync<BankAccountVM>(url);
            var policytobank = financialdetails.PolicyBankDetails.ToList();

            if (policytobank.Count > 0)
            {
                foreach (var item in policytobank)
                {
                    var PolicyBank = new PolicyToBankAccountVM
                    {
                        EntityId = financialdetails.EntityID,
                        PolicyNumber = item,
                        BankAccID = bresult.BankAccountID,
                        PaymentMethodId = financialdetails.PaymentMethodId,
                        UserID = bresult.AudModUser
                    };

                    var policyChangeBankDetails = await httpClient.PostAsJsonAsync($"{BaseURIFinancial}/savepolicytobankaccount", PolicyBank);
                }
            }


            var policytodebitdays = financialdetails.PolicyDebitDays.ToList();

            if (policytodebitdays.Count > 0)
            {
                foreach (var item in policytodebitdays)
                {
                    var policyDebitDay = new PolicyToDebitDaysVM
                    {
                        FirstDebitDay = financialdetails.FirstDebitDay,
                        EntityId = financialdetails.EntityID,
                        PolicyNumber = item,
                        BankAccID = bresult.BankAccountID,
                        UserID = bresult.AudModUser
                    };


                    var policyChangeDebitDay = await httpClient.PostAsJsonAsync($"{BaseURIFinancial}/financial/savepolicytodebitday", policyDebitDay);
                }
            }
            return "success";
        }

        public async Task<BankValidationResultVM> ValidateAccount(FinancialDetailsValidationVM financialdetails)
        {
            var result = await httpClient.PostAsJsonAsync($"{BankValidationURI}/AccountValidation", financialdetails);

            BankValidationResultVM bvresult = new BankValidationResultVM();
            var responseBody = await result.Content.ReadAsStringAsync();

            bvresult = JsonConvert.DeserializeObject<BankValidationResultVM>(responseBody);

            return bvresult;
        }

        public async Task<BankValidationOptionsVM> GetBankValidationOptions(FinancialDetailsVM details)
        {
            int[] fraud = { 4, 32, 34, 36, 7101 };

            var first = details.FirstName != String.Empty ? (details.FirstName).Substring(0, 1) : "";
            var second = details.Surname != String.Empty ? (details.Surname).Substring(0, 1) : "";
            var initials = first + second;

            var options = new BankValidationOptionsVM
            {
                SourceSystemId = _configuration["BankValidation:SourceSystemId"],
                IsLegal = true,
                IdentityOrPassportOrRegistrationNumber = details.IDNumber,
                Initials = initials,
                SurnameOrCompanyName = details.Surname,
                BusinessEntity = _configuration["BankValidation:BusinessEntity"],
                ValidateSoftyComp = true,
                ValidateFraudster = false,
                ValidateD3BlackList = false,
                ValidateAvsr = true,
                FraudsterRejectionCodesToIgnore = fraud,
                AvsrBanksToIgnore = { },
                TimeoutInSeconds = 30,
                CellNumber = details.CellNumber,
                EmailAddress = details.EmailAddress

            };

            return options;
        }

        public async Task<FinancialDetailsVM> GetFinancialDetails(GlobalVariables? userInfo)
        {
            var financialParams = new FinancialDetailParamsVM
            {
                EntityNo = userInfo.EntityNO.Value,
                PolicyNumber = userInfo.PolicyNumber.Value
            };

            string URL = $"{BaseURIFinancial}/FinancialDetails";
            var result = await httpClient.PostAsJsonAsync(URL, financialParams);

            if (result.IsSuccessStatusCode)
            {
                var responseBody = await result.Content.ReadAsStringAsync();
                var bresult = new BankAccountVM();
                bresult = JsonConvert.DeserializeObject<BankAccountVM>(responseBody);
                string debitURL = BaseURISCV + "Financial/DebitDay";
                var debitdayresult = await httpClient.PostAsJsonAsync(debitURL, userInfo.PolicyNumber);

                short debitday = 0;

                if (debitdayresult.IsSuccessStatusCode)
                {
                    var debitdayresponseBody = await debitdayresult.Content.ReadAsStringAsync();
                    debitday = JsonConvert.DeserializeObject<short>(debitdayresponseBody);
                }


                var details = new FinancialDetailsVM
                {
                    BankAccHolder = bresult.BankAccHolder,
                    BankId = bresult.BankID,
                    BankAccNo = bresult.BankAccNo,
                    BankAccBranchCode = bresult.BankAccBranchCode,
                    BankAccTypeCD = bresult.BankAccountTypeCD,
                    FirstDebitDay = debitday,

                    //EarlyWEPH
                    //PolicyBankDetails
                    //PolicyDebitDays

                };

                return details;
            }

            var emptydetails = new FinancialDetailsVM();
            return emptydetails;
        }

        public async Task<string> GetGovernmentEmployee(GovernmentEmployee employee)
        {
            string URL = $"{BaseURIFinancial}/GovernmentEmployee";
            var result = await httpClient.PostAsJsonAsync(URL, employee);

            if (result.IsSuccessStatusCode)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                // var answer = JsonConvert.DeserializeObject<string>(responseBody);
                return responseBody;
            }

            return "Error";
        }

        public async Task<DebiCheckStatus> GetDebiCheckStatus(PolicyDebicheckStatus param)
        {

            string URL = $"{BaseURIFinancial}/DebicheckStatus";
            var result = await httpClient.PostAsJsonAsync(URL, param);

            if (result.IsSuccessStatusCode)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                var answer = JsonConvert.DeserializeObject<DebiCheckStatus>(responseBody);
                return answer;

            }

            return null;

        }

        public async Task<CanRequestMandateResponse> GetCanRequestMandate(CanRequestMandate request)
        {
            string URL = BaseURISCV + "Financial/CanRequestMandate";
            var result = await httpClient.PostAsJsonAsync(URL, request);

            if (result.IsSuccessStatusCode)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                var answer = JsonConvert.DeserializeObject<CanRequestMandateResponse>(responseBody);
                return answer;

            }

            return null;
        }

        public async Task<RequestMandateResponse> GetRequestAMandate(RequestMandate item)
        {
            string URL = BaseURISCV + "Financial/RequestMandate";
            var result = await httpClient.PostAsJsonAsync(URL, item);

            if (result.IsSuccessStatusCode)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                var answer = JsonConvert.DeserializeObject<RequestMandateResponse>(responseBody);
                return answer;

            }

            return null;
        }

        public async Task<string> SavePayerDetails(FinancialDetailsVM details)
        {
            var payer = new PayerDetails
            {
                EntityID = details.EntityID,
                Title = details.Title,
                FirstName = details.FirstName,
                SurName = details.Surname,
                IdNumber = details.IDNumber,
                PassportNumber = details.PassportNumber,
                RelationToMember = details.RelationshipToMember,
                DOB = details.DOB,
                GenderCD = Convert.ToByte(details.GenderCD),
                CellNumber = details.CellNumber,
                HomeNumber = details.HomeNumber,
                WorkNumber = details.WorkNumber,
                EmailAddress = details.EmailAddress,
                EmployerName = "N/A",
                EmployerNumber = "N/A",
                UserID = details.UserID,

            };



            string URL = BaseURISCV + "Financial/SavePayerDetails";
            var result = await httpClient.PostAsJsonAsync(URL, payer);

            if (result.IsSuccessStatusCode)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                var answer = JsonConvert.DeserializeObject<string>(responseBody);
                return answer;

            }

            return null;
        }

        public async Task<PayerDetails> GetPayerDetails(int entityId)
        {
            string URL = BaseURISCV + "Financial/PayerDetails";
            var result = await httpClient.PostAsJsonAsync(URL, entityId);

            if (result.IsSuccessStatusCode)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                var answer = JsonConvert.DeserializeObject<PayerDetails>(responseBody);
                return answer;

            }
            return null;
        }

        public async Task<BankingDetailsVM> GetBankingDetails(int entityId)
        {
            string URL = BaseURISCV + "Financial/FinancialDetails";
            var result = await httpClient.PostAsJsonAsync(URL, entityId);
            if (result.IsSuccessStatusCode)
            {
                var responseBody = await result.Content.ReadAsStringAsync();

                var answer = JsonConvert.DeserializeObject<BankingDetailsVM>(responseBody);
                return answer;

            }
            return null;
        }
    }
}
