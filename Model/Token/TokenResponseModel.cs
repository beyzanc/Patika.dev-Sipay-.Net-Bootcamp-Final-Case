using System;

namespace ResiPay.Model.Token
{
    public class TokenResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
