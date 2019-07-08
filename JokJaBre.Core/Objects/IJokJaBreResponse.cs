using JokJaBre.Core.Extensions;

namespace JokJaBre.Core.Objects
{
    public interface IJokJaBreResponse : IJokJaBreObject
    {
        void SetFrom(IJokJaBreModel model);
    }

    public abstract class JokJaBreResponse<TModel> : IJokJaBreResponse
        where TModel : IJokJaBreModel
    {
        public abstract void SetFrom(IJokJaBreModel obj);
    }
}
