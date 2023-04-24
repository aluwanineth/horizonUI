using HorizonPollyC.Components;
using HorizonPollyC.Models;

namespace HorizonPollyC.Shared
{
    public class GlobalVariables
    {
        /// <summary>
        /// Please be carefull when adding additional fields to this class. Its injected as a singleton and will be used on almost every screen
        /// Please ask yourself if it really needs to be Global data
        /// Please don't put anything in here that will change regularly as it wil cause a cascade of changes
        /// </summary>
        /// 
        public string LoggedInUser { get; set; }
        public int? EntityID { get; set; }
        public int? EntityNO { get; set; }
        public int? PolicyNumber { get; set; }
        public string? PersonSurname { get; set; }
        public string? PersonFirstName { get; set; }
        public String? EmailAddress { get; set; }
        public String? CellphoneNumber { get; set; } 
        public List<PersonSearch> ClientSearchResults { get; set; }

        public IEnumerable<CustomerPolicies> SearchedCustomers{get;set;}
        public CustomerPolicies SelectedCustomersPolicy { get; set; }
       

        public bool isPolicySelected
        {
            get
            {
                return PolicyNumber != null && PolicyNumber!=0;
            }
        }

        public int SelectedQuote { get; set; }
        public int SelectedItemPage { get; internal set; }

        public string error_msg { get; set; } = string.Empty;
        public string validation_msg { get; set; } = string.Empty;
    }
}
