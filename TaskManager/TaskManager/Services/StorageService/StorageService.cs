namespace TaskManager.Services;

public class StorageService : IStorageService
{
    private List<TaskItem> taskItemList;

    public StorageService()
    {
        taskItemList = new List<TaskItem>();
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

    public async Task<List<TaskItem>> GetTaskItems()
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
            taskItemList.Add(taskItem);
        else
        {
            var elementIndex = taskItemList.FindIndex(x => x.Id == taskItem.Id);
            taskItemList[elementIndex] = taskItem;
        }
    }

    public async Task RemoveTaskItems(int id)
    {
        await Task.Delay(500);
        taskItemList.RemoveAll(x => x.Id == id);
    }
}
