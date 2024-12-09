using ThesisMate.Models;

namespace ThesisMate.Repositories
{
    public interface ISupervisorRepository
    {
        IEnumerable<User> GetAllSupervisors();
    }
}