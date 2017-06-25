using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WSCME.Data.Infrastructure
{
    public class UnitOfWorkAsync : IUnitOfWorkAsync
    {
        private readonly CMEDbContext dataContext;
        public UnitOfWorkAsync(CMEDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Commit()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
