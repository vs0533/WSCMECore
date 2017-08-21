using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WSCME.Domain
{
    /// <summary>
    /// 考场教室信息
    /// </summary>
    public class ExamRoom:EntitiesBase
    {
        public string Code { get; set; }
        public string PassWord { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 地点 通常说明具体位置 如：二楼东侧
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Site { get; set; }

        public int Galleryful { get; set; }

        public Guid ExamPointId { get; set; }
        [ForeignKey("ExamPointId")]
        public ExamPoint ExamPoint { get; set; }

        public IEnumerable<ExamRoomPlant> Plants { get; set; }
    }
}
