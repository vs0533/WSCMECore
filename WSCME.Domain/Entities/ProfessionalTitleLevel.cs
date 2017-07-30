using System;
using System.Collections.Generic;

namespace WSCME.Domain
{
    public class ProfessionalTitleLevel:EntitiesBase
    {
        public string Name { get; set; }

        public IEnumerable<ProfessionalTitle> ProfessionalTitles { get; set; }


    }
}
