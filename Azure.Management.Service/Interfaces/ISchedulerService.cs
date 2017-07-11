using Microsoft.Azure.Management.Scheduler.Models;
using System.Collections.Generic;

namespace Azure.Management.Service.Interfaces
{
    public interface ISchedulerService
    {
        IList<JobHistoryDefinition> GetJobHistory(string resourceGroupName, string jobCollection, string jobName);
        JobHistoryDefinition GetLastRunJobHistory(string resourceGroup, string jobCollection, string jobName);
    }
}