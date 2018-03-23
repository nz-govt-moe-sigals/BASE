namespace App.Core.Infrastructure.IDA.Models
{
    public interface IApiQueryConfiguration
    {
        string Uri { get; set; }

        string[] FullyQualifiedRequiredScopes { get; set; }
    }
}