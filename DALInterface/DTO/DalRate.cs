using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterface.DTO
{
    public class DalRate:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AuctionId { get; set; }
        public decimal Value { get; set; }
    }
}
