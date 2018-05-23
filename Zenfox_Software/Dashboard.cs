using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenfox_Software
{
    public partial class Dashboard : Form
    {
        private Int32 id = 0;

        public Dashboard(Int32 id)
        {
            InitializeComponent();
            this.id = id;
           // Cadastros.Configuracao cmd = new Cadastros.Configuracao();
           // cmd.ShowDialog();
           // Application.Exit();
            //btnprodutos_Click(new object(), new EventArgs());
        }


        private void btnprodutos_Click(object sender, EventArgs e)
        {
            Cadastros.Produto cmd = new Cadastros.Produto();
            cmd.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e){

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Cadastros.Fornecedor cmd = new Cadastros.Fornecedor();
            cmd.ShowDialog();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            caixa.Caixa cmd = new caixa.Caixa(this.id);
            cmd.ShowDialog();
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.Configuracao cmd = new Cadastros.Configuracao();
            cmd.ShowDialog();
        }

        private void btn_abrir_caixa_Click(object sender, EventArgs e)
        {
            caixa.Caixa cmd = new caixa.Caixa(this.id);
            cmd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gerenciamento.Vendas cmd = new Gerenciamento.Vendas();
            cmd.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             //= DateTime.Now.ToShortTimeString();

            DateTime data = new DateTime(); //29/05/2009  
            data = DateTime.Now;
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            lbl_dia_semana.Text = dtfi.GetDayName(data.DayOfWeek);
            lbl_hora.Text = data.ToShortTimeString();
            lbl_data.Text = data.ToShortDateString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cadastros.Produto cmd = new Cadastros.Produto();
            cmd.ShowDialog();
        }
    }
}
