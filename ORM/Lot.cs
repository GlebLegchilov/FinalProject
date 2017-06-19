using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM
{
    public partial class Lot
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public byte[] Img { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CreatorId { get; set; }
        public int OwnerId { get; set; }

    }
}
