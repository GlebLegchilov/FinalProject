﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLInterface.Entities
{
    public class FeedbackEntity : IEntity
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int TargetId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
