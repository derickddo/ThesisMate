namespace ThesisMate.DTOs
{
    public record StudentProposal(
        int ProposalId,
        string ProposalName,
        string ProposalFile,
        string Status
    );
}