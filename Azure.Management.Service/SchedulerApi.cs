using Azure.Management.Service.Interfaces;
using Microsoft.Azure.Management.Scheduler.Models;
using System.Collections.Generic;

namespace Azure.Management.Service
{
    public class SchedulerApi : ISchedulerApi
    {
        private readonly ISchedulerService _schedulerService;

        public SchedulerApi(ISchedulerService schedulerService)
        {
            _schedulerService = schedulerService;
        }

        public JobHistoryDefinition GetLastRunJobHistory(string resourceGroup, string jobCollection, string jobName)
        {
            return _schedulerService.GetLastRunJobHistory(resourceGroup, jobCollection, jobName);
        }

        public IList<JobHistoryDefinition> GetJobHistory(string resourceGroup, string jobCollection, string jobName)
        {
            return _schedulerService.GetJobHistory(resourceGroup, jobCollection, jobName);
        }
    }
}
