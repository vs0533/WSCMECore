using System;
namespace WSCME.Domain
{
    /// <summary>
    /// 专业技术职务系列开设科目情况
    /// </summary>
    public class ExamSubjectAndProfessionalTitleCategory:EntitiesBase
    {
        public Guid ExamSubjectId { get; set; }
        public Guid ProfessionalTitleId { get; set; }

        public ExamSubject ExamSubject { get; set; }
        public ProfessionalTitleCategory ProfessionalTitleCategory { get; set; }
    }
}
