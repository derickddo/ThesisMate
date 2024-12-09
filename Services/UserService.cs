using ThesisMate.Models;
using ThesisMate.Repositories;

namespace ThesisMate.Services
{
    public class UserService : IUserRepository
    {
        private readonly ThesisMateContext _context;
        public UserService(ThesisMateContext context)
        {
            _context = context;
        }

        public Role GetUserRole(int roleId)
        {
            var role = _context.Roles.Find(roleId);
            return role ?? null!;
        }

        // get all students
        public IEnumerable<User> GetStudents()
        {
            // get all students including their supervisors
            return _context.Users.Where(u => u.RoleId == 2).ToList();   
        }

        // get all supervisors
        public IEnumerable<User> GetSupervisors()
        {
            return _context.Users.Where(u => u.RoleId == 1).ToList();
        }

        // get student by id
        public User GetStudentById(int studentId)
        {
            return _context.Users.Find(studentId) ?? null!;
        }

        public void AssignSupervisor(int supervisorId, int studentId)
        {
            // check that no student has more than one supervisor
            var student = _context.Users.Find(studentId);
            var supervisee = _context.Supervisees.Find(studentId);
            
            if(supervisee != null)
            {
                // student already has a supervisor
                return;
            }
            var newSupervisee = new Supervisee
            {
                SupervisorId = supervisorId,
                StudentId = studentId
            };
            _context.Supervisees.Add(newSupervisee);
            _context.SaveChanges();
        }

        public User GetStudentSupervisor(int userId)
        {
            var supervisee = _context.Supervisees.Find(userId);
            if(supervisee != null)
            {
                // student has a supervisor
                // query supervisor with supervisorId
                var supervisor = _context.Users.Find(supervisee.SupervisorId);

                return supervisor ?? null!;
            }

            return null!;
        }

        public IEnumerable<User> GetSupervisorStudents(int userId)
        {
            // get all students supervised by a supervisor
            var supervisee = _context.Supervisees.Where(s => s.SupervisorId == userId);

            var students = _context.Users.Where(u => supervisee.Any(s => s.StudentId == u.UserId)).ToList();

            return students;
        }

        public IEnumerable<Proposal> GetStudentProposals(int userId)
        {
            // get all proposals by a student
            var proposals = _context.Proposals.Where(p => p.UserId == userId).ToList();

            return proposals ?? null!;
        }

        public void UploadProposal(Proposal proposal)
        {
            _context.Proposals.Add(proposal);
            _context.SaveChanges();
        }

        public Proposal GetStudentProposal(int userId)
        {
            // get proposal by student id
            var proposal = _context.Proposals.FirstOrDefault(p => p.UserId == userId);

            return proposal ?? null!;
        }

        public ProposalStatus GetProposalStatus(int proposalId)
        {
            // get proposal status
            var status = _context.ProposalStatuses.Find(proposalId);
            return status ?? null!;
        }
    }
}