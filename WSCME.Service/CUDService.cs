using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSCME.Data;
using WSCME.Domain;

namespace WSCME.Service
{
    public interface ICUDService<Entities> where Entities : EntitiesBase
    {
        void Create(Entities entity);
        void Delete(Guid Id);
        void Update(Entities entity);
        Task<Entities> GetById(Guid Id);
        Task<IPagedList<Entities>> GetPageListAsync(
            Expression<Func<Entities, bool>> predicate = null,
            int pageIndex = 0, int pageSize = 20);
        Task<IEnumerable<Entities>> GetAll();
        Task<IEnumerable<Entities>> GetListWhere(Expression<Func<Entities, bool>> where);
        Task<Entities> GetFirstOrDefault(Expression<Func<Entities, bool>> where);
    }
    public class DefaultCUDService<Entities> where Entities : EntitiesBase
    {
        private readonly IUnitOfWork<CMEDbContext> _unitOfWork;
        private readonly IRepository<Entities> _repository;
        public DefaultCUDService(IUnitOfWork<CMEDbContext> _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            this._repository = _unitOfWork.GetRepository<Entities>();
        }
        public virtual async void Create(Entities entity)
        {
            await _repository.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual void Delete(Guid Id)
        {
            _repository.Delete(Id);
            _unitOfWork.SaveChanges();
        }

        public virtual async Task<Entities> GetById(Guid Id)
        {
            var result = await _repository.FindAsync(Id);
            return result;
        }

        public virtual async void Update(Entities entity)
        {
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<IPagedList<Entities>> GetPageListAsync(
            Expression<Func<Entities, bool>> predicate = null,
            int pageIndex = 0, int pageSize = 20)
        {
            var result = await _repository.GetPagedListAsync(predicate, null, null, pageIndex, pageSize);
            return result;
        }

        public virtual async Task<IEnumerable<Entities>> GetAll()
        {
            var result = await _repository.Query(disableTracking: true).OrderByDescending(x => x.Created).ToListAsync<Entities>();
            return result;
        }

        public virtual async Task<IEnumerable<Entities>> GetListWhere(Expression<Func<Entities, bool>> where)
        {
            var result = await _repository.Query(disableTracking: false, predicate: where).OrderByDescending(x => x.Created).ToListAsync();
            return result;
        }
        public virtual async Task<Entities> GetFirstOrDefault(Expression<Func<Entities, bool>> where)
        {
            return await _repository.Query(disableTracking: false, predicate: where).OrderByDescending(x => x.Created).FirstOrDefaultAsync();
        }
    }

}
