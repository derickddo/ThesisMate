﻿using System;
using System.Collections.Generic;

namespace ThesisMate.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleType { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
