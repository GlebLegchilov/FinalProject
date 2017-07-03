using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM.Models
{
    public partial class Feedback:IOrmEntity
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int TargetId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }



        public virtual User Creator { get; set; }
        public virtual User Target { get; set; }
    }
}
