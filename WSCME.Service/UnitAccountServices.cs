using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WSCME.Data;
using WSCME.Domain;

namespace WSCME.Service
{
    public interface IUnitAccountServices:ICUDService<UnitAccount>
    {
    }
    public class UnitAccountServices : DefaultCUDService<UnitAccount>, IUnitAccountServices
    {
        public UnitAccountServices(IUnitOfWork<CMEDbContext> _unitOfWork):base(_unitOfWork)
        {

        }
    }
}
