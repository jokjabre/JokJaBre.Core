using JokJaBre.Core.Objects;

namespace JokJaBre.Core.Identity
{
    public abstract class JokJaBreIdentityRequest<TIdentityModel> : IJokJaBreIdentityRequest
      where TIdentityModel : IJokJaBreIdentityModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public abstract void SetTo(TIdentityModel obj);

        public void SetTo(IJokJaBreIdentityModel obj)
        {
            if (obj is TIdentityModel model)
            {
                SetTo(model);
            }
        }
    }
}
