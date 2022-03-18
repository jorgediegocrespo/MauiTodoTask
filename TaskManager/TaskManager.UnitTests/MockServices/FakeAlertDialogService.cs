using System.Threading.Tasks;
using TaskManager.Services;

namespace TaskManager.UnitTests.MockServices;

public class FakeAlertDialogService : IAlertDialogService
{
    public string Message { get; set; }
    
    public Task ShowDialogAsync(string title, string message, string close)
    {
        Message = message;
        return Task.CompletedTask;
    }

    public Task<bool> ShowDialogConfirmationAsync(string title, string message, string cancel, string ok)
        => Task.FromResult(true);
}