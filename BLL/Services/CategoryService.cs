using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLLInterface.Entities;
using BLLInterface.Services;
using BLL.Mappers;
using DALInterface.Repository;
using DALInterface.DTO;

namespace BLL.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork uow;
        private readonly ICategoryRepository repository;

        public CategoryService(IUnitOfWork uow, ICategoryRepository repository)
        {
            this.uow = uow;
            this.repository = repository;
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return repository.GetAll().Select(role => role.ToBllCategory());
        }

        public CategoryEntity GetById(int id)
        {
            return repository.GetById(id).ToBllCategory();
        }
    }
}
