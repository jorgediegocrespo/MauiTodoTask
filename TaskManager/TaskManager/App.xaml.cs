namespace TaskManager;

public partial class App : Application
{
    public App(INavigationService navigationService)
	{
		InitializeComponent();

        MainPage = navigationService.GetInitialPage();
    }
}
