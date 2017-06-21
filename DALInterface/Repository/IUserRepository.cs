using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterface.DTO;

namespace DALInterface.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByName(string name);
    }
}
