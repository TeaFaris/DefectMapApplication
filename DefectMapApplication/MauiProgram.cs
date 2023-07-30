﻿namespace DefectMapApplication;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMaps()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<CameraViewModel>();

		builder.Services.AddSingleton<CameraPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<DefectListDetailViewModel>();
		builder.Services.AddTransient<DefectListDetailPage>();

		builder.Services.AddSingleton<DefectListViewModel>();

		builder.Services.AddSingleton<DefectListPage>();

		return builder.Build();
	}
}