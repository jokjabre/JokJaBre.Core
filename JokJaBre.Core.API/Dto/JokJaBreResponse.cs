using JokJaBre.Core.Objects;

namespace JokJaBre.Core.API.Dto
{
    public abstract class JokJaBreResponse<TModel> : IJokJaBreResponse
        where TModel : IJokJaBreModel
    {
        public abstract void SetFrom(IJokJaBreModel obj);
    }
}
