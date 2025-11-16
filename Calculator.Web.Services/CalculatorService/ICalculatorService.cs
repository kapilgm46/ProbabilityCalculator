using Calculator.Web.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Web.Services.CalculatorService
{
    public interface ICalculatorService
    {
        public decimal Calculate(CalculatorModel model);
    }
}
