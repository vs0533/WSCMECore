using System;
using System.Collections.Generic;
using WSCME.Domain.Enum;

namespace WSCME.Domain
{
    /// <summary>
    /// 科目设置
    /// </summary>
    public class ExamSubject:EntitiesBase
    {
        public string Name { get; set; }
        public ExamSubjectType Type { get; set; }
        public int Credit { get; set; }

        public DateTime? TrainDate { get; set; }
        public DateTime? ApplyStartDate { get; set; }
        public DateTime? ApplyEndDate { get; set; }
        public DateTime? KSDate { get; set; }

        public decimal ApplyCost { get; set; }
        public decimal ExamCost { get; set; }

        public int PassingScore { get; set; }


        public Guid TrainingCenterId { get; set; }

        public TrainingCentre TrainingCentre { get; set; }

        public IEnumerable<ExamSubjectAndProfessionalTitleCategory> ProfessionalTitleCategorys { get; set; }

    }
}
