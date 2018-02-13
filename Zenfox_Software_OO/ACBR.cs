using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zenfox_Software_OO
{

    public class ACBR{


        public Boolean valida_ncm(String ncm)
        {
            Boolean acbr_return = false;
            Boolean ncm_valido = false;
            

            if (!Directory.Exists("C:/Rede_Sistema"))
                Directory.CreateDirectory("C:/Rede_Sistema");

            String texto = "NCM.Validar('"+ncm+"')";
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", texto);

            Thread.Sleep(200);

            if(!acbr_return){
                Thread.Sleep(500);
                String[] ncm_result = System.IO.File.ReadAllText(@"C:\Rede_Sistema\SAI.txt").Split(':');

                if (ncm_result.Length > 0)
                {
                    acbr_return = true;
                    System.IO.File.Delete(@"C:\Rede_Sistema\SAI.txt");
                    if (ncm_result[0].ToString() == "OK")
                        ncm_valido = true;
                }
            }


            if (!acbr_return)
            {
                Thread.Sleep(2000);
                String[] ncm_result = System.IO.File.ReadAllText(@"C:\Rede_Sistema\SAI.txt").Split(':');

                if (ncm_result.Length > 0)
                {
                    acbr_return = true;
                    System.IO.File.Delete(@"C:\Rede_Sistema\SAI.txt");
                    if (ncm_result[0].ToString() == "OK")
                        ncm_valido = true;
                }
            }

            if (!acbr_return)
            {
                Thread.Sleep(5000);
                String[] ncm_result = System.IO.File.ReadAllText(@"C:\Rede_Sistema\SAI.txt").Split(':');

                if (ncm_result.Length > 0)
                {
                    acbr_return = true;
                    System.IO.File.Delete(@"C:\Rede_Sistema\SAI.txt");
                    if (ncm_result[0].ToString() == "OK")
                        ncm_valido = true;
                }
            }
            

            return ncm_valido;
        }


        

        public Boolean inicializa_sat()
        {
            if (!Directory.Exists("C:/Rede_Sistema"))
                Directory.CreateDirectory("C:/Rede_Sistema");

            String texto = "SAT.Inicializar";
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", texto);

            return true;
        }
        
        // SAT ============================
        // ==============================

        /* 
         *   1 - Iniciar Montagem
         *   2 - Identificação
         *   3 - Emitente
         *   4 - Destinatario
         *   5 - Adiciona Produto
         *   6 - Total
         *   7 - Pagamentos
         *   8 - Dados Adicionais
         *   9 - Gera Cupom
        */
        

        public String inicia_montagem(String versao){
            return "SAT.CriarEnviarCfe('[infCFe] versao = "+versao+"";
        }

        public String identificacao(String cnpj,String codigo_vinculacao,String numero_caixa)
        {
            String texto = "[IDentificacao]";
            texto += " CNPJ = " + cnpj.Replace(".", "").Replace("/", "");
            texto += " signAC = " + codigo_vinculacao;
            texto += " numeroCaixa = " + numero_caixa;
            return texto;
        }

        public String emitente()
        {
            String texto = "";
            texto += "";
            texto += "";
            return texto;
        }

    }
}
