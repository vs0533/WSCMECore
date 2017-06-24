using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WSCME.Domain
{
    public class TrainingCentreAndType:EntitiesBase
    {
        public Guid TrainingCentreId { get; set; }
        public Guid TrainingCentreTypeId { get; set; }
        
        public TrainingCentre TrainingCentre { get; set; }

        public TrainingCentreType Type { get; set; }
    }
}
