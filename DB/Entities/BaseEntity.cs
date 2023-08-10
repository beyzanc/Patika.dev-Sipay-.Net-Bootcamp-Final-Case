using System;

namespace ResiPay.DB.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set;}

    }
}


