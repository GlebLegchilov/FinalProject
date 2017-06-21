using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM
{

    public partial class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Lot> Lots { get; set; }
    }
}
