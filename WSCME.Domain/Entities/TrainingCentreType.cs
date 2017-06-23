using System.Collections.Generic;

namespace WSCME.Domain
{
    /// <summary>
    /// 培训点类型
    /// 标识一个培训点是【专业技术人员】【公务员】或者两者都是
    /// </summary>
    public class TrainingCentreType:EntitiesBase
    {
        public string Name { get; set; }
        public int Desc { get; set; }

        public virtual ICollection<TrainingCentre> TrainingCentre { get; set; }
    }
}