using Microsoft.Azure.Devices;
using System;
using System.Device.Gpio;
using System.Linq;
using System.Threading.Tasks;
using piapi.Models;

namespace piapi.Services
{
    public class IotHub : IIotHub
    {
        private readonly RegistryManager _registryManager;
        private readonly string _deviceId;

        public IotHub(string connectionString, string deviceId)
        {
            _registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            _deviceId = deviceId;
            Console.WriteLine(connectionString);
            Console.WriteLine(deviceId);
        }

        public async Task<bool> GetLedIlluminated()
        {
            var twin = await _registryManager.GetTwinAsync(_deviceId);
            var patch =
                @"{
                    tags: {
                        location: {
                            region: 'US',
                            plant: 'Redmond43'
                        }
                    }
                }";
            await _registryManager.UpdateTwinAsync(twin.DeviceId, patch, twin.ETag);

            var query = _registryManager.CreateQuery("SELECT * FROM devices WHERE tags.location.plant = 'Redmond43'", 100);
            var twinsInRedmond43 = await query.GetNextAsTwinAsync();
            Console.WriteLine("Devices in Redmond43: {0}", string.Join(", ", twinsInRedmond43.Select(t => t.DeviceId)));

            query = _registryManager.CreateQuery("SELECT * FROM devices WHERE tags.location.plant = 'Redmond43' AND properties.reported.connectivity.type = 'cellular'", 100);
            var twinsInRedmond43UsingCellular = await query.GetNextAsTwinAsync();
            Console.WriteLine("Devices in Redmond43 using cellular network: {0}", string.Join(", ", twinsInRedmond43UsingCellular.Select(t => t.DeviceId)));

            return await Task.Run(() => true);
        }
    }
}