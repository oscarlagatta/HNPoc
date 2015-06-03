using System;
using System.Runtime.Serialization;
using Core.Common.Core;
using Core.Common.Contracts;


namespace HN.Wow.Business.Entities
{
    public class Product : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal Cost { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public DateTime IntroductionDate { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public bool IsDiscontinued { get; set; }

        public int EntityId
        {
            get { return ProductId; }
            set { ProductId = value; }
        }

        [DataMember]
        public int Stock { get; set; }
    }
}
