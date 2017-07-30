using System;
using System.Collections.Generic;

namespace WSCME.Domain
{
    /// <summary>
    /// 职称系列 如 卫生系列 、工程系列 等...
    /// </summary>
    public class ProfessionalTitleCategory:EntitiesBase
    {
        public string Name { get; set; }
        public IEnumerable<ExamSubjectAndProfessionalTitleCategory> ExamSubjects { get; set; }

        public IEnumerable<ProfessionalTitle> ProfessionalTitles { get; set; }
    }
}
