using Xamarin.Forms.Maps;
using Xamarin.Forms;
using GHQ.Logic.ViewModels.Map;
using GHQ.Logic;
using GHQ.Resources.Strings;
using GHQ.Logic.Models.Data.Map;

namespace GHQ.UI.Pages.MapLocation
{
    //LINK:https://developer.xamarin.com/guides/android/platform_features/maps_and_location/maps/obtaining_a_google_maps_api_key/
    //LINK:https://developer.xamarin.com/guides/xamarin-forms/user-interface/map/

    public class MapPage : ContentPage
    {
        readonly MapViewModel MapViewModel = Locator.Default.MapViewModel;

        public MapPage()
        {

            Title = AppResources.PageHeader_Map;
            MapViewModel.OnIntializeCommand.Execute(null);
            var map = new Map
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,

            };

            map.MoveToRegion(
				new MapSpan(MapViewModel.Locations[0].Location , 3,3)
              );
			for (int i = 0; i < MapViewModel.Locations.Count; i++)
			{
				MapData data = MapViewModel.Locations[i];
				var mapPin = new Pin
				{
					Type = PinType.Place,
					Position = data.Location,
					Label = data.Title
				};
				map.Pins.Add(mapPin);

			}

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    map
                }
            };
        }
    }
}
