using System;
using System.IO;

namespace Library.Application.Logger
{
    public static class Logger
    {
        public static void Log(string message)
        {
            var x = DateTime.Now;
            string logPath = $"Logs/{x.Day.ToString()}-{x.Month.ToString()}-{x.Year.ToString()}.txt";
            Directory.CreateDirectory("Logs");
            File.AppendAllText(logPath, message);
        }
    }
}
