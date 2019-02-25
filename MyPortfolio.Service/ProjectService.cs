using MyPortfolio.Data;
using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Service
{
    public interface IProjectService
    {
        void Insert(Project entity);
        void Update(Project entity);
        void Delete(Project entity);
        void Delete(Guid id);
        Project Find(Guid id);
        IEnumerable<Project> GetAll();
        IEnumerable<Project> GetAllByName(string name);
    }
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork, IRepository<Project> projectRepository)
        {
            this.unitOfWork = unitOfWork;
            this.projectRepository = projectRepository;
        }
        public void Delete(Project entity)
        {
            projectRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var project = projectRepository.Find(id);
            if (project != null)
            {
                this.Delete(project);
            }
        }

        public Project Find(Guid id)
        {
            return projectRepository.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return projectRepository.GetAll();

        }

        public IEnumerable<Project> GetAllByName(string name)
        {
            return projectRepository.GetAll(w => w.Name.Contains(name));
        }

        public void Insert(Project entity)
        {
            projectRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public void Update(Project entity)
        {
            var project = projectRepository.Find(entity.Id);
            project.Name = entity.Name;
            project.Description = entity.Description;
            projectRepository.Update(project);
            unitOfWork.SaveChanges();
        }
    }

}
