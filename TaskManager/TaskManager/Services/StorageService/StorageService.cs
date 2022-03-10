using System.Collections.ObjectModel;

namespace TaskManager.Services;

public class StorageService : IStorageService
{
    private ObservableCollection<TaskItem> taskItemList;

    public StorageService()
    {
        taskItemList = new ObservableCollection<TaskItem>();
        for (int i = 1; i <= 100; i++)
        {
            taskItemList.Add(new TaskItem
            {
                Id = i,
                Name = $"Task {i}",
                Description = $"Description {i}",
                ExpirationDate = DateTime.Now.AddDays(-10).AddDays(i),
                Priority = (TaskPriority)(i % 3)
            });
        }
    }

    public async Task<ObservableCollection<TaskItem>> GetTaskItems()
    {
        await Task.Delay(500);
        return taskItemList;
    }

    public async Task<TaskItem> GetTaskItem(int id)
    {
        await Task.Delay(500);
        var taskItem = taskItemList.FirstOrDefault(x => x.Id == id);
        return taskItem;
    }

    public async Task SaveTaskItem(TaskItem taskItem)
    {
        await Task.Delay(500);
        if (taskItem.Id == 0)
        {
            int maxId = taskItemList?.Max(x => x.Id) ?? 0;
            taskItem.Id = maxId + 1;
            taskItemList.Add(taskItem);
        }
        else
        {
            for (int i = 0; i < taskItemList.Count; i++)
            {
                if (taskItemList[i].Id == taskItem.Id)
                {
                    taskItemList[i] = taskItem;
                    break;
                }
            }
        }
    }

    public async Task RemoveTaskItems(int id)
    {
        await Task.Delay(500);
        var itemToRemove = taskItemList.ToList().First(x => x.Id == id);
        taskItemList.Remove(itemToRemove);
    }
}
