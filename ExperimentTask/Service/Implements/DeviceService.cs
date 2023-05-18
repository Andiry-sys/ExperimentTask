using ExperimentTask.Context;
using ExperimentTask.Model;
using ExperimentTask.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ExperimentTask.Service.Implements
{
    public class DeviceService : IDeviceService
    {
        private readonly ExperimentContext _context;
        public DeviceService(ExperimentContext context) => _context = context;     
            
        public async Task<Device> GetDevice(string deviceToken)
        {
           return await _context.Devices.FirstOrDefaultAsync(s=>s.DeviceToken == deviceToken);
        }
    }
}
