using BLLInterface.Entities;
using DALInterface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        #region User
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
        #endregion

        #region Role
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
        #endregion

        #region Lot
        public static DalLot ToDalLot(this LotEntity entity)
        {
            if (entity == null) return null;
            return new DalLot()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Image = entity.Image,
                OwnerId = entity.OwnerId,
                AuctionId = entity.AuctionId
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
                Image = entity.Image,
                OwnerId = entity.OwnerId,
                AuctionId = entity.AuctionId
            };
        }
        #endregion

     
        #region Auction
        public static DalAuction ToDalAuction(this AuctionEntity entity)
        {
            if (entity == null) return null;
            return new DalAuction()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatorId = entity.CreatorId,
                MinPrice = entity.Price,
                EndingDate = entity.EndingDate,
                Type = entity.Type,
                LotId = entity.LotId,
                AvailabilityStatus = entity.AvailabilityStatus
            };
        }

        public static AuctionEntity ToBllAuction(this DalAuction entity)
        {
            if (entity == null) return null;
            return new AuctionEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatorId = entity.CreatorId,
                Price = entity.MinPrice,
                EndingDate = entity.EndingDate,
                Type = entity.Type,
                LotId = entity.LotId,
                AvailabilityStatus = entity.AvailabilityStatus
            };
        }
        #endregion

      

        #region Feedback
        public static DalFeedback ToDalFeedback(this FeedbackEntity entity)
        {
            if (entity == null) return null;
            return new DalFeedback()
            {
                Id = entity.Id,
                CreationDate = entity.CreationDate,
                CreatorId = entity.CreatorId,
                TargetId = entity.TargetId,
                Text = entity.Text
            };
        }

        public static FeedbackEntity ToBllFeedback(this DalFeedback entity)
        {
            if (entity == null) return null;
            return new FeedbackEntity()
            {
                Id = entity.Id,
                CreationDate = entity.CreationDate,
                CreatorId = entity.CreatorId,
                TargetId = entity.TargetId,
                Text = entity.Text
            };
        }
        #endregion

        #region Rate
        public static DalRate ToDalRate(this RateEntity entity)
        {
            if (entity == null) return null;
            return new DalRate()
            {
                Id = entity.Id,
                AuctionId = entity.AuctionId,
                UserId = entity.UserId,
                Value = entity.Value
            };
        }

        public static RateEntity ToBllRate(this DalRate entity)
        {
            if (entity == null) return null;
            return new RateEntity()
            {
                Id = entity.Id,
                AuctionId = entity.AuctionId,
                UserId = entity.UserId,
                Value = entity.Value
            };
        }
        #endregion
    }
}
