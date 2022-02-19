namespace TaskManager.Models
{
    public class TaskItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public TaskPriority Priority { get; set; }
    }
}
