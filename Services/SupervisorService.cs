
using ThesisMate.Models;

namespace ThesisMate.Repositories
{
    public class SupervisorService(ThesisMateContext _context) : ISupervisorRepository
    {
        public IEnumerable<User> GetAllSupervisors()
        {
            return _context.Users.Where(u => u.RoleId == 1);
        }
    }


}