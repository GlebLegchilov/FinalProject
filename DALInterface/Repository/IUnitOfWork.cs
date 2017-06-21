using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterface.DTO;

namespace DALInterface.Repository
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository Users { get; }
        IRepository<DalRole> Roles { get; }
        IRepository<DalLot> Lots { get; }
        IRepository<DalCategory> Categorys { get; }

        void Commit();

    }
}
