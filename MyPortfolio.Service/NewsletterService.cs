using MyPortfolio.Data;
using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Service
{
    public interface INewsletterService
    {
        void Insert(Newsletter entity);
        void Update(Newsletter entity);
        void Delete(Newsletter entity);
        void Delete(Guid id);
        Newsletter Find(Guid id);
        IEnumerable<Newsletter> GetAll();
        IEnumerable<Newsletter> GetAllByEmail(string partOfEmail);
    }
    public class NewsletterService : INewsletterService
    {
        private readonly IRepository<Newsletter> newsletterRepository;
        private readonly IUnitOfWork unitOfWork;
        public NewsletterService(IUnitOfWork unitOfWork, IRepository<Newsletter> newsletterRepository)
        {
            this.unitOfWork = unitOfWork;
            this.newsletterRepository = newsletterRepository;
        }
        public void Delete(Newsletter entity)
        {
            newsletterRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var newsletter = newsletterRepository.Find(id);
            if (newsletter != null)
            {
                this.Delete(newsletter);
            }
        }

        public Newsletter Find(Guid id)
        {
            return newsletterRepository.Find(id);
        }

        public IEnumerable<Newsletter> GetAll()
        {
            return newsletterRepository.GetAll();
        }

        public IEnumerable<Newsletter> GetAllByEmail(string partOfEmail)
        {
            return newsletterRepository.GetAll(w=>w.Email.Contains(partOfEmail));
        }

        public void Insert(Newsletter entity)
        {
            newsletterRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public void Update(Newsletter entity)
        {
            var newsletter = newsletterRepository.Find(entity.Id);
            newsletter.FullName = entity.FullName;
            newsletter.Email = entity.Email;
            newsletter.IsActive = entity.IsActive;
            newsletterRepository.Update(newsletter);
            unitOfWork.SaveChanges();
        }
    }
}
