using System.ComponentModel.DataAnnotations;

namespace Calculator.Web.Models
{
    public class CalculatorInputModel
    {
        [Required(ErrorMessage ="Please enter first probability!")]
        [Range(typeof(decimal), "0", "1", ErrorMessage = "Value must be between 0 and 1!")]
        [RegularExpression(@"\d+(\.\d{0,2})?", ErrorMessage ="Max 2 decimal places are allowed!")]
        public decimal? ProbA { get; set; }

        [Required(ErrorMessage = "Please enter second probability!")]
        [Range(0, 1, ErrorMessage = "Value must be between 0 and 1 !")]
        [RegularExpression(@"\d+(\.\d{0,2})?", ErrorMessage = "Max 2 decimal places are allowed!")]
        public decimal? ProbB { get; set; }

        [Required(ErrorMessage ="Please select an operation")]
        public string Function { get; set; }

        public decimal Result { get; set; }
    }
}
