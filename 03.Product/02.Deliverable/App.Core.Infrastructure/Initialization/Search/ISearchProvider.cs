
namespace App.Core.Infrastructure.Initialization.Search
{
    using System.Linq;
    using App.Core.Shared.Models.Messages;

    public interface ISearchProvider
    {
        IQueryable<SearchResponseItem> Search(string searchTerm);
    }
}
