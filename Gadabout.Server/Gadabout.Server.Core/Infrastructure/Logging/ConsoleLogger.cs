using System;
using System.Drawing;

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

        public static void Log(string text, LogLevel level)
        {
            var now = DateTime.Now;
            var textToLog = $"[{now}]   {text}";
            Colorful.Console.WriteLine(textToLog, GetColor(level));
        }

        private static Color GetColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    return Color.Aquamarine;
                case LogLevel.Information:
                    return Color.LightSkyBlue;
                case LogLevel.Debug:
                    return Color.DarkOrange;
                case LogLevel.Error:
                    return Color.Red;
                default:
                    return Color.White;
            }
        }
    }
}
