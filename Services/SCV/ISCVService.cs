using HorizonPollyC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorizonPollyC.Services.SCV
{
    public interface ISCVService
    {
        public Task<List<PersonSearch>> GetPersonSearch(PersonSearchCriteria SearchParams);
        public Task<List<CustomerPolicies>> GetCustomerPolicyInfo(int EntityID);

        public Task<CustomerPolicyDetail> GetCustomerPolicyDetails(string PolicyNo);
        public Task<MembersDetails> GetPolicyMemberDetails(string PolicyNo);
        public Task<PremiumDetails> GetPremiumDetails(Int32 PolicyNo);
        public Task<String> UpdatePolicyMemberDetails(MembersDetailsUpdate UpdateData);
        public Task<DiscountDetails> GetPolicyDiscountDetails(string PolicyNo);
        public Task<List<BenefitDetails>> GetPolicyBenefitsDetails(string PolicyNo);
        public Task<List<ExtendedMembersDetails>> GetPolicyExtendedMembers(string PolicyNo);
        public Task<List<BeneficiaryDetails>> GetPolicyBeneficiaries(string PolicyNo);
        public Task<List<AccountingHistoryDetails>> GetPolicyAccountingHistory(string PolicyNo);
        public Task<List<AuditLogDetails>> GetPolicyAuditLogs(string PolicyNo);
        public Task<BrokerDetail> GetBrokerDetails(string PolicyNo);
        public Task<List<BenefitDetail2>> GetBenefitDetail2(String PolicyNo);
       // public Task<List<title>> get_titles();
       // public Task<List<TelecomType>> GetTelecomTypes();

    }
}
