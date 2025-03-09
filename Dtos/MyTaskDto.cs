namespace TaskList.Api.Dtos
{
    public class MyTaskDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = "";
        public bool IsCompleted { get; set; } = false;
    }
}