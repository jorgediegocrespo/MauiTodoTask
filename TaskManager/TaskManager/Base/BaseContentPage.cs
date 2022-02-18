using TaskManager.Base;

namespace TaskManager;

public class BaseContentPage : ContentPage
{
	public BaseContentPage(BaseViewModel viewModel)
	{
		BindingContext = viewModel;
	}
}