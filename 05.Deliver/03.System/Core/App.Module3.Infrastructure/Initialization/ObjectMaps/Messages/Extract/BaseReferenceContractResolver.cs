using App.Module3.Shared.Models.Messages.Extract;


namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.Extract
{
    public abstract class BaseReferenceContractResolver<T> : BaseMessageContractResolver<T>  where T: BaseReference
    {
        protected BaseReferenceContractResolver() :base()
        {
            AddMap(x => x.Code);
            AddMap(x => x.Comments);
            AddMap(x => x.Description);
        }
    }
}
