﻿using System;
using System.Collections.Generic;

namespace HumanResource.Data.Database;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
