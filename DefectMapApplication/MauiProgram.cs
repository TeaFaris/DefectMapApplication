using Camera.MAUI;
using DefectMapApplication.Platforms.ControlMappers;
using DefectMapApplication.Services.API.DefectEndpointService;
using Microsoft.Maui.Handlers;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace DefectMapApplication;

public static class MauiProgram
{
	const string ServerAddress = "https://zp2q0cz6-7285.euw.devtunnels.ms/";

	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp(true)
			.UseSimpleToolkit()
			.UseSimpleShell()
			.UseMauiCameraView()
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

		builder.Services.AddSingleton<HttpClient>(_ => new HttpClient { BaseAddress = new Uri(Path.Combine(ServerAddress, "api/")) });

		builder.Services.AddSingleton<IDefectEndpoint, DefectEndpoint>();

		ElementHandler.ElementMapper.AppendToMapping("Classic",
			(handler, view) =>
			{
				EntryMapper.Map(handler, view);
			});

		return builder.Build();
	}
}
