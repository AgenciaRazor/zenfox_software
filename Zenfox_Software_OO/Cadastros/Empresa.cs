using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenfox_Software_OO.Cadastros
{
    public class Empresa
    {

        public Boolean verifica_primeiro_acesso()
        {

            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();
            sql.AbrirConexao();

            sql.Comando = new Npgsql.NpgsqlCommand();
            sql.Comando.CommandText = "select * from empresa";

            DataTable dt = sql.RetornaDados_v2_dt();
            // sql.ExecutaComando_v2()
            // DataTable dt = sql.selectQuery("select * from empresa");
            sql.FechaConexao();

            if (dt.Rows.Count > 0)
                return false; //Não é o primeiro acesso
            else
                return true; // Sim, é o primeiro acesso
        }

        public void vincula_empresa(Int32 id)
        {
            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO empresa (id)");
            sb.AppendLine("VALUES (" + id + ");");

            sql.AbrirConexao();
            sql.ExecutaComando(sb.ToString());
            sql.FechaConexao();


        }

    }
}
