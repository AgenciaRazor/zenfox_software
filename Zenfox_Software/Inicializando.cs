using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenfox_Software
{
    public partial class Inicializando : Form
    {
        public Inicializando()
        {
            InitializeComponent();

           //String string_sat = "";
           //
           //Zenfox_Software_OO.ACBR acbr = new Zenfox_Software_OO.ACBR();
           //
           ///* 
           // *   1 - Iniciar Montagem
           // *   2 - Identificação
           // *   3 - Emitente
           // *   4 - Destinatario
           // *   5 - Adiciona Produto
           // *   6 - Total
           // *   7 - Pagamentos
           // *   8 - Dados Adicionais
           // *   9 - Gera Cupom
           //*/
           //String aux;
           //aux = acbr.inicia_montagem("0.07");
           //string_sat = string_sat +@" " +aux;
           //string_sat += acbr.identificacao("11111111111111", "123456", "1");
           //string_sat += acbr.emitente("11111111111111", "111111111111", "");
           //string_sat += @acbr.destinatario("", "");
           //string_sat += acbr.adiciona_produto(1, "1","", "", "teste", "21050090", "5102", 1, 10, 0, 0,0.2);
           //
           //string_sat += acbr.total(0.2, 0);
           //
           //Int32 pagamento = 1;
           //
           ////if (Double.Parse(txt_dinheiro.Text) > 0)
           //if (Double.Parse("10") > 0)
           //{
           //    string_sat += acbr.formas_pagamento(1, pagamento, Double.Parse("10"));
           //    pagamento++;
           //}
           //
           //string_sat += acbr.dados_adicionais("");
           //acbr.emite_sat(string_sat);

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
                    Dashboard dashboard = new Dashboard(1);
                    dashboard.Show();
                    atualizacao.RunWorkerAsync();
                }
                
            }
            catch (Exception ee)
            {
               // MessageBox.Show(ee.Message);
                Configura_Database c_database = new Configura_Database();
                c_database.ShowDialog();
                timer1.Enabled = true;
            }
            
        }

        private void atualizacao_DoWork(object sender, DoWorkEventArgs e)
        {
            

            while (true)
            {

                Thread.Sleep(1000);
                MessageBox.Show("Ta porra viado !");

            }

        }
    }
}
