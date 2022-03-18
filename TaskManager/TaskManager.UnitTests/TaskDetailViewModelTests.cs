using Moq;
using TaskManager.Features;
using TaskManager.Models;
using TaskManager.Services.ConnectivityService;
using TaskManager.UnitTests.MockServices;
using Xunit;

namespace TaskManager.UnitTests;

[Collection("ViewModels")]
public class TaskDetailViewModelTests
{
     [Fact]
     public void task_item_validate_all_fields()
     {
          var fakeAlertDialogService = new FakeAlertDialogService();
          var taskDetailViewModel = new TaskDetailViewModel(null, null, fakeAlertDialogService);
          taskDetailViewModel.SaveTaskItemCommand.Execute(null);
          
          Assert.Equal("You must specify all the fields of the task", fakeAlertDialogService.Message);
     }

     [Fact]
     public void Bug123_low_priority_task_fails()
     {
          
         //new  Mock<IConnectivityService>().
     }


     [Theory]
     [InlineData(TaskPriority.Low, false)]
     [InlineData(TaskPriority.Medium, true)]
     [InlineData(TaskPriority.High, true)]
     public void task_item_with_priority_show_or_not_dialog(TaskPriority taskPriority, bool showDialogExpected)
     {
            
         
     }
     
     
}