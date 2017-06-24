using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WSCME.Domain
{
    public class TrainingCentre:EntitiesBase
    {
        /// <summary>
        /// 培训点名称
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        public string  Address { get; set; }
        [MaxLength(20)]
        public string  LinkMain { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage ="")]
        public string Email { get; set; }
        

        public IEnumerable<TrainingCentreAccount> Accounts { get; set; }

        public IEnumerable<TrainingCentreAndCategory> Categorys { get; set; }
        public IEnumerable<TrainingCentreAndType> Types { get; set; }
    }
}
