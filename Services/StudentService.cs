
using ThesisMate.Models;
using ThesisMate.Repositories;

namespace ThesisMate.Services {
    public class StudentService(ThesisMateContext _context): IStudentRepository {
        
        

        

        

        // public Task AssignSupervisors(){
        //     // Get students without supervisors
        //     var students = _studentRepository.GetStudentsWithoutSupervisorAsync();

        //     // Get supervisors with capacity; supervisors who can take on more students
        //     var supervisors = _supervisorRepository.GetSupervisorsWithCapacity();

        //     // Randomly assign supervisors to students
        //     foreach (var student in students)
        //     {   
        //         // Randomly select a supervisor
        //         var supervisor = supervisors.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        //         // If a supervisor is found, assign the supervisor to the student
        //         if (supervisor != null)
        //         {   
        //             // Update the student's supervisor
        //             student.SupervisorId = supervisor.Id;
        //             _studentRepository.Update(student);
        //         }
        //     }

        //     return Task.CompletedTask;
        // }

        

        
        public IEnumerable<User> GetAllStudents()
        {
            return _context.Users.Where(u => u.RoleId == 2).ToList();
        }

        public IEnumerable<User> GetStudentsWithoutSupervisorAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}