using System;
using System.Collections.Generic;
using System.Text;

namespace WSCME.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
