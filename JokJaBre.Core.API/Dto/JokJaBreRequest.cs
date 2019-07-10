using JokJaBre.Core.Objects;

namespace JokJaBre.Core.API
{
    public abstract class JokJaBreRequest<TModel> : IJokJaBreRequest
        where TModel : IJokJaBreModel
    {
        public abstract void SetTo(TModel obj);
        public void SetTo(IJokJaBreModel obj)
        {
            if (obj is TModel model)
            {
                SetTo(model);
            }
        }
    }
}
