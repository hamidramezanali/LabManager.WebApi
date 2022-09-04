
using LabManager.WebApi.Model;
using LabManager.WebApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        [HttpGet("{name}")]
        public async Task<IActionResult> Run(string name)
        {
            string outputText = string.Empty;
            var standardError = string.Empty;

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = "dotnet",
                        Arguments = @$"run --project WaitingTest.csproj",
                        WorkingDirectory = @"C:\Users\hamid\source\repos\WaitingTest\WaitingTest\",//the file must exist
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = false,
                    };

                    process.Start();
                    outputText = process.StandardOutput.ReadToEnd();
                    outputText = outputText.Replace(Environment.NewLine, string.Empty);
                    standardError = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {

            }
            var stringjsonData = @"{'FirstName': 'Jignesh', 'LastName': 'Trivedi'}";
            return Ok(stringjsonData + standardError);
        }

    }
}
