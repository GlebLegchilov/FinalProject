using ORM.Models;
using DALInterface.DTO;

namespace DAL.Mappers
{
    public static class DalEntityMappers
    {
        #region User
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
        #endregion

        #region Role
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
        #endregion

        #region Lot
        public static DalLot ToDalLot(this Lot entity)
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

        public static Lot ToOrmLot(this DalLot entity)
        {
            if (entity == null) return null;
            return new Lot()
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
        public static DalAuction ToDalAuction(this Auction entity)
        {
            if (entity == null) return null;
            return new DalAuction()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatorId = entity.CreatorId,
                MinPrice = entity.MinPrice,
                EndingDate = entity.EndingDate,
                Type = entity.Type,
                LotId = entity.LotId,
                AvailabilityStatus = entity.AvailabilityStatus
            };
        }

        public static Auction ToOrmAuction(this DalAuction entity)
        {
            if (entity == null) return null;
            return new Auction()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatorId = entity.CreatorId,
                MinPrice = entity.MinPrice,
                EndingDate = entity.EndingDate,
                Type = entity.Type,
                LotId = entity.LotId,
                AvailabilityStatus = entity.AvailabilityStatus
            };
        }
        #endregion

       

        #region Feedback
        public static DalFeedback ToDalFeedback(this Feedback entity)
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

        public static Feedback ToOrmFeedback(this DalFeedback entity)
        {
            if (entity == null) return null;
            return new Feedback()
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
        public static DalRate ToDalRate(this Rate entity)
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

        public static Rate ToOrmRate(this DalRate entity)
        {
            if (entity == null) return null;
            return new Rate()
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
