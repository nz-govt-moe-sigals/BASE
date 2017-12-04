namespace App.Core.Shared.Attributes
{
    using App.Core.Shared.Models.Entities;

    // Attribute to attach to Models to *Hint* (it depends on additional factors too, but it's a start) 
    // as to the risks associated to exposure.
    public class DataClassificationAttribute
    {
        public DataClassificationAttribute(NZDataClassification dataClassification)
        {
            this.DataClassification = dataClassification;
        }
        public NZDataClassification DataClassification { get; set; }
    }
}
