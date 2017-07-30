using System;
namespace WSCME.Domain
{
    /// <summary>
    /// 专业技术职称
    /// </summary>
    public class ProfessionalTitle:EntitiesBase
    {
        public string Name { get; set; }

        public Guid ProfessionalTitleCategoryId { get; set; }
        public Guid ProfessionalTitleLevelId { get; set; }
        public Guid ProfessionId { get; set; }


        public ProfessionalTitleCategory Categorys { get; set; }
        public ProfessionalTitleLevel Levels { get; set; }
        public Profession Professions { get; set; }
    }
}