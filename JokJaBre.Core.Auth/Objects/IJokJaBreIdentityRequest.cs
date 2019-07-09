using JokJaBre.Core.Objects;

namespace JokJaBre.Core.Auth.Objects
{

    public interface IJokJaBreIdentityRequest : IJokJaBreObject
    {
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }

        void SetTo(IJokJaBreIdentityModel obj);
    }

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
