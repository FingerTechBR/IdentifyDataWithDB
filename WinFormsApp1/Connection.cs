using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    internal class Connection
    {
        readonly string connection = "SERVER=localhost; DATABASE=test_bench; UID=root; PWD= ";

        public MySqlConnection con = null;

        public void AbrirConexao()
        {
            try
            {
                con = new MySqlConnection(connection);
                con.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao conectar" + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                con = new MySqlConnection(connection);
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao fechar conexão" + ex.Message);
            }
        }
    }
}
