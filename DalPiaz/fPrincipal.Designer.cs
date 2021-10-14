

namespace DalPiaz
{
    partial class FormPrincipal
    {


        


        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.lbEntradaXML = new System.Windows.Forms.Label();
            this.lbPlanilha = new System.Windows.Forms.Label();
            this.lbArquivosSaida = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbInputPlanilhaExcel = new System.Windows.Forms.Label();
            this.lbValorInputXml = new System.Windows.Forms.Label();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.lbOutputXml = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOutputCsv = new System.Windows.Forms.Label();
            this.btExecutar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.brEncerrarAplicacao = new System.Windows.Forms.Button();
            this.lbExecutarAoAbrir = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbIntervalo = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbTituloApp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbOutputRaiz = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMoved = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFuso = new System.Windows.Forms.Label();
            this.lbMinuto = new System.Windows.Forms.Label();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.lbQtdLog = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbEntradaXML
            // 
            this.lbEntradaXML.AutoSize = true;
            this.lbEntradaXML.Location = new System.Drawing.Point(22, 30);
            this.lbEntradaXML.Name = "lbEntradaXML";
            this.lbEntradaXML.Size = new System.Drawing.Size(76, 13);
            this.lbEntradaXML.TabIndex = 0;
            this.lbEntradaXML.Text = "Arquivos XML:";
            this.lbEntradaXML.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbPlanilha
            // 
            this.lbPlanilha.AutoSize = true;
            this.lbPlanilha.Location = new System.Drawing.Point(22, 55);
            this.lbPlanilha.Name = "lbPlanilha";
            this.lbPlanilha.Size = new System.Drawing.Size(76, 13);
            this.lbPlanilha.TabIndex = 4;
            this.lbPlanilha.Text = "Planilha Excel:";
            this.lbPlanilha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbArquivosSaida
            // 
            this.lbArquivosSaida.AutoSize = true;
            this.lbArquivosSaida.Location = new System.Drawing.Point(22, 21);
            this.lbArquivosSaida.Name = "lbArquivosSaida";
            this.lbArquivosSaida.Size = new System.Drawing.Size(120, 13);
            this.lbArquivosSaida.TabIndex = 5;
            this.lbArquivosSaida.Text = "Arquivos de saída TXT:";
            this.lbArquivosSaida.UseMnemonic = false;
            this.lbArquivosSaida.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbInputPlanilhaExcel);
            this.groupBox1.Controls.Add(this.lbValorInputXml);
            this.groupBox1.Controls.Add(this.lbEntradaXML);
            this.groupBox1.Controls.Add(this.lbPlanilha);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 81);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Caminhos para  Input";
            // 
            // lbInputPlanilhaExcel
            // 
            this.lbInputPlanilhaExcel.AutoSize = true;
            this.lbInputPlanilhaExcel.Location = new System.Drawing.Point(115, 55);
            this.lbInputPlanilhaExcel.Name = "lbInputPlanilhaExcel";
            this.lbInputPlanilhaExcel.Size = new System.Drawing.Size(82, 13);
            this.lbInputPlanilhaExcel.TabIndex = 6;
            this.lbInputPlanilhaExcel.Text = "não encontrado";
            // 
            // lbValorInputXml
            // 
            this.lbValorInputXml.AutoSize = true;
            this.lbValorInputXml.Location = new System.Drawing.Point(115, 29);
            this.lbValorInputXml.Name = "lbValorInputXml";
            this.lbValorInputXml.Size = new System.Drawing.Size(0, 13);
            this.lbValorInputXml.TabIndex = 5;
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.lbMoved);
            this.groupBoxOutput.Controls.Add(this.label4);
            this.groupBoxOutput.Controls.Add(this.lbOutputRaiz);
            this.groupBoxOutput.Controls.Add(this.label3);
            this.groupBoxOutput.Controls.Add(this.lbOutputXml);
            this.groupBoxOutput.Controls.Add(this.label2);
            this.groupBoxOutput.Controls.Add(this.lbOutputCsv);
            this.groupBoxOutput.Controls.Add(this.lbArquivosSaida);
            this.groupBoxOutput.Location = new System.Drawing.Point(12, 168);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(776, 119);
            this.groupBoxOutput.TabIndex = 7;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Caminhos para Output";
            // 
            // lbOutputXml
            // 
            this.lbOutputXml.AutoSize = true;
            this.lbOutputXml.Location = new System.Drawing.Point(176, 45);
            this.lbOutputXml.Name = "lbOutputXml";
            this.lbOutputXml.Size = new System.Drawing.Size(82, 13);
            this.lbOutputXml.TabIndex = 9;
            this.lbOutputXml.Text = "não encontrado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Arquivos de saída XML:";
            this.label2.UseMnemonic = false;
            // 
            // lbOutputCsv
            // 
            this.lbOutputCsv.AutoSize = true;
            this.lbOutputCsv.Location = new System.Drawing.Point(176, 21);
            this.lbOutputCsv.Name = "lbOutputCsv";
            this.lbOutputCsv.Size = new System.Drawing.Size(82, 13);
            this.lbOutputCsv.TabIndex = 7;
            this.lbOutputCsv.Text = "não encontrado";
            // 
            // btExecutar
            // 
            this.btExecutar.Location = new System.Drawing.Point(25, 28);
            this.btExecutar.Name = "btExecutar";
            this.btExecutar.Size = new System.Drawing.Size(96, 42);
            this.btExecutar.TabIndex = 8;
            this.btExecutar.Text = "Executar";
            this.btExecutar.UseVisualStyleBackColor = true;
            this.btExecutar.Click += new System.EventHandler(this.btExecutar_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbMinuto);
            this.groupBox3.Controls.Add(this.lbFuso);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.brEncerrarAplicacao);
            this.groupBox3.Controls.Add(this.lbExecutarAoAbrir);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lbIntervalo);
            this.groupBox3.Controls.Add(this.btExecutar);
            this.groupBox3.Location = new System.Drawing.Point(12, 293);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 87);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Execução";
            // 
            // brEncerrarAplicacao
            // 
            this.brEncerrarAplicacao.Location = new System.Drawing.Point(650, 35);
            this.brEncerrarAplicacao.Name = "brEncerrarAplicacao";
            this.brEncerrarAplicacao.Size = new System.Drawing.Size(94, 41);
            this.brEncerrarAplicacao.TabIndex = 13;
            this.brEncerrarAplicacao.Text = "Encerrar Aplicação";
            this.brEncerrarAplicacao.UseVisualStyleBackColor = true;
            this.brEncerrarAplicacao.Click += new System.EventHandler(this.brEncerrarAplicacao_Click);
            // 
            // lbExecutarAoAbrir
            // 
            this.lbExecutarAoAbrir.AutoSize = true;
            this.lbExecutarAoAbrir.Location = new System.Drawing.Point(278, 42);
            this.lbExecutarAoAbrir.Name = "lbExecutarAoAbrir";
            this.lbExecutarAoAbrir.Size = new System.Drawing.Size(82, 13);
            this.lbExecutarAoAbrir.TabIndex = 12;
            this.lbExecutarAoAbrir.Text = "não encontrado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Executar ao abrir:";
            // 
            // lbIntervalo
            // 
            this.lbIntervalo.AutoSize = true;
            this.lbIntervalo.Location = new System.Drawing.Point(176, 16);
            this.lbIntervalo.Name = "lbIntervalo";
            this.lbIntervalo.Size = new System.Drawing.Size(96, 13);
            this.lbIntervalo.TabIndex = 9;
            this.lbIntervalo.Text = "Intervalo (minutos):";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "DPSync";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // lbTituloApp
            // 
            this.lbTituloApp.AutoSize = true;
            this.lbTituloApp.Font = new System.Drawing.Font("Trebuchet MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTituloApp.Location = new System.Drawing.Point(299, 19);
            this.lbTituloApp.Name = "lbTituloApp";
            this.lbTituloApp.Size = new System.Drawing.Size(156, 49);
            this.lbTituloApp.TabIndex = 10;
            this.lbTituloApp.Text = "DPSync";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output raiz: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbOutputRaiz
            // 
            this.lbOutputRaiz.AutoSize = true;
            this.lbOutputRaiz.Location = new System.Drawing.Point(176, 68);
            this.lbOutputRaiz.Name = "lbOutputRaiz";
            this.lbOutputRaiz.Size = new System.Drawing.Size(76, 13);
            this.lbOutputRaiz.TabIndex = 10;
            this.lbOutputRaiz.Text = "Planilha Excel:";
            this.lbOutputRaiz.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Arquivos movidos: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbMoved
            // 
            this.lbMoved.AutoSize = true;
            this.lbMoved.Location = new System.Drawing.Point(176, 93);
            this.lbMoved.Name = "lbMoved";
            this.lbMoved.Size = new System.Drawing.Size(76, 13);
            this.lbMoved.TabIndex = 12;
            this.lbMoved.Text = "Planilha Excel:";
            this.lbMoved.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Fuso Horário:";
            // 
            // lbFuso
            // 
            this.lbFuso.AutoSize = true;
            this.lbFuso.Location = new System.Drawing.Point(278, 63);
            this.lbFuso.Name = "lbFuso";
            this.lbFuso.Size = new System.Drawing.Size(82, 13);
            this.lbFuso.TabIndex = 15;
            this.lbFuso.Text = "não encontrado";
            // 
            // lbMinuto
            // 
            this.lbMinuto.AutoSize = true;
            this.lbMinuto.Location = new System.Drawing.Point(281, 16);
            this.lbMinuto.Name = "lbMinuto";
            this.lbMinuto.Size = new System.Drawing.Size(35, 13);
            this.lbMinuto.TabIndex = 16;
            this.lbMinuto.Text = "label6";
            // 
            // rtLog
            // 
            this.rtLog.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtLog.Location = new System.Drawing.Point(12, 399);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(776, 272);
            this.rtLog.TabIndex = 11;
            this.rtLog.Text = "";
            // 
            // lbQtdLog
            // 
            this.lbQtdLog.AutoSize = true;
            this.lbQtdLog.Location = new System.Drawing.Point(12, 383);
            this.lbQtdLog.Name = "lbQtdLog";
            this.lbQtdLog.Size = new System.Drawing.Size(82, 13);
            this.lbQtdLog.TabIndex = 17;
            this.lbQtdLog.Text = "não encontrado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(526, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Aquivo configuração:  c:\\dpsync\\configuracao.db";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(26, 0);
            this.linkLabel1.Location = new System.Drawing.Point(4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 16);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.Text = "http://lucasdalpiaz.com.br";
            this.linkLabel1.UseCompatibleTextRendering = true;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 699);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbQtdLog);
            this.Controls.Add(this.rtLog);
            this.Controls.Add(this.lbTituloApp);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DPSync";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEntradaXML;
        private System.Windows.Forms.Label lbPlanilha;
        private System.Windows.Forms.Label lbArquivosSaida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.Button btExecutar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbIntervalo;
        private System.Windows.Forms.Label lbValorInputXml;
        private System.Windows.Forms.Label lbInputPlanilhaExcel;
        private System.Windows.Forms.Label lbOutputCsv;
        private System.Windows.Forms.Label lbExecutarAoAbrir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button brEncerrarAplicacao;
        private System.Windows.Forms.Label lbTituloApp;
        private System.Windows.Forms.Label lbOutputXml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbOutputRaiz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbMoved;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbFuso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbMinuto;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Label lbQtdLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

