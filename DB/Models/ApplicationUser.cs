using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DB.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string Address { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public DateTime LastSeen { get; set; }
        public virtual ICollection<UsersTask> UsersTasks { get; set; }
    }
}
