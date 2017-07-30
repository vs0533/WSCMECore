using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSCME.Data;
using WSCME.Domain;

namespace WSCME.Service
{
    public interface ITESTLibraryCategoryServices
    {
        Task<IEnumerable<TESTLibraryCategory>> Get();
        Task<TESTLibrary> Get(Guid id);
        void Create(TESTLibraryCategory category);
        void Delete(Guid id);
        void Save();
    }
    public class TESTLibraryCategoryService : ITESTLibraryCategoryServices
    {
        private readonly IUnitOfWork<CMEExamDbContext> examUnitOfWork;
        public TESTLibraryCategoryService(IUnitOfWork<CMEExamDbContext> examUnitOfWork)
        {
            this.examUnitOfWork = examUnitOfWork;
        }
        public async void Create(TESTLibraryCategory category)
        {
            var repository = examUnitOfWork.GetRepository<TESTLibraryCategory>();
            await repository.InsertAsync(category);
            await examUnitOfWork.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TESTLibraryCategory>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TESTLibrary> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
