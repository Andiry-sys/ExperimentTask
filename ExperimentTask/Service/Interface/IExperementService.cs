using ExperimentTask.Model;

namespace ExperimentTask.Service.Interface
{
    public interface IExperementService
    {
        Task<Experiment> GetPriceExperiment(string key);
        Task<Experiment> GetButtonColorExperiment(string key);
    }
}
