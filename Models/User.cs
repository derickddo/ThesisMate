using System;
using System.Collections.Generic;

namespace ThesisMate.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Supervisee> SuperviseeStudents { get; set; } = new List<Supervisee>();

    public virtual ICollection<Supervisee> SuperviseeSupervisors { get; set; } = new List<Supervisee>();
}
