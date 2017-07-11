using Azure.Management.Service;
using Azure.Management.Service.Helpers;
using Azure.Management.Service.Services;
using System;

namespace Azure.Management.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var schedulerApi = new SchedulerApi(new SchedulerService(new ConfigHelper(), new AzureAdHelper(new ConfigHelper())));

            var jobHistory = schedulerApi.GetLastRunJobHistory("PoC", "TestCollection", "TestJob");

            Console.WriteLine(jobHistory.Name);
            Console.ReadLine();
        }
    }
}
