namespace App.Module11.Shared.Models.Messages.APIs.MOE.V0100
{
    using App.Module11.Shared.Models.Messages.APIs.MOE.V0100.Base;

    /// <summary>
    /// 
    /// <para>
    /// Uses MOE Codes as public PK.
    /// </para>
    /// <para>
    /// MOE Codes are required for compatibility with existing systems, 
    /// even if throuhg new API Clients,
    /// unless they add a code transalation layer as well.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Module11.Shared.Models.Messages.APIs.MOE.V0100.Base.TenantedMOEReferenceDtoBase" />
    public class EducationProviderClassificationDto : TenantedMOEReferenceDtoBase
    {
    }
}