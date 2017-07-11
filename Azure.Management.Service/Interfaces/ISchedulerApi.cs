using Microsoft.Azure.Management.Scheduler.Models;
using System.Collections.Generic;

namespace Azure.Management.Service.Interfaces
{
    public interface ISchedulerApi
    {
        IList<JobHistoryDefinition> GetJobHistory(string resourceGroup, string jobCollection, string jobName);
        JobHistoryDefinition GetLastRunJobHistory(string resourceGroup, string jobCollection, string jobName);
    }
}