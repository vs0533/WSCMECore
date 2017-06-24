using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSCME.Domain
{
    /// <summary>
    /// 培训点/报名点账号
    /// </summary>
    public class TrainingCentreAccount:EntitiesBase
    {
        public string Name { get; set; }
        public string PassWordHash { get; set; }
        /// <summary>
        /// 报名点名称 如果为NULL 说明该账号只是一个培训点账号
        /// </summary>
        public string ApplyName { get; set; }
        public string UsbKey { get; set; }
        
        public Guid TrainingCentreId { get; set; }

        public TrainingCentre TrainingCentre { get; set; }
    }
}
