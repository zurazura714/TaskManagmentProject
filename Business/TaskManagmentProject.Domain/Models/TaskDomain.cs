using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagmentProject.Domain.Models
{
    public class TaskDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Brief description cannot be longer than 500 characters.")]
        public string BriefDescription { get; set; }

        public string Description { get; set; }

        [Required]
        public int AssignedUserId { get; set; }

        [ForeignKey(nameof(AssignedUserId))]
        public AppUser AssignedUser { get; set; }

        public int CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public AppUser CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TaskFile> AttachedFiles { get; set; }
    }
}
