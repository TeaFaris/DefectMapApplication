namespace DefectMapApplication.Views;

public partial class CameraPage : ContentPage
{
	public CameraPage(CameraViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		NavigatedFrom += CameraPage_NavigatedFrom;
	}

	private void CameraPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
	{
		LoadCamera();
	}

	private void camera_CamerasLoaded(object sender, EventArgs e)
	{
		camera.Camera = camera.Cameras[0];

		LoadCamera();
	}

	private void LoadCamera()
	{
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await camera.StopCameraAsync();
			await camera.StartCameraAsync();
		});
	}
}
