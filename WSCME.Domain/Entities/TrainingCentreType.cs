using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSCME.Domain
{
    /// <summary>
    /// 培训点类型
    /// 标识一个培训点是【专业技术人员】【公务员】或者两者都是
    /// </summary>
    public class TrainingCentreType:EntitiesBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Desc { get; set; }
        
        public IEnumerable<TrainingCentreAndType> TrainingCentreAndTypes { get; set; }
    }
}