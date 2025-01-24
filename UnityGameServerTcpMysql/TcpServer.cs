using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UnityGameServerTcpMysql
{
    public class TcpServer
    {
        private TcpListener tcpListener;
        private Thread listenerThread;

        public TcpServer(int port)
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
            listenerThread = new Thread(new ThreadStart(ListenForClients));
        }

        public void Start()
        {
            tcpListener.Start();
            listenerThread.Start();
            DebugConsole.Message("Servidor iniciado: "+Utils.GetPublicIP());
        }

        private void ListenForClients()
        {
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
               DebugConsole.Message("Cliente conectado!");

                // Processa o cliente de forma assíncrona
                ThreadPool.QueueUserWorkItem(HandleClientComm, tcpClient);
            }
        }

        private void HandleClientComm(object obj)
        {
            TcpClient tcpClient = obj as TcpClient;
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[4096];

            try
            {
                while (true)
                {
                    int bytesRead;
                    if ((bytesRead = stream.Read(buffer, 0, buffer.Length)) == 0)
                    {
                        break; // Desconectar se não houver mais dados
                    }

                    string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                   DebugConsole.Message("Recebido: " + dataReceived);

                    // Enviar de volta ao cliente
                    byte[] dataToSend = Encoding.UTF8.GetBytes("Mensagem recebida: " + dataReceived);
                    stream.Write(dataToSend, 0, dataToSend.Length);
                }
            }
            catch (Exception ex)
            {
               DebugConsole.Message("Erro: " + ex.Message);
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}
