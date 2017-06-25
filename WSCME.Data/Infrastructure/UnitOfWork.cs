using System;
using System.Collections.Generic;
using System.Text;

namespace WSCME.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMEDbContext dataContext;
        public UnitOfWork(CMEDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Commit()
        {
            dataContext.Commit();
        }
    }
}
