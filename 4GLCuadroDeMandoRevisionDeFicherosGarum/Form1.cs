using _4GLCuadroDeMandoRevisionDeFicherosGarum.Model;
using _4GLCuadroDeMandoRevisionDeFicherosGarum.Service;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _4GLCuadroDeMandoRevisionDeFicherosGarum
{
    public partial class Form1 : Form
    {
        public ApiService Servicio = new ApiService();
        private Response Respuesta;
        private string tokenAPI;
        private string usuarioIdWsOk;
        private string urlApi = "";
        private readonly ArrayList ventasAutomatArray = new ArrayList();
        List<ControlAutomatResponse> automaResponses = new List<ControlAutomatResponse>();
        private WebClient webClient;
        private string ficherodescarga;
        private int FicheroVersionDownload;
        private List<FicheroGarumResponse> ficherosResponse;




        public Form1()
        {
            InitializeComponent();
            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Cargado);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Cargando);
        }
        
        
  



    private void Escribelog(string texto)
        {
            try
            {
                rtbSalidaLog.SelectedText = DateTime.Now.ToString() + " --> " + texto + "\r\n";
                rtbSalidaLog.SelectionStart = rtbSalidaLog.Text.Length;
                rtbSalidaLog.ScrollToCaret();


            }
            catch (Exception ex)
            {


            }
        }
        public async void ObtenerToken()
        {
            urlApi = TxtUrl2.Texts;
            try
            {
                Escribelog("Conectando con Servidor Central.Espere...");

                TokenRequest request = new TokenRequest
                {
                    Username = "xad@4glsp.com",
                    Password = Txtpassword.Texts,
                };

                Respuesta = await Servicio.GetTokenAsync(urlApi,
                                                           "/Account",
                                                           "/CreateToken",
                                                           request);



                Escribelog("Oteniendo token .....");


                if (!Respuesta.IsSuccess)
                {

                    Escribelog("ObtenerToken | Error en loginp para obtener el token");
                    // TxtEstadoApi.BackColor = Color.Red;
                    // TxtEstadoApi.Text = "KO";






                }
                else // si hemos obtenido respuesta
                {
                    Escribelog("ObtenerToken | Login ok. Estableciendo token");
                    TokenResponse token = (TokenResponse)Respuesta.Result;

                    string fechaWs1 = JsonConvert.SerializeObject(token.ExpirationLocal.ToString());
                    string fechaWsOk = fechaWs1.Replace("\"", "");
                    string tokenWs1 = JsonConvert.SerializeObject(token.Token.ToString());
                    tokenAPI = tokenWs1.Replace("\"", "");
                    TxtToken.Texts = tokenAPI;
                    //   TxtTokenApi.Text = tokenAPI;
                    Escribelog("token Ws Ok");
                    //   TxtEstadoApi.BackColor = Color.LightGreen;
                    //   TxtEstadoApi.Text = "OK";
                    try
                    {
                        Response response2 = await Servicio.GetUserByEmail(urlApi, "/api", "/Accounts/GetUserByEmail", "bearer", tokenAPI, "jalax@4glsp.com");
                        UserResponse userResponse = (UserResponse)response2.Result;
                        string usuarioIdWs1 = JsonConvert.SerializeObject(userResponse.Id);
                        usuarioIdWsOk = usuarioIdWs1.Replace("\"", "");
                        TxtUsuario.Texts = usuarioIdWsOk;
                        //  TxtUsuarioApi.Text = usuarioIdWsOk.ToString();




                    }
                    catch (Exception)
                    {
                        Escribelog("Problemas al obtener el id de autorizacion");

                    }

                    // como ya tengo token voy a obtener el id de la estacion





                }
            }
            catch (Exception)
            {
                //errorProvider1.SetError(textBox27, "Error al obtener el  token");
                Escribelog("Problemas al obtener el token");

            }
        }
        private void BtnRefrescarDatos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtToken.Texts))
            {
              
                ObtenerToken();
                ObtenerFicherosGarumEstacion();
            }
            else
            {
                ObtenerFicherosGarumEstacion();
            }

        }

        private async Task ObtenerFicherosGarumEstacion()
        {
            try
            {

                Respuesta = await Servicio.GetficherosGarumCuadrodeMando(urlApi, "/api", "/getficherosGarumCuadrodeMando/", "bearer", tokenAPI);

                if (!Respuesta.IsSuccess)
                {
                    Escribelog(Respuesta.Message.ToString());
                    Escribelog("ObtenerIdEstacionAsync | Respuesta Poolling KO ");

                    //MessageBox.Show("Contraseña incorrecta");
                }
                else // si hemos obtenido respuesta
                {
                    int contadorEstacionesConProblemas = 0;
                    DateTime fechaEstudio = DateTime.Now.AddHours(-12);
                    //   DateTime fechaError = DateTime.Now.AddHours(-12);
                    //                    List<ControlAutomatResponse> automaResponses = (List<ControlAutomatResponse>)Respuesta.Result;
                    ficherosResponse = (List<FicheroGarumResponse>)Respuesta.Result;
                    // automaResponses = (List<ControlAutomatResponse>)Respuesta.Result;

                    var resultados1 = ficherosResponse.OrderBy(e => e.Estacion)
                              .Where(g => g.Fecha_Estudio > fechaEstudio && !g.Nombre_Fichero.ToString().ToLower().Contains("@0@")).ToList();


                 
                    var resultado1 = from p in resultados1 // todas las eess
                                     orderby p.Estacionid,p.Nombre_Fichero
                                     select new
                                     {
                                         p.Fecha_Estudio,
                                         p.Estacionid,
                                         p.Nombre_Estacion,
                                         p.Nombre_Fichero,
                                         p.TPV,
                                     
                                     };
                    DgvFichero.DataSource = resultado1.ToList();

                    
                    foreach (DataGridViewRow itemFechaUltimaVenta in DgvFichero.Rows)
                    {
                        if (itemFechaUltimaVenta.Cells[4].Value.ToString().Contains("TPV2"))
                        {
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                           // contadorEstacionesConProblemas++;
                        }

                        else
                        {
                            if (itemFechaUltimaVenta.Cells[3].Value.ToString().ToLower().Contains("export"))
                            {
                                itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightCoral;
                            }
                            else
                            {
                                itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.Orange;
                            }

                            
                        }

                        // comprobamos si tiene la hora de la celda ultimamedion

                    }

                 



                    //// estadistica
                    //TxtTotalES.Text = resultado1.Count().ToString();
                    //TxtEsOffline.Text = resultado1.Where(r => r.ultimaMedicion < fechaLimite).Count().ToString(); // Filtrar y contar los registros que cumplen la condición
                    //TxtEsOnline.Text = (Convert.ToInt32(TxtTotalES.Text) - Convert.ToInt32(TxtEsOffline.Text)).ToString();
                    ////                    TxtEsconProblemas.Text = resultado1.Where(r => r.ultimaOperacion < fechaError).Count().ToString(); // Filtrar y contar los registros que cumplen la condición
                    //TxtEsconProblemas.Text = cuantaeessconproblemas.ToString();

                }
            }
            catch (Exception ex)
            {
                Escribelog("Error al obtener el id estacion " + ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtMail.Texts = "xad@4glsp.com";
            TxtUrl2.Texts = "https://2.139.147.209:1604";
            urlApi = "https://2.139.147.209:1604";
            //   TxtUrl.Text = "https://localhost:443";
            try
            {
                if (!Directory.Exists(@"C:\GARUMTOOLS\4GLCuadrodeMando-RevisionFicherosGarum\Descargas"))
                {
                    Directory.CreateDirectory(@"C:\GARUMTOOLS\4GLCuadrodeMando-RevisionFicherosGarum\Descargas");
                }
            }
            catch (Exception ex)
            {

              
            }
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            }
            catch (Exception ex)
            {


            }

            ObtenerToken();
            TxtHoraRevVersion.Texts= DateTime.Now.AddSeconds(Convert.ToInt32("60")).ToString();
            TxtVersion.Texts = "1.1";
        }

        private void TmrRefresco_Tick(object sender, EventArgs e)
        {
            TmrRefresco.Enabled = false;
            Lblconsulta.Visible = true;
            Escribelog("Consultando datos en central...espere");
            //   DgvSondas.DataSource = null;
            TmrConsulta.Enabled = true;
        }

        private void TmrConsulta_Tick(object sender, EventArgs e)
        {
            Lblconsulta.Visible = false;
            Escribelog("Datos obtenidos correctamente.");
            Escribelog("Actualizando vistas.");
            Escribelog("Vistas Actualizadas.");
            ObtenerFicherosGarumEstacion();
            TmrConsulta.Enabled = false;
            TmrRefresco.Enabled = true;
        }

        private void ChkEsConProblemas_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtToken.Texts))
            {
                ObtenerToken();
                ObtenerFicherosGarumEstacion();
            }
            else
            {
                ObtenerFicherosGarumEstacion();
            }
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string textoabuscar = TxtBusqueda.Texts.ToLower();
            BusquedaTotal(textoabuscar);
        }

        private void BusquedaTotal(string textoabuscar)
        {


            DgvFichero.DataSource = "";
            DgvFichero.DataSource = ficherosResponse.Where(x => x.Estacionid.ToLower().Contains(textoabuscar) || x.Nombre_Fichero.ToString().ToLower().Contains(textoabuscar) || x.Nombre_Estacion.ToString().ToLower().Contains(textoabuscar)).ToList();

            DateTime fechaEstudio = DateTime.Now.AddHours(-12);
            var resultados1 = ficherosResponse.Where(x =>!x.Nombre_Fichero.ToString().ToLower().Contains("@0@") && ( x.Estacionid.ToLower().Contains(textoabuscar) || x.Nombre_Fichero.ToString().ToLower().Contains(textoabuscar) || x.Nombre_Estacion.ToString().ToLower().Contains(textoabuscar)) );

            var resultado1 = from p in resultados1 // todas las eess
                             orderby p.Estacionid, p.Nombre_Fichero
                             select new
                             {
                                 p.Fecha_Estudio,
                                 p.Estacionid,
                                 p.Nombre_Estacion,
                                 p.Nombre_Fichero,
                                 p.TPV,

                             };
            DgvFichero.DataSource = resultado1.ToList();


            foreach (DataGridViewRow itemFechaUltimaVenta in DgvFichero.Rows)
            {
                if (itemFechaUltimaVenta.Cells[4].Value.ToString().Contains("TPV2"))
                {
                    itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    // contadorEstacionesConProblemas++;
                }

                else
                {
                    if (itemFechaUltimaVenta.Cells[3].Value.ToString().ToLower().Contains("export"))
                    {
                        itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.Orange;
                    }


                }

                // comprobamos si tiene la hora de la celda ultimamedion

            }


        }


      

        private void TmrHora_Tick(object sender, EventArgs e)
        {
            TxtHora.Texts = DateTime.Now.ToString();


            if (TxtHora.Texts == TxtHoraRevVersion.Texts)

            {
                TxtHoraRevVersion.Texts = DateTime.Now.AddMinutes(60).ToString();
                DescargarVersionApp4GLCMRevisiondeFicherosTxt();
            }

        }

        private void TControldeRetardos_Tick(object sender, EventArgs e)
        {

            if (Convert.ToDateTime(TxtHoraRevVersion.Texts) < Convert.ToDateTime(TxtHora.Texts))
            {
                TxtHoraRevVersion.Texts = DateTime.Now.AddMinutes(3).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      

        private void TxtBusqueda__TextChanged(object sender, EventArgs e)
        {
            string textoabuscar = TxtBusqueda.Texts.ToLower();
            BusquedaTotal(textoabuscar);
        }

        #region ActualizaciondelaapliacioControlDeOperacionesAutomat

        private void DescargarVersionApp4GLCMRevisiondeFicherosTxt()
        {
            BorrarFicheroVersionApp4GLCMRevisiondeFicherostxtyZip();

            try
            {
                Escribelog("DescargarVersionApp4GLCMRevisiondeFicherosTxt | Descargar fichero VersionApp4GLCMRevisiondeFicheros.txt");
                ficherodescarga = TxtUrl2.Texts + @"/Descargas/VersionApp4GLCMRevisiondeFicheros.txt";
                webClient.DownloadFileAsync(new Uri(ficherodescarga), @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.txt");

            }
            catch (Exception e)
            {
                Escribelog("DescargarVersionApp4GLCMRevisiondeFicherosTxt | Error al descargar Fichero VersionApp4GLCMRevisiondeFicheros.txt " + e.Message.ToString());
            }
        }

        private void BorrarFicheroVersionApp4GLCMRevisiondeFicherostxtyZip()
        {
            Escribelog("BorrarFicheroVersionApp4GLCMRevisiondeFicherostxtyZip | Procedemos a borrar ficheros antiguos descargados VersionApp4GLCMRevisiondeFicheros.txt y VersionApp4GLCMRevisiondeFicheros.zip ");
            if (File.Exists(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.txt"))
            {
                try
                {
                    File.Delete(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.txt");
                    Escribelog(@"BorrarFicheroVersionApp4GLCMRevisiondeFicherostxtyZip | Borrado Fichero c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.txt");

                }
                catch (Exception ex)
                {
                    Escribelog(@"BorrarFicheroVersionApp4GLCMRevisiondeFicherostxtyZip | Error al borrar el Fichero c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.txt " + ex.ToString());


                }
                try
                {
                    File.Delete(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.zip");
                    Escribelog(@"BorrarFicheroVersionApp4GLCMRevisiondeFicherostxtyZip | Borrado Fichero c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.zip");

                }
                catch (Exception ex)
                {
                    Escribelog(@"BorrarFicheroVersionApp4GLCMRevisiondeFicherostxtyZip | Error al borrar el Fichero  c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.zip " + ex.ToString());


                }


            }

        }

        private void LeerVersionApp()
        {

            bool descargaractualizacionApp;
            descargaractualizacionApp = false;
            try
            {
                if (File.Exists(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\descargas\VersionApp4GLCMRevisiondeFicheros.txt"))

                {

                    string line;

                    // Read the file and display it line by line.  
                    System.IO.StreamReader file =
                        new System.IO.StreamReader(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\descargas\VersionApp4GLCMRevisiondeFicheros.txt");
                    line = file.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {

                        if (line.Trim() != TxtVersion.Texts)
                        {
                            Escribelog("LeerVersionApp          | Version de App no actualizada");
                            descargaractualizacionApp = true;
                        }
                        else
                        {
                            Escribelog("LeerVersionApp          | Comprobando version de APP y esta actualizada");
                        }

                    }

                    file.Close();
                    if (descargaractualizacionApp == true)
                    {
                        DescargarActualizacionApp();
                    }
                    else // si no tiene version qeu descargar no hace nada y se para el circuito pone el ficherodownload a 0
                    {
                        FicheroVersionDownload = 0;

                        // TODO aqui vamos a meter el reinicio cada 12 horas si fuera necesario
                        // System.Diagnostics.Process.Start(@"C:\GARUMTOOLS\4GLControlDeOperacionesAutomat\ReiniciaTcpToCom.exe");
                    }
                }
                else
                {
                    FicheroVersionDownload = 0;

                }

            }
            catch (Exception e)
            {
                FicheroVersionDownload = 0;
                Escribelog("LeerVersionApp          | Problema al procesar el fichero VersionApp4GLCMRevisiondeFicheros.txt" + e.Message);
            }

        }
        private void DescargarActualizacionApp()
        {
            try
            {
                Escribelog("DescargarActualizacionAp| Descargar fichero VersionApp4GLCMRevisiondeFicheros.zip");
                ficherodescarga = TxtUrl2.Texts + @"/Descargas/VersionApp4GLCMRevisiondeFicheros.zip";
                webClient.DownloadFileAsync(new Uri(ficherodescarga), @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.zip");

            }
            catch (Exception e)
            {
                Escribelog("DescargarActualizacionAp| Error al descargar Fichero VersionApp4GLCMRevisiondeFicheros.zip " + e.Message.ToString());
            }
        }

        #region Cargando
        private void Cargando(object sender, DownloadProgressChangedEventArgs e)
        {
            BarraProgreso.Value = e.ProgressPercentage;

        }




        #endregion
        #region Cargado
        private void Cargado(object sender, AsyncCompletedEventArgs e)
        {
            switch (FicheroVersionDownload)
            {
                case 0:
                    FicheroVersionDownload = 1;
                    LeerVersionApp();

                    break;
                case 1:
                    DescomprimirversionApp();
                    break;

                default:
                    break;
            }


        }





        #endregion
        private void DescomprimirversionApp()
        {
            if (Directory.Exists(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\UltimaVersionApp")) // si existe lo vacia de todo
            {
                Directory.Delete(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\UltimaVersionApp", true);
                Directory.CreateDirectory(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\UltimaVersionApp"); // lo vuelve a crear

            }
            else
            {
                Directory.CreateDirectory(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\UltimaVersionApp"); //si no existe lo crea
            }

            if (Directory.Exists(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\UltimaVersionApp")) // una vez que esta vacio descomprimimos en el
            {
                try
                {
                    ZipFile.ExtractToDirectory(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\VersionApp4GLCMRevisiondeFicheros.zip", @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\UltimaVersionApp");
                    Escribelog("DescomprimirversionApp  | Descomprimimos la nueva version de VersionApp4GLCMRevisiondeFicheros y la actualizamos");
                    // aqui llamamos al bat qeu hace copia de seguridad y actualiza version
                    System.Diagnostics.Process.Start(@"C:\GARUMTOOLS\4GLCuadrodeMando-RevisionFicherosGarum\4GLActualizadorCuadroDeMandoRevisionDeFicherosGarum.exe");

                }
                catch (Exception ex)
                {

                    Escribelog("DescomprimirversionApp  | Error al descomprimir la nueva version de VersionApp4GLCMRevisiondeFicheros " + ex.ToString());

                }

            }
        }



        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
               Process[] LocalByName = Process.GetProcessesByName("4GLCuadroDeMandoRevisionDeFicherosGarum");

                foreach (Process proc in LocalByName)
                {

                    //  proc.Kill();

                }

                string directorioorigen = @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum";
                string directoriobackup = @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\Backup" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                string directoriodedescarga = @"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\Descargas\UltimaVersionApp\";
                if (!Directory.Exists(directoriobackup)) // si no existe lo creo y copio el contenido de todo el directorio de control incidencias
                {
                    Directory.CreateDirectory(directoriobackup);
                }

                if (Directory.Exists(directorioorigen) && Directory.Exists(directoriodedescarga)) //compruebo qeu existen el directorio de origen y el de descarga 
                {

                    string[] fileEntries = Directory.GetFiles(directorioorigen);

                    foreach (string fileName in fileEntries)
                    {
                        string ficherosource = fileName;
                        string ficherodestino = directoriobackup + @"/" + fileName.Replace(@"\", "").Substring(50, fileName.Replace(@"\", "").Length - 50);
                        try
                        {
                            File.Copy(ficherosource, ficherodestino);
                        }
                        catch (Exception)
                        {

                        }


                    }
                    string[] fileEntries1 = Directory.GetFiles(directoriodedescarga);

                    foreach (string fileName in fileEntries1)
                    {
                        string ficherosource = fileName;
                        string ficherodestino = directorioorigen + @"\" + fileName.Replace(@"\", "").Substring(66, fileName.Replace(@"\", "").Length - 66);
                        try
                        {
                            File.Copy(ficherosource, ficherodestino, true);
                        }
                        catch (Exception)
                        {

                        }


                    }

                }

                try
                {
                    Thread.Sleep(5000);
                    System.Diagnostics.Process.Start(@"c:\garumtools\4GLCuadrodeMando-RevisionFicherosGarum\4GLCuadroDeMandoRevisionDeFicherosGarum.exe");


                }
                catch (Exception)
                {


                }
            
        }
    }


}

