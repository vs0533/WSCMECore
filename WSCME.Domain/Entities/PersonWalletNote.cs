using System;
using WSCME.Domain.Enum;

namespace WSCME.Domain
{
    public class PersonWalletNote:EntitiesBase
    {
        public Guid PersonId { get; set; }
        public decimal Cost { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        /// <value>The cause.</value>
        public string Cause { get; set; }
        public WalletNoteType Type { get; set; }
    }
}
