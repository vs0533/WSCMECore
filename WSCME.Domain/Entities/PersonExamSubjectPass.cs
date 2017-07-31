using System;
namespace WSCME.Domain
{
    /// <summary>
    /// 学员科目合格情况
    /// </summary>
    public class PersonExamSubjectPass:EntitiesBase
    {
        public Guid PersonId { get; set; }

        public Guid ExamSubjectId { get; set; }

        public Guid PersonExamResultId { get; set; }

        public int SumScore { get; set; }

        public int Credit { get; set; }

        public DateTime ExamDate { get; set; }

        public Person Person { get; set; }
        public ExamSubject ExamSubject { get; set; }
        public PersonExamResult PersonExamResult { get; set; }
    }
}
