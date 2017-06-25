using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WSCME.Data.Infrastructure
{
    public interface IUnitOfWorkAsync
    {
        Task Commit();
    }
}
