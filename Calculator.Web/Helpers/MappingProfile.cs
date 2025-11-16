using AutoMapper;
using Calculator.Web.Models;
using Calculator.Web.Services.Model;

namespace Calculator.Web.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CalculatorInputModel, CalculatorModel>().ReverseMap();
        }
    }
}
