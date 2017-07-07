using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSCME.Data;
using WSCME.Data.Infrastructure;
using WSCME.Domain;

namespace WSCME.Service
{
	public interface ITESTLibraryServices
	{
		Task<IEnumerable<TESTLibrary>> Get();
		Task<TESTLibrary> Get(Guid id);
		void Create(TESTLibrary category);
		void Delete(Guid id);
		void Save();
	}
    public class TESTLibraryServices : ITESTLibraryServices
    {
		private readonly ITESTLibraryRepository testLibraryRepository = null;
		private readonly IUnitOfWorkAsync unitOfWork = null;
        public async void Create(TESTLibrary testLibrary)
        {
            await testLibraryRepository.AddAsync(testLibrary);
            Save();
        }

        public void Delete(Guid id)
        {
            testLibraryRepository.Delete(c=>c.Id == id);
            Save();
        }

        public Task<IEnumerable<TESTLibrary>> Get()
        {
            
            testLibraryRepository.GetAll();
        }

        public Task<TESTLibrary> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async void Save()
        {
            await unitOfWork.Commit();
        }
    }
}
