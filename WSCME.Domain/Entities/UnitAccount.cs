using System;
using System.ComponentModel.DataAnnotations;

namespace WSCME.Domain
{
    public class UnitAccount:EntitiesBase
    {
        public Guid UnitId { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        [Required(ErrorMessage = "账号必须填写"),StringLength(20,MinimumLength = 4,ErrorMessage = "账号长度范围是{1}-{2}")]
        public string Code { get; set; }
        public string PassWord { get; set; }

        public Unit Unit { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }

    }
}
