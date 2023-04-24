using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.UserManagement
{
    public class RoleUpdate
    {
        public  int ID { get; set; }
        public string RoleDescription { get; set; }
        public bool isActive { get; set; }
    }
}
