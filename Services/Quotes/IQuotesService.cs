using HorizonPollyC.Models.Quoting;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HorizonPollyC.Services
{
    public interface IQuotesService
    {

        Task<List<QuoteListModel>> GetEntityPolicyQuotes(int EntityNo, int PolicyNo);
        //Task<QuoteMaterialInfoModel> GetQuoteMaterialInfo(int QuoteNo);

        //Task<List<QuoteExtendedmembersModel>> GetQuoteExtendedMembers(int QuoteNo);
        Task<List<QuoteEntitiesList>> GetQuoteEntities(int QuoteNo);
        Task<string> AcceptQuote(int PolicyID, int QuoteID);
        Task<string> DeActivateQuote(int PolicyID, int QuoteID);
        Task<string> CopyQuote(int PolicyID, int QuoteID);
        Task<string> CreateNewQuote(int PolicyID);
        Task<QuoteEntity> GetQuoteEntity(int EntityNo, int PolicyNO, int QuoteID);
        Task<string> CreateUpdateEntity(QuoteEntity Model);
        
    }
}
