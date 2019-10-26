using System.Device.Gpio;
using System.Threading.Tasks;
using piapi.Models;

namespace piapi.Services
{
    public class LedService : ILedService
    {
        const int LEDPIN = 17;

        public async Task<bool> GetIlluminatedAsync()
        {
            using var gpio = new GpioController();
            gpio.OpenPin(LEDPIN, PinMode.Output);
            
            return await Task<bool>.Run(() => true);
        }
    }
}