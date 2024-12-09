using System;
using System.Collections.Generic;

namespace ThesisMate.Models;

public partial class ProposalStatus
{
    public int StatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
