namespace JokJaBre.Core.Identity
{
    public interface IJokJaBreIdentityService<TIdentityModel> 
        where TIdentityModel : IJokJaBreIdentityModel
    {

        TResponse Register<TRequest, TResponse>(TRequest obj)
            where TRequest : IJokJaBreIdentityRequest
            where TResponse : IJokJaBreIdentityResponse;

        TResponse Login<TRequest, TResponse>(TRequest obj)
            where TRequest : IJokJaBreIdentityRequest
            where TResponse : IJokJaBreIdentityResponse;

        bool UsernameAvailable(string username);
        bool EmailAvaiilable(string email);
    }
}
