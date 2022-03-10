namespace TaskManager.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Page GetInitialPage()
    {
        var view = serviceProvider.GetService<TaskListView>();
        return new NavigationPage(view);
    }

    public async Task NavigateBack()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    public async Task NavigateToPageDetail(int taskId)
    {
        var view = serviceProvider.GetService<TaskDetailView>();
        ((TaskDetailViewModel)view.BindingContext).Init(taskId);
        await Application.Current.MainPage.Navigation.PushAsync(view);
    }
}
