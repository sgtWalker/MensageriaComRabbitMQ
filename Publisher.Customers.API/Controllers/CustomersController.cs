using Microsoft.AspNetCore.Mvc;
using Publisher.Customers.API.Bus;
using Publisher.Customers.API.Entities;
using Publisher.Customers.API.InputModels;
using System.Runtime.CompilerServices;

namespace Publisher.Customers.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IBusService _busService;
        private const string ROUTING_KEY = "customer-created";

        public CustomersController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerInputModel inputModel)
        {
            try
            {
                var @event = new CustomerCreated(inputModel.Id, inputModel.Name, inputModel.BirthDate);

                await _busService.Publish(ROUTING_KEY, @event);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
