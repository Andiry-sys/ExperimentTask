using ExperimentTask.Model;

namespace ExperimentTask.Service.Interface
{
    public interface IDeviceService
    {
        Task<Device> GetDevice(string deviceToken);
    }
}
