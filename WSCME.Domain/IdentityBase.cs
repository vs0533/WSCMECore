using System;
using System.Collections.Generic;
using System.Text;

namespace WSCME.Domain
{
    public abstract class IdentityBase:EntitiesBase
    {
        public string Name { get; set; }
        public string PassWordHash { get; set; }

    }
}
