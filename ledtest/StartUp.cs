using SimpleLed.Services;

namespace SimpleLed
{
    public class Startup
    {
        private readonly ITestService _testService;

        public Startup(ITestService testService)
        {
            _testService = testService;
        }

        public void Run()
        {
            _testService.Process();
        }
    }
}