using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalPiaz.Model
{
    public enum ParametrosValor
    {
        INPUT_XML,
        INPUT_EXCEL,
        OUTPUT_XML,
        MOVED_XML,
        OUTPUT_TXT,
        OUTPUT_TXT_POSICAO,
        EXECUTAR_AO_ABRIR,
        INTERVALO_MINUTOS,
        OUTPUT_RAIZ,
        FUSO_HORARIO,
        QTD_LOG

    }

    public class Configuracao
    {
        public string parametro { get; set; }
        public string valor { get; set; }

        public static string RetornaConfiguracao(ParametrosValor op, List<Configuracao> configuracoes)
        {
            return configuracoes.Find(c => c.parametro == Configuracao.RetornaParametroConfiguracao(op)).valor;

        }
        public static string RetornaParametroConfiguracao(ParametrosValor op)
        {
            switch (op)
            {
                case ParametrosValor.INPUT_XML: return "INPUT_XML";
                case ParametrosValor.INPUT_EXCEL: return "INPUT_EXCEL";
                case ParametrosValor.OUTPUT_XML: return "OUTPUT_XML";
                case ParametrosValor.OUTPUT_RAIZ: return "OUTPUT_RAIZ";
                case ParametrosValor.MOVED_XML: return "MOVED_XML";
                case ParametrosValor.OUTPUT_TXT: return "OUTPUT_TXT";
                case ParametrosValor.OUTPUT_TXT_POSICAO: return "OUTPUT_TXT_POSICAO";
                case ParametrosValor.INTERVALO_MINUTOS: return "INTERVALO_MINUTOS";
                case ParametrosValor.EXECUTAR_AO_ABRIR: return "EXECUTAR_AO_ABRIR";
                case ParametrosValor.FUSO_HORARIO: return "FUSO_HORARIO";
                case ParametrosValor.QTD_LOG: return "QTD_LOG";
                default: return "";
            }
        }

        
    }
}
