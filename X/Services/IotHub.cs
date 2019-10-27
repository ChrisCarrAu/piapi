using Microsoft.Azure.Devices.Shared;
using Microsoft.Azure.Devices.Client;
using System;
using System.Device.Gpio;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using piapi.Models;
using Newtonsoft.Json.Linq;

namespace piapi.Services
{
    public class IotHub : IIotHub
    {
        private readonly Lazy<Task<DeviceClient>> _deviceClient;

        public IotHub(string connectionString)
        {
            _deviceClient = new Lazy<Task<DeviceClient>>(async () =>
            {
                var client = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);
                await client.SetDesiredPropertyUpdateCallbackAsync(desiredPropertyUpdated, null);
                var reported = new TwinCollection();
                reported["LastConnected"] = DateTime.Now;
                await client.UpdateReportedPropertiesAsync(reported);
                return client;
            });
        }

        private Task desiredPropertyUpdated(TwinCollection desiredProperties, object userContext)
        {
            var model = JsonConvert.DeserializeObject<IotHubModel>(desiredProperties.ToJson());
            return Task<bool>.Run(() => model.LedIlluminated);
        }

        public async Task<bool> GetLedIlluminated()
        {
            var client = await _deviceClient.Value;
            var twin = await client.GetTwinAsync();

            return await Task.Run(() => true);
        }

        public async void SetLedIlluminated(bool illuminated)
        {
            var client = await _deviceClient.Value;
            var reported = new TwinCollection();
            reported["ledIlluminated"] = illuminated;
            await client.UpdateReportedPropertiesAsync(reported);
        }
    }
}