using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using TaskManager.Features;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.UnitTests.MockServices;
using Xunit;

namespace TaskManager.UnitTests;

public class TaskListViewModelTests
{
    private Mock<IStorageService> _mockStorage;
    
    public TaskListViewModelTests()
    {
        _mockStorage = new Mock<IStorageService>();
        _mockStorage.Setup(x => x.GetTaskItems())
            .ReturnsAsync(() => new ObservableCollection<TaskItem>()
            {
                new TaskItem() { Id = 3},
                new TaskItem() { Id = 5},
                new TaskItem() { Id = 1},
                new TaskItem() { Id = 27}
            });
    }
    
    [Fact]
    public void correct_sort_by_id_in_task_list()
    {
        var taskViewModel = new TaskListViewModel(null, _mockStorage.Object);
        taskViewModel.SortByIdCommand.Execute(null);
        
        Assert.Equal(1, taskViewModel.TaskItems[0].Id);
        Assert.Equal(27, taskViewModel.TaskItems[taskViewModel.TaskItems.Count -1].Id);
    }
    
    [Fact]
    public void correct_sort_by_id_in_task_list_with_fake_service()
    {
        var mockStorageService = new FakeStorageService(
            new List<TaskItem>()
            {
                new TaskItem() { Id = 3},
                new TaskItem() { Id = 5},
                new TaskItem() { Id = 1},
                new TaskItem() { Id = 27}
            });

        var taskViewModel = new TaskListViewModel(null, mockStorageService);
        taskViewModel.SortByIdCommand.Execute(null);
        
        Assert.Equal(1, taskViewModel.TaskItems[0].Id);
        Assert.Equal(27, taskViewModel.TaskItems[taskViewModel.TaskItems.Count -1].Id);
    }
}