using System;
using System.ComponentModel.DataAnnotations;

namespace WSCME.Domain
{
    /// <summary>
    /// 学员考试结果
    /// </summary>
    public class PersonExamResult:EntitiesBase
    {
        public Guid PersonId { get; set; }

        public Guid AdmissionTicketId { get; set; }
        public Guid ExamSubjectId { get; set; }
        public Guid ExamRoomPlantId { get; set; }
        [Required]
        public int Score { get; set; }
        public DateTime? ExamDate { get; set; }

        public bool IsToPass { get; set; }

        public Person Person { get; set; }
        public AdmissionTicket AdmissionTicket { get; set; }
        public ExamSubject ExamSubject { get; set; }
        public ExamRoomPlant ExamRoomPlant { get; set; }

        public PersonExamSubjectPass ExamSubjectPass { get; set; }

    }
}
