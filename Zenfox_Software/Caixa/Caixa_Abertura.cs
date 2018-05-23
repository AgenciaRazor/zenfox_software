using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenfox_Software.caixa
{
    public partial class Caixa_Abertura : Form
    {
        public Boolean fechou = false;
        private Int32 id_usuario = 0;

        public Caixa_Abertura(Int32 id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            textBox1.Focus();
        }

        private void Caixa_Abertura_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') &&
              (e.KeyChar != ',' && e.KeyChar != '.' &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!textBox1.Text.Contains(','))
                        {
                            e.KeyChar = ',';
                        }
                        else
                        {
                            e.KeyChar = (Char)0;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){


                Double valor = 0;

                if (textBox1.Text.Length > 0)
                    valor = Double.Parse(textBox1.Text);

                if (MessageBox.Show("Deseja realmente abrir o caixa com valor de R$ "+ valor +" ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes){
                    Zenfox_Software_OO.Caixa.Caixa cmd = new Zenfox_Software_OO.Caixa.Caixa();
                    cmd.abrir_caixa(new Zenfox_Software_OO.Caixa.Entidade_Caixa() { usuario = this.id_usuario,valor_abertura = valor });
                    this.fechou = true;
                    this.Close();
                }

            }
        }
    }
}
