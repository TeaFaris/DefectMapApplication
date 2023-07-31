using Mapsui.Tiling;

namespace DefectMapApplication.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		Loaded += MainPage_Loaded;
	}

	private async void MainPage_Loaded(object sender, EventArgs e)
	{
		var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

		map.Map.Layers.Add(OpenStreetMap.CreateTileLayer());

		if (status == PermissionStatus.Granted)
		{
			await (BindingContext as MainViewModel).Init(map);
		}
		else
		{
			await DisplayAlert("Доступ к геолокации", "Приложение не может работаеть корректно без доступа к геолокации. Пожалуйтса предоставьте доступ.", "Хорошо");
		}
	}
}
