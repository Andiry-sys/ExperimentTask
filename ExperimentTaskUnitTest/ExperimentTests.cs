namespace ExperimentTaskUnitTest
{
    [TestClass]
    public class ExperimentTests
    {
        [TestMethod]
        public async Task GetButtonColorExperiment_ShouldReturnValidExperiment()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ExperimentContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var dbContext = new ExperimentContext(dbContextOptions);
            var service = new ExperementService(dbContext);

            // Act
            var experiment = await service.GetButtonColorExperiment("button_color");

            // Assert
            Assert.IsNotNull(experiment);
            Assert.AreEqual("button_color",experiment.Key);
            Assert.IsTrue(new List<string> { "#FF0000","#00FF00","#0000FF" }.Contains(experiment.Options));
        }

        [TestMethod]
        public async Task GetPriceExperiment_ShouldReturnValidExperiment()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ExperimentContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var dbContext = new ExperimentContext(dbContextOptions);
            var service = new ExperementService(dbContext);

            // Act
            var experiment = await service.GetPriceExperiment("price");

            // Assert
            Assert.IsNotNull(experiment);
            Assert.AreEqual("price",experiment.Key);
            Assert.IsTrue(new List<string> { "10","20","50","5" }.Contains(experiment.Options));
        }
    }
}