using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//Inserido manualmente

namespace CeuEscuro.DAL
{
    public class Conexao
    {
        //Variaveis
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        //Metodos
        public void Conectar()
        {
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CeuEscuro;Integrated Security=True;");
                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Deu o erro a seguir!" + ex.Message);
            }
        }
        public void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Deu o erro a seguir!" +ex.Message);
            }
        }
    }
}
