using System;
using System.Threading;
using Windows.ApplicationModel.Background;
using Windows.Devices.Geolocation;

namespace CookAdvisor.Client.BackgroundTasks
{
    public sealed class LocationBackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            
            var geolocator = new Geolocator();
            var pos = await geolocator.GetGeopositionAsync().AsTask();

            deferral.Complete();
         }
    }
}
