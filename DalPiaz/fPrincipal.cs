using DalPiaz.contexto;
using DalPiaz.Model;
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

namespace DalPiaz
{
 
   
    public partial class FormPrincipal : Form
    {
        public static List<Configuracao> configuracoes;

        static Thread tLog;
        static Thread tUploadArq;
        static Thread tUploadArqLoop;
        int _MINUTOS=999;
        int _LINHAS_LOG = 999;
        string _EXECUTAR_AO_ABRIR="N";

        private bool allowVisible = true;
        private bool allowClose = false;

        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }


        public FormPrincipal()
        {
            configuracoes = new List<Configuracao>();
            if (tUploadArqLoop == null)
                tUploadArqLoop = new Thread(new ParameterizedThreadStart(TUploadArqPortal));
            InitializeComponent();
            notifyIcon1.Icon = new Icon(GetType(), "icone.ico");
        }



        #region Upload de Arquivos 

       

        private void btExecutar_Click_1(object sender, EventArgs e)
        {

            ExecucaoPrincipal();
        }

        public void ExecucaoPrincipal()
        {
            //Inicialização da tImportacaoCO para utilização de N parâmetros 
            //A Thrad em questão aceita o recebimento de 'object' apenas. Então:
            //  1. vamos enviar um List<object> 
            //  2. o List<object> será recebido como 'object'
            //  3. Agora o 'object' tem um filho List<object>
            //  4. Resgatar o filho de 'object'
            //  5. O filho , depois do cast será do tipo List<object> novamente.
            //  6. Pegar os elementos da lista e utilizá-los
            List<object> objList = new List<object>();

            //Adicionando o botão de importação
            objList.Add(btExecutar);
            //Verificando se a Thread em questão esá ativa
            //Adicionando Verificação de Existencia de Loop ou não
            if (!tUploadArqLoop.IsAlive)
                // Loop
                objList.Add(true);
            else
                // Executa apenas 1 vez
                objList.Add(false);
            //Adicionando Tempo em minutos
            objList.Add(3);


            if (tUploadArqLoop.IsAlive)//tImportacaoCO será executada apenas 1 vez
            {

                tUploadArq = new Thread(new ParameterizedThreadStart(TUploadArqPortal));
                tUploadArq.Start(objList);

            }
            else
            {
                //tImportacaoCO será executada N vezes
                tUploadArqLoop.Start(objList);
            }
        }

