using System;
using System.ComponentModel.DataAnnotations;

namespace WSCME.Domain
{
    /// <summary>
    /// 单位类型  机关单位、事业单位、企业、等...
    /// </summary>
    public class UnitNature:EntitiesBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
