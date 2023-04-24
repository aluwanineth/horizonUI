namespace HorizonPollyC.Models.Chat
{
    public class ChatGroupToCollegueVM
    {
        public int ChatGroupId { get; set; }
        public string ChatGroupName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int ColleagueToChatGroupId { get; set; }
        public string ColleagueEmail { get; set; }
        public string ColleagueName { get; set; }
        public string ColleagueSurName { get; set; }
        public string Department { get; set; }
    }
}
