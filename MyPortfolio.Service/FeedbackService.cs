using MyPortfolio.Data;
using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Service
{
    public interface IFeedbackService
    {
        void Insert(Feedback entity);
        void Delete(Feedback entity);
        void Delete(Guid id);
        Feedback Find(Guid id);
        IEnumerable<Feedback> GetAll();
        IEnumerable<Feedback> GetAllByName(string name);
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository<Feedback> feedbackRepository;
        private readonly IUnitOfWork unitOfWork;

        public FeedbackService(IRepository<Feedback> feedbackRepository, IUnitOfWork unitOfWork)
        {
            this.feedbackRepository = feedbackRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(Feedback entity)
        {
            feedbackRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var feedback = feedbackRepository.Find(id);
            if (feedback != null)
            {
                this.Delete(feedback);
            }
        }

        public Feedback Find(Guid id)
        {
            return feedbackRepository.Find(id);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return feedbackRepository.GetAll();
        }

        public IEnumerable<Feedback> GetAllByName(string name)
        {
            return feedbackRepository.GetAll(e => e.Name.Contains(name));
        }

        public void Insert(Feedback entity)
        {
            feedbackRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }
    }
}
