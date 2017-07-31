using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSCME.Data;
using WSCME.Domain;

namespace WSCME.Service
{
    public interface IUnitServices:ICUDService<Unit>
    {
        
    }
    public class UnitServices : DefaultCUDService<Unit>, IUnitServices
    {
        public UnitServices(IUnitOfWork<CMEDbContext> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
