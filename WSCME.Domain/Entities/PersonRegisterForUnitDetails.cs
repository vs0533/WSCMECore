using System;
namespace WSCME.Domain
{
    public class PersonRegisterForUnitDetails:EntitiesBase
    {
        public Guid PersonId { get; set; }
        public Guid PersonRegisterForUnitId { get; set; }

        public Guid ExamSubjectId { get; set; }
        public PersonRegisterForUnit PersonRegisterForUnit { get; set; }
        public Person Person { get; set; }
    }
}
