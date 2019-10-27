using System.Threading.Tasks;

namespace piapi.Services
{
    public interface ILedService
    {
        public Task<bool> GetIlluminatedAsync();
    }
}