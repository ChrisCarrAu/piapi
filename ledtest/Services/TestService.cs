using System;

namespace SimpleLed.Services
{
    public class TestService : ITestService
    {
        public void Process()
        {
            Console.WriteLine("Hello World!");
        }
    }
}