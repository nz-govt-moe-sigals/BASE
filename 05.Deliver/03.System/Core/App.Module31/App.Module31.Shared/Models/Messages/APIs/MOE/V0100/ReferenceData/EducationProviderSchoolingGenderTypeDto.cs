namespace App.Module31.Shared.Models.Messages.APIs.MOE.V0100
{
    using App.Module31.Shared.Models.Messages.APIs.MOE.V0100.Base;
    using App.Module31.Shared.Models.Messages.APIs.SIF.V0100.Base;

    /// <summary>
    /// A description of the gender of students that the school accepts for a certain year level or other instructional grouping.
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
    public class EducationProviderSchoolingGenderTypeDto :  /*ok*/ TenantedMOEReferenceDtoBase
    {
    }
}




