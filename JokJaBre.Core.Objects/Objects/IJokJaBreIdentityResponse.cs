namespace JokJaBre.Core.Objects
{
    public interface IJokJaBreIdentityResponse : IJokJaBreObject
    {
        string Token { get; set; }
        void SetFrom(IJokJaBreIdentityModel model);
    }

}
