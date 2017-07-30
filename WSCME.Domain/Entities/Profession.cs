using System;
using System.Collections.Generic;

namespace WSCME.Domain
{
    /// <summary>
    /// 职称的专业
    /// </summary>
    public class Profession:EntitiesBase
    {
        public string Name { get; set; }
        public IEnumerable<ProfessionalTitle> ProfessionalTitles { get; set; }

    }
}
