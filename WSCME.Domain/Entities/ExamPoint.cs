using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSCME.Domain
{
    /// <summary>
    /// 考点
    /// </summary>
    public class ExamPoint:EntitiesBase
    {
        [Required]
        [MaxLength(50)]
        public string  Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        public Guid TrainingCentreId { get; set; }

        [ForeignKey("TrainingCentreId")]
        public TrainingCentre TrainingCentre { get; set; }

        public IEnumerable<ExamRoom> Rooms { get; set; }
    }
}
