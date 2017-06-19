using BLLInterface.Entities;
using DALInterface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            if (userEntity == null) return null;
            return new DalUser()
            {
                Id = userEntity.Id,
                Name = userEntity.UserName,
                RoleId = userEntity.RoleId,
                Password = userEntity.Password,
                CreationDate = userEntity.CreationDate
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null) return null;
            return new UserEntity()
            {
                Id = dalUser.Id,
                UserName = dalUser.Name,
                RoleId = dalUser.RoleId,
                Password = dalUser.Password,
                CreationDate = dalUser.CreationDate
            };
        }

        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            if (roleEntity == null) return null;
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name            
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalLot ToDalLot(this LotEntity entity)
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

        public static LotEntity ToBllLot(this DalLot entity)
        {
            if (entity == null) return null;
            return new LotEntity()
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

        public static DalCategory ToDalCategory(this CategoryEntity entity)
        {
            if (entity == null) return null;
            return new DalCategory()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public static CategoryEntity ToBllCategory(this DalCategory entity)
        {
            if (entity == null) return null;
            return new CategoryEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }
    }
}
