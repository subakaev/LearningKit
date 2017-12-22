using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningKit.Data
{
    public static class LocationHelper
    {
        private const string DataDirName = "Data";

        public static string DataPath = Path.Combine(Environment.CurrentDirectory, DataDirName);

        public static string ResolveDataFilePath(string fileName) => Path.Combine(DataPath, fileName);
    }
}
