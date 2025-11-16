using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Web.Services.Model
{
    public class CalculatorModel
    {
        public decimal? ProbA { get; set; }
        public decimal? ProbB { get; set; }
        public string? Function { get; set; }
        public decimal Result { get; set; }
    }
}
