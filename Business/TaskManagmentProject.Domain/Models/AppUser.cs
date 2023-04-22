using System.ComponentModel.DataAnnotations;

namespace TaskManagmentProject.Domain.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<TaskDomain> AssignedTasks { get; set; }

        public ICollection<TaskDomain> CreatedTasks { get; set; }

        [Required]
        public UserRole Role { get; set; }
    }
}
