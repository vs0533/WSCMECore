using System;
using System.Collections.Generic;
using WSCME.Data.Infrastructure;
using WSCME.Domain;
using System.Linq;

namespace WSCME.Data
{
    public class TESTLibraryRepository:RepositoryAsync<TESTLibrary>
    {
        public TESTLibraryRepository(CMEDbContext dataContext):base(dataContext)
        {
        }

        //public IEnumerable<TESTLibrary> GetPage(){
        //    base.dataContext.TESTLibrary.Where(c => c.Id == new Guid("1"));
        //}
    }
	public interface ITESTLibraryRepository : IRepository<TESTLibrary>, IRepositoryAsync<TESTLibrary>
	{ }
}