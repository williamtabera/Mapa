using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Location.ClassMaster
{
    public class CustomMap : Map
    {
        private Map _map;

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.CreateAttached("ItemsSource", typeof(IEnumerable<CustomPin>), typeof(CustomMap),default(IEnumerable<CustomPin>), BindingMode.Default, null, OnItemsSourceChanged);

        public IEnumerable<CustomPin> ItemsSource
        {
            get { return (IEnumerable<CustomPin>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        private static void OnItemsSourceChanged(BindableObject view, object oldValue, object newValue)
        {
            var customMap = view as CustomMap;

            if (customMap != null)
            {
                customMap.AddPins();
                customMap.PositionMap();
            }
        }

        private void AddPins()
        {
            for (int i = _map.Pins.Count - 1; i >= 0; i--)
            {
                _map.Pins.RemoveAt(i);
            }

            var pins = ItemsSource.Select(x =>
            {
                var pin = new Pin
                {
                    Type = PinType.SearchResult,
                    Position = new Position(x.Latitude, x.Longitude),
                    Label = string.Format("{0}, {1}", x.Latitude, x.Longitude)
                };

                return pin;
            }).ToArray();

            foreach (var pin in pins)
                _map.Pins.Add(pin);
        }

        private void PositionMap()
        {
            if (ItemsSource == null || !ItemsSource.Any()) return;

            var centerPosition = new Position(ItemsSource.Average(x => x.Latitude), ItemsSource.Average(x => x.Longitude));

            var distance = 0.5;

            _map.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromMiles(distance)));

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                _map.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromMiles(distance)));
                return false;
            });
        }

    }
}
