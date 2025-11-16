using Calculator.Web.Services.Model;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.Web.Services.CalculatorService
{
    public class CalculatorService : ICalculatorService
    {
        //Logger for logging errors and information.
        private readonly ILogger<CalculatorService> _logger;

        //Constructor to initialize the logger.
        public CalculatorService(ILogger<CalculatorService> logger) 
        {
            _logger = logger;
        }

        //Calculates the result based on the provided probabilities and operation.
        public decimal Calculate(CalculatorModel model)
        {
            decimal result = 0;
            try
            {
                switch (model.Function)
                {
                    case "combined":
                        result = model.ProbA.Value * model.ProbB.Value;
                        break;
                    case "either":
                        result = model.ProbA.Value + model.ProbB.Value - (model.ProbA.Value * model.ProbB.Value);
                        break;
                    default:
                        throw new ArgumentException("Invalid operation");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calculating probabilities.");
                throw;
            }
            return Math.Round(result, 2);
        }
    }
}
