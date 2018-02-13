using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenfox_Software.Cadastros
{
    public partial class Produto_Cadastro : Form
    {
        public Int32 id { get; set; }
        public Produto_Cadastro()
        {
            InitializeComponent();

            Zenfox_Software_OO.sistema s = new Zenfox_Software_OO.sistema();
            s.preenche_combobox(cb_fornecedor, "fornecedor", "id", "fantasia", "", "fantasia");

        }

        public void preenche_campos()
        {
            Zenfox_Software_OO.Cadastros.Produto cmd = new Zenfox_Software_OO.Cadastros.Produto();
            Zenfox_Software_OO.Cadastros.Entidade_Produto item = cmd.seleciona_entidade(new Zenfox_Software_OO.Cadastros.Entidade_Produto() { id = this.id });

            txtData.Text = item.data_cadastro;
            txt_nome_produto.Text = item.nome_produto;
            txt_ean.Text = item.ean;

            txtValor_Compra.Text = item.valor_compra.ToString();
            txtPreco_Venda.Text = item.valor_venda.ToString();
            txtPreco_Atacado.Text = item.valor_venda_atacado.ToString();
            txtPreco_Venda_Margem.Text = item.valor_venda_margem.ToString();
            txtPreco_Atacado_Margem.Text = item.valor_venda_atacado_margem.ToString();

            txtNCM.Text = item.ncm;

            if (item.cfop == 5101)
                txtCFOP.SelectedIndex = txtCFOP.Items.IndexOf("5101 - Venda de produção do estabelecimento");

            if (item.cfop == 5102)
                txtCFOP.SelectedIndex = txtCFOP.Items.IndexOf("5102 - Venda de mercadoria adquirida ou recebida de terceiros");

            if (item.cfop == 5103)
                txtCFOP.SelectedIndex = txtCFOP.Items.IndexOf("5103 - Venda de produção do estabelecimento, efetuada fora do estabelecimento");

            if (item.cfop == 5405)
                txtCFOP.SelectedIndex = txtCFOP.Items.IndexOf("5405 - Venda de mercadoria adquirida ou recebida de terceiros em operação com mercadoria sujeita ao regime de substituição tributária, na condição de contribuinte substituído");





            txt_estoque.Text = item.estoque.ToString();
            txt_estoque_maximo.Text = item.estoque_maximo.ToString();
            txt_estoque_minimo.Text = item.estoque_minimo.ToString();

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Produto_Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zenfox_Software_OO.Cadastros.Entidade_Produto item = new Zenfox_Software_OO.Cadastros.Entidade_Produto();

            // Validando NCM
            if (txtNCM.Text.Length >= 8)
            {
                //Validando CFOP
                try
                {
                    if (Int32.Parse(txtCFOP.SelectedItem.ToString().Split('-')[0].Trim()) > 0)
                    {
                        //Validando EAN
                        if (txt_ean.Text != null && txt_ean.Text != "")
                        {
                            Zenfox_Software_OO.ACBR acbr = new Zenfox_Software_OO.ACBR();

                            if (acbr.valida_ncm(txtNCM.Text))
                            {


                                item.id = this.id;

                                //Dados Produto
                                try
                                {
                                    if (cb_fornecedor.SelectedValue.ToString() != null && cb_fornecedor.SelectedValue.ToString() != "")
                                        item.fornecedor = Int32.Parse(cb_fornecedor.SelectedValue.ToString());
                                    else
                                        item.fornecedor = 0;
                                }
                                catch
                                {
                                    item.fornecedor = 0;
                                }

                                item.nome_produto = txt_nome_produto.Text;
                                item.ean = txt_ean.Text;
                                #region Valores

                                if (txtValor_Compra.Text.Length > 0)
                                    item.valor_compra = Double.Parse(txtValor_Compra.Text);
                                else
                                    item.valor_compra = 0;


                                if (txtPreco_Venda.Text.Length > 0)
                                    item.valor_venda = Double.Parse(txtPreco_Venda.Text);
                                else
                                    item.valor_compra = 0;


                                if (txtPreco_Venda_Margem.Text.Length > 0)
                                    item.valor_venda_margem = Double.Parse(txtPreco_Venda_Margem.Text);
                                else
                                    item.valor_venda_margem = 0;

                                if (txtPreco_Atacado.Text.Length > 0)
                                    item.valor_venda_atacado = Double.Parse(txtPreco_Atacado.Text);
                                else
                                    item.valor_venda_atacado = 0;

                                if (txtPreco_Atacado_Margem.Text.Length > 0)
                                    item.valor_venda_atacado_margem = Double.Parse(txtPreco_Atacado_Margem.Text);
                                else
                                    item.valor_venda_atacado_margem = 0;
                                #endregion

                                item.cfop = Int32.Parse(txtCFOP.SelectedItem.ToString().Split('-')[0].Trim());
                                item.ncm = txtNCM.Text;

                                #region Estoque

                                if (txt_estoque_inicial.Text.Length > 0)
                                    item.estoque_inicial = Double.Parse(txt_estoque_inicial.Text);
                                else
                                    item.estoque_inicial = 0;

                                if (txt_estoque_minimo.Text.Length > 0)
                                    item.estoque_minimo = Double.Parse(txt_estoque_minimo.Text);
                                else
                                    item.estoque_minimo = 0;

                                if (txt_estoque_maximo.Text.Length > 0)
                                    item.estoque_maximo = Double.Parse(txt_estoque_maximo.Text);
                                else
                                    item.estoque_maximo = 0;

                                if (txt_estoque.Text.Length > 0)
                                    item.estoque = Double.Parse(txt_estoque.Text);
                                else
                                    item.estoque = 0;

                                #endregion

                                Zenfox_Software_OO.Cadastros.Produto cmd = new Zenfox_Software_OO.Cadastros.Produto();
                                try
                                {
                                    cmd.salva(item);
                                    MessageBox.Show("Cadastro realizado com sucesso !");
                                    this.Close();
                                }
                                catch (Exception ee)
                                {
                                    MessageBox.Show(ee.Message);
                                }

                            }
                            else
                            {
                                MessageBox.Show("NCM Inválido !");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você precisa informar o Código Barras(EAN) deste produto");
                            tabControl1.SelectedTab = tabPage1;
                            txt_ean.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Você precisa informar o CFOP deste produto");
                        tabControl1.SelectedTab = tabPage2;
                        txtCFOP.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Você precisa informar o CFOP deste produto");
                    tabControl1.SelectedTab = tabPage2;
                    txtCFOP.Focus();
                }
            }
            else
            {
                MessageBox.Show("Você precisa informar o NCM deste produto");
                tabControl1.SelectedTab = tabPage2;
                txtNCM.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_nome_produto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtData_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Fornecedor_Cadastro f = new Fornecedor_Cadastro();
            f.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtValor_Compra_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtValor_Compra.Text.Contains(','))
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCFOP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtPreco_Venda_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtValor_Compra.Text.Contains(','))
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

        private void txtPreco_Atacado_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtValor_Compra.Text.Contains(','))
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

        private void txtPreco_Venda_Margem_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtValor_Compra.Text.Contains(','))
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

        private void txtPreco_Atacado_Margem_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtValor_Compra.Text.Contains(','))
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_estoque_minimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!txtValor_Compra.Text.Contains(','))
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!txtValor_Compra.Text.Contains(','))
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!txtValor_Compra.Text.Contains(','))
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



    }
}
