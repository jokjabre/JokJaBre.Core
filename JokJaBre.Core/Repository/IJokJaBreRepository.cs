using JokJaBre.Core.Objects;

namespace JokJaBre.Core.Repository
{
    public interface IJokJaBreRepository<T> : IJokJaBreCrudProvider<T>
        where T : JokJaBreModel
    {
        
    }
}
