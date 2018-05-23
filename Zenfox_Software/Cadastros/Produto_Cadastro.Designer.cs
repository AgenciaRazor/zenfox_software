namespace Zenfox_Software.Cadastros
{
    partial class Produto_Cadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPreco_Venda_Margem = new System.Windows.Forms.TextBox();
            this.txtPreco_Atacado = new System.Windows.Forms.TextBox();
            this.txtPreco_Venda = new System.Windows.Forms.TextBox();
            this.txtValor_Compra = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.txt_ean = new System.Windows.Forms.TextBox();
            this.txt_nome_produto = new System.Windows.Forms.TextBox();
            this.cb_fornecedor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNCM = new System.Windows.Forms.TextBox();
            this.txtCFOP = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_estoque_inicial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_estoque_maximo = new System.Windows.Forms.TextBox();
            this.txt_estoque_minimo = new System.Windows.Forms.TextBox();
            this.txt_estoque = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 380);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(663, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastro";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPreco_Venda_Margem);
            this.panel1.Controls.Add(this.txtPreco_Atacado);
            this.panel1.Controls.Add(this.txtPreco_Venda);
            this.panel1.Controls.Add(this.txtValor_Compra);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtData);
            this.panel1.Controls.Add(this.txt_ean);
            this.panel1.Controls.Add(this.txt_nome_produto);
            this.panel1.Controls.Add(this.cb_fornecedor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 347);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtPreco_Venda_Margem
            // 
            this.txtPreco_Venda_Margem.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreco_Venda_Margem.Location = new System.Drawing.Point(4, 252);
            this.txtPreco_Venda_Margem.Margin = new System.Windows.Forms.Padding(2);
            this.txtPreco_Venda_Margem.Name = "txtPreco_Venda_Margem";
            this.txtPreco_Venda_Margem.Size = new System.Drawing.Size(111, 22);
            this.txtPreco_Venda_Margem.TabIndex = 229;
            this.txtPreco_Venda_Margem.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.txtPreco_Venda_Margem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_Venda_Margem_KeyPress);
            // 
            // txtPreco_Atacado
            // 
            this.txtPreco_Atacado.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreco_Atacado.Location = new System.Drawing.Point(236, 309);
            this.txtPreco_Atacado.Margin = new System.Windows.Forms.Padding(2);
            this.txtPreco_Atacado.Name = "txtPreco_Atacado";
            this.txtPreco_Atacado.Size = new System.Drawing.Size(111, 22);
            this.txtPreco_Atacado.TabIndex = 228;
            this.txtPreco_Atacado.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtPreco_Atacado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_Atacado_KeyPress);
            // 
            // txtPreco_Venda
            // 
            this.txtPreco_Venda.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreco_Venda.Location = new System.Drawing.Point(121, 309);
            this.txtPreco_Venda.Margin = new System.Windows.Forms.Padding(2);
            this.txtPreco_Venda.Name = "txtPreco_Venda";
            this.txtPreco_Venda.Size = new System.Drawing.Size(111, 22);
            this.txtPreco_Venda.TabIndex = 227;
            this.txtPreco_Venda.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.txtPreco_Venda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_Venda_KeyPress);
            // 
            // txtValor_Compra
            // 
            this.txtValor_Compra.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor_Compra.Location = new System.Drawing.Point(2, 309);
            this.txtValor_Compra.Margin = new System.Windows.Forms.Padding(2);
            this.txtValor_Compra.Name = "txtValor_Compra";
            this.txtValor_Compra.Size = new System.Drawing.Size(111, 22);
            this.txtValor_Compra.TabIndex = 226;
            this.txtValor_Compra.TextChanged += new System.EventHandler(this.txtValor_Compra_TextChanged);
            this.txtValor_Compra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_Compra_KeyPress);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Zenfox_Software.Properties.Resources.add__1_;
            this.button3.Location = new System.Drawing.Point(579, 73);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(20, 20);
            this.button3.TabIndex = 223;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(2, 235);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 221;
            this.label15.Text = "Margem Lucro (%)";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(505, 8);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 220;
            this.label14.Text = "Data Cadastro";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // txtData
            // 
            this.txtData.BackColor = System.Drawing.Color.White;
            this.txtData.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(508, 25);
            this.txtData.Margin = new System.Windows.Forms.Padding(2);
            this.txtData.Mask = "00/00/0000";
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(138, 22);
            this.txtData.TabIndex = 219;
            this.txtData.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtData_MaskInputRejected);
            // 
            // txt_ean
            // 
            this.txt_ean.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ean.Location = new System.Drawing.Point(3, 70);
            this.txt_ean.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ean.Name = "txt_ean";
            this.txt_ean.Size = new System.Drawing.Size(195, 22);
            this.txt_ean.TabIndex = 10;
            this.txt_ean.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_nome_produto
            // 
            this.txt_nome_produto.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome_produto.Location = new System.Drawing.Point(2, 25);
            this.txt_nome_produto.Margin = new System.Windows.Forms.Padding(2);
            this.txt_nome_produto.Name = "txt_nome_produto";
            this.txt_nome_produto.Size = new System.Drawing.Size(490, 22);
            this.txt_nome_produto.TabIndex = 8;
            this.txt_nome_produto.TextChanged += new System.EventHandler(this.txt_nome_produto_TextChanged);
            // 
            // cb_fornecedor
            // 
            this.cb_fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_fornecedor.FormattingEnabled = true;
            this.cb_fornecedor.Location = new System.Drawing.Point(310, 97);
            this.cb_fornecedor.Margin = new System.Windows.Forms.Padding(2);
            this.cb_fornecedor.Name = "cb_fornecedor";
            this.cb_fornecedor.Size = new System.Drawing.Size(277, 28);
            this.cb_fornecedor.TabIndex = 7;
            this.cb_fornecedor.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(233, 292);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Valor em Atacado (R$)";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(119, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Valor de Venda (R$)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 292);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valor de Compra (R$)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código de Barras (EAN) / Referência *";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fornecedor";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Produto *";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNCM);
            this.tabPage2.Controls.Add(this.txtCFOP);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(663, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dados Fiscais";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // txtNCM
            // 
            this.txtNCM.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNCM.Location = new System.Drawing.Point(7, 75);
            this.txtNCM.Margin = new System.Windows.Forms.Padding(2);
            this.txtNCM.Name = "txtNCM";
            this.txtNCM.Size = new System.Drawing.Size(218, 22);
            this.txtNCM.TabIndex = 9;
            // 
            // txtCFOP
            // 
            this.txtCFOP.DropDownWidth = 1080;
            this.txtCFOP.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCFOP.FormattingEnabled = true;
            this.txtCFOP.Items.AddRange(new object[] {
            "5101 - Venda de produção do estabelecimento",
            "5102 - Venda de mercadoria adquirida ou recebida de terceiros",
            "5103 - Venda de produção do estabelecimento, efetuada fora do estabelecimento",
            "5405 - Venda de mercadoria adquirida ou recebida de terceiros em operação com mer" +
                "cadoria sujeita ao regime de substituição tributária, na condição de contribuint" +
                "e substituído"});
            this.txtCFOP.Location = new System.Drawing.Point(7, 28);
            this.txtCFOP.Margin = new System.Windows.Forms.Padding(2);
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.Size = new System.Drawing.Size(462, 21);
            this.txtCFOP.TabIndex = 8;
            this.txtCFOP.SelectedIndexChanged += new System.EventHandler(this.txtCFOP_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "CFOP *";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 58);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "NCM *";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_estoque_inicial);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.txt_estoque_maximo);
            this.tabPage3.Controls.Add(this.txt_estoque_minimo);
            this.tabPage3.Controls.Add(this.txt_estoque);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(663, 354);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Estoque";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // txt_estoque_inicial
            // 
            this.txt_estoque_inicial.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estoque_inicial.Location = new System.Drawing.Point(416, 38);
            this.txt_estoque_inicial.Margin = new System.Windows.Forms.Padding(2);
            this.txt_estoque_inicial.Name = "txt_estoque_inicial";
            this.txt_estoque_inicial.Size = new System.Drawing.Size(111, 29);
            this.txt_estoque_inicial.TabIndex = 238;
            this.txt_estoque_inicial.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.txt_estoque_inicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(413, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 237;
            this.label4.Text = "Estoque Inicial";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::Zenfox_Software.Properties.Resources._002_diskette;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(531, 34);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 37);
            this.button5.TabIndex = 236;
            this.button5.Text = "Acerto Estoque";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(658, 278);
            this.dataGridView1.TabIndex = 235;
            // 
            // txt_estoque_maximo
            // 
            this.txt_estoque_maximo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estoque_maximo.Location = new System.Drawing.Point(284, 38);
            this.txt_estoque_maximo.Margin = new System.Windows.Forms.Padding(2);
            this.txt_estoque_maximo.Name = "txt_estoque_maximo";
            this.txt_estoque_maximo.Size = new System.Drawing.Size(111, 29);
            this.txt_estoque_maximo.TabIndex = 234;
            this.txt_estoque_maximo.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.txt_estoque_maximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // txt_estoque_minimo
            // 
            this.txt_estoque_minimo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estoque_minimo.Location = new System.Drawing.Point(142, 38);
            this.txt_estoque_minimo.Margin = new System.Windows.Forms.Padding(2);
            this.txt_estoque_minimo.Name = "txt_estoque_minimo";
            this.txt_estoque_minimo.Size = new System.Drawing.Size(111, 29);
            this.txt_estoque_minimo.TabIndex = 233;
            this.txt_estoque_minimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_estoque_minimo_KeyPress);
            // 
            // txt_estoque
            // 
            this.txt_estoque.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estoque.Location = new System.Drawing.Point(4, 38);
            this.txt_estoque.Margin = new System.Windows.Forms.Padding(2);
            this.txt_estoque.Name = "txt_estoque";
            this.txt_estoque.ReadOnly = true;
            this.txt_estoque.Size = new System.Drawing.Size(111, 29);
            this.txt_estoque.TabIndex = 232;
            this.txt_estoque.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(282, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 231;
            this.label10.Text = "Estoque Máximo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(140, 22);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 230;
            this.label11.Text = "Estoque Mínimo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(2, 22);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 229;
            this.label12.Text = "Estoque Atual";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Zenfox_Software.Properties.Resources.trash;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(499, 396);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Apagar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Zenfox_Software.Properties.Resources._002_diskette;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(590, 396);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Salvar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Produto_Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(689, 436);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Produto_Cadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Produto";
            this.Load += new System.EventHandler(this.Produto_Cadastro_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_fornecedor;
        private System.Windows.Forms.TextBox txt_nome_produto;
        private System.Windows.Forms.TextBox txt_ean;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtValor_Compra;
        private System.Windows.Forms.TextBox txtPreco_Venda;
        private System.Windows.Forms.TextBox txtPreco_Atacado;
        private System.Windows.Forms.TextBox txtPreco_Venda_Margem;
        private System.Windows.Forms.TextBox txtNCM;
        private System.Windows.Forms.ComboBox txtCFOP;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_estoque_maximo;
        private System.Windows.Forms.TextBox txt_estoque_minimo;
        private System.Windows.Forms.TextBox txt_estoque;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_estoque_inicial;
        private System.Windows.Forms.Label label4;

    }
}