using Calculator.Web.Services.CalculatorService;
using Calculator.Web.Services.Model;
using Microsoft.Extensions.Logging;
using Moq;

namespace Calculator.Web.Tests
{
    public class CalculatorTests
    {
        private CalculatorService _service;
        private Mock<ILogger<CalculatorService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<CalculatorService>>();
            _service = new CalculatorService(_mockLogger.Object);
        }

        [Test]
        public void Calculate_Combined()
        {
            var model = new CalculatorModel { ProbA = 0.5m, ProbB = 0.5m, Function = "combined" };
            var result = _service.Calculate(model);
            Assert.AreEqual(0.25m, result);
        }

        [Test]
        public void Calculate_Either()
        {
            var model = new CalculatorModel { ProbA = 0.5m, ProbB = 0.5m, Function = "either" };
            var result = _service.Calculate(model);
            Assert.AreEqual(0.75m, result);
        }

        [Test]
        public void Calculate_Invalid()
        {
            var model = new CalculatorModel { ProbA = 0.5m, ProbB = 0.5m, Function = "invalid" };
            var ex = Assert.Throws<ArgumentException>(() => _service.Calculate(model));
            Assert.That(ex.Message, Is.EqualTo("Invalid operation"));
        }

        [Test]
        public void Calculate_NullProbA()
        {
            var model = new CalculatorModel { ProbA = null, ProbB = 0.5m, Function = "combined" };
            Assert.Throws<InvalidOperationException>(() => _service.Calculate(model));
        }

        [Test]
        public void Calculate_NullProbB()
        {
            var model = new CalculatorModel { ProbA = 0.5m, ProbB = null, Function = "either" };
            Assert.Throws<InvalidOperationException>(() => _service.Calculate(model));
        }
    }
}