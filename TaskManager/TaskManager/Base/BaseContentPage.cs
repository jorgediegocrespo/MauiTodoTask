namespace TaskManager.Base
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage(BaseViewModel viewModel)
        {
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((BaseViewModel)BindingContext).OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((BaseViewModel)BindingContext).OnDisappearing();
        }
    }
}
