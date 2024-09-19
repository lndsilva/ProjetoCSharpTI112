using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MultJogos
{
    class Conexao
    {
        private static String conexao = "server=localhost;port=3306;database=dbti112;uid=ti112;pwd=123456";
        private static MySqlConnection conn;

        public static MySqlConnection obterConexao()
        {
            conn = new MySqlConnection(conexao);

            try
            {
                conn.Open();
            }
            catch (MySqlException)
            {
                conn = null;
            }

            return conn;
        }
        public static void fecharConexao()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
