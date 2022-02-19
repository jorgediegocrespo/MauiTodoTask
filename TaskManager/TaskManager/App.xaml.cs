namespace TaskManager;

public partial class App : Application
{
    private readonly IServiceProvider serviceProvider;

    public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
        this.serviceProvider = serviceProvider;

        var view = serviceProvider.GetService<TaskListView>();
        MainPage = new NavigationPage(view);
    }
}
