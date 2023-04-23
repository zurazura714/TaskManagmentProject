using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagmentProject.Domain.Models
{
    public class UserRole
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public UserRoleEnum Role { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual AppUser User { get; set; }
    }
    public enum UserRoleEnum
    {
        Create = 1,
        Update = 2,
        Delete = 3,
        View = 4,
    }
}
