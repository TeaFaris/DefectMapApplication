using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace DefectMapApplication;

public partial class AppShell : SimpleShell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DefectListDetailPage), typeof(DefectListDetailPage));
	}

	private async void ShellItemButtonClicked(object sender, EventArgs e)
	{
		var button = sender as ContentButton;
		var bindingContext = button.BindingContext as BaseShellItem;

		if (!CurrentState.Location.OriginalString.Contains(bindingContext.Route))
		{
			await GoToAsync($"///{bindingContext.Route}", true);
		}
	}

	private async void Search(object sender, EventArgs e)
	{
		await GoToAsync(nameof(DefectListDetailPage), true, new Dictionary<string, object>
		{
			{ "SearchQuery", searchBar.Text }
		});
	}
}
