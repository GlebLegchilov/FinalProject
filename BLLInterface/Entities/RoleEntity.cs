using System;
using System.Collections.Generic;

namespace BLLInterface.Entities
{
    public class RoleEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
