using System.ComponentModel;

namespace TaskManager.Base;

public class BaseViewModel : INotifyPropertyChanged
{
    protected readonly INavigationService navigationService;

    public BaseViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual Task OnAppearing()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnDisappearing()
    {
        return Task.CompletedTask;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
