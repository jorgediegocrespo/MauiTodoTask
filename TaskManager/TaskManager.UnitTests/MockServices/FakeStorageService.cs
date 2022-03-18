using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.UnitTests.MockServices;

public class FakeStorageService : IStorageService
{
    private List<TaskItem> _taskItems;
    
    public FakeStorageService(List<TaskItem> taskItems)
    {
        _taskItems = taskItems;
    }

    public Task<ObservableCollection<TaskItem>> GetTaskItems()
        => Task.FromResult(new ObservableCollection<TaskItem>(_taskItems));

    public Task<TaskItem> GetTaskItem(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task SaveTaskItem(TaskItem taskItem)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveTaskItems(int id)
    {
        throw new System.NotImplementedException();
    }
}