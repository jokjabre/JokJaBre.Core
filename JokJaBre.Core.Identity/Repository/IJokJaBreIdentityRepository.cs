namespace JokJaBre.Core.Identity
{
    public interface IJokJaBreIdentityRepository<TIdentityModel> where TIdentityModel : IJokJaBreIdentityModel
    {
        TIdentityModel Get(TIdentityModel model);
        TIdentityModel Create(TIdentityModel model);
        bool UsernameAvailable(string username);
        bool EmailAvaiilable(string email);
    }
}
