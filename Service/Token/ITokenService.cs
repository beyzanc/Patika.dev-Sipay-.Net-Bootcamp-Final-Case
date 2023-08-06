namespace ResiPay.Service.Token;

public interface ITokenService
{
    public string GenerateToken(ResiPay.DB.Entities.User user);
    public int? ValidateToken(string token);


}
