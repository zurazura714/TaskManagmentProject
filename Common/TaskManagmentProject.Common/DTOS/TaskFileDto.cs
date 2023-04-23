namespace TaskManagmentProject.Common.DTOS
{
    public class TaskFileDto
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] FileContent { get; set; }

        public int TaskId { get; set; }
    }
}
