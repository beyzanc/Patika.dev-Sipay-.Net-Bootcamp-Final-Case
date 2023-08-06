using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.BaseModel;
using ResiPay.Model.Bill;
using ResiPay.Service.Bill;

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
        public Base<BillViewModel> GetBills()
        {
            return billService.GetBills();
        }

        [HttpGet("PaidBills")]
        public Base<BillViewModel> GetPaidBills()
        {
            return billService.GetPaidBills();
        }

        [HttpGet("UnpaidBills")]
        public Base<BillViewModel> GetNotPaidBills()
        {
            return billService.GetNotPaidBills();
        }

        [HttpPut]
        public Base<BillViewModel> Update(BillUpdateModel billToUpdate)
        {
            return billService.Update(billToUpdate);

        }


        [HttpGet("PaidBillsForUser/{id}")]
        public Base<BillViewModel> GetPaidBillsForUser(int id)
        {
            return billService.GetPaidBillsForUser(id);

        }

        [HttpGet("UnpaidBillsForUser/{id}")]
        public Base<BillViewModel> GetUnPaidBillsForUser(int id)
        {
            return billService.GetUnPaidBillsForUser(id);

        }


        [HttpDelete("{id}")]
        public Base<BillViewModel> Delete(int id)
        {
            return billService.Delete(id);
        }

        [HttpPost("/AssignBill")]
        public Base<BillViewModel> AssignBill(BillInsertModel newBill)
        {
            return billService.AssignBill(newBill);
        }

        [HttpPost("/PayBill")]
        public Base<BillViewModel> PayBill(int id, string type, string cardNumber)
        {
            return billService.PayBill(id, type, cardNumber);
        }

        [HttpPost("/PayBills")]
        public Base<BillViewModel> PayBills(int id, string type, string cardNumber)
        {
            return billService.PayBills(id, type, cardNumber);
        }

        [HttpGet("/MonthlyStatus")]
        public Base<BillViewModel> GetMonthlyBills(int month, int year)
        {
            return billService.GetMonthlyBills(month, year);
        }

    }
}
