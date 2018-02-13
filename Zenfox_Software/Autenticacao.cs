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
    public partial class Autenticacao : Form
    {
        public Autenticacao()
        {
            InitializeComponent();
        }

        

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            Zenfox_Software_OO.Cadastros.Entidade_Usuario item = new Zenfox_Software_OO.Cadastros.Entidade_Usuario();

            Zenfox_Software_OO.Cadastros.Usuario cmd = new Zenfox_Software_OO.Cadastros.Usuario();
            Int32 id = cmd.autenticacao(item);

            if(id > 0)
            {
                
            }
            else
            {
                MessageBox.Show("Usuario ou senha invalidos !");
            }

        }
    }
}
