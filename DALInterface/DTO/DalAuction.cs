using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterface.DTO
{
    public class DalAuction : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool Type { get; set; }
        public decimal MinPrice { get; set; }
        public int CreatorId { get; set; }
        public DateTime EndingDate { get; set; }
        public bool AvailabilityStatus { get; set; }
        public int LotId { get; set; }
    }
}
