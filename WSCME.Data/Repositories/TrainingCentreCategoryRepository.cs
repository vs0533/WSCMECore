using System;
using System.Collections.Generic;
using System.Text;
using WSCME.Data.Infrastructure;
using WSCME.Domain;

namespace WSCME.Data
{
    public class TrainingCentreCategoryRepository:RepositoryAsync<TrainingCentreCategory>,ITrainingCentreCategoryRepository
    {
        public TrainingCentreCategoryRepository(CMEDbContext dataContext):base(dataContext)
        {

        }
    }
    public interface ITrainingCentreCategoryRepository : IRepository<TrainingCentreCategory>,IRepositoryAsync<TrainingCentreCategory>
    { }
}
