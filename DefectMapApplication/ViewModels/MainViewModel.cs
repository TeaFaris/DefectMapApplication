using GeolocatorPlugin.Abstractions;
using GeolocatorPlugin;
using Mapsui.UI.Maui;

namespace DefectMapApplication.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private MapView mapView = null!;

    private GeolocatorPlugin.Abstractions.Position currentPosition = null!;

    public async void Init(MapView mapView)
    {
        this.mapView = mapView;

        if (await CrossGeolocator.Current.StartListeningAsync(
                    TimeSpan.FromSeconds(0.5f),
                    1,
                    true,
                    new ListenerSettings
                    {
                        ActivityType = ActivityType.AutomotiveNavigation,
                        AllowBackgroundUpdates = true,
                        DeferLocationUpdates = false,
                        ListenForSignificantChanges = false,
                        PauseLocationUpdatesAutomatically = false,
                        ShowsBackgroundLocationIndicator = true,
                    }
                )
            )
        {
            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
        }
    }

    private async void Current_PositionChanged(object sender, PositionEventArgs e)
    {
        Mapsui.UI.Maui.Position mauiPosition = new Mapsui.UI.Maui.Position(e.Position.Latitude, e.Position.Longitude);
        mapView.MyLocationLayer.UpdateMyLocation(mauiPosition);

        if(currentPosition is null)
        {
            mapView.MyLocationFollow = true;
        }

        if(mapView.MyLocationFollow)
        {
            mapView.Map.Navigator.CenterOnAndZoomTo(mauiPosition.ToMapsui(), 1);
        }

        currentPosition = e.Position;
    }
}
