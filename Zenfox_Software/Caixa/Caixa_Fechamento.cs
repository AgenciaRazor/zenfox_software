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
    public partial class Caixa_Fechamento : Form
    {
        Zenfox_Software_OO.Cadastros.Entidade_Vendas venda = new Zenfox_Software_OO.Cadastros.Entidade_Vendas();
        Zenfox_Software_OO.Cadastros.Vendas cmd_venda = new Zenfox_Software_OO.Cadastros.Vendas();
        public Boolean vendido = false;

        public Caixa_Fechamento(Int32 id)
        {
            InitializeComponent();

            this.venda.id = id;

            venda = cmd_venda.seleciona(venda);

            lbl_subtotal.Text = "R$ " + venda.valor_total;
            //lbl_subtotal.Text = "R$ " + decimal.Parse(item.valor_total.ToString());
            
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", "SAT.Inicializar");

            txt_dinheiro.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar esta venda ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {

                //Aqui vai ficar a validação da Venda
                if (true)
                {
                    String string_sat = "";


                    double aliquota_icms = 0.02;

                    Zenfox_Software_OO.ACBR acbr = new Zenfox_Software_OO.ACBR();

                    /* 
                     *   1 - Iniciar Montagem
                     *   2 - Identificação
                     *   3 - Emitente
                     *   4 - Destinatario
                     *   5 - Adiciona Produto
                     *   6 - Total
                     *   7 - Pagamentos
                     *   8 - Dados Adicionais
                     *   9 - Gera Cupom
                    */
                    string_sat += acbr.inicia_montagem("7.0");
                    string_sat += acbr.identificacao("11111111111111", "123456", "1");
                    string_sat += acbr.emitente("11111111111111", "111111111111", "");
                    string_sat += acbr.destinatario("", "");
                    string_sat += acbr.adiciona_produto(1, "12345678", "1", "", "teste", "21050090", "5102", 1, Double.Parse(txt_dinheiro.Text), 0, 0, aliquota_icms);

                    string_sat += acbr.total(((5 * 1)* 0.2),0);
                    

                    Int32 pagamento = 1;

                    if (Double.Parse(txt_dinheiro.Text) > 0) {
                        string_sat += acbr.formas_pagamento(1, pagamento, Double.Parse(txt_dinheiro.Text));
                        pagamento++;
                    }

                    string_sat += acbr.dados_adicionais("");
                    String x = acbr.emite_sat(venda.id,string_sat);

                    if (x == "ok"){
                        MessageBox.Show("Venda realizada com sucesso !");
                        vendido = true;
                        this.Close();
                    }
                }
                else
                {

                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Moeda(txt_dinheiro);
            calcula_totais();
        }


        public static void Moeda(TextBox txt)
        {

            string m = string.Empty;
            Double v = 0;
            try
            {
                m = txt.Text.Replace(",", "").Replace(",", "");
                if (m.Equals(""))
                {
                    m = "";
                }
                m = m.PadLeft(3, '0');
                if (m.Length > 3 & m.Substring(0, 1) == "0")
                {
                    m = m.Substring(1, m.Length - 1);
                }
                v = Convert.ToDouble(m) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

            }
            catch (Exception)
            {
                txt.Text = "0,00";
            }
        }





        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txt_dinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
                e.Handled = true;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Moeda(txt_cartao_debito);
            calcula_totais();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
                e.Handled = true;
        }

        private void txt_cheque_TextChanged(object sender, EventArgs e)
        {
            Moeda(txt_cheque);
            calcula_totais();
        }

        private void txt_cheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
                e.Handled = true;
        }

        private void txt_cartao_credito_TextChanged(object sender, EventArgs e)
        {
            Moeda(txt_cartao_credito);
            calcula_totais();
        }

        private void txt_cartao_credito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
                e.Handled = true;
        }

        public void calcula_totais()
        {
            Double troco = 0;
            Double desconto = 0;
            Double total = Convert.ToDouble(txt_dinheiro.Text);
            total += Convert.ToDouble(txt_cartao_debito.Text);
            total += Convert.ToDouble(txt_cartao_credito.Text);
            total += Convert.ToDouble(txt_cheque.Text);

            if (txt_desconto_percentual.Text.Length > 0)
                desconto = venda.valor_total * (Convert.ToDouble(txt_desconto_percentual.Text) / 100);

            if (txt_desconto.Text.Length > 0)
                desconto = venda.valor_total - Convert.ToDouble(txt_desconto.Text);

            troco = total - (venda.valor_total - desconto);
            if (troco <= 0)
                troco = 0;


            lbl_desconto.Text = "R$ " + Convert.ToDouble(desconto).ToString();
            lbl_troco.Text = "R$ " + Convert.ToDouble(troco).ToString();
            lbl_pagamento.Text = "R$ " + Convert.ToDouble(total).ToString();
            lbl_total_pagar.Text = "R$ " + (venda.valor_total - desconto);



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txt_desconto.Text = "";
            txt_desconto_percentual.Text = txt_desconto_percentual.Text.Replace(",", "").Replace(".", "");
            calcula_totais();
        }

        private void txt_desconto_TextChanged(object sender, EventArgs e)
        {
            txt_desconto_percentual.Text = "";
            Moeda(txt_desconto);
            calcula_totais();
        }

        private void txt_desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
                e.Handled = true;
        }
    }
}
