using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenfox_Software_OO.Cadastros
{
    public class Entidade_Fornecedor
    {

        public Int32 id { get; set; }
        public Int32 id_nuvem { get; set; }
        public String fantasia { get; set; }

    }

    public class Fornecedor
    {

        public void salva(Entidade_Fornecedor item){
            
            data.bd_postgres sql = new data.bd_postgres();
            sql.localdb();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO empresa (id)");
            sb.AppendLine("VALUES (" + item.id + ");");
            sql.AbrirConexao();
            sql.ExecutaComando(sb.ToString());
            sql.FechaConexao();
            
        }




    }
}
