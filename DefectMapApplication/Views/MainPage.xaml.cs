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
		map.Map.Layers.Add(OpenStreetMap.CreateTileLayer());

		await (BindingContext as MainViewModel).Init(map);
	}
}
