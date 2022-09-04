using RestAspNet.Data.Value_Object;

namespace RestAspNet.Services.Implementations
{
    public interface ILoginService
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string userName);
    }
}
