using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenfox_Software_OO.Caixa
{

    public class Entidade_Caixa
    {

        public Int32 id { get; set; }
        public Int32 usuario { get; set; }
        public String data_abertura { get; set; }
        public String data_fechamento { get; set; }

        public Double valor_abertura { get; set; }
          
    }

    public class Entidade_Caixa_pagamento
    {
        
        public forma_pagamento forma_pagamento { get; set; }
    
    }

    public enum forma_pagamento{
        dinheiro = 1,
        cheque = 2,
        cartao_credito = 3,
        cartao_debito = 4
    }

    public class Caixa
    {

        public Boolean verifica_caixa_aberto(Entidade_Caixa item){
            Boolean x = false;

            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();
            sql.Comando.CommandText = "select * from caixa where usuario = " + item.usuario + " and data_fechamento is null";
            IDataReader dr = sql.RetornaDados_v2();

            Int32 id = dr.GetOrdinal("id");

            while (dr.Read()){
                item.id = dr.GetInt32(id);
                x = true;
            }

            sql.FechaConexao();
            return x;
            //return item;

        }

        public void abrir_caixa(Entidade_Caixa item)
        {
            Boolean x = false;

            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();
            sql.Comando = new Npgsql.NpgsqlCommand();
            sql.Comando.CommandText = "INSERT INTO caixa(usuario, data_abertura, valor_abertura) VALUES (@usuario,current_timestamp, @valor_abertura);";
            sql.Comando.Parameters.AddWithValue("@usuario",item.usuario);
            sql.Comando.Parameters.AddWithValue("@valor_abertura", item.valor_abertura);
            sql.ExecutaComando_v2();

            sql.FechaConexao();

            //return item;

        }

    }
}
