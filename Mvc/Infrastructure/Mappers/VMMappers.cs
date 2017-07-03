using BLLInterface.Entities;
using BLLInterface.Services;
using Mvc.Models;
using System.Web;
using System.IO;


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
                Role = s.GetRole(userEntity.RoleId).Name,
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
                //CategoryId = int.Parse(entity.CategoryId),
                AuctionId = entity.AuctionId,
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
                OwnerId = entity.OwnerId,
                //CategoryId = int.Parse(entity.Category),
               

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
               Image = entity.Image,
                OwnerId = entity.OwnerId,

            };
        }

        public static byte[] ToImage(this HttpPostedFileBase image)
        {
            var content = new byte[image.ContentLength];
            image.InputStream.Seek(0, SeekOrigin.Begin);
            image.InputStream.Read(content, 0, image.ContentLength);
            return content;
        }

        public static AuctionEntity ToBllAuction(this AuctionViewModel entity)
        {
            if (entity == null) return null;
            bool type = true;
            if (entity.Type == "Simple")
            {
                type = false;
            }
            return new AuctionEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                AvailabilityStatus = entity.AvailabilityStatus,
                CreatorId =entity.CreatorId,
                EndingDate = entity.EndingDate,
                Price = entity.Price,
                //LotId = entity.LotId,
                Type = type

            };
        }

        public static AuctionViewModel ToViewModelAuction(this AuctionEntity entity)
        {
            if (entity == null) return null;
            string type = "Standart";
            if (!entity.Type)
            {
                type = "Simple";
            }
            return new AuctionViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                AvailabilityStatus = entity.AvailabilityStatus,
                CreatorId = entity.CreatorId,
                EndingDate = entity.EndingDate,
                Price = entity.Price,
                LotId = entity.LotId.ToString(),
                Type = type

            };
        }



    }
}