namespace App.Module3.Shared.Models.Entities
{
    public interface IHasSIFNOTIdAsStringId
    {
        /// <summary>
        /// Gets or sets the string PK of the 
        /// 'SIF API' id....when there is no 
        /// SIF value.
        /// <para>
        /// In other words, this ID is rather useless, it's only for reflection
        /// to spot a difference between the two conditions.
        /// </para>
        /// </summary>
        string Id
        {
            get; set;
        }
    }
}