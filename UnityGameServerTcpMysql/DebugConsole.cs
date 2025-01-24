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
        static ConsoleColor debugColor = ConsoleColor.White;
        static ConsoleColor warningColor = ConsoleColor.Yellow;
        static ConsoleColor errorColor = ConsoleColor.Red;



        public static void Message(string msg, InfoType type = InfoType.Debug)
        {
            if (type == InfoType.Debug)
                Console.ForegroundColor = debugColor;
            else if (type == InfoType.Warning)
                Console.ForegroundColor = warningColor;
            else
                Console.ForegroundColor = errorColor;

            Console.WriteLine(string.Format("[{0}]:{1}", DateTime.Now.ToLongTimeString(), msg));
            messagesList.Add(string.Format("[{0}]:{1}", DateTime.Now.ToLongTimeString(), msg));
            Console.ResetColor();
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

    public enum InfoType { Debug, Warning, Error}
}
