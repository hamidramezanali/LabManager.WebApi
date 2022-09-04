
using LabManager.WebApi.Model;
using LabManager.WebApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
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
  

            try
            {
               await  Task.Factory.StartNew(async () => await ProcessAsync(new BlockingCollection<QueueItem>
                   ()
               { new QueueItem()
               {
                   OrderId=Guid.NewGuid(),
                   Request=new SampleInQueueRequest(){Name="HAMID"}
               }
               }), TaskCreationOptions.LongRunning);
            }
            catch (Exception ex)
            {

            }
            var stringjsonData = @"{'FirstName': 'Jignesh', 'LastName': 'Trivedi'}";
            return Ok(stringjsonData );
        }

        private async Task ProcessEachQueueItemAsync(QueueItem sample)
        {
            string outputText = string.Empty;
            var standardError = string.Empty;
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
        private async Task ProcessAsync(BlockingCollection<QueueItem> queue)
        {
            foreach (var item in queue)
            {
                await ProcessEachQueueItemAsync(item);
            }
        }
        public class CheckoutResponse
        {
            public Guid OrderId { get; set; }

            public OrderStatus OrderStatus { get; set; }
            public string Message { get; set; }
        }
        public class QueueItem
        {
            public Guid OrderId { get; set; }
            public SampleInQueueRequest Request { get; set; }
        }
    }

    public enum OrderStatus
    {
        Failed,
        OK
    }

    public class SampleInQueueRequest
    {
        public string Name { get; set; }
    }
}
