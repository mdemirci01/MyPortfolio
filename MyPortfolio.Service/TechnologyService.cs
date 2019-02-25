using MyPortfolio.Data;
using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Service
{
    public interface ITechnologyService
    {
        void Insert(Technology entity);
        void Update(Technology entity);
        void Delete(Technology entity);
        void Delete(Guid id);
        Technology Find(Guid id);
        IEnumerable<Technology> GetAll();
        IEnumerable<Technology> GetAllByName(string name);
    }
    public class TechnologyService : ITechnologyService
    {

            private readonly IRepository<Technology> technologyRepository;
            private readonly IUnitOfWork unitOfWork;
            public TechnologyService(IUnitOfWork unitOfWork, IRepository<Technology> technologyRepository)
            {
                this.unitOfWork = unitOfWork;
                this.technologyRepository = technologyRepository;
            }
            public void Delete(Technology entity)
            {
                technologyRepository.Delete(entity);
                unitOfWork.SaveChanges();
            }

            public void Delete(Guid id)
            {
                var technology = technologyRepository.Find(id);
                if (technology != null)
                {
                    this.Delete(technology);
                }
            }

            public Technology Find(Guid id)
            {
                return technologyRepository.Find(id);
            }

            public IEnumerable<Technology> GetAll()
            {
                return technologyRepository.GetAll();

            }

            public IEnumerable<Technology> GetAllByName(string name)
            {
                return technologyRepository.GetAll(w => w.Name.Contains(name));
            }

            public void Insert(Technology entity)
            {
                technologyRepository.Insert(entity);
                unitOfWork.SaveChanges();
            }

            public void Update(Technology entity)
            {
                var technology = technologyRepository.Find(entity.Id);
                technology.Name = entity.Name;
                technologyRepository.Update(technology);
                unitOfWork.SaveChanges();
            }
        }

    }

