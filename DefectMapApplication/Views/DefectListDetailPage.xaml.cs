namespace DefectMapApplication.Views;

public partial class DefectListDetailPage : ContentPage
{
	public DefectListDetailPage(DefectListDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
