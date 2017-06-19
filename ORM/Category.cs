using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM
{
    public partial class Category
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
    }
}
