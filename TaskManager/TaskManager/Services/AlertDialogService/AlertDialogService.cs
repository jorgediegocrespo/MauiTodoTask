namespace TaskManager.Services;

public class AlertDialogService : IAlertDialogService
{
	public async Task ShowDialogAsync(string title, string message, string close)
	{
		await Application.Current.MainPage.DisplayAlert(title, message, close);
	}

	public async Task<bool> ShowDialogConfirmationAsync(string title, string message, string cancel, string ok)
	{
		return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
	}
}
