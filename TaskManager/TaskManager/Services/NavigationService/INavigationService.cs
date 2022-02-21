namespace TaskManager.Services;

public interface INavigationService
{
    Page GetInitialPage();

    Task NavigateToPageDetail(int taskId);

    Task NavigateBack();
}
