using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSCME.Domain
{
    /// <summary>
    /// 报名点
    /// </summary>
    public class RegisterPoint:EntitiesBase
    {
        [Required]
        [MaxLength(50)]
        public string  Name { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        public Guid TrainingCentreId { get; set; }

        [ForeignKey("TrainingCentreId")]
        public TrainingCentre TrainingCentre { get; set; }

        public IEnumerable<RegisterPointAccount> Accounts { get; set; }
    }
}
