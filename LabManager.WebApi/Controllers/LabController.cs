
using LabManager.WebApi.Model;
using LabManager.WebApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace LabManager.WebApi.Controllers
{
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly IInstrumentService _instrumentService;

        public LabController(IInstrumentService instrumentService)
        {
            _instrumentService = instrumentService;
        }
        [HttpGet("Instruments/{id}")]
        public async Task<ActionResult<Instrument>> Get(int id)
        {

            var person = _instrumentService.GetInstrument(2);
            if (person == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await person;
        }
        [HttpGet("Instruments/")]
        public async Task<IEnumerable<Instrument>> GetAll()
        {
            var Instruments = _instrumentService.GetInstruments();

            return await Instruments;
        }

    }
}
