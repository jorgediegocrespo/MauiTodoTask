using System.Collections.ObjectModel;

namespace TaskManager.Services;

public interface IStorageService
{
    Task<ObservableCollection<TaskItem>> GetTaskItems();
    Task<TaskItem> GetTaskItem(int id);
    Task SaveTaskItem(TaskItem taskItem);
    Task RemoveTaskItems(int id);
}
