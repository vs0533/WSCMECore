using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSCME.Domain
{
    /// <summary>
    /// 学员 单位人员
    /// </summary>
    public class Person:EntitiesBase
    {
        [Required(ErrorMessage = "姓名必须填写"),StringLength(20,MinimumLength = 3,ErrorMessage = "学员姓名长度必须是{2}-{1}")]
		public string Name { get; set; }
        [Required(ErrorMessage = "身份证号必须填写"),StringLength(18,MinimumLength = 18,ErrorMessage = "身份证号必须为18位")]
        public string IDCard { get; set; }
        [StringLength(5,MinimumLength = 1, ErrorMessage = "性别长度范围是{2}-{1}")]
        public string Sex { get; set; }

        public DateTime? BirthDay { get; set; }
        [MaxLength(50)]
        public string GraduationSchool { get; set; }
        public DateTime? GraduationDate { get; set; }
        [MaxLength(50)]
        public string Specialty { get; set; }
        public DateTime? WorkDate { get; set; }
        [MaxLength(50)]
        public string Office { get; set; }
        [Required(ErrorMessage = "密码必须填写"),StringLength(20,MinimumLength = 6,ErrorMessage = "密码长度范围必须在{1}-{2}")]
        public string PassWord { get; set; }
        [StringLength(11,MinimumLength = 11,ErrorMessage = "手机必须是11位")]
        public string Photo { get; set; }
        public bool PhotoIsValid { get; set; }
        [StringLength(100, ErrorMessage = "")]
        public string Email { get; set; }
        public bool EmailIsValid { get; set; }
        [StringLength(100)]
        public string Address { get; set; }

        public Guid? CurApplyTrainingCentreId { get; set; }
        public Guid? CurApplyTrainingCentreId_Servant { get; set; }

        [ForeignKey("CurApplyTrainingCentreId")]
        public TrainingCentre CurrentApplyTrainingCentre { get; set; }
        [ForeignKey("CurApplyTrainingCentreId_Servant")]
        public TrainingCentre CurrentApplyTrainingCentre_Servant { get; set; }

    }
}
