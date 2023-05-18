using ExperimentTask.Context;
using ExperimentTask.Model;
using ExperimentTask.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ExperimentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        private readonly ExperimentContext _context;
        private readonly IExperementService _experimentService;
        private readonly IDeviceService _deviceService;

        public ExperimentController(ExperimentContext context, IDeviceService deviceService,IExperementService experimentService) 
        {
            _context = context;
            _deviceService = deviceService;
            _experimentService = experimentService;
        } 


        [HttpGet("button-color")]
        public async Task<IActionResult> GetButtonColorExperiment(string deviceToken)
        {
            if (string.IsNullOrEmpty(deviceToken))
            {
                return BadRequest("Device token is required.");
            }

             var existingDevice = await _deviceService.GetDevice(deviceToken);

            
           

            var experiment = await _experimentService.GetButtonColorExperiment("button-color");
                   
               
                if(existingDevice == null)
                {
                    var newDevice = new Device { Id = Guid.NewGuid().ToString(),DeviceToken = deviceToken,Experiment = experiment };
                    _context.Devices.Add(newDevice);
                }
            
                await _context.SaveChangesAsync();

                return Ok(new ExperimentColorResponse { Key = experiment.Key,Options = experiment.Options });
            }
            
           
                    
                
            
        

        [HttpGet("price")]
        public async Task<IActionResult> GetPriceExperiment(string deviceToken)
        {
            if (string.IsNullOrEmpty(deviceToken))
            {
                return BadRequest("Device token is required.");
            }

            var existingDevice = await _deviceService.GetDevice(deviceToken);

           
            
            var experiment = await _experimentService.GetPriceExperiment("price");

            if (existingDevice == null)
            {
                var newDevice = new Device { Id = Guid.NewGuid().ToString(),DeviceToken = deviceToken,Experiment = experiment };
                _context.Devices.Add(newDevice);
            }
            await _context.SaveChangesAsync();

            return Ok(new ExperimentPriceResponse { Key = experiment.Key, Options= experiment.Options,Count= experiment.Count});
        }





    }
}
