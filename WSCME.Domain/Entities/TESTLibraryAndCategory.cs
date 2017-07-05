using System;
namespace WSCME.Domain
{
    public class TESTLibraryAndCategory:EntitiesBase
    {
        public Guid TESTLibraryId { get; set; }
        public Guid TESTLibraryCategoryId { get; set; }

        public TESTLibrary TESTLibrary { get; set; }
        public TESTLibraryCategory Category { get; set; }
    }
}

