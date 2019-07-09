using JokJaBre.Core.Auth.Objects;

namespace JokJaBre.Core.Auth.Repository
{
    public interface IJokJaBreIdentityRepository<TIdentityModel> where TIdentityModel : IJokJaBreIdentityModel
    {
        TIdentityModel Get(TIdentityModel model);
        TIdentityModel Create(TIdentityModel model);
        bool UsernameAvailable(string username);
        bool EmailAvaiilable(string email);
    }
}
