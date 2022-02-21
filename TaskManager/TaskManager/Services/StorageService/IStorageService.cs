namespace TaskManager.Services;

public interface IStorageService
{
    Task<List<TaskItem>> GetTaskItems();
    Task<TaskItem> GetTaskItem(int id);
    Task SaveTaskItem(TaskItem taskItem);
    Task RemoveTaskItems(int id);
}
