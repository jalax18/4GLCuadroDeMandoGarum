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
            urlApi = TxtUrl.Text;
            try
            {
                Escribelog("Conectando con Servidor Central.Espere...");

                TokenRequest request = new TokenRequest
                {
                    Username = "xad@4glsp.com",
                    Password = Txtpassword.Text,
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
                    TxtToken.Text = tokenAPI;
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
                        TxtUsuario.Text = usuarioIdWsOk;
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
            if (string.IsNullOrEmpty(TxtToken.Text))
            {
                ObtenerToken();
                ObtenerAutomatEstacion();
            }
            else
            {
                ObtenerAutomatEstacion();
            }

        }

        private async Task ObtenerAutomatEstacion()
        {
            try
            {

                Respuesta = await Servicio.GetautomatEstacion(urlApi, "/api", "/getautomatestacion/", "bearer", tokenAPI);

                if (!Respuesta.IsSuccess)
                {
                    Escribelog(Respuesta.Message.ToString());
                    Escribelog("ObtenerIdEstacionAsync | Respuesta Poolling KO ");

                    //MessageBox.Show("Contraseña incorrecta");
                }
                else // si hemos obtenido respuesta
                {
                    int contadorEstacionesConProblemas = 0;
                    DateTime fechaLimite = DateTime.Now.AddHours(-1);
                    //   DateTime fechaError = DateTime.Now.AddHours(-12);
                    //                    List<ControlAutomatResponse> automaResponses = (List<ControlAutomatResponse>)Respuesta.Result;
                    automaResponses = (List<ControlAutomatResponse>)Respuesta.Result;

                    var resultados1 = automaResponses.GroupBy(e => e.idEstacion)
                               .Select(g => g.OrderByDescending(e => e.ultimaMedicion).First()).ToList();

                    var resultados2 = automaResponses.GroupBy(e => e.idEstacion)
                               .Select(g => g.OrderByDescending(e => e.ultimaMedicion).First()).Where(r => r.ultimaOperacion < DateTime.Now.AddHours(-1 * r.horasError) || r.externaVenta != 0 || r.mm4 > 10 || r.ultimaMedicion < DateTime.Now.AddHours(-1)).ToList();
                    int cuantaeessconproblemas = automaResponses.GroupBy(e => e.idEstacion)
                               .Select(g => g.OrderByDescending(e => e.ultimaMedicion).First()).Where(r => r.ultimaOperacion < DateTime.Now.AddHours(-1 * r.horasError) || r.externaVenta != 0 || r.mm4 > 10 || r.ultimaMedicion < DateTime.Now.AddHours(-1)).Count();

                    var resultado1 = from p in resultados1 // todas las eess
                                     orderby p.horasError
                                     select new
                                     {
                                         p.ultimaMedicion,
                                         p.ultimaOperacion,
                                         p.estacion,
                                         p.idEstacion,
                                         p.horasError,
                                         p.externaVenta,
                                         p.mm4,
                                         p.versionApp,
                                         p.id,
                                         //    p.producto,
                                         //    p.litros,
                                         //    p.precio,
                                         //    p.importe,
                                         //    p.descuento,

                                     };

                    var resultado2 = from p in resultados2 // solo las de error
                                     orderby p.horasError
                                     select new
                                     {
                                         p.ultimaMedicion,
                                         p.ultimaOperacion,
                                         p.estacion,
                                         p.idEstacion,
                                         p.horasError,
                                         p.externaVenta,
                                         p.mm4,
                                         p.versionApp,
                                         p.id,
                                         //    p.producto,
                                         //    p.litros,
                                         //    p.precio,
                                         //    p.importe,
                                         //    p.descuento,

                                     };
                    //


                    if (!ChkEsConProblemas.Checked)
                    {
                        DgvAutomat.DataSource = resultado1.ToList();
                    }
                    else
                    {
                        DgvAutomat.DataSource = resultado2.ToList();
                    }

                    //foreach (DataGridViewRow itemFechaUltimaVenta in DgvAutomat.Rows)
                    //{
                    //    if (Convert.ToInt32(itemFechaUltimaVenta.Cells[5].Value)>1 || Convert.ToInt32(itemFechaUltimaVenta.Cells[6].Value) > 10)
                    //    {
                    //        itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightCoral;
                    //        contadorEstacionesConProblemas++;
                    //    }
                    //    else
                    //    {
                    //        itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightGreen;
                    //    }

                    //    // comprobamos si tiene la hora de la celda ultimamedion

                    //}

                    foreach (DataGridViewRow itemFechaUltimaVenta in DgvAutomat.Rows)
                    {
                        if (Convert.ToDateTime(itemFechaUltimaVenta.Cells[1].Value.ToString()) < DateTime.Now.AddHours(-1 * (Convert.ToInt32(itemFechaUltimaVenta.Cells[4].Value))) || Convert.ToInt32(itemFechaUltimaVenta.Cells[5].Value) > 1 || Convert.ToInt32(itemFechaUltimaVenta.Cells[6].Value) > 10)
                        {
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.Orange;
                            contadorEstacionesConProblemas++;
                        }

                        else
                        {
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightGreen;
                        }

                        // comprobamos si tiene la hora de la celda ultimamedion

                    }

                    foreach (DataGridViewRow itemFechaUltimaVenta in DgvAutomat.Rows)
                    {
                        if (Convert.ToDateTime(itemFechaUltimaVenta.Cells[0].Value.ToString()) < DateTime.Now.AddHours(-1))
                        {
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                        }


                        // comprobamos si tiene la hora de la celda ultimamedion

                    }



                    foreach (DataGridViewRow itemFechaUltimaVenta in DgvAutomat.Rows)
                    {
                        if (Convert.ToInt32(itemFechaUltimaVenta.Cells[5].Value) > 1 || Convert.ToInt32(itemFechaUltimaVenta.Cells[6].Value) > 10)
                        {
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightCoral;
                            contadorEstacionesConProblemas++;
                        }

                        //else
                        //{
                        //    itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightGreen;
                        //}

                        // comprobamos si tiene la hora de la celda ultimamedion

                    }
                    // estadistica
                    TxtTotalES.Text = resultado1.Count().ToString();
                    TxtEsOffline.Text = resultado1.Where(r => r.ultimaMedicion < fechaLimite).Count().ToString(); // Filtrar y contar los registros que cumplen la condición
                    TxtEsOnline.Text = (Convert.ToInt32(TxtTotalES.Text) - Convert.ToInt32(TxtEsOffline.Text)).ToString();
                    //                    TxtEsconProblemas.Text = resultado1.Where(r => r.ultimaOperacion < fechaError).Count().ToString(); // Filtrar y contar los registros que cumplen la condición
                    TxtEsconProblemas.Text = cuantaeessconproblemas.ToString();

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
            TxtMail.Text = "xad@4glsp.com";
            TxtUrl.Text = "https://2.139.147.209:1604";
            urlApi = "https://2.139.147.209:1604";
            //   TxtUrl.Text = "https://localhost:443";
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            }
            catch (Exception ex)
            {


            }

            ObtenerToken();
            TxtHoraRevVersion.Text = DateTime.Now.AddSeconds(Convert.ToInt32("60")).ToString();
            TxtVersion.Text = "1.4";
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
            ObtenerAutomatEstacion();
            TmrConsulta.Enabled = false;
            TmrRefresco.Enabled = true;
        }

        private void ChkEsConProblemas_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtToken.Text))
            {
                ObtenerToken();
                ObtenerAutomatEstacion();
            }
            else
            {
                ObtenerAutomatEstacion();
            }
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string textoabuscar = TxtBusqueda.Text.ToLower();
            BusquedaTotal(textoabuscar);
        }

        private void BusquedaTotal(string textoabuscar)
        {


            DgvAutomat.DataSource = "";
            DgvAutomat.DataSource = automaResponses.Where(x => x.estacion.ToLower().Contains(textoabuscar) || x.idEstacion.ToString().Contains(textoabuscar)).ToList();
            var resultados1 = automaResponses.Where(x => x.estacion.ToLower().Contains(textoabuscar) || x.idEstacion.ToString().Contains(textoabuscar)).GroupBy(e => e.idEstacion)
                            .Select(g => g.OrderByDescending(e => e.ultimaMedicion).First()).ToList();

            var resultados2 = automaResponses.Where(x => x.estacion.ToLower().Contains(textoabuscar) || x.idEstacion.ToString().Contains(textoabuscar)).GroupBy(e => e.idEstacion)
                       .Select(g => g.OrderByDescending(e => e.ultimaMedicion).First()).Where(r => r.ultimaOperacion < DateTime.Now.AddHours(-1 * r.horasError)).ToList();


            var resultado1 = from p in resultados1 // todas las eess
                             orderby p.horasError
                             select new
                             {
                                 p.ultimaMedicion,
                                 p.ultimaOperacion,
                                 p.estacion,
                                 p.idEstacion,
                                 p.horasError,
                                 p.externaVenta,
                                 p.mm4,
                                 p.versionApp,
                                 //    p.producto,
                                 //    p.litros,
                                 //    p.precio,
                                 //    p.importe,
                                 //    p.descuento,

                             };

            var resultado2 = from p in resultados2 // solo las de error
                             orderby p.horasError
                             select new
                             {
                                 p.ultimaMedicion,
                                 p.ultimaOperacion,
                                 p.estacion,
                                 p.idEstacion,
                                 p.horasError,
                                 p.externaVenta,
                                 p.mm4,
                                 p.versionApp,
                                 //    p.producto,
                                 //    p.litros,
                                 //    p.precio,
                                 //    p.importe,
                                 //    p.descuento,

                             };
            //

            int contadorEstacionesConProblemas = 0;
            if (!ChkEsConProblemas.Checked)
            {
                DgvAutomat.DataSource = resultado1.ToList();
            }
            else
            {
                DgvAutomat.DataSource = resultado2.ToList();
            }

            foreach (DataGridViewRow itemFechaUltimaVenta in DgvAutomat.Rows)
            {
                if (Convert.ToDateTime(itemFechaUltimaVenta.Cells[1].Value.ToString()) < DateTime.Now.AddHours(-1 * (Convert.ToInt32(itemFechaUltimaVenta.Cells[4].Value))))
                {
                    itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightCoral;
                    contadorEstacionesConProblemas++;
                }
                else
                {
                    itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                // comprobamos si tiene la hora de la celda ultimamedion

            }

            foreach (DataGridViewRow itemFechaUltimaVenta in DgvAutomat.Rows)
            {
                if (Convert.ToDateTime(itemFechaUltimaVenta.Cells[0].Value.ToString()) < DateTime.Now.AddHours(-1))
                {
                    itemFechaUltimaVenta.DefaultCellStyle.BackColor = Color.Orange;

                }


                // comprobamos si tiene la hora de la celda ultimamedion

            }

            // estadistica
            TxtTotalES.Text = resultado1.Count().ToString();

            DateTime fechaLimite = DateTime.Now.AddHours(-1);

            TxtEsOffline.Text = resultado1.Where(r => r.ultimaMedicion < fechaLimite).Count().ToString(); // Filtrar y contar los registros que cumplen la condición
            TxtEsOnline.Text = (Convert.ToInt32(TxtTotalES.Text) - Convert.ToInt32(TxtEsOffline.Text)).ToString();
            //                    TxtEsconProblemas.Text = resultado1.Where(r => r.ultimaOperacion < fechaError).Count().ToString(); // Filtrar y contar los registros que cumplen la condición
            TxtEsconProblemas.Text = contadorEstacionesConProblemas.ToString();


        }


        #region ActualizaciondelaapliacioControlDeOperacionesAutomat

        private void DescargarVersionApp4GLCuadrodeMandoAutomatTxt()
        {
            BorrarFicheroVersionApp4GLCuadrodeMandoAutomattxtyZip();

            try
            {
                Escribelog("DescargarVersionApp4GLCuadrodeMandoAutomatTxt | Descargar fichero VersionApp4GLCuadrodeMandoAutomat.txt");
                ficherodescarga = TxtUrl.Text + @"/Descargas/VersionApp4GLCuadrodeMandoAutomat.txt";
                webClient.DownloadFileAsync(new Uri(ficherodescarga), @"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.txt");

            }
            catch (Exception e)
            {
                Escribelog("DescargarVersionApp4GLCuadrodeMandoAutomatTxt | Error al descargar Fichero VersionApp4GLCuadrodeMandoAutomat.txt " + e.Message.ToString());
            }
        }

        private void BorrarFicheroVersionApp4GLCuadrodeMandoAutomattxtyZip()
        {
            Escribelog("BorrarFicheroVersionApp4GLCuadrodeMandoAutomattxtyZip | Procedemos a borrar ficheros antiguos descargados VersionApp4GLCuadrodeMandoAutomat.txt y VersionApp4GLCuadrodeMandoAutomat.zip ");
            if (File.Exists(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.txt"))
            {
                try
                {
                    File.Delete(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.txt");
                    Escribelog(@"BorrarFicheroVersionApp | Borrado Fichero c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.txt");

                }
                catch (Exception ex)
                {
                    Escribelog(@"BorrarFicheroVersionApp4GLCuadrodeMandoAutomattxtyZip | Error al borrar el Fichero c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.txt " + ex.ToString());


                }
                try
                {
                    File.Delete(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.zip");
                    Escribelog(@"BorrarFicheroVersionApp4GLCuadrodeMandoAutomattxtyZip | Borrado Fichero c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.zip");

                }
                catch (Exception ex)
                {
                    Escribelog(@"BorrarFicheroVersionApp4GLCuadrodeMandoAutomattxtyZip | Error al borrar el Fichero  c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.zip " + ex.ToString());


                }


            }

        }

        private void LeerVersionApp()
        {

            bool descargaractualizacionApp;
            descargaractualizacionApp = false;
            try
            {
                if (File.Exists(@"c:\garumtools\4GLCuadrodeMando-Automat\descargas\VersionApp4GLCuadrodeMandoAutomat.txt"))

                {

                    string line;

                    // Read the file and display it line by line.  
                    System.IO.StreamReader file =
                        new System.IO.StreamReader(@"c:\garumtools\4GLCuadrodeMando-Automat\descargas\VersionApp4GLCuadrodeMandoAutomat.txt");
                    line = file.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {

                        if (line.Trim() != TxtVersion.Text)
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
                Escribelog("LeerVersionApp          | Problema al procesar el fichero VersionApp4GLCuadrodeMandoAutomat.txt" + e.Message);
            }

        }
        private void DescargarActualizacionApp()
        {
            try
            {
                Escribelog("DescargarActualizacionAp| Descargar fichero VersionApp4GLCuadrodeMandoAutomat.zip");
                ficherodescarga = TxtUrl.Text + @"/Descargas/VersionApp4GLCuadrodeMandoAutomat.zip";
                webClient.DownloadFileAsync(new Uri(ficherodescarga), @"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.zip");

            }
            catch (Exception e)
            {
                Escribelog("DescargarActualizacionAp| Error al descargar Fichero VersionApp4GLCuadrodeMandoAutomat.zip " + e.Message.ToString());
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
            if (Directory.Exists(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\UltimaVersionApp")) // si existe lo vacia de todo
            {
                Directory.Delete(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\UltimaVersionApp", true);
                Directory.CreateDirectory(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\UltimaVersionApp"); // lo vuelve a crear

            }
            else
            {
                Directory.CreateDirectory(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\UltimaVersionApp"); //si no existe lo crea
            }

            if (Directory.Exists(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\UltimaVersionApp")) // una vez que esta vacio descomprimimos en el
            {
                try
                {
                    ZipFile.ExtractToDirectory(@"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\VersionApp4GLCuadrodeMandoAutomat.zip", @"c:\garumtools\4GLCuadrodeMando-Automat\Descargas\UltimaVersionApp");
                    Escribelog("DescomprimirversionApp  | Descomprimimos la nueva version de VersionApp4GLCuadrodeMandoAutomat y la actualizamos");
                    // aqui llamamos al bat qeu hace copia de seguridad y actualiza version
                    System.Diagnostics.Process.Start(@"C:\GARUMTOOLS\4GLCuadrodeMando-Automat\4GLCuadroDeMandoAutomatActualizador.exe");

                }
                catch (Exception ex)
                {

                    Escribelog("DescomprimirversionApp  | Error al descomprimir la nueva version de VersionApp4GLCuadrodeMandoAutomat " + ex.ToString());

                }

            }
        }

        #endregion

        private void TmrHora_Tick(object sender, EventArgs e)
        {
            TxtHora.Text = DateTime.Now.ToString();


            if (TxtHora.Text == TxtHoraRevVersion.Text)

            {
                TxtHoraRevVersion.Text = DateTime.Now.AddMinutes(60).ToString();
                DescargarVersionApp4GLCuadrodeMandoAutomatTxt();
            }

        }

        private void TControldeRetardos_Tick(object sender, EventArgs e)
        {

            if (Convert.ToDateTime(TxtHoraRevVersion.Text) < Convert.ToDateTime(TxtHora.Text))
            {
                TxtHoraRevVersion.Text = DateTime.Now.AddMinutes(3).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       

      
    }


}

