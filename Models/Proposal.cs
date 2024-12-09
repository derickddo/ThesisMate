using System;
using System.Collections.Generic;

namespace ThesisMate.Models;

public partial class Proposal
{
    public int ProposalId { get; set; }

    public string ProposalFile { get; set; } = null!;

    public string ProposalName { get; set; } = null!;

    public int StatusId { get; set; }

    public int UserId { get; set; }

    public virtual ProposalStatus Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
