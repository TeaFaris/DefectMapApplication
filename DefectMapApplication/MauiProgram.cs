using DefectMapApplication.Platforms.ControlMappers;
using Microsoft.Maui.Handlers;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace DefectMapApplication;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp(true)
			.UseSimpleToolkit()
			.UseSimpleShell()
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

		ElementHandler.ElementMapper.AppendToMapping("Classic",
			(handler, view) =>
			{
				EntryMapper.Map(handler, view);
			});

		return builder.Build();
	}
}
