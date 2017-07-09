using System;
using System.Collections.Generic;
using WSCME.Data.Infrastructure;
using WSCME.Domain;
using System.Linq;

namespace WSCME.Data
{
    public class TESTLibraryRepository:RepositoryAsync<TESTLibrary>,ITESTLibraryRepository
    {
        public TESTLibraryRepository(CMEDbContext dataContext):base(dataContext)
        {
        }

        //public IEnumerable<TESTLibrary> GetPage(){
        //    base.dataContext.TESTLibrary.
        //}
    }
	public interface ITESTLibraryRepository : IRepository<TESTLibrary>, IRepositoryAsync<TESTLibrary>
	{ }
}