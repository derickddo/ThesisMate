using ThesisMate.Models;

namespace ThesisMate.Repositories
{
    public interface IUserRepository
    {
        Role GetUserRole(int roleId);
        IEnumerable<User> GetStudents();
        IEnumerable<User> GetSupervisors();
        User GetStudentById(int studentId);
        void AssignSupervisor(int supervisorId, int studentId);
        User GetStudentSupervisor(int userId);
        IEnumerable<User> GetSupervisorStudents(int userId);
        IEnumerable<Proposal> GetStudentProposals(int userId);
        void UploadProposal(Proposal proposal);
        Proposal GetStudentProposal(int userId);
        ProposalStatus GetProposalStatus(int proposalId);
    }
}