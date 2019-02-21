using MyPortfolio.Data;
using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Service
{

    public interface INotificationService
    {
        void Insert(Notification entity);
        IEnumerable<Notification> GetAll();
       


    }
    public class NotificationService : INotificationService
    {
        private readonly IRepository<Notification> notificationRepository;
        private readonly IUnitOfWork unitOfWork;
        public NotificationService(IUnitOfWork unitOfWork, IRepository<Notification> notificationRepository)
        {
            this.unitOfWork = unitOfWork;
            this.notificationRepository = notificationRepository;
        }
        public IEnumerable<Notification> GetAll()
        {
          //  return notificationRepository.GetAll().OrderBy(s=>s.UpdatedAt);
            return notificationRepository.GetAll().OrderByDescending (s=>s.UpdatedAt).Take(10).ToList();
        }

       

        public void Insert(Notification entity)
        {
            notificationRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }
    }
}
