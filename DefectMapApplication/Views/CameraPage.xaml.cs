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

	private async void TakePicture(object sender, EventArgs e)
	{
		var picture = camera.GetSnapShot();

		using var stream = await ((StreamImageSource)picture).Stream(CancellationToken.None);

		var pictureStream = new MemoryStream();
		await stream.CopyToAsync(pictureStream);

		pictureStream.Position = 0;

		var file = new LocalFile()
		{
			Stream = pictureStream,
			ContentType = "Image/png"
		};

		// TODO: Push to create defect page
	}
}
