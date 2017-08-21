using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WSCME.Domain.Enum;

namespace WSCME.Domain
{
    /// <summary>
    /// 考场考试计划 场次设置
    /// </summary>
    public class ExamRoomPlant:EntitiesBase
    {
        public DateTime BeginTime { get; set; }
        public int LengthTime { get; set; }
        /// <summary>
        /// 场次序号
        /// </summary>
        [Required(ErrorMessage =  "场次序号必须填写")]
        [StringLength(8,MinimumLength = 8,ErrorMessage = "场次序号必须是8位结构为两位年+四位科目ID+两位顺序号")]
        public string Number { get; set; }

        public DateTime SelectTime { get; set; }
        public DateTime OverSelectTime { get; set; }
        /// <summary>
        /// 预先多少分钟开始进场 签到 考试
        /// </summary>
        public short HowLongBefore { get; set; }
        /// <summary>
        /// 场次结束时间
        /// </summary>
        public DateTime OverTime { get; set; }
        public ExamRoomPlantState State { get; set; }

        public Guid ExamRoomId { get; set; }

        [ForeignKey("ExamRoomId")]
        public ExamRoom ExamRoom { get; set; }

        public IEnumerable<PersonExamResult> PersonExamResult { get; set; }

        public Guid ExamPointId { get; set; }

        public ExamPoint ExamPoint { get; set; }

    }
}
