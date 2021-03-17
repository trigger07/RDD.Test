using RDD.Test.Console.Domain;
using RDD.Test.Console.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDD.Test.Console
{
    public class ProcessExecution
    {
        /// <summary>
        /// Execute file reading process
        /// </summary>
        public static void Run()
        {
            try
            {
                System.Console.WriteLine("Starting CSV Reading!");

                var path = AppDomain.CurrentDomain.BaseDirectory + "/InputData/" + AppSettings.LoadAppSettings().FileName;

                //In debug mode, file will be saved in bin/debug/net5.0/OutputData
                var destinationPath = AppDomain.CurrentDomain.BaseDirectory + "/OutputData/" + AppSettings.LoadAppSettings().ResultFileName;

                Logic l = new Logic();
                var rowsCsv = l.ReadCsv(path);
                l.WriteCsv(destinationPath, rowsCsv);

                System.Console.WriteLine("Process finished, data rows count: " + rowsCsv.Count());
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error log: { ex.Message } Trace: { ex.StackTrace }");
                System.Console.ReadKey();
            }
        }
    }
}
