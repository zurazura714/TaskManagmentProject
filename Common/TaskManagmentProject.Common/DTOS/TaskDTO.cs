using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentProject.Common.DTOS
{
    public class TaskDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Brief description cannot be longer than 500 characters.")]
        public string BriefDescription { get; set; }

        public string Description { get; set; }

        [Required]
        public int AssignedUserId { get; set; }

        public int CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<TaskFileDto> AttachedFiles { get; set; }
    }
}
