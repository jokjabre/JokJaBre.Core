using JokJaBre.Core.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Objects
{
    public interface IJokJaBreIdentityModel : IJokJaBreModel
    {
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
