using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenfox_Software_OO.Cadastros
{

    public class Entidade_Vendas{

        public Int32 id { get; set; }
        public Status_venda status { get; set; }
        public String data { get; set; }
        public Double valor_total { get; set; }
        public Double desconto { get; set; }
        public Int32 usuario { get; set; }
        public Int32 vendedor { get; set; }
        public String xml { get; set; }
        public List<Entidade_Vendas_Produtos> produtos { get; set; }
        public Boolean para_cancelamento { get; set; }

        public String data_inicial { get; set; }
        public String data_final { get; set; }

    }

    public class Entidade_Vendas_Produtos{
        public Int32 id { get; set; } 
        public Int32 venda { get; set; }
        public Int32 produto { get; set; }
        public Double valor { get; set; }
        public Int32 quantidade { get; set; }
    }

        public enum Status_venda{
        aberto = 0,
        fechado = 1,
        cancelado = 2
    }


    public class Vendas{

        public DataTable seleciona_vendas_gerencia(Entidade_Vendas item)
        {

            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();
            String x = "select id, ";
            x += "CASE WHEN status =1 THEN 'Venda' end as status, ";
            x += "data,valor_total ";


            x += "from vendas ";
            x += "where status = " + Status_venda.fechado.GetHashCode() + " ";

            if (item.para_cancelamento)
            {
                DateTime dt = DateTime.Now;
                dt = dt.AddMinutes(-30);
                x += " and data > '" + dt.ToString() + "' ";
            }

            if (item.data_inicial.Length > 0)
                x += " and data >= '" + item.data_inicial + "'";

            if (item.data_final.Length > 0)
                x += " and data <= '" + item.data_final + "'";



            sql.Comando.CommandText = x;
            IDataReader dr = sql.RetornaDados_v2();
            DataTable dttb = new DataTable();
            dttb.Load(dr);

            sql.FechaConexao();
            return dttb;
        }

        public DataTable seleciona_vendas(Entidade_Vendas item){

            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();
            String x = "select * from vendas where status = "+Status_venda.fechado.GetHashCode()+" ";

            if (item.para_cancelamento){
                DateTime dt = DateTime.Now;
                dt = dt.AddMinutes(-30);
                x += " and data > '"+dt.ToString()+"' ";
            }

            if (item.data_inicial.Length > 0)
                x += " and data >= '"+item.data_inicial+"'";

            if (item.data_final.Length > 0)
                x += " and data <= '" + item.data_final + "'";



            sql.Comando.CommandText = x;
            IDataReader dr = sql.RetornaDados_v2();
            DataTable dttb = new DataTable();
            dttb.Load(dr);

            sql.FechaConexao();
            return dttb;
        }

        public Entidade_Vendas seleciona(Entidade_Vendas item){

            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();
            String x = "select * from vendas where id = " + item.id + " ";

            if (item.para_cancelamento){
                DateTime dt = DateTime.Now;
                dt = dt.AddMinutes(-30);
                x += " and data > '"+dt.ToString()+"' ";
            }

            sql.Comando.CommandText = x;
            IDataReader dr = sql.RetornaDados_v2();

            Int32 id = dr.GetOrdinal("id");
            //Int32 status = dr.GetOrdinal("status");
            Int32 valor_total = dr.GetOrdinal("valor_total");
            Int32 xml = dr.GetOrdinal("xml");

            while (dr.Read())
            {
                item.id = dr.GetInt32(id);
                item.valor_total = dr.GetDouble(valor_total);
                if(!dr.IsDBNull(xml))
                    item.xml = dr.GetString(xml);
            }

            sql.FechaConexao();
            return item;


        }

        public Int32 cadastra(Entidade_Vendas item){

            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO vendas (status,valor_total,usuario,vendedor)");
            sb.AppendLine("VALUES (0," + item.valor_total + ",0,0)returning id;");
            
            sql.AbrirConexao();
            Int32 id = sql.RetornaID(sb.ToString());
            sql.FechaConexao();

            sb.Clear();
            foreach (var produto in item.produtos){
                sb.AppendLine("INSERT INTO public.vendas_itens(venda, produto, valor, quantidade) ");
                sb.AppendLine("VALUES("+id+", "+produto.produto+", "+ produto.valor+", "+produto.quantidade+"); ");
            }

            sql.AbrirConexao();
            sql.ExecutaComando(sb.ToString());
            sql.FechaConexao();
            return id;
        }

        public void fecha_venda(Entidade_Vendas item){
            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();
            sql.Comando.CommandText = "update vendas set status = "+Status_venda.fechado.GetHashCode()+" , data = current_timestamp, xml = '"+item.xml+"' where id = " + item.id + " ";
            sql.ExecutaComando_v2();
            sql.FechaConexao();
        }

    }
}