        public void LerArquivoConfiguracaoDp()
        {
            //Lendo do arquivo local
            string[] fonte = System.IO.File.ReadAllLines(Path.Combine(
                "C:\\dpsync",
                "configuracao.dp"),
                Encoding.GetEncoding("ISO-8859-1"));

            configuracoes = new List<Configuracao>();

            //Leitura do arquivo de configuração
            foreach (string line in fonte)
            {
                if (line.Contains("#"))
                    continue;
                if (!line.Contains("="))
                    continue;

                string[] split = line.Split("=".ToCharArray());

                string parametro = split[0];
                string valor = split[1];
                if (string.IsNullOrEmpty(parametro) || string.IsNullOrEmpty(valor))
                {
                    continue;
                }

                parametro = parametro.Trim();
                valor = valor.Trim();

                //atualizando valor da lista configuracoes
                configuracoes.Add(
                        new Configuracao
                        {
                            parametro = parametro,
                            valor = valor
                        }
                    );





            }


            //atualizando valores do form principal

            lbValorInputXml.Text = Configuracao.RetornaConfiguracao(
                        ParametrosValor.INPUT_XML,
                        configuracoes
                        );

            lbInputPlanilhaExcel.Text = Configuracao.RetornaConfiguracao(
                        ParametrosValor.INPUT_EXCEL,
                        configuracoes
                        );


            lbOutputCsv.Text = Configuracao.RetornaConfiguracao(
                        ParametrosValor.OUTPUT_TXT,
                        configuracoes
                        ) + " / " + Configuracao.RetornaConfiguracao(
                        ParametrosValor.OUTPUT_TXT_POSICAO,
                        configuracoes)
                        ;

            lbOutputXml.Text = Configuracao.RetornaConfiguracao(
                        ParametrosValor.OUTPUT_XML,
                        configuracoes
                        );

            lbOutputRaiz.Text =  Configuracao.RetornaConfiguracao(
                        ParametrosValor.OUTPUT_RAIZ,
                        configuracoes
                        );

            lbMoved.Text = Configuracao.RetornaConfiguracao(
                        ParametrosValor.MOVED_XML,
                        configuracoes
                        );

            try
            {
                _MINUTOS = Convert.ToInt32(
                        Configuracao.RetornaConfiguracao(
                          ParametrosValor.INTERVALO_MINUTOS,
                          configuracoes
                          )
                    );
            }
            catch 
            {
                lbMinuto.Text = "Verifique o arquivo de configuração";
            }

            lbMinuto.Text = _MINUTOS.ToString() ;


            int _FUSO = 0;
            try
            {
                _FUSO = Convert.ToInt32(
                        Configuracao.RetornaConfiguracao(
                          ParametrosValor.FUSO_HORARIO,
                          configuracoes
                          )
                    );
            }
            catch
            {
                lbFuso.Text = "Verifique o arquivo de configuração";
            }

            lbFuso.Text = _FUSO.ToString();


            try
            {
                _EXECUTAR_AO_ABRIR = 
                       Configuracao.RetornaConfiguracao(
                         ParametrosValor.EXECUTAR_AO_ABRIR,
                         configuracoes
                     );
            }
            catch 
            {

               
            }
            lbExecutarAoAbrir.Text = _EXECUTAR_AO_ABRIR == "S" ? "Sim" : "Não";




            
            try
            {
                _LINHAS_LOG = Convert.ToInt32(
                        Configuracao.RetornaConfiguracao(
                          ParametrosValor.QTD_LOG,
                          configuracoes
                          )
                    );
            }
            catch
            {
            }

            lbQtdLog.Text = "Mostando as primeiras " + _LINHAS_LOG.ToString() + " linhas do log:";



        }
    

        public void TUploadArqPortal(object obj)
        {

            List<object> objList = (List<object>)obj;

            Button btImportacao = (Button)objList[0];
            bool loopImportacao = (bool)objList[1];
            int tempoLoop = (int)objList[2];

            while (true)
            {

                Invoke(new Action(() =>
                {
                    btImportacao.Enabled = false;
                    btImportacao.Text = "Executando";
                }));


                LerArquivoConfiguracaoDp();



                //Leitura dos arquivos XML de entrada
                LeituraXml.PegarTodosOsArquivosDeUmaPasta(
                    Configuracao.RetornaConfiguracao(
                        ParametrosValor.INPUT_XML,
                        configuracoes
                        )
                    );

                //Invoke(new Action(() =>
                //{
                //    btImportacao.Enabled = true;
                //}));

                if (!loopImportacao)
                    break;
                Thread.Sleep(TimeSpan.FromMinutes(_MINUTOS));
            }



        }
        #endregion


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void TListLog(object obj)
        {
            while (true)
            {

                Invoke(new Action(() =>
                {
                    rtLog.Enabled = true;
                    
                    using (var ctx = new DPSyncContext())
                    {
                        rtLog.Text = "Total de logs: " + ctx.logs.Count() + Environment.NewLine;
                        List<Log> list  = ctx.logs.Take(_LINHAS_LOG).OrderByDescending(x=>x.dataCriacao).ToList();
                        foreach (Log item in list)
                        {
                            rtLog.Text += item.dataCriacao + "\t" + item.aviso + "\t"+ item.arquivo + Environment.NewLine + Environment.NewLine;
                        }
                    }

                }));




                Thread.Sleep(TimeSpan.FromMinutes(_MINUTOS));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LerArquivoConfiguracaoDp();
            if (_EXECUTAR_AO_ABRIR == "S")
            {
                ExecucaoPrincipal();
            }


            tLog = new Thread(new ParameterizedThreadStart(TListLog));
            tLog.Start();

        }

     
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            allowVisible = true;
            Show();
        }

        private void brEncerrarAplicacao_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
            System.Windows.Forms.Application.Exit();
            System.Environment.Exit(1);
        }
    }
}
