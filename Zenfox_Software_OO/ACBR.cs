using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zenfox_Software_OO
{

    public class ACBR
    {


        public Boolean valida_ncm(String ncm)
        {
            Boolean acbr_return = false;
            Boolean ncm_valido = false;


            if (!Directory.Exists("C:/Rede_Sistema"))
                Directory.CreateDirectory("C:/Rede_Sistema");

            String texto = "NCM.Validar('" + ncm + "')";
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", texto);

            Thread.Sleep(200);

            if (!acbr_return)
            {
                Thread.Sleep(500);
                String[] ncm_result;
                try
                {
                    ncm_result = System.IO.File.ReadAllText(@"C:\Rede_Sistema\sai.txt").Split(':');
                }
                catch
                {
                    throw new Exception("Falha ao tentar se comunicar com o SAT !");
                }
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

            ncm_valido = true;

            return ncm_valido;
        }

        public void configura_acbr(String cnpj, String ie, String im, String codigo_vinculacao)
        {

            System.IO.StreamReader arquivo = File.OpenText(@"C:\ACBrMonitorPLUS\ACBrMonitor.ini");
            System.IO.StreamWriter novoArquivo = File.CreateText(@"C:\ACBrMonitorPLUS\ACBrMonitorx.ini");
            string depura = "";
            string linha = "";

            Boolean flag = false; //flag para quando o arquivo chegou na parte do sat
            Boolean flag_monitor = false;
            Boolean flag_emitente = false; // Flag para quando chegar no arquivo de configuração do emitente
            Boolean flag_software_house = false;
            Boolean flag_impressao = false;

            //Cria os diretórios
            if (!Directory.Exists(@"C:\Rede_Sistema"))
                Directory.CreateDirectory(@"C:\Rede_Sistema");

            while ((linha = arquivo.ReadLine()) != null)
            {
                if (linha.Trim() == "[ACBrMonitor]")
                    flag_monitor = true;

                if (linha.Trim() == "[SAT]")
                    flag = true;

                if (linha.Trim() == "[SATEmit]")
                    flag_emitente = true;

                if (linha.Trim() == "[SATSwH]")
                    flag_software_house = true;

                if (linha.Trim() == "[SATFortes]")
                    flag_impressao = true;

                if (flag_monitor)
                {
                    if (linha.Split('=')[0].ToString() == "TXT_Entrada")
                        linha = "TXT_Entrada = C:/Rede_Sistema/ent.txt";

                    if (linha.Split('=')[0].ToString() == "TXT_Saida")
                    {
                        linha = "TXT_Saida = C:/Rede_Sistema/sai.txt";
                        flag_monitor = false;
                    }

                }


                if (flag)
                {

                    if (linha.Split('=')[0].ToString() == "CodigoAtivacao")
                    {
                        linha = "CodigoAtivacao = 123";
                        flag = false;
                    }
                }

                if (flag_emitente)
                {

                    if (linha.Split('=')[0].ToString() == "CNPJ")
                        linha = "CNPJ = " + cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");

                    if (linha.Split('=')[0].ToString() == "IE")
                        linha = "IE = " + ie.Replace(".", "");

                    if (linha.Split('=')[0].ToString() == "IM")
                    {
                        linha = "IM = " + im;
                        flag_emitente = false;
                    }
                }

                if (flag_software_house)
                {

                    if (linha.Split('=')[0].ToString() == "CNPJ")
                        linha = "CNPJ = 11444406000180";

                    if (linha.Split('=')[0].ToString() == "Assinatura")
                    {
                        linha = "Assinatura = " + codigo_vinculacao;
                        flag_software_house = false;
                    }
                }


                if (flag_impressao)
                {
                    if (linha.Split('=')[0].ToString() == "Largura")
                    {
                        linha = "Largura = 280";
                        flag_impressao = false;
                    }

                }
                novoArquivo.WriteLine(linha);
            }

            arquivo.Close();
            novoArquivo.Dispose();
            novoArquivo.Close();
            File.Replace(@"C:\ACBrMonitorPLUS\ACBrMonitorx.ini", @"C:\ACBrMonitorPLUS\ACBrMonitor.ini", @"C:\ACBrMonitorPLUS\ACBrMonitorbkp.ini");
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


        public String inicia_montagem(String versao)
        {
            return @"
                SAT.CriarEnviarCfe(""[infCFe]
            versao = " + versao +@" ";
        }

        public String identificacao(String cnpj_sh, String codigo_vinculacao, String numero_caixa)
        {
            String texto = @" 
            [IDentificacao]
            CNPJ = " + cnpj_sh.Replace(".", "").Replace("/", "") + @"
            signAC = " + codigo_vinculacao + @"
            numeroCaixa = " + numero_caixa;
            return texto;

            
        }

        public String emitente(String cnpj, String ie, String im){
            String text = @" 
            [Emitente]
            CNPJ = " + cnpj  +@"
            IE = " + ie +@"
            IM = " + im + @"
            indRatISSQN = S " + @"";
            return text;
        }

        public String destinatario(String cpf_cnpj,String nome){
            String text = @" 
            [Destinatario]
            CNPJCPF = " + cpf_cnpj + @" 
            xNome = " + nome+ " ";
            return text;
        }

        public String adiciona_produto(Int32 numero,String codigo,String infAdicional,String ean,String nome,String ncm,String cfop, Double quantidade, Double valor,
            Double desconto,Double vOutro, Double icms)
        {
            String text = @" 
            [Produto" + ((numero).ToString("000")) + @"]
            cProd = "+ codigo+ @"
            infAdProd = "+ infAdicional+ @"
            cEAN = "+ ean+ @"
            xProd = " + nome+ @"
            NCM = "+ ncm+ @"
            CFOP = " + cfop+ @"
            uCom = UN" +@"
            Combustivel = 0 
            qCom = "+ quantidade + @"
            vUnCom = " + valor + @"
            indRegra = A 
            vDesc = "+ desconto + @"         
            vOutro = " + vOutro+ @"
            vItem12741 = " + (valor * quantidade  ) + @"
            [ObsFiscoDet" + ((numero).ToString("000")) + @"]
            xCampoDet = Cod. CEST
            xTextoDet = ";

            text += @" 
            [ICMS" + ((numero).ToString("000")) + @"]
            Orig = 10 ";

            if(true){

                text += @"
                CSOSN = 900 ";
                text += @"
                pICMS = "+icms+" ";

                text += @"
                [PIS" + ((numero).ToString("000")) + @"]
                CST = 49 
                [COFINS" + ((numero).ToString("000")) + @"] 
                CST = 49 ";
                                    
            }else{

                //text += @"[ICMS" + ((numero).ToString("000")) + @"]
                //                    Orig = 0
                //                    CST = 40
                //                    [PIS" + ((numero).ToString("000")) + @"]
                //                    CST = 01
                //                    [COFINS" + ((numero).ToString("000")) + @"]
                //                    CST = 01";
            }

            return text;
        }

        public String total(Double aliquotatotal,Double totaldesconto)
        {
            String text = @" 
            [Total]
            vCFeLei12741 = " + aliquotatotal + @"
            [DescAcrEntr]
            vDescSubtot = " + totaldesconto +" ";
            return text;
        }

        public String formas_pagamento(Int32 codigo_pagamento,Int32 pagamento,Double total)
        {
            String text = "";
            

            text = @" 
            [Pagto" + ((codigo_pagamento).ToString("000")) + @"]
            cMP = " + int.Parse(pagamento.ToString()).ToString("00") + @"
            vMP = " + total;

            return text;
        }

        public String dados_adicionais(String mensagem)
        {
            String text = "";

            text += @"
              [DadosAdicionais]
              infCpl = " + mensagem + @"
                [ObsFisco001]
              xCampo = 
              xTexto = "")";
            return text;
        }

        public String emite_sat(Int32 id_venda,String texto)
        {
            //MessageBox.Show("Vai escrever o arquivo TXT");
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", texto, Encoding.UTF8);

            
            String xml = "";
            String xml_impressao = "";
            Boolean arquivo_existe = false;

            #region verificando se arquivo existe

            Thread.Sleep(1000);
            if (File.Exists("C:/Rede_Sistema/sai.txt"))
                arquivo_existe = true;

            if(!arquivo_existe)
            Thread.Sleep(1000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            if (!arquivo_existe)
                Thread.Sleep(2000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            if (!arquivo_existe)
                Thread.Sleep(2000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            if (!arquivo_existe)
                Thread.Sleep(3000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            if (!arquivo_existe)
                Thread.Sleep(3000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            if (!arquivo_existe)
                Thread.Sleep(5000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            if (!arquivo_existe)
                Thread.Sleep(5000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            if (!arquivo_existe)
                Thread.Sleep(10000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            if (!arquivo_existe)
                Thread.Sleep(10000);
            if (File.Exists("C:/Rede_Sistema/sai.txt") && arquivo_existe == false)
                arquivo_existe = true;

            #endregion

            string[] lines = File.ReadAllLines("C:/Rede_Sistema/sai.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("XML="))
                {
                    xml = lines[i].Substring(4);
                }
            }
            //xml_impressao = "SAT.ImprimirExtratoResumido(\"" + xml + "\");";
            xml_impressao = "SAT.ImprimirExtratoVenda(\"" + xml + "\");";
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", xml_impressao);          

            File.Delete("C:/Rede_Sistema/sai.txt");


            Cadastros.Vendas cmd = new Cadastros.Vendas();
            cmd.fecha_venda(new Cadastros.Entidade_Vendas() { id = id_venda, xml = xml });

            return "ok";
        }

    }
}
