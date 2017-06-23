using System;
using System.Collections.Generic;
using System.Text;

namespace WSCME.Domain
{
    public class TrainingCentre:EntitiesBase
    {
        /// <summary>
        /// 培训点名称
        /// </summary>
        public string Name { get; set; }
        public string  Address { get; set; }
        public string  LinkMain { get; set; }
        public string Email { get; set; }

        
        public virtual TrainingCentreType Type { get; set; }
        public virtual TrainingCentreCategory Category { get; set; }
    }
}
