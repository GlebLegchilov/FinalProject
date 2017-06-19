using ORM;
using DALInterface.DTO;

namespace DAL.Mappers
{
    public static class DalEntityMappers
    {
        public static DalUser ToDalUser(this User userEntity)
        {
            if (userEntity == null) return null;
            return new DalUser()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                RoleId = userEntity.RoleId,
                Password = userEntity.Password,
                CreationDate = userEntity.CreationDate
            };
        }

        public static User ToOrmUser(this DalUser userEntity)
        {
            if (userEntity == null) return null;
            return new User()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                RoleId = userEntity.RoleId,
                Password = userEntity.Password,
                CreationDate = userEntity.CreationDate
            };
        }

        public static DalRole ToDalRole(this Role roleEntity)
        {
            if (roleEntity == null) return null;
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }

        public static Role ToOrmRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;
            return new Role()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalLot ToDalLot(this Lot entity)
        {
            if (entity == null) return null;
            return new DalLot()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Img = entity.Img,
                Price = entity.Price,
                CategoryId = entity.CategoryId,
                CreationDate = entity.CreationDate,
                PurchaseDate = entity.PurchaseDate,
                CreatorId = entity.CreatorId,
                OwnerId = entity.OwnerId
            };
        }

        public static Lot ToOrmLot(this DalLot entity)
        {
            if (entity == null) return null;
            return new Lot()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Img = entity.Img,
                Price = entity.Price,
                CategoryId = entity.CategoryId,
                CreationDate = entity.CreationDate,
                PurchaseDate = entity.PurchaseDate,
                CreatorId = entity.CreatorId,
                OwnerId = entity.OwnerId
            };
        }

        public static DalCategory ToDalCategory(this Category entity)
        {
            if (entity == null) return null;
            return new DalCategory()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
                
            };
        }

        public static Category ToOrmCategory(this DalCategory entity)
        {
            if (entity == null) return null;
            return new Category()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
                
            };
        }

    }
}
