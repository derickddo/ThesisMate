using System;
using System.Collections.Generic;

namespace ThesisMate.Models;

public partial class Supervisee
{
    public int SuperviseeId { get; set; }

    public int StudentId { get; set; }

    public int SupervisorId { get; set; }

    public virtual User Student { get; set; } = null!;

    public virtual User Supervisor { get; set; } = null!;
}
