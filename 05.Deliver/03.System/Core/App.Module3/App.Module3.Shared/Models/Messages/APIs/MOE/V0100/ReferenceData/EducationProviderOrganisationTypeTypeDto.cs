namespace App.Module3.Shared.Models.Messages.APIs.MOE.V0100
{
    using App.Module3.Shared.Models.Messages.APIs.MOE.V0100.Base;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Base;

    /// <summary>
    /// I think this is
    /// Criteria for defining the nature of a school.
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
    /// <seealso cref="SIFReferenceDtoBase" />
    public class EducationProviderOrganisationTypeTypeDto : TenantedMOEReferenceDtoBase
    {
    }
}