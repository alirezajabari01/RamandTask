using System;
using System.Collections.Generic;

namespace Persistence.EF.Models;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
