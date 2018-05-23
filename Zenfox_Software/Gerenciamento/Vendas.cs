using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenfox_Software.Gerenciamento
{
    public partial class Vendas : Form
    {
        public Vendas()
        {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e){
           

            mes_atual();
            pesquisa();
        }
        public void mes_anterior()
        {
            var data = new DateTime(Int32.Parse(data_inicial.Text.Split('/')[2]), Int32.Parse(data_inicial.Text.Split('/')[1]), Int32.Parse(data_inicial.Text.Split('/')[0])); //pega a data que está no controle
            var mesAnterior = data.AddMonths(-1);
            var primeiroDia = new DateTime(mesAnterior.Year, mesAnterior.Month, 1);
            var ultimoDia = new DateTime(mesAnterior.Year, mesAnterior.Month,
                    DateTime.DaysInMonth(mesAnterior.Year, mesAnterior.Month));


            data_inicial.Text = primeiroDia.ToShortDateString();
            data_final.Text = ultimoDia.ToShortDateString();
        }

        public void mes_atual() {
            var data = DateTime.Now; //pega a data que está no controle
            var mesAnterior = data.AddMonths(0);
            var primeiroDia = new DateTime(mesAnterior.Year, mesAnterior.Month, 1);
            var ultimoDia = new DateTime(mesAnterior.Year, mesAnterior.Month,
                    DateTime.DaysInMonth(mesAnterior.Year, mesAnterior.Month));


            data_inicial.Text = primeiroDia.ToShortDateString();
            data_final.Text = ultimoDia.ToShortDateString();
        }

        public void pesquisa(){

            Zenfox_Software_OO.Cadastros.Vendas cmd = new Zenfox_Software_OO.Cadastros.Vendas();
            dataGridView1.DataSource = cmd.seleciona_vendas_gerencia(new Zenfox_Software_OO.Cadastros.Entidade_Vendas() { data_inicial = data_inicial.Value.ToString().Replace("00:00:00","").Trim(), data_final = data_final.Value.ToString().Replace("00:00:00", "").Trim() });


        }

        private void button4_Click(object sender, EventArgs e)
        {
            pesquisa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            Zenfox_Software_OO.Cadastros.Vendas cmd = new Zenfox_Software_OO.Cadastros.Vendas();
            Zenfox_Software_OO.Cadastros.Entidade_Vendas item = cmd.seleciona(new Zenfox_Software_OO.Cadastros.Entidade_Vendas() { id = id });

            String xml = "SAT.ImprimirExtratoVenda(\"" + item.xml + "\");";
            System.IO.File.WriteAllText("C:/Rede_Sistema/ENT.txt", xml.Replace("\\\"", "'"));

            Thread.Sleep(5000);

            File.Delete("C:/Rede_Sistema/sai.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mes_anterior();
            pesquisa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mes_atual();
            pesquisa();
        }
    }
}
