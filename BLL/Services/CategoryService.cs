using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLLInterface.Entities;
using BLLInterface.Services;
using BLL.Mappers;
using DALInterface.Repository;

namespace BLL.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork uow;

        public CategoryService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public bool Exist(CategoryEntity c)
        {
            return uow.Categorys.Exist(c.ToDalCategory());
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return uow.Categorys.GetAll().Select(role => role.ToBllCategory());
        }

        public CategoryEntity GetById(int id)
        {
            return uow.Categorys.GetById(id).ToBllCategory();
        }

      
    }
}
