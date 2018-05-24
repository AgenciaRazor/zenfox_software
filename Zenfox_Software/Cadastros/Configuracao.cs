using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenfox_Software.Cadastros
{
    public partial class Configuracao : Form
    {
        public Configuracao()
        {
            InitializeComponent();
            lista_impressoras();

            Zenfox_Software_OO.Cadastros.Entidade_Configuracao item = new Zenfox_Software_OO.Cadastros.Entidade_Configuracao();

            Zenfox_Software_OO.Cadastros.Configuracao cmd = new Zenfox_Software_OO.Cadastros.Configuracao();
            item = cmd.seleciona(item);

            cb_validar_ncm.Checked = item.valida_ncm;
            
            
        }

        public void atualiza()
        {
            Zenfox_Software_OO.Cadastros.Entidade_Configuracao item = new Zenfox_Software_OO.Cadastros.Entidade_Configuracao();
            Zenfox_Software_OO.Cadastros.Configuracao cmd = new Zenfox_Software_OO.Cadastros.Configuracao();

            item.valida_ncm = cb_validar_ncm.Checked;
            cmd.atualiza(item);
        }


        public void lista_impressoras()
        {
            combo_impressora.Items.Clear();

            foreach (string impressora in PrinterSettings.InstalledPrinters)
            {
                combo_impressora.Items.Add(impressora);
            }
        }

        private void Configuracao_Load(object sender, EventArgs e){
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            lista_impressoras();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                Zenfox_Software_OO.ACBR acbr = new Zenfox_Software_OO.ACBR();
                acbr.configura_acbr("", "", "", "");
                MessageBox.Show("SAT Configurado com sucesso !");
            }
            catch
            {
                MessageBox.Show("Falha ao configurar SAT !");
            }
        }

        private void cb_validar_ncm_CheckedChanged(object sender, EventArgs e)
        {
            atualiza();
        }
    }
}
