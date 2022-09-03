using LabManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabManager.WebApi.Controllers
{
    [ApiController]
    public class LabController : ControllerBase
    {
        [HttpGet("Instruments/{id}")]
        public ActionResult<Instrument> Get(int id)
        {
            var Instruments = new List<Instrument>() {
             new Instrument() { Id = 2, Name = "MiSeq1", LabId =  Guid.NewGuid() },
            new Instrument() { Id = 3, Name = "MiSeq2", LabId = Guid.NewGuid() },
            new Instrument() { Id = 4, Name = "MiSeq3", LabId = Guid.NewGuid() }
        };
            var person = Instruments.SingleOrDefault(_=>_.Id==id);
            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
        [HttpGet("Instruments/")]
        public ActionResult<List<Instrument>> GetAll()
        {
            var Instruments = new List<Instrument>() {
             new Instrument() { Id = 2, Name = "MiSeq1", LabId =  Guid.NewGuid() },
            new Instrument() { Id = 3, Name = "MiSeq2", LabId = Guid.NewGuid() },
            new Instrument() { Id = 4, Name = "MiSeq3", LabId = Guid.NewGuid() }
        };
            if (Instruments == null)
            {
                return NotFound();
            }

            return Instruments;
        }

    }
}
