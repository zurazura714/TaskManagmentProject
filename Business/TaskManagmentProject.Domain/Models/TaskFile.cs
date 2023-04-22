using System.ComponentModel.DataAnnotations;

namespace TaskManagmentProject.Domain.Models
{
    public class TaskFile
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] FileContent { get; set; }

        [Required]
        public int TaskId { get; set; }

        public TaskDomain Task { get; set; }
    }
}
