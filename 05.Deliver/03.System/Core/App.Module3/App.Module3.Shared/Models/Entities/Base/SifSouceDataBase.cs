
namespace App.Module3.Shared.Models.Entities
{
    public enum SifLookup
    {
        FirstId,
        EvaId,
        SifId
    }


    public class SifSouceDataBase : IHasSifSouceDataBase
    {
        public string FirstId { get; set; }

        public string EvaId { get; set; }

        public string SifId { get; set; }

    }
}
