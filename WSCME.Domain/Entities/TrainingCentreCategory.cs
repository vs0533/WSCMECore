namespace WSCME.Domain
{
    /// <summary>
    /// 培训点分类
    /// 标识一个培训点属于【公共科目培训】【专业协会】或者两者都是
    /// </summary>
    public class TrainingCentreCategory:EntitiesBase
    {
        public string Name { get; set; }
    }
}