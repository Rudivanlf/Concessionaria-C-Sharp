using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Concessionária
{
    internal class CarroDAL
    {
        private static String conexao = "server=127.0.0.1;port=3306;user=root;password=mariadb;database=carros";
        private static MySqlConnection conn = new MySqlConnection(conexao);
        private static MySqlCommand strSQL;
        private static MySqlDataReader result;
        public static void conecta()
        {
            try
            {
                conn.Open();
            }
            catch(Exception)
            {
                Erro.setMsg("Não foi possível se conectar ao Banco de Dados.");
            }
        }
        public static void desconecta() 
        {
            conn.Close();
        }

        public static void createCarro(Carro carro)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                String aux = "insert into tabcarros(codigo,modelo,marca, ano, km) values (@codigo,@modelo,@marca,@ano, @km)";

                strSQL = new MySqlCommand(aux, conn);
                strSQL.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = carro.getCodigo();
                strSQL.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = carro.getModelo();
                strSQL.Parameters.Add("@marca", MySqlDbType.VarChar).Value = carro.getMarca();
                strSQL.Parameters.Add("@ano", MySqlDbType.VarChar).Value = carro.getAno();
                strSQL.Parameters.Add("@km", MySqlDbType.VarChar).Value = carro.getKm();


                Erro.setErro(false);
                try
                {
                    strSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Erro.setMsg("Erro ao cadastrar os dados.");
                }
            }
        }
        public static void readCarro(Carro carro)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                String aux = "select * from tabcarros where codigo = @codigo";

                strSQL = new MySqlCommand(aux, conn);
                strSQL.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = carro.getCodigo();
                result = strSQL.ExecuteReader();

                Erro.setErro(false);
                if (result.Read())
                {
                    carro.setModelo(result.GetString(1));
                    carro.setMarca(result.GetString(2));
                    carro.setAno(result.GetString(3));
                    carro.setKm(result.GetString(4));
                }
                else
                    Erro.setMsg("Carro não cadastrado");
            }
        }
        public static void updateCarro(Carro carro)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                String aux = "update tabcarros set modelo=@modelo, marca=@marca, km=@km, ano=@ano where codigo=@codigo";

                strSQL = new MySqlCommand(aux, conn);
                strSQL.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = carro.getKm();
                strSQL.Parameters.Add("@marca", MySqlDbType.VarChar).Value = carro.getMarca();
                strSQL.Parameters.Add("@ano", MySqlDbType.VarChar).Value = carro.getAno();
                strSQL.Parameters.Add("@km", MySqlDbType.VarChar).Value = carro.getKm();
                strSQL.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = carro.getCodigo();

                strSQL.ExecuteNonQuery();
            }
        }
        public static void deleteCarro(Carro carro)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                String aux = "delete from tabcarros where codigo = @codigo";

                strSQL = new MySqlCommand(aux, conn);
                strSQL.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = carro.getCodigo();
                strSQL.ExecuteNonQuery();
            }
        }
    }
}
