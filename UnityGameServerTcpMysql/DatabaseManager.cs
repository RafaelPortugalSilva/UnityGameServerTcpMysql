﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace UnityGameServerTcpMysql
{
    public  class DatabaseManager
    {
        // Variáveis para a conexão MySQL
        string server = "localhost";        // Endereço do servidor (localhost ou IP do servidor)
        string database = "gameserver";         // Nome do banco de dados
        string user = "root";               // Usuário do banco
        string password = "";   // Senha do banco
        string port = "3306";               // Porta do MySQL (3306 é a padrão)
        string sslMode = "None";            // SSL Mode (None, Preferred, etc.)

        public string GetConectionString()
        {
            return string.Format(
            "Server={0};Database={1};User={2};Password={3};Port={4};SslMode={5};",
            server, database, user, password, port, sslMode
            );
        }

        public string Init()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(GetConectionString()))
                {
                    connection.Open();
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                DebugConsole.Message(ex.Message, InfoType.Error);
                return "Error";
            }
        }
    }
}
