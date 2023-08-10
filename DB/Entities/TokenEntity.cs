using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResiPay.DB.Entities
{

    public class TokenEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TokenCreated { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
