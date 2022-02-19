namespace TaskManager.Base
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage(BaseViewModel viewModel)
        {
            BindingContext = viewModel;
        }
    }
}
