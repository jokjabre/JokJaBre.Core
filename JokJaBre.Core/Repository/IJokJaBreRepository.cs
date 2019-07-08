using JokJaBre.Core.Objects;
using System.Collections.Generic;

namespace JokJaBre.Core.Repository
{
    public interface IJokJaBreRepository<TModel>
        where TModel : IJokJaBreModel
    {
        IEnumerable<TModel> GetAll();
        TModel GetById<TClass>(TClass key, bool shouldThrow = true);

        TModel Create(TModel model);
    }
}
