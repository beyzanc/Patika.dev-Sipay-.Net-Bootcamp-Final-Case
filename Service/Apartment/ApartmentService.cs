using AutoMapper;
using ResiPay.DB;
using ResiPay.Model.Apartment;
using ResiPay.Model.BaseModel;
using ResiPay.Service.Validations.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResiPay.Service.Apartment
{
    public class ApartmentService : IApartmentService
    {
        private readonly IMapper mapper;
        private readonly ApartmentInsertValidator validator;
        private readonly ResiPayDbContext dbContext;

        public ApartmentService(IMapper _mapper, ApartmentInsertValidator _validator, ResiPayDbContext dbContext)
        {
            this.mapper = _mapper;
            this.validator = _validator;
            this.dbContext = dbContext;
        }


        public Base<ApartmentViewModel> GetAllApartments()
        {
            var result = new Base<ApartmentViewModel>();

            var data = dbContext.Apartment
                .Where(a => a.Id >0 )
                .OrderBy(a => a.Id)
                .ToList();

            if (data.Any())
            {
                result.List = mapper.Map<List<ApartmentViewModel>>(data);
                result.IsSuccess = true;
                result.OkMessage = "All apartments are listed successfully.";
                result.TotalCount = data.Count();

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "Apartments are not found";
            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<ApartmentViewModel> GetById (int id)
        {
            var result = new Base<ApartmentViewModel>();

            var data = dbContext.Apartment.SingleOrDefault(a => a.Id == id);

            if (data is null)
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "Apartment is not found with given ID.";
                return result;

            }

            result.Entity = mapper.Map<ApartmentViewModel>(data);

            dbContext.SaveChanges();
            return result;
        }

        public Base<ApartmentViewModel> Insert (ApartmentInsertModel newInsert)
        {
            var result = new Base<ApartmentViewModel>();

            var valid = validator.Validate(newInsert);

            if (!valid.IsValid)
            {
                result.IsSuccess = false;
                result.ExceptionMessage = string.Join(", ", valid.Errors);
                return result;

            }

            var existApartment = dbContext.Apartment.FirstOrDefault(a =>
                a.ApartmentBlock == newInsert.ApartmentBlock &&
                a.ApartmentFloor == newInsert.ApartmentFloor &&
                a.ApartmentNumber == newInsert.ApartmentNumber 
               
            );

            if ( existApartment is not null )
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "Apartment with the same details already exists.";
                return result;

            }

            else { 
                var apartment = mapper.Map<ResiPay.DB.Entities.Apartment>(newInsert);

                apartment.InsertDate = DateTime.Now;
                apartment.UpdateDate = DateTime.Now;

                dbContext.Apartment.Add(apartment);

                dbContext.SaveChanges();

                var insertedApartment = mapper.Map<ApartmentViewModel>(apartment);

                result.IsSuccess = true;
                result.Entity = insertedApartment;
                result.OkMessage = "Apartment successfully created.";

            }
                              
            return result;

        }

        public Base<ApartmentViewModel> Delete(int id)
        {
            var result = new Base<ApartmentViewModel>();

            var data = dbContext.Apartment.SingleOrDefault(a => a.Id == id);

            if (data is null)
            {
                result.ExceptionMessage = "Apartment not found.";
                result.IsSuccess = false;

            }

            else
            {
                dbContext.Apartment.Remove(data);
                dbContext.SaveChanges();

                result.Entity = mapper.Map<ApartmentViewModel>(data);
                result.IsSuccess = true;
                result.OkMessage = "Apartment deleted successfully.";

            }

            return result;

        }

        public Base<ApartmentViewModel> Update(ApartmentInsertModel apartment, int id)
        {
            var result = new Base<ApartmentViewModel>();
                
            var updateApart = dbContext.Apartment.SingleOrDefault(a =>a.Id == id);

            if (updateApart is not null)
            {
                updateApart.ApartmentBlock = apartment.ApartmentBlock;
                updateApart.ApartmentFloor = apartment.ApartmentFloor;
                updateApart.ApartmentNumber = apartment.ApartmentNumber;
                updateApart.ApartmentType = apartment.ApartmentType;
                updateApart.IsFull = apartment.IsFull;
                updateApart.IsRented = apartment.IsRented;
           
                dbContext.SaveChanges();

                result.Entity = mapper.Map<ApartmentViewModel>(updateApart);
                result.IsSuccess = true;
                result.OkMessage = "Apartment is updated.";

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "Apartment not found with given ID.";

            }

            return result;
                   
        }
    }
}
