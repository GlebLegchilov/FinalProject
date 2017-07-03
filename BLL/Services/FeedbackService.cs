using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLLInterface.Entities;
using BLLInterface.Services;
using BLL.Mappers;
using DALInterface.Repository;
using System;


namespace BLL.Services
{
    public class FeedbackService : IFeedbackServise
    {

        private readonly IUnitOfWork uow;

        public FeedbackService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddFeedback(FeedbackEntity comment)
        {
            comment.CreationDate = DateTime.Now;
            uow.Feedbacks.Create(comment.ToDalFeedback());
        }

        public void DeleteFeedback(int id)
        {
            uow.Feedbacks.Delete(id);
        }

        public FeedbackEntity GetFeedback(int id)
        {
            return uow.Feedbacks.GetById(id).ToBllFeedback();
        }

        public IEnumerable<FeedbackEntity> GetFeedbacks(int target)
        {
            return uow.Feedbacks
                .GetByPredicate(f => f.TargetId == target)
                .Select(f => f.ToBllFeedback());
        }

        public void UpdateFeedback(FeedbackEntity comment)
        {
            uow.Feedbacks.Update(comment.ToDalFeedback());
        }
    }
}
