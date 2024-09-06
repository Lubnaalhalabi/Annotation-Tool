using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DB.Models
{
    public partial class UsersTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId;

        public int TaskId;

        public virtual Task Task { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
