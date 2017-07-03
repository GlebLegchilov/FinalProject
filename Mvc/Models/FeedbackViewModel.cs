using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int TargetId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}