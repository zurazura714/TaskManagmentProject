using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentProject.Models.Models
{
    public class TaskDomain
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public ICollection<TaskFile> TaskFiles { get; set; }


    }
}
