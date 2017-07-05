using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSCME.Domain
{
    /// <summary>
    /// 报名点账号
    /// </summary>
    public class RegisterPointAccount:IdentityBase
    {
        [MaxLength(200)]
        public string  UsbKey { get; set; }

        public Guid RegisterPointId { get; set; }
        [ForeignKey("RegisterPointId")]
        public RegisterPoint RegisterPoint { get; set; }
    }
}
