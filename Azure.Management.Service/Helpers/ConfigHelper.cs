using Azure.Management.Service.Interfaces;
using System.Configuration;

namespace Azure.Management.Service.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public string ClientId { get => ConfigurationManager.AppSettings["ClientId"]; }
        public string ClientSecret { get => ConfigurationManager.AppSettings["ClientSecret"]; }
        public string SubscriptionId { get => ConfigurationManager.AppSettings["SubscriptionId"]; }
        public string AuthenticationId { get => ConfigurationManager.AppSettings["AuthenticationId"]; }
    }
}
