namespace TaskManagmentProject.Models.Models
{
    public class TaskFile
    {
        public int ID { get; set; }
        public byte[] Data { get; set; }
        public int TaskID { get; set; }
        public TaskDomain Task { get; set; }
    }
}
