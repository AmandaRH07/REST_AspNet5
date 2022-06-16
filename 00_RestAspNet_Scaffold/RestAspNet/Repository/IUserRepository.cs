using RestAspNet.Data.Value_Object;
using RestAspNet.Model;

namespace RestAspNet.Repository
{
    public interface IUserRepository
    {
        User ValidadeCredentials(UserVO user);
    }
}
