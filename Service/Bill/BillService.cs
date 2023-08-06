using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResiPay.DB;
using ResiPay.Model.BaseModel;
using ResiPay.Model.Bill;
using ResiPay.Service.Apartment;
using ResiPay.Service.CardService;
using ResiPay.Service.User;
using ResiPay.Service.Validations.Bill;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResiPay.Service.Bill
{
    public class BillService : IBillService
    {
        private readonly IMapper mapper;
        private readonly BillInsertValidator validator;
        private readonly ResiPayDbContext dbContext;
        private readonly IUserService userService;
        private readonly IApartmentService apartmentService;
        private readonly ICardService cardService;


        public BillService(IMapper mapper, BillInsertValidator validator, ResiPayDbContext dbContext, IUserService userService, IApartmentService apartmentService, ICardService cardService)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.dbContext = dbContext;
            this.userService = userService;
            this.apartmentService = apartmentService;
            this.cardService = cardService;

        }

        public Base<BillViewModel> GetBills()
        {
            var result = new Base<BillViewModel>();

            var bills = dbContext.Bill.OrderBy(b => b.Id);

            if (bills.Any())
            {
                result.List = mapper.Map<List<BillViewModel>>(bills);
                result.IsSuccess = true;
                result.OkMessage = "All bills are listed.";
                result.TotalCount = bills.Count();
            }

            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No bills found.";
            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<BillViewModel> GetPaidBills()
        {
            var result = new Base<BillViewModel>();

            var bills = dbContext.Bill.OrderBy(b => b.ApartmentId).ThenBy(b => b.Id).Where(i => i.IsPaid);


            if (bills.Any())
            {
                result.List = mapper.Map<List<BillViewModel>>(bills);
                result.IsSuccess = true;
                result.OkMessage = "All paid bills are listed.";
                result.TotalCount = bills.Count();
            }

            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No paid bills found.";
            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<BillViewModel> GetNotPaidBills()
        {
            var result = new Base<BillViewModel>();

            var bills = dbContext.Bill.Include(p => p.User)
                .OrderBy(b => b.ApartmentId)
                .ThenBy(b => b.Id)
                .Where(i => !i.IsPaid);


            if (bills.Any())
            {
                result.List = mapper.Map<List<BillViewModel>>(bills);
                result.IsSuccess = true;
                result.OkMessage = "All unpaid bills are listed.";
                result.TotalCount = bills.Count();
            }

            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No unpaid bills found.";
            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<BillViewModel> GetPaidBillsForUser(int id)
        {
            var result = new Base<BillViewModel>();

            var bills = dbContext.Bill.Where(b => b.IsPaid && b.UserId == id)
                .OrderBy(a => a.Month).ThenBy(a => a.UpdateDate);

            if (bills.Any())
            {
                result.List = mapper.Map<List<BillViewModel>>(bills);
                result.IsSuccess = true;
                result.OkMessage = "User's paid bills are listed.";
                result.TotalCount = bills.Count();

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No paid bills for user.";
            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<BillViewModel> GetUnPaidBillsForUser(int id)
        {
            var result = new Base<BillViewModel>();

            var bills = dbContext.Bill.Where(b => !b.IsPaid && b.UserId == id)
                .OrderBy(a => a.Month).ThenBy(a => a.DueDate);

            if (bills.Any())
            {
                result.List = mapper.Map<List<BillViewModel>>(bills);
                result.IsSuccess = true;
                result.OkMessage = "User's unpaid bills are listed.";
                result.TotalCount = bills.Count();

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No unpaid bills for user.";
            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<BillViewModel> GetMonthlyBills(int month, int year)
        {
            var result = new Base<BillViewModel>();

            var bills = dbContext.Bill.Include(p => p.User)
                .OrderBy(b => b.ApartmentId)
                .ThenBy(b => b.Id)
                .Where(i => (int)i.Month == month && i.DueDate.Year == year); 

            var paidBills = bills.Where(i => i.IsPaid); 
            var notPaidBills = bills.Where(i => !i.IsPaid); 

            var totalPaidAmount = paidBills.Sum(i => i.BillAmount); 
            var totalNotPaidAmount = notPaidBills.Sum(i => i.BillAmount);

            if (bills.Any())
            {

                result.OkMessage = @"All bills are listed for " + month + "/" +year + ". Total paid bills: " + totalPaidAmount + " TL and total unpaid bills: " + totalNotPaidAmount + " TL.";
                result.List = mapper.Map<List<BillViewModel>>(bills);
                result.IsSuccess = true;

            }

            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = $"No bills are found for {month}/{year}.";
            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<BillViewModel> Update(BillUpdateModel billToUpdate)
        {
            var result = new Base<BillViewModel>();

            var model = dbContext.Bill.SingleOrDefault(b => b.Id == billToUpdate.Id);

            if (model is not null)
            {
                model.BillAmount = billToUpdate.BillAmount;
                model.DueDate = billToUpdate.DueDate;
                model.IsPaid = billToUpdate.IsPaid;
                model.BillType = billToUpdate.BillType;

                dbContext.SaveChanges();

                result.Entity = mapper.Map<BillViewModel>(model);
                result.IsSuccess = true;
                result.OkMessage = "Bill updated successfully.";

            }

            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "Bill is not found with given ID.";

            }

            return result;

        }

        public Base<BillViewModel> Delete(int id)
        {
            var result = new Base<BillViewModel>();

            var bill = dbContext.Bill.SingleOrDefault(b => b.Id == id);

            if (bill is not null)
            {

                dbContext.Bill.Remove(bill);
                dbContext.SaveChanges();

                result.Entity = mapper.Map<BillViewModel>(bill);
                result.IsSuccess = true;
                result.OkMessage = "Bill deleted successfully.";
            }

            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "Bill not found with given ID.";
            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<BillViewModel> AssignBill(BillInsertModel newBill)
        {

            var result = new Base<BillViewModel>();
            var model = mapper.Map<ResiPay.DB.Entities.Bill>(newBill);

            var isExist = dbContext.Bill.Any
                (x => x.DueDate == newBill.DueDate
                && x.ApartmentId == newBill.ApartmentId
                && x.BillType.ToLower() == newBill.BillType.ToLower());

            if (isExist)
            {
                result.ExceptionMessage = "Bill is already exist with given informations.";
                result.IsSuccess = false;
                return result;

            }

            var apartment = dbContext.Apartment.FirstOrDefault(x => x.IsFull && x.Id == newBill.ApartmentId);

            if (apartment is null)
            {

                result.ExceptionMessage = "There is no person in this apartment and it can not be assigned the bill";
                result.IsSuccess = false;
                return result;

            }

            model.ApartmentId = newBill.ApartmentId;
            model.BillAmount = newBill.BillAmount;
            model.BillType = newBill.BillType;
            model.DueDate = newBill.DueDate;
            model.IsPaid = newBill.IsPaid;
            model.Month = (DB.Enums.Month)DateTime.Now.Month;


            dbContext.Bill.Add(model);


            dbContext.SaveChanges();

            result.Entity = mapper.Map<BillViewModel>(model);
            result.IsSuccess = true;
            result.OkMessage = "Bill is created for apartment with ID " + model.ApartmentId;
            return result;


        }

        public Base<BillViewModel> PayBill (int id, string type, string cardNumber)
        {

            var result = new Base<BillViewModel>();

            var card = cardService.GetCardByUserId(id);

            var bill = dbContext.Bill.FirstOrDefault(x => x.UserId == id && x.BillType == type && !x.IsPaid );

            if (bill != null && bill.UserId == card.Data.UserId && card.Data.CardNumber == cardNumber)
            {
                bill.IsPaid = true;

                result.IsSuccess = true;
                result.OkMessage = "Bill is payed successfully.";

                dbContext.SaveChanges();

            }

            else
            {
                result.ExceptionMessage = "Payment is fail. Try again.";
                result.IsSuccess = false;
            }

            return result;

        }

        public Base<BillViewModel> PayBills(int id, string type, string cardNumber)
        {
            var result = new Base<BillViewModel>();

            var card = cardService.GetCardByUserId(id);

            var unpaidBills = dbContext.Bill.Where(x => x.UserId == id && x.BillType == type && !x.IsPaid).ToList();

            if (unpaidBills.Any() && card.Data.UserId == id && card.Data.CardNumber == cardNumber)
            {
                unpaidBills.ForEach(bill => bill.IsPaid = true);

                dbContext.SaveChanges();
                result.OkMessage = "Multiple payment is successful.";
                result.IsSuccess = true;
            }
            else
            {
                result.ExceptionMessage = "Multiple payment is fail. Try again.";
                result.IsSuccess = false;
            }

            return result;
        }

    }
}

