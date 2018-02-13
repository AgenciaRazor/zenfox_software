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
    public partial class Inicializando : Form
    {
        public Inicializando()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            try{
                Zenfox_Software_OO.data.bd_postgres bd = new Zenfox_Software_OO.data.bd_postgres();
                bd.localdb();

                Zenfox_Software_OO.Cadastros.Empresa cmd = new Zenfox_Software_OO.Cadastros.Empresa();
                if (cmd.verifica_primeiro_acesso())
                {
                    inicial inicial = new inicial();
                    inicial.ShowDialog();
                    timer1.Enabled = true;
                }
                else
                {
                    this.Visible = false;
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                }
                
            }
            catch (Exception ee)
            {
                Configura_Database c_database = new Configura_Database();
                c_database.ShowDialog();
                timer1.Enabled = true;
            }
            
        }
    }
}
