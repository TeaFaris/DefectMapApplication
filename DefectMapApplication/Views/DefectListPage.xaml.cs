namespace DefectMapApplication.Views;

public partial class DefectListPage : ContentPage
{
	DefectListViewModel ViewModel;

	public DefectListPage(DefectListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
