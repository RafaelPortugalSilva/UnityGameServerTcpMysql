using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnityGameServerTcpMysql
{
    public static class DebugConsole
    {
        static List<string> messagesList = new List<string>();
        static string LOG_PATH = @"log.txt";

        public static void Message(string msg)
        {
            Console.WriteLine(string.Format("[{0}]:{1}", DateTime.Now.ToLongTimeString(), msg));
            messagesList.Add(string.Format("[{0}]:{1}", DateTime.Now.ToLongTimeString(), msg));
        }

        public static void WriteLog()
        {
            Message("Saving log file...");
            try
            {
                using (StreamWriter sw = File.AppendText(LOG_PATH))
                {
                    for (int i = 0; i < messagesList.Count; i++)
                    {
                        sw.WriteLine(messagesList[i]);
                    }
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Message("Log error: " + e.ToString());
                return;
            }
            Message("log created.");
        }
    }
}
