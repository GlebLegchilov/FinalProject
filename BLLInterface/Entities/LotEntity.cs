using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLInterface.Entities
{
    public class LotEntity : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public byte[] Image { get; set; }
        public int CategoryId { get; set; }
        public int CreatorId { get; set; }
        public int OwnerId { get; set; }
    }
}
