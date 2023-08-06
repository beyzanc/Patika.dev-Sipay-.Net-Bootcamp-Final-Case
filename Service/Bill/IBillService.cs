using ResiPay.Model.BaseModel;
using ResiPay.Model.Bill;

namespace ResiPay.Service.Bill
{
    public interface IBillService
    {
        public Base<BillViewModel> GetBills();
        public Base<BillViewModel> GetPaidBills();
        public Base<BillViewModel> GetNotPaidBills();
        public Base<BillViewModel> Update(BillUpdateModel billToUpdate);
        public Base<BillViewModel> GetPaidBillsForUser(int id);
        public Base<BillViewModel> GetUnPaidBillsForUser(int id);
        public Base<BillViewModel> Delete(int id);
        public Base<BillViewModel> AssignBill(BillInsertModel newBill);
        public Base<BillViewModel> PayBill(int id, string type, string cardNumber);
        public Base<BillViewModel> PayBills(int id, string type, string cardNumber);
        public Base<BillViewModel> GetMonthlyBills(int month, int year);



    }
}
