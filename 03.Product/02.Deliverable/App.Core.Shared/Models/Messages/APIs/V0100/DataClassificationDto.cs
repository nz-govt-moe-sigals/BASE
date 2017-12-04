namespace App.Core.Shared.Models.Messages.APIs.V0100
{
    using System;
    using App.Core.Shared.Models.Entities;

    public class DataClassificationDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ 
    {
        public virtual NZDataClassification Id { get; set; }    
        public virtual string Text { get; set; }
        public virtual int DisplayOrderHint { get; set; }
        public virtual string DisplayStyleHint { get; set; }
    }


}
