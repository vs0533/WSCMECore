﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WSCME.Domain
{
    /// <summary>
    /// 学员报名表
    /// </summary>
    public class PersonRegister:EntitiesBase
    {
        public Guid PersonId { get; set; }
        public Guid ExamSubjectId { get; set; }
        public Guid TrainingCentreId { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public Person Person { get; set; }
        public ExamSubject ExamSubject { get; set; }
        public TrainingCentre TrainingCentre { get; set; }


    }
}
