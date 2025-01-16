using System;
using System.Net.Http;

namespace UnityGameServerTcpMysql
{
    public class Utils
    {
        public static string GetPublicIP()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Faz uma requisição HTTP para um serviço que retorna o IP público
                    string ip = client.GetStringAsync("https://api.ipify.org").GetAwaiter().GetResult();
                    return ip;
                }
                catch (Exception ex)
                {
                    DebugConsole.Message("Erro ao obter IP público: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
