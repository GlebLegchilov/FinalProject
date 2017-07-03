using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM.Models
{

    public partial class User : IOrmEntity
    {
        public User()
        {
            Lots = new HashSet<Lot>();
            Auctions = new HashSet<Auction>();
            Feedbacks = new HashSet<Feedback>();
            Rates = new HashSet<Rate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }



        public virtual Role Role { get; set; }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }

    }
}
