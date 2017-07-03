using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM.Models
{
    public partial class Lot : IOrmEntity
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int AuctionId { get; set; }
      

        public virtual Auction Auction { get; set; }
        public virtual User Owner { get; set; }

    }
}
