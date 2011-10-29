using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BabyDazzler.Util
{
    class SimpleLogger
    {
        private static StreamWriter writer;

        public static void Log(string logMessage)
        {
            if (writer == null)
                writer = File.AppendText("log.txt");

            writer.Write(logMessage + "\n");
            // Update the underlying file.
            writer.Flush();
        }
    }
}
