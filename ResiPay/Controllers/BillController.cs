using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.BaseModel;
using ResiPay.Model.Bill;
using ResiPay.Service.Bill;
using System.Data;

namespace ResiPay.API.Controllers
{

    [Route("api/[controller]s")]
    [ApiController]
    public class BillController : Controller
    {

        private readonly IBillService billService;
        private readonly IMapper mapper;

        public BillController(IBillService billService, IMapper mapper)
        {
            this.billService = billService;
            this.mapper = mapper;

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public Base<BillViewModel> GetBills()
        {
            return billService.GetBills();

        }

        [HttpGet("PaidBills")]
        [Authorize(Roles = "Admin")]
        public Base<BillViewModel> GetPaidBills()
        {
            return billService.GetPaidBills();

        }

        [HttpGet("UnpaidBills")]
        [Authorize(Roles = "Admin")]
        public Base<BillViewModel> GetNotPaidBills()
        {
            return billService.GetNotPaidBills();

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public Base<BillViewModel> Update(BillUpdateModel billToUpdate)
        {
            return billService.Update(billToUpdate);

        }


        [HttpGet("PaidBillsForUser/{id}")]
        [Authorize(Roles = "Admin, Resident")]
        public Base<BillViewModel> GetPaidBillsForUser(int id)
        {
            return billService.GetPaidBillsForUser(id);

        }

        [HttpGet("UnpaidBillsForUser/{id}")]
        [Authorize(Roles = "Admin, Resident")]
        public Base<BillViewModel> GetUnPaidBillsForUser(int id)
        {
            return billService.GetUnPaidBillsForUser(id);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public Base<BillViewModel> Delete(int id)
        {
            return billService.Delete(id);

        }

        [HttpPost("/AssignBill")]
        [Authorize(Roles = "Admin")]
        public Base<BillViewModel> AssignBill(BillInsertModel newBill)
        {
            return billService.AssignBill(newBill);

        }

        [HttpPost("/PayBill")]
        [Authorize(Roles = "Admin, Resident")]
        public Base<BillViewModel> PayBill(int id, string type, string cardNumber)
        {
            return billService.PayBill(id, type, cardNumber);

        }

        [HttpPost("/PayBills")]
        [Authorize(Roles = "Admin, Resident")]
        public Base<BillViewModel> PayBills(int id, string type, string cardNumber)
        {
            return billService.PayBills(id, type, cardNumber);

        }

        [HttpGet("/MonthlyStatus")]
        [Authorize(Roles = "Admin")]
        public Base<BillViewModel> GetMonthlyBills(int month, int year)
        {
            return billService.GetMonthlyBills(month, year);

        }

    }
}
