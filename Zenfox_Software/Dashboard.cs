using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenfox_Software
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

           // Cadastros.Configuracao cmd = new Cadastros.Configuracao();
           // cmd.ShowDialog();
           // Application.Exit();
            btnprodutos_Click(new object(), new EventArgs());
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
            caixa.Caixa cmd = new caixa.Caixa();
            cmd.ShowDialog();
        }
    }
}
