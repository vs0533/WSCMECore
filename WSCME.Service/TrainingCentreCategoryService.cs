using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSCME.Data;
using WSCME.Data.Infrastructure;
using WSCME.Domain;

namespace WSCME.Service
{
    public interface ITrainingCentreCategoryService
    {
        Task<IEnumerable<TrainingCentreCategory>> Get();
        Task<TrainingCentreCategory> Get(Guid id);
        void Create(TrainingCentreCategory category);
        void Delete(Guid id);
        void Save();
    }
    public class TrainingCentreCategoryService : ITrainingCentreCategoryService
    {
        private readonly ITrainingCentreCategoryRepository trainingCentreRepository = null;
        private readonly IUnitOfWorkAsync unitOfWork = null;
        public TrainingCentreCategoryService(
            IUnitOfWorkAsync unitOfWork,
            ITrainingCentreCategoryRepository trainingCentreRepository)
        {

        }
        public void Create(TrainingCentreCategory category)
        {
            trainingCentreRepository.AddAsync(category);
            Save();
        }

        public void Delete(Guid id)
        {
            trainingCentreRepository.Delete(c => c.Id == id);
            Save();
        }

        public async Task<IEnumerable<TrainingCentreCategory>> Get()
        {
            return await trainingCentreRepository.GetAllAsync();
        }

        public async Task<TrainingCentreCategory> Get(Guid id)
        {
            return await trainingCentreRepository.GetByIdAsync(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}
