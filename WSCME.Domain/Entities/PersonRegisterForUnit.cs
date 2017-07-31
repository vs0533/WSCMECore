using System;
using System.Collections.Generic;

namespace WSCME.Domain
{
    /// <summary>
    /// 单位报名表
    /// </summary>
    public class PersonRegisterForUnit:EntitiesBase
    {
        
        public string Number { get; set; }
        public Decimal Cost { get; set; }

        public Guid UnitId { get; set; }


        public Guid Token { get; set; }

        public bool IsPay { get; set; }

        public Unit Unit { get; set; }
        public IEnumerable<PersonRegisterForUnitDetails> Details { get; set; }

    }
}
