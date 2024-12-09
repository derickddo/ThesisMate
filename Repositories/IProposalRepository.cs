using ThesisMate.Models;

namespace ThesisMate.Repositories
{
    public interface IProposalRepository
    {
        IEnumerable<Proposal> GetProposals();
        Proposal GetProposalById(int proposalId);
        void AddProposal(Proposal proposal);
        void UpdateProposal(Proposal proposal);
        void DeleteProposal(int proposalId);
    }
}