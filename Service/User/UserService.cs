using AutoMapper;
using ResiPay.DB;
using ResiPay.Model.BaseModel;
using ResiPay.Model.User;
using ResiPay.Service.Validations.User;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ResiPay.Service.Token;
using ResiPay.Service.Helpers;
using PasswordGenerator;


namespace ResiPay.Service.User
{
    public class UserService : IUserService
    {

        private readonly IMapper mapper;
        private readonly UserInsertValidator validator;
        private readonly UserLoginRequestValidator loginValidator;
        private readonly ResiPayDbContext dbContext;
        private readonly ITokenService tokenService;

        public UserService(IMapper _mapper, UserInsertValidator _validator, UserLoginRequestValidator _loginValidator, ResiPayDbContext dbContext, ITokenService tokenService)
        {
            this.mapper = _mapper;
            this.validator = _validator;
            this.loginValidator = _loginValidator;
            this.dbContext = dbContext;
            this.tokenService = tokenService;
        }

        public Base<UserViewModel> GetAllUsers()
        {
            var result = new Base<UserViewModel>();

            var data = dbContext.User
                .Where(user => user.IsActive && !user.IsDelete)
                .OrderBy(user => user.Id)
                .ToList();

            if (data.Any())
            {
                result.IsSuccess = true;
                result.TotalCount = data.Count();
                result.OkMessage = "All users are listed.";
                result.List = mapper.Map<List<UserViewModel>>(data);

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No users found.";

            }
            dbContext.SaveChanges();
            return result;
        }


        public Base<UserViewModel> GetById (int id)
        {
            var result = new Base<UserViewModel>();

            var data = dbContext.User.SingleOrDefault(user => user.Id == id);

            if (data is null)
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "User not found with given ID.";
                return result;
            }

            result.Entity = mapper.Map<UserViewModel>(data);

            dbContext.SaveChanges();

            return result;
        }


        public Base<UserViewModel> Delete(int id)
        {
            var result = new Base<UserViewModel>();

            var data = dbContext.User.SingleOrDefault(user => user.Id == id);

            if (data is null)
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "User not found.";
            }
            
            else
            {
                data.IsDelete = true;
                data.IsActive = false;
                dbContext.User.Remove(data);
                dbContext.SaveChanges();

                result.Entity = mapper.Map<UserViewModel>(data);
                result.IsSuccess = true;
                result.OkMessage = "User deleted successfully.";
            }

            return result;

        }

        public Base<UserViewModel> Insert(UserInsertModel newInsert)
        {

            var result = new Base<UserViewModel>();

            var valid = validator.Validate(newInsert);

            if(!valid.IsValid)
            {
                result.IsSuccess = false;
                result.ExceptionMessage = string.Join(", ", valid.Errors);
                return result;
            }

            if(newInsert.ApartmentId.HasValue && dbContext.Apartment.FirstOrDefault(a => a.Id == newInsert.ApartmentId.Value) == null)
            {
                result.IsSuccess=false;
                result.ExceptionMessage = "The entered apartment does not exist in the system.";
                return result;
            }

            if(dbContext.User.Any(u => u.IdentityNumber == newInsert.IdentityNumber))
            {
                result.IsSuccess=false;
                result.ExceptionMessage = "User is already exist.";
                return result;
            }

            else
            {
                var user = mapper.Map<ResiPay.DB.Entities.User>(newInsert);

                user.IsActive = true;
                user.IsDelete = false;
                user.InsertDate = DateTime.Now;
                user.IsAdmin = newInsert.IsAdmin;


                var newPassword = new Password().IncludeLowercase().IncludeUppercase().LengthRequired(8);
                string password = newPassword.Next();
                result.OkMessage = "User successfully created. Password for user: " + password;
                user.Password = Hasher.GetHash(password);


                dbContext.User.Add(user);

                if (newInsert.ApartmentId.HasValue)
                {
                    var apartment = dbContext.Apartment.SingleOrDefault(a => a.Id == newInsert.ApartmentId);
                    if (apartment != null)
                    {
                        apartment.Users.Add(user);
                        apartment.IsFull = true;
                    }
                }

                dbContext.SaveChanges();

                var insertedUser = mapper.Map<UserViewModel>(user);

                result.IsSuccess = true;
                result.Entity = insertedUser;

            }

            return result;

        }

        public Base<UserViewModel> Update (UserInsertModel user, int id)
        {
            var result = new Base<UserViewModel>();

            var updateUser = dbContext.User.SingleOrDefault(u => u.Id == id);

            if (updateUser is not null)
            {
                updateUser.Name = user.Name;
                updateUser.Surname = user.Surname;
                updateUser.Email = user.Email;
                updateUser.PhoneNumber = user.PhoneNumber;
                updateUser.ApartmentId = (int)user.ApartmentId;
                
                var oldApartmentId = updateUser.ApartmentId;

                if (user.ApartmentId.HasValue)
                {
                    var oldApartment = dbContext.Apartment.SingleOrDefault(a => a.Id == oldApartmentId);
                    if (oldApartment != null)
                    {
                        oldApartment.IsFull = false;
                        dbContext.SaveChanges();

                    }

                    var newApartment = dbContext.Apartment.SingleOrDefault(a => a.Id == user.ApartmentId.Value);
                    if (newApartment != null)
                    {
                        newApartment.Users.Add(updateUser);
                        newApartment.IsFull = true;
                    }
                }

                dbContext.SaveChanges();
                
                result.Entity = mapper.Map<UserViewModel>(updateUser);
                result.IsSuccess = true;
                result.OkMessage = "User is updated.";

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "User not found with given ID.";

            }

            return result;
        }


        public Base<UserLoginResponseModel> Login (UserLoginRequestModel user)
        {

            var result = new Base<UserLoginResponseModel>();

            var data = dbContext.User.SingleOrDefault(u => u.Email == user.Email);
            if (data is null || Hasher.GetHash(user.Password) != data.Password)
            {
                result.ExceptionMessage = "Username or password is incorrect.";
                result.IsSuccess = false;
                return result;

            }

            result.IsSuccess = true;
            result.Entity = mapper.Map<UserLoginResponseModel>(data);
            result.Entity.AuthToken = tokenService.GenerateToken(data);

            return result;

        }


    }
}
