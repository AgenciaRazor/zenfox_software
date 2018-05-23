using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenfox_Software_OO.Cadastros
{

    public class Entidade_Produto
    {

        public Int32 id { get; set; }
        public Int32 fornecedor { get; set; }
        public String nome_produto { get; set; }
        public String ean { get; set; }
        public String ncm { get; set; }
        public Int32 cfop { get; set; }
        public String data_cadastro { get; set; }


        public Double valor_compra { get; set; }
        public Double valor_venda { get; set; }
        public Double valor_venda_margem { get; set; }
        public Double valor_venda_atacado { get; set; }
        public Double valor_venda_atacado_margem { get; set; }

        public Double estoque { get; set; }
        public Double estoque_inicial { get; set; }
        public Double estoque_minimo { get; set; }
        public Double estoque_maximo { get; set; }

    }

    public class Produto
    {


        public Entidade_Produto seleciona_entidade(Entidade_Produto item)
        {
            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();
            sql.Comando.CommandText = "select * from produto where id = " + item.id + " or ean = '"+item.ean+"'";
            IDataReader dr = sql.RetornaDados_v2();

            Int32 id = dr.GetOrdinal("id");
            Int32 fornecedor = dr.GetOrdinal("fornecedor");
            Int32 xnome = dr.GetOrdinal("nome");
            Int32 data_cadastro = dr.GetOrdinal("data_cadastro");
            Int32 ean = dr.GetOrdinal("ean");
            Int32 valor_compra = dr.GetOrdinal("valor_compra");
            Int32 valor_venda = dr.GetOrdinal("valor_venda");
            Int32 valor_venda_atacado = dr.GetOrdinal("valor_atacado");
            Int32 valor_venda_margem = dr.GetOrdinal("margem");
            Int32 valor_venda_atacado_margem = dr.GetOrdinal("margem_atacado");
            Int32 cfop = dr.GetOrdinal("cfop");
            Int32 ncm = dr.GetOrdinal("ncm");
            Int32 estoque = dr.GetOrdinal("estoque");
            Int32 estoque_minimo = dr.GetOrdinal("estoque_minimo");
            Int32 estoque_maximo = dr.GetOrdinal("estoque_maximo");
            
            while (dr.Read())
            {
                item.id = dr.GetInt32(id);

                if(!dr.IsDBNull(fornecedor))
                    item.fornecedor = dr.GetInt32(fornecedor);

                if (!dr.IsDBNull(xnome))
                    item.nome_produto = dr.GetString(xnome);
                else
                    item.nome_produto = "";
                                                    
                item.data_cadastro = dr.GetDateTime(data_cadastro).ToShortDateString();
                if (!dr.IsDBNull(ean))
                    item.ean = dr.GetString(ean);

                item.valor_compra = dr.GetDouble(valor_compra);
                item.valor_venda = dr.GetDouble(valor_venda);
                item.valor_venda_atacado = dr.GetDouble(valor_venda_atacado);
                item.valor_venda_margem =dr.GetDouble(valor_venda_margem);
                item.valor_venda_atacado_margem = dr.GetDouble(valor_venda_atacado_margem);
                item.cfop = dr.GetInt32(cfop);
                item.ncm =dr.GetString(ncm);
                item.estoque = dr.GetInt32(estoque);
                item.estoque_minimo =dr.GetInt32(estoque_minimo);
                item.estoque_maximo = dr.GetInt32(estoque_maximo);
            }

            sql.FechaConexao();
            return item;
        }
        public DataTable seleciona()
        {
            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();
            sql.Comando.CommandText = "select * from produto";
            DataTable dt = sql.RetornaDados_v2_dt();
            sql.FechaConexao();
            return dt;
        }

        public DataTable seleciona_listagem(Entidade_Produto item)
        {
            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();

            StringBuilder sb = new StringBuilder();
            sb.Append("select id,data_cadastro,nome,estoque,estoque_minimo,valor_compra,valor_venda,ean,ncm,cfop from produto where 1 = 1 ");

            if (item.nome_produto != "" && item.nome_produto != null)
            {
                sb.Append("and nome ilike '"+item.nome_produto+"%'");
                sql.Comando.Parameters.AddWithValue("@nome", item.nome_produto);
            }

            sql.Comando.CommandText = sb.ToString();
            DataTable dt = sql.RetornaDados_v2_dt();
            sql.FechaConexao();
            return dt;
        }
        

        public void salva(Entidade_Produto item)
        {
            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.Comando = new Npgsql.NpgsqlCommand();

            StringBuilder sb = new StringBuilder();

            if (item.id > 0)
            {
                sb.AppendLine("update produto set fornecedor=@fornecedor,nome=@nome,ean=@ean,valor_compra=@valor_compra,valor_venda=@valor_venda");
                sb.AppendLine(",valor_atacado=@valor_atacado,margem=@margem,margem_atacado=@margem_atacado,cfop=@cfop,ncm=@ncm,estoque=@estoque,estoque_minimo=@estoque_minimo");
                sb.AppendLine(",estoque_maximo=@estoque_maximo where id = @id");

                sql.Comando.Parameters.AddWithValue("@id", item.id);
                sql.Comando.Parameters.AddWithValue("@fornecedor", item.fornecedor);
                sql.Comando.Parameters.AddWithValue("@nome", item.nome_produto);
                sql.Comando.Parameters.AddWithValue("@ean", item.ean);
                sql.Comando.Parameters.AddWithValue("@valor_compra", item.valor_compra);
                sql.Comando.Parameters.AddWithValue("@valor_venda", item.valor_venda);
                sql.Comando.Parameters.AddWithValue("@valor_atacado", item.valor_venda_atacado);
                sql.Comando.Parameters.AddWithValue("@margem", item.valor_venda_margem);
                sql.Comando.Parameters.AddWithValue("@margem_atacado", item.valor_venda_atacado_margem);
                sql.Comando.Parameters.AddWithValue("@cfop", item.cfop);
                sql.Comando.Parameters.AddWithValue("@ncm", item.ncm);
                sql.Comando.Parameters.AddWithValue("@estoque", item.estoque_inicial);
                sql.Comando.Parameters.AddWithValue("@estoque_minimo", item.estoque_minimo);
                sql.Comando.Parameters.AddWithValue("@estoque_maximo", item.estoque_maximo);

            }
            else
            {
                //Salva

                //INSERT INTO produto(
                //        id, nome, empresa, fornecedor, ean, tipo_produto, valor_compra, 
                //        venda, status, ncm, cfop, estoque, estoque_minimo, estoque_maximo, 
                //        sat_cfop, sat_ncm)
                //VALUES (?, ?, ?, ?, ?, ?, ?, 
                //        ?, ?, ?, ?, ?, ?, ?, 
                //        ?, ?);

                sb.AppendLine("INSERT INTO produto(fornecedor,nome,ean,valor_compra,valor_venda,valor_atacado,margem,margem_atacado,cfop,ncm,estoque,estoque_minimo,estoque_maximo)");
                sb.AppendLine("VALUES (@fornecedor,@nome,@ean,@valor_compra,@valor_venda,@valor_atacado,@margem,@margem_atacado,@cfop,@ncm,@estoque,@estoque_minimo,@estoque_maximo)");

                sql.Comando.Parameters.AddWithValue("@fornecedor", item.fornecedor);
                sql.Comando.Parameters.AddWithValue("@nome", item.nome_produto);
                sql.Comando.Parameters.AddWithValue("@ean", item.ean);
                sql.Comando.Parameters.AddWithValue("@valor_compra", item.valor_compra);
                sql.Comando.Parameters.AddWithValue("@valor_venda", item.valor_venda);
                sql.Comando.Parameters.AddWithValue("@valor_atacado", item.valor_venda_atacado);
                sql.Comando.Parameters.AddWithValue("@margem", item.valor_venda_margem);
                sql.Comando.Parameters.AddWithValue("@margem_atacado", item.valor_venda_atacado_margem);
                sql.Comando.Parameters.AddWithValue("@cfop", item.cfop);
                sql.Comando.Parameters.AddWithValue("@ncm", item.ncm);
                sql.Comando.Parameters.AddWithValue("@estoque", item.estoque_inicial);
                sql.Comando.Parameters.AddWithValue("@estoque_minimo", item.estoque_minimo);
                sql.Comando.Parameters.AddWithValue("@estoque_maximo", item.estoque_maximo);

            }

            sql.Comando.CommandText = sb.ToString();
            sql.AbrirConexao();
            sql.ExecutaComando_v2();
            sql.FechaConexao();
        }

    }
}
