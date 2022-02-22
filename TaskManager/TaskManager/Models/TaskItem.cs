namespace TaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public TaskPriority Priority { get; set; }
    }
}
