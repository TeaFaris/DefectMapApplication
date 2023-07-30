namespace DefectMapApplication.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class DefectListDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem item;
}
