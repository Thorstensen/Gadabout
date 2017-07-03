using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;

namespace Gadabout.Server.Infrastructure.Logging
{
    public static class ConsoleLogger
    {
        public static void Log(string text)
        {
            Colorful.Console.WriteLine(text);
        }

        public static void Log(string text, Color color)
        {
            Colorful.Console.WriteLine(text, color);
        }
    }
}
