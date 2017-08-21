using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSCME.Data;
using WSCME.Domain;

namespace WSCME.Service
{
    public interface IUnitServices:ICUDService<Unit>
    {
        Task<UnitAccount> GetAccount(string username,string password);
    }
    public class UnitServices : DefaultCUDService<Unit>, IUnitServices
    {
        private readonly IUnitOfWork<CMEDbContext> _unitOfWork;
        public UnitServices(IUnitOfWork<CMEDbContext> _unitOfWork) : base(_unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public async Task<UnitAccount> GetAccount(string username, string password)
        {
            var unitaccount = _unitOfWork.GetRepository<UnitAccount>();
            var query = await unitaccount.Query(c => c.Name == username && c.PassWord == password).FirstOrDefaultAsync();
            return query;
        }
    }
}
