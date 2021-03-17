

namespace RDD.Test.Console.Domain
{
    using CsvHelper;
    using RDD.Test.Console.Models;
    using RDD.Test.Console.Settings;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Logic
    {
        /// <summary>
        /// Read the file and return data
        /// </summary>
        /// <param name="pFilepath">File path to process</param>
        /// <returns>List of rows</returns>
        public List<Row> ReadCsv(string pFilepath)
        {
            using (var sReader = new StreamReader(pFilepath, Encoding.Default))
            {
                using (var csv = new CsvReader(sReader, CultureInfo.InvariantCulture))
                {
                    var records = new List<Row>();
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        for (int i = 1; i <= Convert.ToInt32(AppSettings.LoadAppSettings().ColumnsLength); i++)
                        {
                            if (!String.IsNullOrEmpty(csv.GetField("Name" + i.ToString())))
                            {
                                var record = new Row
                                {
                                    Flag1 = Convert.ToBoolean(csv.GetField("Flag" + i.ToString())),
                                    Flag2 = Convert.ToBoolean(csv.GetField("Flag" + i.ToString())),
                                    Flag3 = Convert.ToBoolean(csv.GetField("Flag" + i.ToString())),
                                    Flag4 = Convert.ToBoolean(csv.GetField("Flag" + i.ToString())),
                                    Flag5 = Convert.ToBoolean(csv.GetField("Flag" + i.ToString())),
                                    Name = csv.GetField("Name" + i.ToString()),
                                    Address = csv.GetField("Address" + i.ToString()),
                                    City = csv.GetField("City" + i.ToString()),
                                    State = csv.GetField("State" + i.ToString()),
                                    Zip = csv.GetField("Zip" + i.ToString())
                                };
                                records.Add(record);
                            }
                        }
                    }
                    return records;
                }
            }
        }

        /// <summary>
        /// Create CSV file in directory
        /// </summary>
        /// <param name="pDestinationPath">File Destination</param>
        /// <param name="pRecord">List of records</param>
        public void WriteCsv(string pDestinationPath, List<Row> pRecord)
        {
            using (StreamWriter sw = new StreamWriter(pDestinationPath, false, new UTF8Encoding(true)))
            {
                using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    cw.WriteHeader<Row>();
                    cw.NextRecord();
                    foreach (Row r in pRecord)
                    {
                        cw.WriteRecord<Row>(r);
                        cw.NextRecord();
                    }
                }
            }
            
        }

    }
}
