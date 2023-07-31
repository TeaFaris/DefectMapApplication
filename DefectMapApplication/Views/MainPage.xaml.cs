using Mapsui.Nts;
using Mapsui.Tiling;
using Mapsui.UI.Maui;

namespace DefectMapApplication.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
