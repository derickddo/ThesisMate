namespace ThesisMate.DTOs
{
    public record StudentWithProposals(
        int StudentId,
        string StudentName,
        string StudentEmail,
        List<StudentProposal> Proposals
    );
}