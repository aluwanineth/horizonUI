using HorizonPollyC.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HorizonPollyC.Services.SCV
{
    public class SCVService : ISCVService
    {
        string BaseURISCV;
        HttpClient httpClient;
        private readonly IConfiguration _configuration;

        public SCVService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURISCV = _configuration["BaseURLSCV"];
        }

        public async Task<List<PersonSearch>> GetPersonSearch(PersonSearchCriteria SearchParams)
        {
            //string URL = BaseURISCV + "/GetPersonWithSearch?SearchString=" + SearchString;

            //String URL = BaseURISCV + "/GetPersonWithSearch";

            //var result = await httpClient.GetFromJsonAsync<List<PersonSearch>>(URL);
            //var result = await httpClient.PostAsJsonAsync(URL, SearchParams);
            //return result;

            String URL = BaseURISCV + "/GetPersonWithSearch";

            List<PersonSearch> PersonSearchResult = new List<PersonSearch>();

            var result = await httpClient.PostAsJsonAsync(URL, SearchParams);

            var ResponseBody = await result.Content.ReadAsStringAsync();

            PersonSearchResult = JsonConvert.DeserializeObject<List<PersonSearch>>(ResponseBody);

            return PersonSearchResult;
        }

        public async Task<String> UpdatePolicyMemberDetails(MembersDetailsUpdate UpdateData)
        {
            String URL = BaseURISCV + "/UpdatePolicyMemberDetails";

            var result = await httpClient.PostAsJsonAsync(URL, UpdateData);

            if (result.IsSuccessStatusCode)
            {
                return true.ToString();
            }
            else
            {
                return false.ToString();
            }

            //var ResponseBody = await result.Content.ReadAsStringAsync();

            //var successresult = JsonConvert.DeserializeObject<String>(ResponseBody);
            //return successresult;
        }

        public async Task<List<CustomerPolicies>> GetCustomerPolicyInfo(int EntityID)
        {
            string URL = BaseURISCV + "/GetCustomerPolicyInfo?EntityID=" + EntityID;

            var result = await httpClient.GetFromJsonAsync<List<CustomerPolicies>>(URL);
            return result;
        }

        public async Task<CustomerPolicyDetail> GetCustomerPolicyDetails(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetCustomerPolicyDetails?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<CustomerPolicyDetail>(URL);
            return result;
        }

        public async Task<PremiumDetails> GetPremiumDetails(Int32 PolicyNo)
        {
            String URL = BaseURISCV + "/GetPremiumDetails?PolicyNo=" + PolicyNo.ToString();

            var result = await httpClient.GetFromJsonAsync<PremiumDetails>(URL);
            return result;
        }

        public async Task<MembersDetails> GetPolicyMemberDetails(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetPolicyMemberDetails?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<MembersDetails>(URL);
            return result;
        }

        public async Task<DiscountDetails> GetPolicyDiscountDetails(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetPolicyDiscountDetails?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<DiscountDetails>(URL);
            return result;
        }

        public async Task<List<BeneficiaryDetails>> GetPolicyBeneficiaries(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetPolicyBeneficiaries?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<List<BeneficiaryDetails>>(URL);
            return result;
        }

        public async Task<List<BenefitDetail2>> GetBenefitDetail2(String PolicyNo)
        {
            String URL = BaseURISCV + "/GetPolicyBenefitDetail2?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<List<BenefitDetail2>>(URL);
            return result;
        }

        public async Task<List<ExtendedMembersDetails>> GetPolicyExtendedMembers(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetPolicyExtendedMembers?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<List<ExtendedMembersDetails>>(URL);
            return result;
        }

        public async Task<List<BenefitDetails>> GetPolicyBenefitsDetails(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetPolicyBenefitsDetails?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<List<BenefitDetails>>(URL);
            return result;
        }

        public async Task<List<AccountingHistoryDetails>> GetPolicyAccountingHistory(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetPolicyAccountingHistory?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<List<AccountingHistoryDetails>>(URL);
            return result;
        }
        public async Task<List<AuditLogDetails>> GetPolicyAuditLogs(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetPolicyAuditLogs?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<List<AuditLogDetails>>(URL);
            return result;
        }

        public async Task<BrokerDetail> GetBrokerDetails(string PolicyNo)
        {
            string URL = BaseURISCV + "/GetBrokerDetails?PolicyNo=" + PolicyNo;

            var result = await httpClient.GetFromJsonAsync<BrokerDetail>(URL);
            return result;
        }

        //public async Task<List<Title>> get_titles()
        //{
        //    string URL = BaseURISCV + "/GetTitlesList";

        //    var result = await httpClient.GetFromJsonAsync<List<Title>>(URL);
        //    return result;
        //}

        //public async Task<List<TelecomType>> GetTelecomTypes()
        //{
        //    String URL = BaseURISCV + "/GetTelecomTypesList";

        //    var result = await httpClient.GetFromJsonAsync<List<TelecomType>>(URL);
        //    return result;
        //}

    }

}
