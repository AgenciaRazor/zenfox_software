using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenfox_Software_OO.Cadastros
{

    public class Entidade_Usuario{
         
         public Int32 id{get;set;}
         public Boolean adm{get;set;}
         public String nome{get;set;}
         public String usuario{get;set;}
         public String senha{get;set;}
         public Boolean ativo{get;set;}

    }

    public class Usuario
    {

        public void insere_usuario(Entidade_Usuario item)
        {
            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
         
            StringBuilder sb = new StringBuilder();

            if(item.id == 0){

                sb.AppendLine("INSERT INTO usuario (adm,nome,usuario,senha,ativo)");                
                sb.AppendLine("VALUES ("+item.adm+",'"+item.nome+"','"+item.usuario+"','"+item.senha+"',true);");

            }else{

            }
                        
            sql.AbrirConexao();
            sql.ExecutaComando(sb.ToString());
            sql.FechaConexao();

          
        }


        public Int32 autenticacao(Entidade_Usuario item)
        {
            Int32 id = 0;

            data.bd sql = new data.bd();

            StringBuilder sb = new StringBuilder();

            if (item.id == 0)
            {

                sb.AppendLine("select id from usuario where usuario = '"+item.usuario+"' and senha = '"+item.senha+"'");

                sql.abrir_conexao();
                DataTable dr = sql.selectQuery(sb.ToString());

                if(dr.Rows.Count > 0)
                {
                    id = Int32.Parse(dr.Rows[0].ToString());
                }

            }
            else
            {

            }

            sql.abrir_conexao();
            sql.selectQuery(sb.ToString());
            sql.fecha_conexao();

            return id;
        }

    }
}
