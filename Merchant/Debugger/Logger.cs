using System;
using System.IO;

namespace Merchant.Debugger
{
    class Logger
    {
        private static Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        public static Logger Instance => _instance.Value;

        public void Log(string logMessage)
        {
            string path = @"c:\log.txt";
            using (StreamWriter w = File.AppendText(path)) //custom path here
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }
    }
}