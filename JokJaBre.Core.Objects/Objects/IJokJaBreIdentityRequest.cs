using JokJaBre.Core.Objects;

namespace JokJaBre.Core.Objects
{

    public interface IJokJaBreIdentityRequest : IJokJaBreObject
    {
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }

        void SetTo(IJokJaBreIdentityModel obj);
    }

}
