using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using TaskManager.Services;

namespace TaskManager.UnitTests.MockServices;

public class FakeNavigationService : INavigationService
{
    public Page GetInitialPage()
    {
        throw new System.NotImplementedException();
    }

    public Task NavigateToPageDetail(int taskId)
    {
        throw new System.NotImplementedException();
    }

    public Task NavigateBack()
    {
        throw new System.NotImplementedException();
    }
}