using DALInterface.DTO;

namespace DALInterface.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByName(string name);
    }
}
