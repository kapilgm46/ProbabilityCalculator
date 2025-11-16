using AutoMapper;
using Calculator.Web.Models;
using Calculator.Web.Services.CalculatorService;
using Calculator.Web.Services.Log;
using Calculator.Web.Services.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        // Inject the calculator service
        private readonly ICalculatorService _service;
        // Inject the AutoMapper
        private readonly IMapper _mapper;
        // Inject the log file service
        private readonly ILogFileService _logService;

        // Constructor to initialize the service and mapper
        public CalculatorController(ICalculatorService service, IMapper mapper, ILogFileService logService)
        {
            _service = service;
            _mapper = mapper;
            _logService = logService;
        }
        public IActionResult Calculator()
        {
            return View(new CalculatorInputModel());
        }

        // POST: Calculator/Calculate
        [HttpPost]
        public IActionResult Calculate(CalculatorInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        e => e.Key,
                        e => e.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(errors);
            }

            var calculationResult = _service.Calculate(_mapper.Map<CalculatorModel>(model));
            _logService.LogToFile(model.Function, model.ProbA, model.ProbB, calculationResult);

            return Json(new {result = calculationResult });
        }

        // Error handling action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
