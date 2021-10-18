using ClosedXML.Excel;
using CsvHelper;
using DalPiaz.contexto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DalPiaz.Model
{
    public static class LeituraXml
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        
        public static void PegarTodosOsArquivosDeUmaPasta(string pasta)
        {
            try
            {
                int max;

                using (var ctx = new DPSyncContext())
                {

                    try
                    {
                        max = ctx.messageFiles.Select(p => p.Id).DefaultIfEmpty(0).Max();


                        //monstar lista de esn e barco
                        List<EsnBarco> esnBarcos = new List<EsnBarco>();
                        string fileName = Configuracao.RetornaConfiguracao(ParametrosValor.INPUT_EXCEL, FormPrincipal.configuracoes);
                        using (var excelWorkbook = new XLWorkbook(fileName))
                        {
                            var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed();

                            foreach (var dataRow in nonEmptyDataRows)
                            {
                                if (dataRow.Cell(2) == null || dataRow.Cell(1) == null)
                                {
                                    continue;
                                }

                                string _DADOS_ESN = dataRow.Cell(2).Value.ToString();
                                string _DADOS_BARCO = dataRow.Cell(1).Value.ToString();
                                //for row number check
                                if (dataRow.RowNumber() > 1)
                                {
                                    esnBarcos.Add(
                                            new EsnBarco
                                            {
                                                Esn = _DADOS_ESN.Trim(),
                                                Barco = _DADOS_BARCO.Trim()
                                            }
                                        );
                                }
                            }
                        }


                        double _DEGREE_PER_COUNT_LAT = (90.0 / (Math.Pow(2, 23)));
                        double _DEGREE_PER_COUNT_LONG = (180.0 / (Math.Pow(2, 23)));

                        string[] dirs = Directory.GetFiles(@pasta, "*.xml");
                        Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                        foreach (string dir in dirs)
                        {
                            string _NOME_ARQUIVO = dir.Split("\\".ToCharArray()).LastOrDefault();
                            try
                            {
                                var serializer = new XmlSerializer(typeof(StuMessages));
                                StuMessages configuracao = new StuMessages();

                                using (var textReader = new StreamReader(dir))
                                {
                                    configuracao = (StuMessages)serializer.Deserialize(textReader);
                                }

                                //Operações de saída xml
                                Positions POS = new Positions();
                                POS.Position = new Position();

                                string _NAME_OUTPUT_FILE = "";

                                string _ERRO_LOG = "";

                                foreach (StuMessage item in configuracao.StuMessage)
                                {

                                    //calculo da latitude
                                    int _HEX_LAT = Convert.ToInt32(item.Payload.Text.Substring(4, 6), 16);

                                    double _LATITUDE = _HEX_LAT * _DEGREE_PER_COUNT_LAT;
                                    if (_LATITUDE > 90)
                                    {
                                        _LATITUDE = _LATITUDE - 180;
                                    }

                                    //calculo longitude
                                    int _HEX_LONG = Convert.ToInt32(item.Payload.Text.Substring(10, 6), 16);

                                    double _LONGITUDE = _HEX_LAT * _DEGREE_PER_COUNT_LONG;
                                    if (_LONGITUDE > 180)
                                    {
                                        _LONGITUDE = _LONGITUDE - 360;
                                    }




                                    Position p = new Position();
                                    p.Id = ++max;

                                    p.Lat = Math.Round(_LATITUDE, 6);
                                    p.Lon = Math.Round(_LONGITUDE, 6);
                                    try
                                    {
                                        p.Mobile = esnBarcos.FirstOrDefault(eb => eb.Esn == item.Esn).Barco;
                                    }
                                    catch
                                    {

                                        _ERRO_LOG = "SEM CORRESPONDÊNCIA PARA BARCOS: " + item.Esn + " ARQUIVO:" + _NOME_ARQUIVO;
                                        continue;
                                    }

                                    DateTime dataAux = epoch.AddSeconds(item.UnixTime);
                                    int fusoHorario = Convert.ToInt32(Configuracao.RetornaConfiguracao(ParametrosValor.FUSO_HORARIO, FormPrincipal.configuracoes).Trim());
                                    dataAux = dataAux.AddHours(fusoHorario);


                                    p.Date = dataAux.ToString("yyyy-MM-dd HH:mm:ss");



                                    _NAME_OUTPUT_FILE = p.Mobile + "_" + dataAux.ToString("yyyyMMdd_HHmmss");

                                    if (item.Esn == "0-3380787")
                                    {

                                    }

                                    //salvando no banco
                                    MessageFile m = new MessageFile
                                    {
                                        Id = max,
                                        Esn = item.Esn,
                                        InputXml = dir.Split("\\".ToCharArray()).LastOrDefault(),
                                        DataConvertida = p.Date,
                                        DataPos =   Convert.ToDateTime(p.Date),
                                        DataCriacao = DateTime.Now,
                                        Tipo = "GLOBAL",
                                        Payload = item.Payload.Text,
                                        Unixtime = item.UnixTime.ToString(),
                                        Lat = p.Lat.ToString(),
                                        Lon = p.Lon.ToString(),
                                        Mobile = p.Mobile,
                                        OutputCsv = _NAME_OUTPUT_FILE + ".csv",
                                        OutputXml = _NAME_OUTPUT_FILE + ".xml"
                                    };



                                    MessageFile mFinded = ctx.messageFiles.FirstOrDefault(x => x.InputXml == m.InputXml && x.Esn == m.Esn);
                                    if (mFinded == null)
                                    {
                                        POS.Position = p;
                                        m.Id = p.Id;
                                        ctx.messageFiles.Add(m);
                                        ctx.SaveChanges();

                                    }
                                    else
                                    {
                                        //_ERRO_LOG = "DUPLICIDADE: " + mFinded.InputXml;
                                       // continue;

                                    }

                                    //criando diretorio para arquivo xml
                                    string raizSubnivel1 = Configuracao.RetornaConfiguracao(ParametrosValor.OUTPUT_RAIZ, FormPrincipal.configuracoes) + "\\" +
                                         Configuracao.RetornaConfiguracao(ParametrosValor.OUTPUT_XML, FormPrincipal.configuracoes) +
                                         "\\" + p.Mobile.ToUpper();
                                    if (!Directory.Exists(raizSubnivel1))
                                        Directory.CreateDirectory(raizSubnivel1);





                                    //Salvando xml de saída
                                    serializer = new XmlSerializer(typeof(Positions));
                                    var localArquivo = raizSubnivel1 + "\\" + _NAME_OUTPUT_FILE + ".xml";
                                    var xmlNamespaces = new XmlSerializerNamespaces();

                                    using (var textWriter = new StreamWriter(localArquivo))
                                    {
                                        serializer.Serialize(textWriter, POS, xmlNamespaces);
                                    }

                                    //diretorio para saida txt
                                    string raizSubnivel2 = Configuracao.RetornaConfiguracao(ParametrosValor.OUTPUT_RAIZ, FormPrincipal.configuracoes) + "\\" +
                                         Configuracao.RetornaConfiguracao(ParametrosValor.OUTPUT_TXT, FormPrincipal.configuracoes) +
                                         "\\" + p.Mobile.ToUpper();
                                    if (!Directory.Exists(raizSubnivel2))
                                        Directory.CreateDirectory(raizSubnivel2);
                                    var csv = new StringBuilder();
                                    var newLine = NmeaGPGGA(dataAux, p.Lat.ToString(), p.Lon.ToString());
                                    csv.Append(newLine);

                                    //after your loop
                                    File.WriteAllText(
                                        raizSubnivel2 + "\\" + _NAME_OUTPUT_FILE + ".txt",
                                        csv.ToString());





                                    //diretorio para saida txt daposição
                                    string raizSubnivel3 = Configuracao.RetornaConfiguracao(ParametrosValor.OUTPUT_RAIZ, FormPrincipal.configuracoes) + "\\" +
                                         Configuracao.RetornaConfiguracao(ParametrosValor.OUTPUT_TXT_POSICAO, FormPrincipal.configuracoes);
                                    if (!Directory.Exists(raizSubnivel3))
                                        Directory.CreateDirectory(raizSubnivel3);



                                    

                                    //verificar ultimo horario
                                    MessageFile aux = ctx.messageFiles.OrderByDescending(x => x.DataPos).Where(x => x.Mobile == p.Mobile.Trim().ToUpper()).FirstOrDefault();


                                    if (aux != null)
                                    {
                                        //remove o arquivo  e cria outro
                                        File.Delete(raizSubnivel3 + "\\" + p.Mobile.Trim().ToUpper() + ".txt");
                                    }

                                    if (Convert.ToDateTime(p.Date).CompareTo(aux.DataPos) >= 0)
                                    {
                                        csv = new StringBuilder();
                                        newLine = NmeaGPGGA(dataAux, p.Lat.ToString(), p.Lon.ToString());
                                        csv.Append(newLine);

                                        //after your loop
                                        File.WriteAllText(
                                            raizSubnivel3 + "\\" + p.Mobile.Trim().ToUpper() + ".txt",
                                            csv.ToString());
                                    }
                                    else
                                    {
                                        csv = new StringBuilder();
                                        newLine = NmeaGPGGA(aux.DataPos, p.Lat.ToString(), p.Lon.ToString());
                                        csv.Append(newLine);

                                        //after your loop
                                        File.WriteAllText(
                                            raizSubnivel3 + "\\" + p.Mobile.Trim().ToUpper() + ".txt",
                                            csv.ToString());
                                    }





                                    //
                                    //bool jaExiste = false;
                                    //string[] dirsPosicao = Directory.GetFiles(raizSubnivel3, "*.txt");
                                    //foreach (string dirP in dirsPosicao)
                                    //{
                                    //    string nomeBarcoDataHora = dirP.Split("\\".ToCharArray()).LastOrDefault().Replace(".txt", "").ToUpper();
                                    //    string[] vetNomeBarco = nomeBarcoDataHora.Split("_".ToCharArray());

                                    //    string hora = vetNomeBarco[vetNomeBarco.Length - 1];
                                    //    string data = vetNomeBarco[vetNomeBarco.Length - 2];

                                    //    string nomeBarco = nomeBarcoDataHora.Replace("_" + data + "_" + hora, "");



                                    //    if (nomeBarco == p.Mobile.ToUpper())
                                    //    {




                                    //        //DateTime dataHoraP = DateTime.ParseExact(data + " " + hora, "yyyyMMdd HHmmss", null);
                                    //        if (Convert.ToDateTime(p.Date).CompareTo(aux.DataPos) >= 0)
                                    //        {


                                    //        }

                                    //        //arquivo já existe
                                    //        jaExiste = true;

                                    //    }
                                    //}

                                    //if (jaExiste == false)
                                    //{
                                    //    csv = new StringBuilder();
                                    //    newLine = NmeaGPGGA(dataAux, p.Lat.ToString(), p.Lon.ToString());
                                    //    csv.Append(newLine);

                                    //    //after your loop
                                    //    File.WriteAllText(
                                    //        raizSubnivel3 + "\\" + _NAME_OUTPUT_FILE + ".txt",
                                    //        csv.ToString());

                                    //}






                                }

                                //mover arquivo  .xml para outra pasta
                                if (string.IsNullOrEmpty(_ERRO_LOG))
                                {
                                    string dirAlvo = Path.Combine(
                                    Configuracao.RetornaConfiguracao(ParametrosValor.MOVED_XML, FormPrincipal.configuracoes),
                                    dir.Split("\\".ToCharArray()).LastOrDefault()
                                    );

                                    System.IO.File.Move(dir, dirAlvo);
                                }
                                else
                                {
                                    Log l = ctx.logs.FirstOrDefault(x => x.arquivo == _NOME_ARQUIVO && x.aviso == _ERRO_LOG);

                                    if (l == null)
                                    {
                                        ctx.logs.Add(new Log
                                        {
                                            dataCriacao = DateTime.Now,
                                            arquivo = _NOME_ARQUIVO,
                                            aviso = _ERRO_LOG
                                        });

                                        ctx.SaveChanges();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Log l = ctx.logs.FirstOrDefault(x => x.arquivo == _NOME_ARQUIVO && x.aviso == ex.Message);

                                if (l==null)
                                {
                                    ctx.logs.Add(new Log
                                    {
                                        dataCriacao = DateTime.Now,
                                        arquivo = _NOME_ARQUIVO,
                                        aviso = ex.Message
                                    });

                                    ctx.SaveChanges();
                                }
                                
                            }




                        }
                    }
                    catch (Exception ex)
                    {
                       Log l = ctx.logs.FirstOrDefault(x => x.arquivo == "NÃO FOI POSSÍVEL LER AQUIVOS" && x.aviso == ex.Message);
                        if (l == null)
                        {
                            ctx.logs.Add(new Log
                            {
                                dataCriacao = DateTime.Now,
                                arquivo = "NÃO FOI POSSÍVEL LER AQUIVOS",
                                aviso = ex.Message
                            });

                            ctx.SaveChanges();
                        }
                        
                    }


                   
                }
               
               
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static string NmeaGPGGA( DateTime date, string lat, string lon)
        {
            string data = date.ToString("yyyyMMdd");
            string hora = date.ToString("HHmmss");
            return $@"$GPGGA,{hora},{lat.Replace(",",".")},S,{lon.Replace(",", ".")},W";
        }


    }
}
