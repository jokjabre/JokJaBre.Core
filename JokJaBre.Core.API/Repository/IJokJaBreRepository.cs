using JokJaBre.Core.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokJaBre.Core.API
{
    public interface IJokJaBreRepository<TModel>
        where TModel : IJokJaBreModel
    {
        IEnumerable<TModel> GetAll();
        Task<TModel> GetById<TClass>(TClass key, bool shouldThrow = true);

        Task<TModel> Create(TModel model);
        Task<bool> Delete<TClass>(TClass key);
    }
}
