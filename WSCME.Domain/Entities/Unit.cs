using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WSCME.Domain.Enum;

namespace WSCME.Domain
{
    /// <summary>
    /// 单位信息
    /// </summary>
    public class Unit:EntitiesBase
    {
        [
            Required(ErrorMessage = "单位代码必须填写"),
            StringLength(15,MinimumLength = 3,ErrorMessage = "单位代码长度范围是{1}-{2}")
        ]
        public string Code { get; set; }
        [Required(ErrorMessage = "单位名称必须填写")]
        public string Name { get; set; }

        public UnitType UnitType { get; set; }
        [StringLength(50)]
        public string LinkMan { get; set; }
        [StringLength(20)]
        public string LinkPhoto { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Address { get; set; }

        public Guid? PID { get; set; }

        public Guid UnitNatureId { get; set; }


        public Unit Parent { get; set; }

        public IEnumerable<Unit> Childs { get; set; }
        public UnitNature UnitNature { get; set; }
        public IEnumerable<PersonRegisterForUnit> PersonRegisterForUnit { get; set; }
        public IEnumerable<UnitAccount> Accounts { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }


    }
}
