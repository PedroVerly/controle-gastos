using ControleGastos.Controllers;
using ControleGastos.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleGastos
{
   

    public partial class Principal : Form
    {

        private Boolean optData = false;
        Financas_DB financas = new Financas_DB();
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //dgReceitas.DataSource = financas.ExibirReceitas();
            //dgDespesas.DataSource = financas.ExibirDespesas();
            dtDaData.Value = DateTime.Parse("01/01/2019");
            dtAteData.Value = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
            dtDaData.Enabled = false;
            dtAteData.Enabled = false;
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            Cadastrar  cadastrar = new Cadastrar();
            cadastrar.Show();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTreceita = new DataTable();
            DataTable DTdespesa = new DataTable();
            double totalDespesa = 0;
            double totalReceita = 0;
            financas.ExibirDespesas();
            if (optData == false)
            {                
                dgReceitas.DataSource = financas.ExibirReceitas();
                dgDespesas.DataSource = financas.ExibirDespesas();
                DTreceita = financas.ExibirSomatorioReceitas();
                if (DTreceita.Rows[0]["sum"].ToString() != "")
                    totalReceita = double.Parse(DTreceita.Rows[0]["sum"].ToString());
                txtTotalReceitas.Text = totalReceita.ToString("C");
                DTdespesa = financas.ExibirSomatorioDespesas();
                if (DTdespesa.Rows[0]["sum"].ToString() != "")
                    totalDespesa = double.Parse(DTdespesa.Rows[0]["sum"].ToString());
                txtTotalDespesas.Text = totalDespesa.ToString("C");
                txtSaldo.Text = (totalReceita - totalDespesa).ToString("C");
            }
            else
            {                
                dgReceitas.DataSource = financas.ExibirReceitasFiltroData(DateTime.Parse(dtDaData.ToString()).ToString("yyyy-MM-dd"), DateTime.Parse(dtAteData.ToString()).ToString("yyyy-MM-dd"));
                dgDespesas.DataSource = financas.ExibirDespesasFiltroData(DateTime.Parse(dtDaData.ToString()).ToString("yyyy-MM-dd"), DateTime.Parse(dtAteData.ToString()).ToString("yyyy-MM-dd"));
                DTreceita = financas.ExibirSomatorioReceitasFiltroData(DateTime.Parse(dtDaData.ToString()).ToString("yyyy-MM-dd"), DateTime.Parse(dtAteData.ToString()).ToString("yyyy-MM-dd"));
                if (DTreceita.Rows[0]["sum"].ToString() != "")
                    totalReceita = double.Parse(DTreceita.Rows[0]["sum"].ToString());
                txtTotalReceitas.Text = double.Parse(DTreceita.Rows[0]["sum"].ToString()).ToString("C"); txtTotalReceitas.Text = totalReceita.ToString("C");
                DTdespesa = financas.ExibirSomatorioDespesasFiltroData(DateTime.Parse(dtDaData.ToString()).ToString("yyyy-MM-dd"), DateTime.Parse(dtAteData.ToString()).ToString("yyyy-MM-dd"));
                if (DTdespesa.Rows[0]["sum"].ToString() != "")
                    totalDespesa = double.Parse(DTdespesa.Rows[0]["sum"].ToString());
                txtTotalDespesas.Text = totalDespesa.ToString("C");
                txtSaldo.Text = (totalReceita - totalDespesa).ToString("C");
            }
        }

        private void checkData_CheckedChanged(object sender, EventArgs e)
        {
            if(checkData.Checked == true)
            {
                dtDaData.Enabled = true;
                dtAteData.Enabled = true;
                optData = true;
            }
            else
            {
                dtDaData.Enabled = false;
                dtAteData.Enabled = false;
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("tú gosta não gosta?", this.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Hum boiola");
            }
            
        }
    }
}
