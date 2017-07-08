using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;

namespace Gadabout.Server.Core.Infrastructure.Logging
{
    public static class ConsoleLogger
    {
        public static void Log(string text)
        {
            var now = DateTime.Now;
            var textToLog = $"[{now}]   {text}";
            Colorful.Console.WriteLine(textToLog);
        }

        public static void Log(string text, Color color)
        {
            var now = DateTime.Now;
            var textToLog = $"[{now}]   {text}";
            Colorful.Console.WriteLine(textToLog, color);
        }
    }
}
