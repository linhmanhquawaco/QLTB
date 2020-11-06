using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.Entities
{
    public class AppUser: IdentityUser<Guid>
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
    }
}
