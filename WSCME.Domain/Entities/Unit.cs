using System;
using System.Collections.Generic;

namespace WSCME.Domain.Entities
{
    /// <summary>
    /// 单位信息
    /// </summary>
    public class Unit:EntitiesBase
    {
        public string Name { get; set; }

        public Guid PID { get; set; }

        public Unit Parent { get; set; }

        public IEnumerable<Unit> Childs { get; set; }
    }
}
