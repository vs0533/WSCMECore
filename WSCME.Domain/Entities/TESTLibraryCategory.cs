using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSCME.Domain
{
    /// <summary>
    /// 题库分类
    /// </summary>
    public class TESTLibraryCategory:EntitiesBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Guid PID { get; set; }

        public TESTLibraryCategory Category { get; set; }
        public IEnumerable<TESTLibraryCategory> Childs { get; set; }

        public IEnumerator<TESTLibrary> TESTLibrarys { get; set; }
    }
}
