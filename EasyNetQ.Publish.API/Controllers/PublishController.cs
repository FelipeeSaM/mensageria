using EasyNetQ.Publish.API.Bus;
using EasyNetQ.Publish.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace EasyNetQ.Publish.API.Controllers
{
    [ApiController]
    [Route("api/publish")]
    public class PublishController : ControllerBase
    {
        private const string EXCHANGE = "nome-exchange";
        private readonly IBusService _bus;

        public PublishController(IBusService bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public IActionResult Post(PublishModel model)
        {
            var publicar = new PublishModelDto(model.Id, model.Name);
            _bus.Publish(EXCHANGE, publicar);

            return Ok();
        }
    }
}
