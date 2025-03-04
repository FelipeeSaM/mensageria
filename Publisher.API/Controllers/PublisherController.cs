using Microsoft.AspNetCore.Mvc;
using Publisher.API.Bus;

namespace Publisher.API.Controllers
{
    [ApiController]
    [Route("api/publish")]
    public class PublisherController : ControllerBase
    {
        private readonly IBusService _bus;

        public PublisherController(IBusService bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public IActionResult Publicar([FromBody] string mensagem)
        {
            _bus.Publish("routing-key-aqui", mensagem);
            return Ok("mensagem publicada");
        }
    }
}
