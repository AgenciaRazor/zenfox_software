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
    public partial class Caixa : Form
    {
        Int32 id_usuario = 0;
        Int32 id_produto = 0;
        Int32 n_item = 0;

        public Caixa(Int32 id)
        {
            InitializeComponent();
            txt_codigo_barras.Focus();


            dg_venda.Columns.Add("item", "Item");
            dg_venda.Columns.Add("descricao", "Descrição");
            dg_venda.Columns.Add("qtd", "Qtd");
            dg_venda.Columns.Add("valor", "Valor");
            dg_venda.Columns.Add("desconto", "Desconto");
            dg_venda.Columns.Add("total", "Total");

            if (id > 0)
            {
                this.id_usuario = id;
                verifica_caixa_aberto();
                this.Visible = false;
            }
            else
                autenticacao();
        }

        public void verifica_key_up_atalho(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                Pesquisa_Produto cmd = new Pesquisa_Produto();
                cmd.ShowDialog();

                if (cmd.id > 0)
                {
                    txt_codigo_barras.Text = cmd.codigo;
                    seleciona_produto(cmd.id, "");
                }
            }




            if (e.KeyCode == Keys.F2)
                finaliza_venda();

            if (e.KeyCode == Keys.F3)
                limpa_venda(false);

            if (e.KeyCode == Keys.F5)
                cancela_sat();
        }

        public void autenticacao()
        {
            this.Visible = false;
            Autentica_Caixa cmd = new Autentica_Caixa();
            cmd.ShowDialog();

            while (cmd.autentica == false && cmd.finaliza == false)
            {
                cmd.ShowDialog();
            }

            if (cmd.finaliza)
            {
                this.Close();
            }
            else
            {
                this.id_usuario = cmd.id;
                verifica_caixa_aberto();
                this.Visible = false;
            }
        }

        public void limpa_produto()
        {
            id_produto = 0;
            n_item = 0;
            txt_codigo_barras.Text = "";
            txt_descricao_produto.Text = "";
            txt_quantidade.Text = "0";
            lbl_valor_produto.Text = "R$ 0.00";
            txt_codigo_barras.Focus();

        }

        public void verifica_caixa_aberto()
        {
            Zenfox_Software_OO.Caixa.Caixa cmd = new Zenfox_Software_OO.Caixa.Caixa();

            if (cmd.verifica_caixa_aberto(new Zenfox_Software_OO.Caixa.Entidade_Caixa() { usuario = this.id_usuario }))
            {
                // Existe caixa em aberto
            }
            else
            {
                // Não existe caixa em aberto 

                if (MessageBox.Show("Este usuario não possui caixa em aberto, deseja abrir o caixa para este usuario ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    Caixa_Abertura cmd_caixa = new Caixa_Abertura(this.id_usuario);
                    cmd_caixa.ShowDialog();

                    if (cmd_caixa.fechou)
                    {

                    }
                    else
                    {
                        if (MessageBox.Show("O Sistema não pode prosseguir sem que o caixa esteja aberto, deseja abrir o caixa ? o sistema irá finalizar a sessão para este usuario ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        {
                            cmd_caixa = new Caixa_Abertura(this.id_usuario);
                            cmd_caixa.ShowDialog();

                            if (cmd_caixa.fechou)
                            {

                            }
                            else
                            {
                                this.id_usuario = 0;
                                autenticacao();
                            }
                        }
                        else
                        {
                            this.id_usuario = 0;
                            autenticacao();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("O Sistema não pode prosseguir sem que o caixa esteja aberto, deseja abrir o caixa ? o sistema irá finalizar a sessão para este usuario ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Caixa_Abertura cmd_caixa = new Caixa_Abertura(this.id_usuario);
                        cmd_caixa.ShowDialog();

                        if (cmd_caixa.fechou)
                        {

                        }
                        else
                        {
                            this.id_usuario = 0;
                            autenticacao();
                        }
                    }
                    else
                    {
                        this.id_usuario = 0;
                        autenticacao();
                    }
                }
            }
        }

        public void finaliza_venda()
        {
            if (MessageBox.Show("Deseja realmente finalizar esta venda ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                try{

                    if (Int32.Parse(dg_venda.Rows[0].Cells[0].Value.ToString()) > 0)
                    {

                        Zenfox_Software_OO.Cadastros.Entidade_Vendas vendas = new Zenfox_Software_OO.Cadastros.Entidade_Vendas();
                        vendas.produtos = new List<Zenfox_Software_OO.Cadastros.Entidade_Vendas_Produtos>();


                        foreach (DataGridViewRow row in dg_venda.Rows){
                            try { 
                                vendas.valor_total += Double.Parse(row.Cells[3].Value.ToString());
                                Zenfox_Software_OO.Cadastros.Entidade_Vendas_Produtos produtos = new Zenfox_Software_OO.Cadastros.Entidade_Vendas_Produtos();
                                                                
                                produtos.produto = Int32.Parse(row.Cells[0].Value.ToString());
                                produtos.quantidade = Int32.Parse(row.Cells[2].Value.ToString());

                                vendas.produtos.Add(produtos);
                            }
                            catch
                            {
                                vendas.valor_total += 0;
                            }
                        }

                        Zenfox_Software_OO.Cadastros.Vendas vcmd = new Zenfox_Software_OO.Cadastros.Vendas();
                        Int32 id = vcmd.cadastra(vendas);

                        Caixa_Fechamento cmd = new Caixa_Fechamento(id);
                        cmd.ShowDialog();

                        if (cmd.vendido)
                            limpa_venda(true);

                    }
                    else
                        MessageBox.Show("É necessario ter pelo menos 1 item para finalizar a venda !");
                }
                catch(Exception ee)
                {
                    MessageBox.Show("É necessario ter pelo menos 1 item para finalizar a venda !");
                }
            }
        }

        public void limpa_venda(Boolean x)
        {
            if (x)
            {
                limpa_produto();
                dg_venda.Rows.Clear();
                calcula_total();
            }
            else if (MessageBox.Show("Deseja realmente limpar esta venda ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                limpa_produto();
                dg_venda.Rows.Clear();
                calcula_total();
            }
        }

        public void seleciona_produto(Int32 id, String codigo_barras)
        {

            Zenfox_Software_OO.Cadastros.Entidade_Produto item = new Zenfox_Software_OO.Cadastros.Entidade_Produto();

            if (id > 0)
                item.id = id;

            if (codigo_barras.Length > 0)
                item.ean = codigo_barras;

            Zenfox_Software_OO.Cadastros.Produto cmd = new Zenfox_Software_OO.Cadastros.Produto();
            item = cmd.seleciona_entidade(item);

            if (item.id > 0)
            {

                this.id_produto = item.id;
                txt_descricao_produto.Text = item.nome_produto;
                txt_quantidade.Text = "1";
                lbl_valor_produto.Text = "R$ " + item.valor_venda;
                txt_quantidade.Focus();
            }
            else
            {
                this.id_produto = 0;
                txt_descricao_produto.Text = "";
                txt_quantidade.Text = "0";
                lbl_valor_produto.Text = "R$ 0.00";
                txt_codigo_barras.Focus();
            }

        }

        public void calcula_total()
        {
            try
            {
                Double total = 0;

                foreach (DataGridViewRow item in dg_venda.Rows)
                {
                    try
                    {
                        total += Double.Parse(item.Cells[5].Value.ToString());
                    }
                    catch { }
                }

                txtTotalFinal.Text = "R$ " + total.ToString("0.00").Replace(',', '.');
            }
            catch
            {
                txtTotalFinal.Text = "R$ 0.00";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Caixa_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotalFinal_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpa_venda(false);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Pesquisa_Produto cmd = new Pesquisa_Produto();
            cmd.ShowDialog();

            if (cmd.id > 0)
            {
                txt_codigo_barras.Text = cmd.codigo;
                seleciona_produto(cmd.id, "");
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_valor_produto_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
                        // if (!textBox1.Text.Contains(','))
                        // {
                        //     e.KeyChar = ',';
                        // }
                        // else
                        // {
                        //     e.KeyChar = (Char)0;
                        // }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void txt_codigo_barras_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                seleciona_produto(0, txt_codigo_barras.Text);



            verifica_key_up_atalho(e);
        }


        Boolean qtd_enter = false;

        private void txt_quantidade_KeyUp(object sender, KeyEventArgs e)
        {

            if (qtd_enter == false)
            {

                if (e.KeyCode == Keys.Enter)
                {

                    if (txt_quantidade.Text.Length > 0)
                    {

                        if (Int32.Parse(txt_quantidade.Text) > 0)
                        {

                            //this.dataGridView1.Rows.Add("five", "six", "seven", "eight");

                            Zenfox_Software_OO.Cadastros.Entidade_Produto item = new Zenfox_Software_OO.Cadastros.Entidade_Produto();
                            Zenfox_Software_OO.Cadastros.Produto cmd = new Zenfox_Software_OO.Cadastros.Produto();

                            if (this.id_produto == 0)
                            {
                                MessageBox.Show("Nenhum produto selecionado !"); qtd_enter = true; return;
                            }



                            item.id = this.id_produto;
                            item = cmd.seleciona_entidade(item);

                            DataGridViewRow row = (DataGridViewRow)dg_venda.Rows[0].Clone();
                            row.Cells[0].Value = item.id;
                            row.Cells[1].Value = item.nome_produto;
                            row.Cells[2].Value = txt_quantidade.Text;
                            row.Cells[3].Value = item.valor_venda;
                            row.Cells[4].Value = 0;
                            row.Cells[5].Value = (Int32.Parse(txt_quantidade.Text)) * item.valor_venda;
                            dg_venda.Rows.Add(row);

                            limpa_produto();
                            calcula_total();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Você deve informar uma quantidade válida !");
                        qtd_enter = true;
                    }

                }
            }
            else
            {
                qtd_enter = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            autenticacao();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Caixa_KeyUp(object sender, KeyEventArgs e)
        {
            verifica_key_up_atalho(e);
        }

        private void verifica_focus_Tick(object sender, EventArgs e)
        {
            if (!txt_codigo_barras.Focused)
                if (!txt_quantidade.Focused)
                    txt_codigo_barras.Focus();

        }

        private void btn_delete_venda_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {

                    if (Int32.Parse(dg_venda.SelectedRows[0].Cells[0].Value.ToString()) > 0)
                    {


                        if (MessageBox.Show("Deseja realmente excluir este item ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        {

                            foreach (DataGridViewRow item in this.dg_venda.SelectedRows)
                            {
                                dg_venda.Rows.RemoveAt(item.Index);
                                limpa_produto();
                                calcula_total();

                            }

                        }
                    }
                }
                catch
                {

                }

            }
            catch
            {

            }
        }

        public void cancela_sat()
        {
            Caixa_Cancela_SAT cmd = new Caixa_Cancela_SAT();
            cmd.ShowDialog();
        }

        public void segunda_via()
        {
            Caixa_Segunda_Via cmd = new Caixa_Segunda_Via();
            cmd.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancela_sat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            segunda_via();
        }
    }
}
