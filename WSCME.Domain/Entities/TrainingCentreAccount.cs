using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSCME.Domain
{
    /// <summary>
    /// 培训点账号
    /// </summary>
    public class TrainingCentreAccount:IdentityBase
    {
        public string UsbKey { get; set; }
        
        public Guid TrainingCentreId { get; set; }

        public TrainingCentre TrainingCentre { get; set; }
    }
}
