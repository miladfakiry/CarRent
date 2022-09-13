using CarRent.Customer.Api.v1;
using CarRent.Customer.Domain;
using CarRent.Rent.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Rent.Api.v1
{
    [Route("api/v1/rent")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentRepository _repository;

        public RentController(IRentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<RentController>
        [HttpGet]
        public IActionResult Get()
        {
            var reservations = _repository.GetAll();
            var reservationDtos = reservations.Select(r => new ReservationResponseDto(r));
            return Ok(reservationDtos);
        }

        // GET api/<RentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var reservation = _repository.GetById(new Guid(id));
            return Ok(reservation);
        }

        // POST api/<RentController>
        [HttpPost]
        public IActionResult Post([FromBody] ReservationResponseDto reservationResponseDto)
        {
            _repository.Add(new Reservation(reservationResponseDto));
            return Ok();
        }

        // PUT api/<RentController>/5
        [HttpPut("{reservation}")]
        public void Put([FromBody] ReservationResponseDto reservationResponseDto)
        {
            _repository.Update(new Reservation(reservationResponseDto));
        }

        // PUT api/<RentController>/5
        [HttpPut("{createContract}")]
        public void Put([FromBody] ReservationResponseDto reservationResponseDto, DateTime pickUpDate, Guid carId)
        {
            var reservation = new Reservation(reservationResponseDto);
            reservation.CreateAndAssignContract(pickUpDate, new Car.Domain.Car(carId));
            _repository.Update(reservation);
        }

        // DELETE api/<RentController>/5
        [HttpDelete("{customer}")]
        public void Delete([FromBody] ReservationResponseDto reservationResponseDto)
        {
            _repository.Remove(new Reservation(reservationResponseDto));
        }

        
    }
}
