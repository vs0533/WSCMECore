using System;
using System.Collections.Generic;
using System.Text;

namespace WSCME.Domain
{
    public class TrainingCentreAndCategory:EntitiesBase
    {
        public Guid TrainingCentreId { get; set; }
        public Guid TrainingCentreCategoryId { get; set; }

        public TrainingCentre TrainingCentre { get; set; }
        public TrainingCentreCategory Category { get; set; }

    }
}
