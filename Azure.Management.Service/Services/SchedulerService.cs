using Azure.Management.Service.Interfaces;
using Microsoft.Azure.Management.Scheduler;
using Microsoft.Azure.Management.Scheduler.Models;
using System.Linq;
using System.Collections.Generic;

namespace Azure.Management.Service.Services
{
    public class SchedulerService : ISchedulerService
    {
        private readonly IConfigHelper _configHelper;
        private readonly IAzureAdHelper _azureAdHelper;

        public SchedulerService(IConfigHelper configHelper, IAzureAdHelper azureAdHelper)
        {
            _configHelper = configHelper;
            _azureAdHelper = azureAdHelper;
        }

        public IList<JobHistoryDefinition> GetJobHistory(string resourceGroupName, string jobCollection, string jobName)
        {
            var client = GetScheulderClient();

            return client.Jobs.ListJobHistory(resourceGroupName, jobCollection, jobName).ToList();
        }

        public JobHistoryDefinition GetLastRunJobHistory(string resourceGroup, string jobCollection, string jobName)
        {
            var client = GetScheulderClient();

            return client.Jobs.ListJobHistory(resourceGroup, jobCollection, jobName)
                    .OrderByDescending(j => j.Properties.EndTime)
                    .FirstOrDefault();
        }

        private SchedulerManagementClient GetScheulderClient()
        {
            var token = _azureAdHelper.GetAdTokenCredentialsAsync($"https://login.windows.net/{_configHelper.AuthenticationId}", "https://management.azure.com/");
            return new SchedulerManagementClient(token.Result) { SubscriptionId = _configHelper.SubscriptionId };
        }
    }
}
