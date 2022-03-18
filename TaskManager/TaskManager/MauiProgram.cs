﻿namespace TaskManager;

public static class MauiProgram
{
	
	
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services
			.AddSingleton<INavigationService, NavigationService>()
			.AddSingleton<IAlertDialogService, AlertDialogService>()
			.AddSingleton<IStorageService, StorageService>()
			.AddTransient<TaskListView>()
			.AddTransient<TaskListViewModel>()
			.AddTransient<TaskDetailView>()
			.AddTransient<TaskDetailViewModel>();

		return builder.Build();
	}
}
