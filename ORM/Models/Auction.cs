using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM.Models
{
    public partial class Auction : IOrmEntity
    {

        public Auction()
        {
            Rates = new HashSet<Rate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; }
        public decimal MinPrice { get; set; }
        public int CreatorId { get; set; }
        public DateTime EndingDate { get; set; }
        public bool AvailabilityStatus { get; set; }
        public int LotId { get; set; }



        public virtual User Creator { get; set; }
        //public virtual Lot Lot { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
    }
}
