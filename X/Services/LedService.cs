using Microsoft.Azure.Devices;
using System.Device.Gpio;
using System.Threading.Tasks;
using piapi.Models;

namespace piapi.Services
{
    public class LedService : ILedService
    {
        private readonly IIotHub _iotHub;
        const int LEDPIN = 17;

        public LedService(IIotHub iotHub)
        {
            _iotHub = iotHub;
        }

        public async Task<bool> GetIlluminatedAsync()
        {
            return await _iotHub.GetLedIlluminated();
            // using var gpio = new GpioController();
            // gpio.OpenPin(LEDPIN, PinMode.Output);
            
            // return await Task<bool>.Run(() => true);
        }
    }
}