using System.ComponentModel;

namespace TaskManager.Base;

public class BaseViewModel : INotifyPropertyChanged
{
    protected readonly IServiceProvider serviceProvider;

    public BaseViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public Task OnAppearing()
    {
        return Task.CompletedTask;
    }

    public Task OnDisappearing()
    {
        return Task.CompletedTask;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
