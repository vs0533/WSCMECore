using System;
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
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 场次序号
        /// </summary>
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
    }
}
