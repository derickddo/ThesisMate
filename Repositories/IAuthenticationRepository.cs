using ThesisMate.Models;

namespace ThesisMate.Repositories
{
    public interface IAuthenticationRepository
    {
        (User? user, string message) Login(string email, string password);
       
    }
}