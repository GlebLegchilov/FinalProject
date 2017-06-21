using BLLInterface.Entities;
using BLLInterface.Services;
using Mvc.Models;


namespace Mvc.Infrastructure.Mappers
{
    public static class VMMappers
    {
        public static UserViewModel ToVMUser(this UserEntity userEntity, IRoleService s)
        {
            if (userEntity == null) return null;

            return new UserViewModel()
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                Password = userEntity.Password,
                Role = s.GetById(userEntity.RoleId).Name,
                CreationDate = userEntity.CreationDate
            };
        }

        public static LotEntity ToBllLot(this LotViewModel entity)
        {
            if (entity == null) return null;

            return new LotEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Image = entity.Img,
                Price = entity.Price,
                CategoryId = int.Parse(entity.Category),
                CreatorId = entity.CreatorId,
                OwnerId = entity.OwnerId

            };
        }

        public static LotEntity ToBllLot(this NewLotViewModel entity)
        {
            if (entity == null) return null;

            return new LotEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Image = entity.Img,
                Price = entity.Price,
                CategoryId = int.Parse(entity.Category),
                CreatorId = entity.Creator
                
            };
        }

        public static LotViewModel ToLotViewModel(this LotEntity entity)
        {
            if (entity == null) return null;

            return new LotViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Img = entity.Image,
                Price = entity.Price,
                CreatorId = entity.CreatorId,
                OwnerId = entity.OwnerId
            };
        }





    }
}