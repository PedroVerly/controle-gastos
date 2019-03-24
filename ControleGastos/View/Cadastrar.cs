using ControleGastos.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleGastos.View
{
    public partial class Cadastrar : Form
    {
        private string strTipo = "";
        private double dblValor = 0;
        private string strData = "";
        private string strDescricao = "";
        private Financas_DB financas = new Financas_DB();

        public Cadastrar()
        {
            InitializeComponent();
        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {
            cmbTipoCadastro.Items.Add("Receita");
            cmbTipoCadastro.Items.Add("Despesa");
            dtCadastro.Value = DateTime.Now;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSairCadastro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            

            if(cmbTipoCadastro == null)
            {
                MessageBox.Show("Escolha um Tipo de Informação", this.Text , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtValorCadastro.Text == "")
            {
                MessageBox.Show("Preencha o campo referente ao valor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Preencha o campo referente a descrição", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTipoCadastro.SelectedIndex == 0)
            {
                strTipo = "R";
            }
            else if(cmbTipoCadastro.SelectedIndex == 1)
            {
                strTipo = "D";
            }

            dblValor = double.Parse(txtValorCadastro.Text);

            if (dblValor <= 0)
            {
                MessageBox.Show("Preencha o campo VALOR com um número valído", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime date = dtCadastro.Value;

            strData = date.ToString("yyyy-MM-dd");
            strDescricao = txtDescricao.Text;

            try
            {
                financas.Incluir(strTipo, strDescricao, dblValor, strData);
            }catch(Exception erro)
            {
                MessageBox.Show("Erro: " + erro.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Cadastrado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
