using System;

namespace ResiPay.Model.User
{
    public class UserLoginResponseModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int ApartmentId { get; set; }
        public bool AuthenticateResult { get; set; }
        public bool IsAdmin { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }

    }
}

