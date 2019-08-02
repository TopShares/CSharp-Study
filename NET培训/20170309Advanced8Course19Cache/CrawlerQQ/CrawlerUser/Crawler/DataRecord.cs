using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Crawler
{
    public class DataRecord
    {
        private static string DataPath = ConfigurationManager.AppSettings["DataPath"];
        private static object DataRecordLock = new object();

        public static void Save(string keyword, int page, string content)
        {
            string fileName = string.Format("groupid={0}\\page_{1}.txt", keyword, page);
            string totalPath = Path.Combine(DataPath, fileName);
            string directory = Path.GetDirectoryName(totalPath);

            StreamWriter sw = null;
            lock (DataRecordLock)
            {
                try
                {
                    if (Directory.Exists(directory))
                    {
                        sw = File.AppendText(totalPath);
                    }
                    else
                    {
                        Directory.CreateDirectory(directory);
                        sw = File.CreateText(totalPath);
                    }
                    sw.WriteLine(content);
                    Console.WriteLine(content);
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
        }
    }
}
