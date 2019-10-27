using System.Threading.Tasks;

namespace piapi.Services
{
    public interface IIotHub
    {
        public Task<bool> GetLedIlluminated();
    }
}