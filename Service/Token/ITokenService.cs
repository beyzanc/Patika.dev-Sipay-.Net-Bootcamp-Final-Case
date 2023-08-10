using ResiPay.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResiPay.Service.Token
{
    public interface ITokenService
    {
        public TokenResponseModel GenerateToken(TokenRequestModel request);

    }
}
