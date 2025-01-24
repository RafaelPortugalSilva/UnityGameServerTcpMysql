using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnityGameServerTcpMysql
{
    class Program
    {
        static TcpServer tcpServer;
        static int tcpPort = 7000;
        static string serverIP;
        static DatabaseManager database = new DatabaseManager();

        static void Main(string[] args)
        {
            DebugConsole.Message("Iniciando Servidor...");

            try
            {
                tcpServer = new TcpServer(tcpPort);
                tcpServer.Start();
            }
            catch (Exception e)
            {
                DebugConsole.Message("Error: " + e.Message);
                DebugConsole.WriteLog();
                Environment.Exit(0);
            }

           if(database.Init() == "OK")
           {
                DebugConsole.Message("Banco de Dados Conecatado Com Sucesso.");
           }
            else
            {
                DebugConsole.WriteLog();
                Environment.Exit(0);
            }
            
            Console.Read();
        }

        
    }
}
