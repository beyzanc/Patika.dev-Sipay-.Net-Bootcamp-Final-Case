using ResiPay.Model.BaseModel;
using ResiPay.Model.User;

namespace ResiPay.Service.User
{
    public interface IUserService
    {
        public Base<UserViewModel> GetAllUsers();
        public Base<UserViewModel> GetById(int id);
        public Base<UserViewModel> Delete(int id);
        public Base<UserViewModel> Insert(UserInsertModel newInsert);
        public Base<UserViewModel> Update(UserInsertModel user, int id);
        
    }
}