using System;
namespace WSCME.Domain
{
    /// <summary>
    /// 学员充值钱包
    /// </summary>
    public class PersonWallet:EntitiesBase
    {
        public Guid PersonId { get; set; }
        public decimal Balance { get; set; }

        public Person Person { get; set; }

    }
}
