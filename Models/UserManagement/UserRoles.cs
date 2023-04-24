using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.UserManagement
{
    public class UserRoles
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
    }
}
