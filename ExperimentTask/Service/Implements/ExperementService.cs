using ExperimentTask.Context;
using ExperimentTask.Model;
using ExperimentTask.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTask.Service.Implements
{
    public class ExperementService : IExperementService
    {
        private readonly ExperimentContext _context;

        public ExperementService(ExperimentContext context) => _context = context;



        public async Task<Experiment> GetButtonColorExperiment(string key)
        {
            var buttonColorCounts = await _context.Devices.Where(d => d.Experiment.Key == key).GroupBy(d => d.Experiment.Options).Select(g => new { Option = g.Key, Count = g.Count() }).ToListAsync();

            var random = new Random();
            int randomNumber = random.Next(1, 101);

            string selectedOption = "";

            if (randomNumber <= 33)
            {
                selectedOption = "#FF0000";
            }
            else if (randomNumber <= 66)
            {
                selectedOption = "#00FF00";
            }

            if (!string.IsNullOrEmpty(selectedOption))
            {
                var optionCount = buttonColorCounts.FirstOrDefault(c => c.Option == selectedOption)?.Count ?? 0;
                if (optionCount <= 400)
                {
                    return new Experiment { Id = Guid.NewGuid().ToString(), Key = key, Options = selectedOption };
                }
            }

            var remainingOptions = buttonColorCounts.Where(c => c.Count <= 400).Select(c => c.Option).ToList();
            if (remainingOptions.Count > 0)
            {
                selectedOption = remainingOptions[random.Next(remainingOptions.Count)];
                return new Experiment { Id = Guid.NewGuid().ToString(), Key = key, Options = selectedOption };
            }
            else
            {
                var options = new List<string> { "#FF0000", "#00FF00", "#0000FF" };
                selectedOption = options[random.Next(options.Count)];
                return new Experiment { Id = Guid.NewGuid().ToString(), Key = key, Options = selectedOption };
            }
        }

        public async Task<Experiment> GetPriceExperiment(string key)
        {
            var random = new Random();
            int randomNumber = random.Next(1, 101);

            string selectedOption = "";

            if (randomNumber <= 75)
            {
                selectedOption = "10";
            }
            else if (randomNumber <= 85)
            {
                selectedOption = "20";
            }
            else if (randomNumber <= 90)
            {
                selectedOption = "50";
            }
            else
            {
                selectedOption = "5";
            }

            if (!string.IsNullOrEmpty(selectedOption))
            {
                return new Experiment { Id = Guid.NewGuid().ToString(), Key = key, Options = selectedOption, Count = randomNumber };
            }
            else
            {
                var options = new List<string> { "10", "20", "50", "5" };
                selectedOption = options[random.Next(options.Count)];
                return new Experiment { Id = Guid.NewGuid().ToString(), Key = key, Options = selectedOption, Count = randomNumber };
            }
        }
    }
}
