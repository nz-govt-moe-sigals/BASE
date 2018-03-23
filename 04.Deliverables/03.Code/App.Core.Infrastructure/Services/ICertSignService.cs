namespace App.Core.Infrastructure.Services
{
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using App.Core.Shared.Services;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// Sign data.
    ///     <para>
    ///         Use to sign OperationLog entries.
    ///     </para>
    /// </summary>
    public interface ICertSignService : IHasAppCoreService
    {
        byte[] Sign(byte[] data, RSACryptoServiceProvider cryptoServiceProvider);
        byte[] Sign(byte[] data, X509FindType certFindType, string certSearchTerm);
        byte[] Sign(string text, X509FindType certFindType, string certSearchTerm);
        bool Verify(byte[] data, byte[] signature, RSACryptoServiceProvider cryptoServiceProvider);
        bool Verify(byte[] data, byte[] signature, X509FindType certFindType, string certSearchTerm);
        bool Verify(string clearText, byte[] signature, X509FindType certFindType, string certSearchTerm);
    }
}