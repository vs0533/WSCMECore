using System.Collections.Generic;
using WSCME.Domain.Enum;

namespace WSCME.Domain
{
    public class TESTLibrary:EntitiesBase
    {
        public string Stem { get; set; }
        public string SelectItem { get; set; }
        public string Answer { get; set; }
        public TESTType Type { get; set; }

        public IEnumerable<TESTLibraryAndCategory> Categorys { get; set; }
    }
}
