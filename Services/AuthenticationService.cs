using ThesisMate.Models;
using ThesisMate.Repositories;


namespace ThesisMate.Services

{
    public class AuthenticationService : IAuthenticationRepository
    {    
        private readonly ThesisMateContext _context;
        public AuthenticationService(ThesisMateContext context)
        {
            _context = context;
        }

        public (User? user, string message) Login(string email, string password)
        {   
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return (null, "Invalid email");
            }

            if(password != user.Password)
            {
                return (null, "Invalid password");
            }

            return (user, string.Empty);

        }

    }
}