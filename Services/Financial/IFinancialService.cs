using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Models.Financial;
using HorizonPollyC.Shared;

namespace HorizonPollyC.Services.Financial
{
    public interface IFinancialService
    {
        public Task<IEnumerable<BankVM>> GetBanks();
        public Task<BankLookups> GetBankLookups();
        public Task<IEnumerable<AccountTypesVM>> GetAccountTypes();
        public Task<IEnumerable<BranchVM>> GetDefaultBankBranch(int bankId);

        public Task<BankValidationOptionsVM> GetBankValidationOptions(FinancialDetailsVM details);
        public Task<PayerDetails> GetPayerDetails(int entityId);
        public Task<BankingDetailsVM> GetBankingDetails(int entityId);
        public Task<BankValidationResultVM> ValidateAccount(FinancialDetailsValidationVM financialdetails);
        public Task<string> SaveAccountAndAccountDetails(FinancialDetailsVM financialdetails);
        public Task<FinancialDetailsVM> GetFinancialDetails(GlobalVariables? userInfo);
        public Task<string> GetGovernmentEmployee(GovernmentEmployee employee);
        public Task<DebiCheckStatus> GetDebiCheckStatus(PolicyDebicheckStatus param);
        public Task<CanRequestMandateResponse> GetCanRequestMandate(CanRequestMandate request);
        public Task<RequestMandateResponse> GetRequestAMandate(RequestMandate item);
        public Task<string> SavePayerDetails(FinancialDetailsVM details);
    }
}
