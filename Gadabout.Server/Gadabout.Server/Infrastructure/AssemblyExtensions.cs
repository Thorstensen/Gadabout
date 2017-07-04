using System;
using System.IO;
using System.Reflection;

namespace Gadabout.Server.Core.Infrastructure
{
    public static class AssemblyExtensions
    {
        public static string GetModulesLocation(this Assembly assembly)
        {
            return GetAssemblyLocation(assembly) + @"/Modules";
        }

        public static string GetAssemblyLocation(this Assembly assembly)
        {
            string filePath = new Uri(assembly.CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }
    }
}
