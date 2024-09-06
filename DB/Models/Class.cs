using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DB.Models
{
    public partial class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
