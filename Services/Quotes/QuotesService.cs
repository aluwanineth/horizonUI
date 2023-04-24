using HorizonPollyC.Models.Quoting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;


namespace HorizonPollyC.Services
{

    public class QuotesService : IQuotesService
    {

        string BaseURIQuotes;
        HttpClient httpClient;
        private readonly IConfiguration _configuration;

        public QuotesService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIQuotes = _configuration["BaseURLQuotes"];
        }

        public async Task<List<QuoteListModel>> GetEntityPolicyQuotes(int EntityNo, int PolicyNo)
        {
            string URL = string.Format("{0}/GetEntityPolicyQuotes?EntityID={1}&PolicyID={2}", BaseURIQuotes, EntityNo, PolicyNo);

            var result = await httpClient.GetFromJsonAsync<List<QuoteListModel>>(URL);
            return result;
        }

        public async Task<QuoteEntity> GetQuoteEntity(int EntityNo, int PolicyNO, int QuoteID) 
        {
            string URL = string.Format("{0}/GetQuoteEntity?EntityID={1}&PolicyNO={2}&QuoteID={3}", BaseURIQuotes, EntityNo, PolicyNO, QuoteID);

            var result = await httpClient.GetFromJsonAsync<QuoteEntity>(URL);
            return result;
        }

        public async Task<string> CreateUpdateEntity(QuoteEntity Model)
        {
            string URL = string.Format("{0}/CreateUpdateEntity", BaseURIQuotes);
            Model.GenderID = 1;//TODO fix this
            Model.Gender = "Male";//TODO
            Model.Title = "";
            Model.RelationDesc = "";

            var result = await httpClient.PostAsJsonAsync(URL, Model);        
            var content = await result.Content.ReadAsStringAsync();

            return result.ToString();
        }

        public async Task<List<QuoteEntitiesList>> GetQuoteEntities(int QuoteNo)
        {
            string URL = string.Format("{0}/GetQuoteEntities?QuoteID={1}", BaseURIQuotes, QuoteNo);

            var result = await httpClient.GetFromJsonAsync<List<QuoteEntitiesList>>(URL);
            return result;
        }

        public async Task<string> AcceptQuote(int PolicyID, int QuoteID)
        {
            string URL = string.Format("{0}/AcceptQuote?PolicyID={1}&QuoteID={2}", BaseURIQuotes, PolicyID, QuoteID);
            var result = await httpClient.PutAsJsonAsync(URL,false);
            return result.ToString();
        }
        public async Task<string> DeActivateQuote(int PolicyID, int QuoteID)
        {
            string URL = string.Format("{0}/DeActivateQuote?PolicyID={1}&QuoteID={2}", BaseURIQuotes, PolicyID, QuoteID);
            var result = await httpClient.PutAsJsonAsync(URL, false);
            var Test = result.Content.ReadAsStringAsync().Result;
            return Test;
        }
        public async Task<string> CopyQuote(int PolicyID, int QuoteID)
        {
            string URL = string.Format("{0}/CopyQuote?PolicyID={1}&QuoteID={2}", BaseURIQuotes, PolicyID, QuoteID);
            var result = await httpClient.PutAsJsonAsync(URL, false);
            var Test = result.Content.ReadAsStringAsync().Result;
            return Test;
        }

        public async Task<string> CreateNewQuote(int PolicyID)
        {
            string URL = string.Format("{0}/CreateNewQuote?PolicyID={1}", BaseURIQuotes, PolicyID);
            var result = await httpClient.PutAsJsonAsync<string>(URL,"");
            var  Test =   result.Content.ReadAsStringAsync().Result;
            return Test;


        }

    }
}
