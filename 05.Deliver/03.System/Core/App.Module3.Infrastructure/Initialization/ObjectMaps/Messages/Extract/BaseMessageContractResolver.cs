using App.Module3.Shared.Models.Messages.Extract;


namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract
{
    public abstract class BaseMessageContractResolver<T> : CustomContractResolver<T> where T : BaseMessage
    {
        protected BaseMessageContractResolver()
        {
            AddMap(x => x.Id, "id");
            AddMap(x => x.TableName, "Table_Name");
            AddMap(x => x.ModifiedBy);
            AddMap(x => x.ModifiedDate);
            AddMap(x => x.SourceDataLastModified);
        }
    }
}
