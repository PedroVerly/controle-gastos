using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ControleGastos.Controllers
{
    class Financas_DB
    {
        private string stringDeConexao = "server=localhost; userid=root; password=; database=gastos; SslMode=none";
        private MySqlConnection conexao = null;
        private MySqlCommand comando;
        
        public DataTable Exibir()
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();

                comando = new MySqlCommand("SELECT * FROM lancamentos", conexao);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

                DataTable DT = null;

                adapter.Fill(DT);

                return DT;

            }
            catch(Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirDespesas()
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();                
                comando = new MySqlCommand("SELECT * FROM lancamentos WHERE lan_tipo_CR = 'D'", conexao);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

                DataTable DT = new DataTable();

                adapter.Fill(DT);

                return DT;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirDespesasFiltroData(string pDaData, string pAteData)
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();
                comando = new MySqlCommand("SELECT * FROM lancamentos WHERE lan_tipo_CR = 'D' AND lan_data_DT BETWEEN '"+ pDaData + "''" + pAteData + "';", conexao);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

                DataTable DT = new DataTable();

                adapter.Fill(DT);                
                return DT;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirSomatorioDespesasFiltroData(string pDaData, string pAteData)
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();
                comando = new MySqlCommand("SELECT sum(lan_valor_DB) as sum FROM lancamentos WHERE lan_tipo_CR = 'D' AND lan_data_DT BETWEEN '" + pDaData + "''" + pAteData + "';", conexao);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

                DataTable DT = new DataTable();

                adapter.Fill(DT);
               
                return DT;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirSomatorioDespesas()
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();
                comando = new MySqlCommand("SELECT sum(lan_valor_DB) as sum FROM lancamentos WHERE lan_tipo_CR = 'D'", conexao);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

                DataTable DT = new DataTable();

                adapter.Fill(DT);

                return DT;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirReceitas()
        {
            try
            {
              

                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();                            
                comando = new MySqlCommand("SELECT * FROM lancamentos WHERE lan_tipo_CR = 'R'", conexao);
                
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;
                
                DataTable DT = new DataTable();

                adapter.Fill(DT);
                

                return DT;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirReceitasFiltroData(string pDaData, string pAteData)
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();
                comando = new MySqlCommand("SELECT * FROM lancamentos WHERE lan_tipo_CR = 'R' AND lan_data_DT BETWEEN '" + pDaData + "''" + pAteData + "';", conexao);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

                DataTable DT = new DataTable();

                adapter.Fill(DT);

                return DT;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirSomatorioReceitas()
        {
            try
            {


                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();
                comando = new MySqlCommand("SELECT sum(lan_valor_DB) as sum FROM lancamentos WHERE lan_tipo_CR = 'R'", conexao);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

                DataTable DT = new DataTable();

                adapter.Fill(DT);


                return DT;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable ExibirSomatorioReceitasFiltroData(string pDaData, string pAteData)
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();
                comando = new MySqlCommand("SELECT sum(lan_valor_DB) as sum FROM lancamentos WHERE lan_tipo_CR = 'R' AND lan_data_DT BETWEEN '" + pDaData + "''" + pAteData + "';", conexao);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

                DataTable DT = new DataTable();

                adapter.Fill(DT);

                return DT;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Incluir(string pTipo, string pDescricao, double pValor, string pData)
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                conexao.Open();
                string SQL = "insert into lancamentos" +
                    "(lan_descricao_TX,lan_data_DT,lan_valor_DB,lan_tipo_CR) " +
                    "values( '" + pDescricao + "','" + pData + "'," + pValor + ",'" + pTipo + "');";
                comando = new MySqlCommand();
                comando.Connection = conexao;
                comando.CommandText = SQL;
                comando.ExecuteNonQuery();

                

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(int pCodigo)
        {
            try
            {
                conexao = new MySqlConnection(stringDeConexao);
                comando = new MySqlCommand("DELETE FROM lancamentos WHERE id_lancamentos = " + pCodigo);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
