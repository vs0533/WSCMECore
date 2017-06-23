using System;
using System.Collections.Generic;
using System.Text;

namespace WSCME.Domain
{
    public abstract class EntitiesBase
    {
        public string  Id { get; set; }

        public DateTime Created { get; set; }
    }
}
