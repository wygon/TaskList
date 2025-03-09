namespace TaskList.Api.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = "";
        public bool IsCompleted { get; set; } = false;
    }
}