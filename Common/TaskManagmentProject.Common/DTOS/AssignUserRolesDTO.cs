using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentProject.Common.DTOS
{
    public class AssignUserRolesDTO
    {
        public int UserID { get; set; }
        public List<int> Roles { get; set; }
    }
}
