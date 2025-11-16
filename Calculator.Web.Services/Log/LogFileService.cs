using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Web.Services.Log
{
    public class LogFileService : ILogFileService
    {
        private readonly string _filePath = "App_logs.txt";
        public void LogToFile(string type, decimal? probA, decimal? probB, decimal result)
        {
            try
            {
                var log = $"{DateTime.Now} | Type: {type} | Inputs: {probA}, {probB} | Result: {result}";
                File.AppendAllText(_filePath, log + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
