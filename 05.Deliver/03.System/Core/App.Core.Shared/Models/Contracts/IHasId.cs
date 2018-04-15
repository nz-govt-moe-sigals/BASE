namespace App.Core.Shared.Models
{
    public interface IHasId<T>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// <para>
        /// Decorating this property with [JsonProperty(PropertyName = "id")]        
        /// This is needed for entities that will be persisted using DocumentDB.
        /// I'm so far resisting putting a reference on Newtonsoft's library, because
        /// it would cause all downstream assemblies to Reference this lib. Not good practices
        /// if it can be avoided.
        /// IH
        /// </para>
        /// </summary>
        T Id { get; set; }
    }
}