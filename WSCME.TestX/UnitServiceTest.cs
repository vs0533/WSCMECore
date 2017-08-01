using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WSCME.Data;
using WSCME.Domain;
using WSCME.Service;
using Xunit;
using System.Linq;

namespace WSCME.TestX
{
    public class UnitServiceTest
    {
        private readonly ServiceCollection _serviceCollection;
        private readonly IServiceProvider provider;
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

            this.provider = _serviceCollection.BuildServiceProvider();
		}
        private void ResetDB()
        {
            var ctx = provider.GetService<CMEDbContext>();

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }
        [Fact]
        public void CreateUnit()
        {
            var _unitService = provider.GetService<IUnitServices>();
            ResetDB();
            Create(_unitService);

        }

        private void Create(IUnitServices unitservice)
        {
            var _unitService = provider.GetService<IUnitServices>();
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

            unitservice.Create(unit);
        }
        [Fact]
        public async void UpdateUnit()
        {
            var _unitService = provider.GetService<IUnitServices>();
            ResetDB();
            Create(_unitService);
            var result = await _unitService.GetWhere(x => x.Code == "370303");
            Assert.NotEqual(result.Count(), 0);
            var update = result.First();
            update.Code = "update";
            _unitService.Update(update);

            var valid = await _unitService.GetWhere(x => x.Code == "update");
            Assert.NotEqual(valid.Count(), 0);
        }
        [Fact]
        public async void DeleteUnit()
        {
            var _unitService = provider.GetService<IUnitServices>();
            ResetDB();
            Create(_unitService);
            var result = await _unitService.GetAll();
            foreach (var item in result)
            {
                _unitService.Delete(item.Id);
            }
        }
    }
}
