using ThesisMate.Models;

namespace ThesisMate.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<User> GetStudentsWithoutSupervisorAsync();
        IEnumerable<User> GetAllStudents();
        
    }
}