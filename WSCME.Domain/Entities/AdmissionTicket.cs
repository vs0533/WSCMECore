using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSCME.Domain
{
    /// <summary>
    /// 准考证
    /// </summary>
    public class AdmissionTicket:EntitiesBase
    {
        /// <summary>
        /// 准考证号
        /// </summary>
        /// <value>The number.</value>
        public string Number
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <value>The identifier card.</value>
        public string IdCard
        {
            get;
            set;
        }

        public Guid ExamRoomPlantId { get; set; }

        [ForeignKey("ExamRoomPlantId")]
        public ExamRoomPlant ExamRoomPlant
        {
            get;
            set;
        }
    }
}
