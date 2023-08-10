using ResiPay.Model.Apartment;
using ResiPay.Model.BaseModel;

namespace ResiPay.Service.Apartment
{
    public interface IApartmentService
    {
        public Base<ApartmentViewModel> GetAllApartments();
        public Base<ApartmentViewModel> GetById(int id);
        public Base<ApartmentViewModel> Insert(ApartmentInsertModel newInsert);
        public Base<ApartmentViewModel> Delete(int id);
        public Base<ApartmentViewModel> Update(ApartmentInsertModel apartment, int id);

    }
}
