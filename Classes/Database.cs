using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleEx01._0._0.Classes
{
    class Database : IDisposable
    {
        private readonly MySqlConnection connec;

        public Database()
        {
            connec = new MySqlConnection(ConfigurationManager.ConnectionStrings["connec"].ConnectionString);
            bool firsttry = true;
            if (firsttry == true)
            {
                try
                {
                    connec.Open();
                    Console.WriteLine("Conectado!");
                    Console.WriteLine(" ");
                    firsttry = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não foi possível se conectar ao banco de dados");
                    Console.ReadLine();
                }
            }
        }

        public void ExcCommand(string StrQuery)
        {
            var comm = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = connec
            };  
            comm.ExecuteNonQuery();
        }
        
        public MySqlDataReader Return (string StrQuery)
        {
            var comm = new MySqlCommand(StrQuery, connec);
            return comm.ExecuteReader();
        }
        public void Dispose()
        {
            if(connec.State==ConnectionState.Open)
            connec.Close();
        }
    }
}