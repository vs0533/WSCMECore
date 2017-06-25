using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WSCME.Data;
using WSCME.Domain;
using Microsoft.EntityFrameworkCore;

namespace WSCME.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Init")]
    public class InitController : Controller
    {
        private readonly CMEDbContext context;
        public InitController(CMEDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<dynamic>> init()
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            await TrainingCenterCategory_();
            await TrainingCenterType_();
            await TrainingCenter_();
            //return Json(new { success = true, message = Pinyin.GetPinyin("�������") });
            var q =  context.TrainingCentre;
            return await q.ToListAsync();
        }
        private async Task TrainingCenterCategory_()
        {
            IEnumerable<TrainingCentreCategory> categorys = new List<TrainingCentreCategory>(){
                 new TrainingCentreCategory(){
                    Name = "������Ŀ",Created = DateTime.Now
                },
                 new TrainingCentreCategory(){
                    Name = "רҵЭ��",Created = DateTime.Now
                },
            };
            await context.TrainingCentreCategory.AddRangeAsync(categorys);
            await context.SaveChangesAsync();

        }
        private async Task TrainingCenterType_()
        {
            IEnumerable<TrainingCentreType> types = new List<TrainingCentreType>() {
                new TrainingCentreType{  Name = "רҵ������Ա",Created = DateTime.Now},
                new TrainingCentreType{  Name = "����Ա",Created = DateTime.Now},
            };

            await context.TrainingCentreType.AddRangeAsync(types);
            await context.SaveChangesAsync();
        }
        private async Task TrainingCenter_()
        {
            var categorys = context.TrainingCentreCategory.SingleOrDefault(c => c.Name == "������Ŀ");
            var types = context.TrainingCentreType.SingleOrDefault(c => c.Name == "רҵ������Ա");
            IEnumerable<TrainingCentre> tc = new List<TrainingCentre>() {
                new TrainingCentre{  Name = "��ֱ�������������Ͳ���������ѵ����", Email="test@wskj.com",Created = DateTime.Now,
                    Categorys = new List<TrainingCentreAndCategory>{
                        new TrainingCentreAndCategory{  Category = categorys }
                    },
                    Types = new List<TrainingCentreAndType>{
                        new TrainingCentreAndType{ Type= types}
                    }
                    ,
                    //Accounts = new List<TrainingCentreAccount>{
                    //    new TrainingCentreAccount{ Name = "SZJXJYZBRSPXZX", PassWordHash = }
                    //}
                }
            };
            await context.TrainingCentre.AddRangeAsync(tc);
            await context.SaveChangesAsync();
        }
    }
}