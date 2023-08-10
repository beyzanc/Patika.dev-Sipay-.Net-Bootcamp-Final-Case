using AutoMapper;
using ResiPay.DB.Entities;
using ResiPay.Model.Apartment;
using ResiPay.Model.BaseModel;
using ResiPay.Model.Bill;
using ResiPay.Model.Card;
using ResiPay.Model.Message;
using ResiPay.Model.Token;
using ResiPay.Model.User;
using System.Collections.Generic;

namespace ResiPay.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {


            CreateMap<User, UserInsertModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();

            CreateMap<Apartment, ApartmentInsertModel>().ReverseMap();
            CreateMap<Apartment, ApartmentViewModel>().ReverseMap();

            CreateMap<Bill, BillInsertModel>().ReverseMap();
            CreateMap<Bill, BillViewModel>().ReverseMap();
            CreateMap<Base<BillViewModel>, List<ResiPay.DB.Entities.Bill>>();

            CreateMap<Message, MessageInsertModel>().ReverseMap();
            CreateMap<Message, MessageViewModel>().ReverseMap();

            CreateMap<Card, CardInsertModel>().ReverseMap();
            CreateMap<Card, CardViewModel>().ReverseMap();

            CreateMap<TokenEntity, TokenRequestModel>().ReverseMap();
            CreateMap<TokenEntity, TokenResponseModel>().ReverseMap();

        }
    }
}
