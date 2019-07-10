using JokJaBre.Core.Objects;

namespace JokJaBre.Core.Identity
{
    public abstract class JokJaBreIdentityResponse<TIdentityModel> : IJokJaBreIdentityResponse
       where TIdentityModel : IJokJaBreIdentityModel
    {
        public string Token { get; set; }

        public abstract void SetFrom(TIdentityModel obj);

        public void SetFrom(IJokJaBreIdentityModel model)
        {
            if (model is TIdentityModel identityModel)
            {
                SetFrom(identityModel);
            }
        }
    }
}
