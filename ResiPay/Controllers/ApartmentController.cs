using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.Apartment;
using ResiPay.Model.BaseModel;
using ResiPay.Service.Apartment;
using System.Data;

namespace ResiPay.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService apartmentService;
        private readonly IMapper mapper;

        public ApartmentController(IApartmentService apartmentService, IMapper mapper)
        {
            this.apartmentService = apartmentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public Base<ApartmentViewModel> GetAllApartments()
        {
            return apartmentService.GetAllApartments();

        }

        [HttpGet("{id}")]
        public Base<ApartmentViewModel> GetById(int id)
        {
            return apartmentService.GetById(id);

        }

        [HttpPost]
        public Base<ApartmentViewModel> Insert ([FromBody] ApartmentInsertModel newApartment) {

            return apartmentService.Insert(newApartment);
                    
        }

        [HttpDelete("{id}")]
        public Base<ApartmentViewModel> Delete (int id)
        {
            return apartmentService.Delete(id);

        }

        [HttpPut("{id}")]
        public Base<ApartmentViewModel> Update ([FromBody] ApartmentInsertModel apartment, int id)
        {
            return apartmentService.Update(apartment, id);

        }

    }
}
