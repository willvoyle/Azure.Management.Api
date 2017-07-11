namespace Azure.Management.Service.Interfaces
{
    public interface IConfigHelper
    {
        string ClientId { get; }
        string ClientSecret { get; }
        string SubscriptionId { get; }
        string AuthenticationId { get; }
    }
}