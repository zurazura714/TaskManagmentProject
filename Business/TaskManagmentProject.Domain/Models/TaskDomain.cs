using System.ComponentModel.DataAnnotations;

namespace TaskManagmentProject.Domain.Models
{
    public class TaskDomain
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string BriefDescription { get; set; }

        public string Description { get; set; }

        public ICollection<TaskFile> AttachedFiles { get; set; }

        [Required]
        public int AssignedUserId { get; set; }

        public AppUser AssignedUser { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }

        public AppUser CreatedBy { get; set; }
    }
}
