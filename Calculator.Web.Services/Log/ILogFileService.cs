using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Web.Services.Log
{
    public interface ILogFileService
    {
        void LogToFile(string type, decimal? probA, decimal? probB, decimal result);
    }
}
