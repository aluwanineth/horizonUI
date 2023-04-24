using HorizonPollyC.Models;
using HorizonPollyC.Models.Chat;
using HorizonPollyC.Models.Configuration;

namespace HorizonPollyC.Services.Chat
{
    public interface IChatService
    {
        public Task<IEnumerable<ColleaguesVM>> GetColleagueDetails();
        public Task<IEnumerable<ChatGroupToCollegueVM>> GetGroupDetails();
    }
}
