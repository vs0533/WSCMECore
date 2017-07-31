using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WSCME.Data;
using WSCME.Domain;
using WSCME.Service;
using Xunit;

namespace WSCME.TestX
{
    public class UnitServiceTest
    {
        private readonly ServiceCollection _serviceCollection;
        public UnitServiceTest()
        {
			_serviceCollection = new ServiceCollection();
			_serviceCollection.AddDbContext<CMEDbContext>(
			  options =>
			  {
			      options.UseSqlServer("server=192.168.4.107;uid=sa;pwd=Abc@123;database=CMEDB");
			  }
			);

			_serviceCollection.AddUnitOfWork<CMEDbContext>();
			_serviceCollection.AddScoped<IUnitServices, UnitServices>();
		}
        [Fact]
        public void CreateUnit()
        {
			IServiceProvider provider = _serviceCollection.BuildServiceProvider();
			var unitservices = provider.GetService<IUnitServices>();
			var ctx = provider.GetService<CMEDbContext>();

			var unitNature = new UnitNature()
			{
			  Name = "机关单位"
			};
			var unitAccount = new UnitAccount()
			{
			  Name = "卢瑞生",
			  Code = "luruisheng",
			  PassWord = "111111"
			};

			var unit = new Unit()
			{
			  Name = "淄博市人力资源和社会保障局",
			  Code = "370303",
			  UnitType = Domain.Enum.UnitType.Administrator,
			  UnitNature = unitNature,
			  Accounts = new List<UnitAccount>() { unitAccount }
			};

			unitservices.Create(unit);

			Debug.WriteLine("success");
		}
    }
}
