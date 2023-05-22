using _4GLCuadroDeMandoRevisionDeAjustesGarum.Model;
using _4GLCuadroDeMandoRevisionDeAjustesGarum.Service;
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

namespace _4GLCuadroDeMandoRevisionDeAjustesGarum
{
    public partial class Form1 : Form
    {
        public ApiService Servicio = new ApiService();
        private Response RespuestaTotalEStaciones;
        private Response Respuesta;
        private string tokenAPI;
        private string usuarioIdWsOk;
        private string urlApi = "";
        private readonly ArrayList ventasAutomatArray = new ArrayList();
        List<ControlAutomatResponse> automaResponses = new List<ControlAutomatResponse>();
        private WebClient webClient;
        private string ficherodescarga;
        private int FicheroVersionDownload;
        private List<EstudioAjusteResponse>  estudioAjusteResponses;
        private int modo = 0;
        private int estadoParpadeo = 0;

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
       

        private async Task ObtenerAjustesGarumEstacion()
        {
            try
            {
                FechaRequest fechaRequest = new FechaRequest
                {
                    Fecha = DateTime.Now.AddHours(1).ToString()
                };

                RespuestaTotalEStaciones = await Servicio.GetEstacionAsyncTotal(urlApi, "/api", "/cestacionesoffline/", "bearer", tokenAPI, DateTime.Now.AddHours(1));

                TxtTotalES.Texts = RespuestaTotalEStaciones.Result.ToString();

                RespuestaTotalEStaciones = await Servicio.GetEstacionAsyncTotal(urlApi, "/api", "/cestacionesoffline/", "bearer", tokenAPI, DateTime.Now.AddHours(-2));

                TxtEsOnline.Texts = RespuestaTotalEStaciones.Result.ToString();


                TxtEsOffline.Texts = (Convert.ToInt32(TxtTotalES.Texts) - Convert.ToInt32(TxtEsOnline.Texts)).ToString();

                Respuesta = await Servicio.GetAjustesGarumCuadrodeMando(urlApi, "/api", "/listadoestudioajustes", "bearer", tokenAPI,Convert.ToDateTime(TxtFechaInicial.Texts), Convert.ToDateTime(TxtFechaFinal.Texts));

                if (!Respuesta.IsSuccess)
                {
                    Escribelog(Respuesta.Message.ToString());
                    Escribelog("ObtenerIdEstacionAsync | Respuesta Poolling KO ");

                    //MessageBox.Show("Contraseña incorrecta");
                }
                else // si hemos obtenido respuesta
                {
                    int contadorEstacionesConProblemas = 0;
                    DateTime fechaEstudio = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                    estudioAjusteResponses = (List<EstudioAjusteResponse>)Respuesta.Result;
                    // voy a contar registros de estaciones agrupados por estacion

                    estudioAjusteResponses.Count();
                    TxtEsconProblemas.Texts = estudioAjusteResponses.Where(f=>f.Diferencia!=0).GroupBy(e => e.Nombre_Estacion).Count().ToString();

                    var listadoEStacionesConProblemas = estudioAjusteResponses.GroupBy(e => e.Nombre_Estacion).ToList();




                    var resultados1 = estudioAjusteResponses.Where(f => f.Diferencia != 0).OrderBy(e => e.Estacion).ToList();
                             


                    var resultado1 = from p in resultados1 // todas las eess
                                     orderby p.Nombre_Estacion

                                     select new
                                     {
                                         p.Fecha_estudio,
                                         p.Fecha_Ajustes,
                                         p.Nombre_Estacion,
                                         p.surtidor,
                                         p.Manguera,
                                         p.Tipo_contador_inicial,
                                         p.LitrosLec,
                                         p.Litrosvta,
                                         p.Diferencia,

                                     };

                    DgvFichero.DataSource = listadoEStacionesConProblemas;
                    DgvFichero.DataSource = resultado1.ToList();
                    refrescaGrid();

                   




                }
            }
            catch (Exception ex)
            {
                Escribelog("Error al obtener el id estacion " + ex.ToString());
            }
        }

        private void BusquedaTotal(string textoabuscar)
        {


            DgvFichero.DataSource = "";
            DgvFichero.DataSource = estudioAjusteResponses.Where(x => x.Nombre_Estacion.ToLower().Contains(textoabuscar)).ToList();

            var resultados1 = estudioAjusteResponses.Where(x => x.Nombre_Estacion.ToLower().Contains(textoabuscar) && x.Diferencia!=0);

            var resultado1 = from p in resultados1 // todas las eess
                             orderby p.Nombre_Estacion

                             select new
                             {
                                 p.Fecha_estudio,
                                 p.Fecha_Ajustes,
                                 p.Nombre_Estacion,
                                 p.surtidor,
                                 p.Manguera,
                                 p.Tipo_contador_inicial,
                                 p.LitrosLec,
                                 p.Litrosvta,
                                 p.Diferencia,

                             };

         



            DgvFichero.DataSource = resultado1.ToList();

            refrescaGrid();




        }


        private void TControldeRetardos_Tick(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(TxtHoraRevVersion.Texts) < Convert.ToDateTime(TxtHora.Texts))
            {
                TxtHoraRevVersion.Texts = DateTime.Now.AddMinutes(3).ToString();
            }
        }

        private void TmrConsulta_Tick(object sender, EventArgs e)
        {
            Lblconsulta.Visible = false;
            Escribelog("Datos obtenidos correctamente.");
            Escribelog("Actualizando vistas.");
            Escribelog("Vistas Actualizadas.");
            ObtenerAjustesGarumEstacion();
            TmrConsulta.Enabled = false;
            TmrRefresco.Enabled = true;
        }

        private void TmrRefresco_Tick(object sender, EventArgs e)
        {
            TmrRefresco.Enabled = false;
            Lblconsulta.Visible = true;
            Escribelog("Consultando datos en central...espere");
            //   DgvSondas.DataSource = null;
            TmrConsulta.Enabled = true;
        }

        private void TmrParpadeo_Tick(object sender, EventArgs e)
        {
            if (modo == 1) // pongo gris y blanco
            {
                switch (estadoParpadeo)
                {
                    case 0:
                        LblAviso.ForeColor = ColorTranslator.FromHtml("#868686");
                        estadoParpadeo = 1;
                        break;
                    case 1:
                        LblAviso.ForeColor = Color.White;
                        estadoParpadeo = 0;
                        break;
                    default:
                        break;
                }

            }
            else // pongo azul y rojo
            {
                switch (estadoParpadeo)
                {
                    case 0:
                        LblAviso.ForeColor = Color.FromArgb(0, 74, 174);
                        estadoParpadeo = 1;
                        break;
                    case 1:
                        LblAviso.ForeColor = Color.Red;
                        estadoParpadeo = 0;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtFechaInicial.Texts = DateTime.Now.AddDays(-1).ToShortDateString() + " " + "07:00:00";
            TxtFechaFinal.Texts = DateTime.Now.ToString();
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
            TxtHoraRevVersion.Texts = DateTime.Now.AddSeconds(Convert.ToInt32("60")).ToString();
            TxtVersion.Texts = "1.1";


        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRefrescarDatos_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtToken.Texts))
            {

                ObtenerToken();
                ObtenerAjustesGarumEstacion();
            }
            else
            {
                ObtenerAjustesGarumEstacion();
            }

        }

        private void ChkEsConProblemas_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtToken.Texts))
            {
                ObtenerToken();
                ObtenerAjustesGarumEstacion();
            }
            else
            {
                ObtenerAjustesGarumEstacion();
            }
        }

        private void TxtBusqueda__TextChanged(object sender, EventArgs e)
        {
            string textoabuscar = TxtBusqueda.Texts.ToLower();
            BusquedaTotal(textoabuscar);
        }

     

        private void EstablecerModo(int modo)
        {

            switch (modo)
            {
                case 0:
                    this.BackColor = ColorTranslator.FromHtml("#ffffff");
                    groupBox1.ForeColor = Color.Black;
                    groupBox3.ForeColor = Color.Black;
                    BtnRefrescarDatos.Normalcolor = ColorTranslator.FromHtml("#004AAA");
                    BtnRefrescarDatos.OnHovercolor = Color.RoyalBlue;
                    BtnSalir.Normalcolor = ColorTranslator.FromHtml("#004AAA");
                    BtnSalir.OnHovercolor = Color.RoyalBlue;
                    // Recorrer todos los controles en el formulario
                    foreach (Control control in this.groupBox1.Controls)
                    {
                        //   MessageBox.Show(control.ToString());
                        // Verificar si el control es un Label

                        if (control is Label label)
                        {
                            // Cambiar el color de fondo del Label
                            label.ForeColor = ColorTranslator.FromHtml("#004AAA");
                        }

                        if (control is CheckBox checkBox)
                        {
                            // Cambiar el color de fondo del Label
                            checkBox.ForeColor = ColorTranslator.FromHtml("#004AAA");
                        }

                        if (control is CustomControls.RJControls.RJTextBox rjcontrol)
                        {
                            // Cambiar el color de fondo del Label
                            // rjcontrol.BackColor = Color.Transparent;
                            rjcontrol.ForeColor = ColorTranslator.FromHtml("#000000");
                            rjcontrol.BackColor = ColorTranslator.FromHtml("#ffffff");
                            rjcontrol.BorderColor = ColorTranslator.FromHtml("#004AAA");
                        }


                    }

                    foreach (Control control in this.groupBox2.Controls)
                    {
                        //   MessageBox.Show(control.ToString());
                        // Verificar si el control es un Label
                        if (control is DataGrid dataGrid)
                        {
                            // Cambiar el color de fondo del Label
                            dataGrid.ForeColor = Color.Black;

                        }


                        if (control is Label label)
                        {
                            // Cambiar el color de fondo del Label
                            label.ForeColor = ColorTranslator.FromHtml("#004AAA");
                        }

                        if (control is CheckBox checkBox)
                        {
                            // Cambiar el color de fondo del Label
                            checkBox.ForeColor = ColorTranslator.FromHtml("#004AAA");
                        }

                        if (control is CustomControls.RJControls.RJTextBox rjcontrol)
                        {
                            // Cambiar el color de fondo del Label
                            // rjcontrol.BackColor = Color.Transparent;
                            rjcontrol.ForeColor = ColorTranslator.FromHtml("#000000");
                            rjcontrol.BackColor = ColorTranslator.FromHtml("#ffffff");
                            rjcontrol.BorderColor = ColorTranslator.FromHtml("#004AAA");
                        }



                    }

                    foreach (Control control in this.groupBox3.Controls)
                    {
                        //   MessageBox.Show(control.ToString());
                        // Verificar si el control es un Label


                        if (control is Label label)
                        {
                            // Cambiar el color de fondo del Label
                            label.ForeColor = ColorTranslator.FromHtml("#004AAA");
                        }

                        if (control is CheckBox checkBox)
                        {
                            // Cambiar el color de fondo del Label
                            checkBox.ForeColor = ColorTranslator.FromHtml("#004AAA");
                        }

                        if (control is RichTextBox richTextBox)
                        {
                            // Cambiar el color de fondo del Label
                            richTextBox.ForeColor = ColorTranslator.FromHtml("#00000");
                            richTextBox.BackColor = ColorTranslator.FromHtml("#ffffff");
                        }

                        if (control is CustomControls.RJControls.RJTextBox rjcontrol)
                        {
                            // Cambiar el color de fondo del Label
                            // rjcontrol.BackColor = Color.Transparent;
                            rjcontrol.ForeColor = Color.Black;
                            rjcontrol.BackColor = ColorTranslator.FromHtml("#ffffff");
                            rjcontrol.BorderColor = ColorTranslator.FromHtml("#004AAA");
                        }



                    }
                    break;
                case 1:
                    //this.BackColor = ColorTranslator.FromHtml("#250517");
                    //this.BackColor = ColorTranslator.FromHtml("#302217");
                    //this.BackColor = ColorTranslator.FromHtml("#342826");
                    //this.BackColor = ColorTranslator.FromHtml("#292a2c");
                    this.BackColor = ColorTranslator.FromHtml("#555555");
                    groupBox1.ForeColor = Color.White;
                    groupBox3.ForeColor = Color.White;
                    BtnRefrescarDatos.Normalcolor = Color.Orange;
                    BtnRefrescarDatos.OnHovercolor = Color.Moccasin;
                    BtnSalir.Normalcolor = Color.Orange;
                    BtnSalir.OnHovercolor = Color.Moccasin;
                    // Recorrer todos los controles en el formulario
                    foreach (Control control in this.groupBox1.Controls)
                    {
                        //   MessageBox.Show(control.ToString());
                        // Verificar si el control es un Label

                        if (control is Label label)
                        {
                            // Cambiar el color de fondo del Label
                            label.ForeColor = Color.White;
                            //  label.ForeColor = ColorTranslator.FromHtml("#3f3835");
                            label.ForeColor = ColorTranslator.FromHtml("#868686");
                        }

                        if (control is CheckBox checkBox)
                        {
                            // Cambiar el color de fondo del Label
                            checkBox.ForeColor = ColorTranslator.FromHtml("#868686");
                        }

                        if (control is CustomControls.RJControls.RJTextBox rjcontrol)
                        {
                            // Cambiar el color de fondo del Label
                            // rjcontrol.BackColor = Color.Transparent;
                            //  rjcontrol.ForeColor = ColorTranslator.FromHtml("#267f79");
                            rjcontrol.ForeColor = ColorTranslator.FromHtml("#868686");
                            //rjcontrol.BackColor = ColorTranslator.FromHtml("#696969");
                            //rjcontrol.BackColor = ColorTranslator.FromHtml("#242424");
                            rjcontrol.BackColor = ColorTranslator.FromHtml("#444444");
                            //  rjcontrol.BorderColor = Color.White;
                            rjcontrol.BorderColor = ColorTranslator.FromHtml("#333333");
                        }


                    }

                    foreach (Control control in this.groupBox2.Controls)
                    {
                        //   MessageBox.Show(control.ToString());
                        // Verificar si el control es un Label
                        if (control is DataGrid dataGrid)
                        {
                            // Cambiar el color de fondo del Label
                            dataGrid.ForeColor = Color.Black;

                        }


                        if (control is Label label)
                        {
                            // Cambiar el color de fondo del Label
                            label.ForeColor = Color.White;
                        }

                        if (control is CheckBox checkBox)
                        {
                            // Cambiar el color de fondo del Label
                            checkBox.ForeColor = Color.White;
                        }

                        if (control is CustomControls.RJControls.RJTextBox rjcontrol)
                        {
                            // Cambiar el color de fondo del Label
                            // rjcontrol.BackColor = Color.Transparent;
                            rjcontrol.ForeColor = Color.White;
                            rjcontrol.BackColor = ColorTranslator.FromHtml("#696969");
                            rjcontrol.BorderColor = Color.White;
                        }



                    }

                    foreach (Control control in this.groupBox3.Controls)
                    {
                        //   MessageBox.Show(control.ToString());
                        // Verificar si el control es un Label


                        if (control is Label label)
                        {
                            // Cambiar el color de fondo del Label
                            label.ForeColor = ColorTranslator.FromHtml("#868686");
                        }

                        if (control is CheckBox checkBox)
                        {
                            // Cambiar el color de fondo del Label
                            checkBox.ForeColor = ColorTranslator.FromHtml("#868686"); ;
                        }

                        if (control is RichTextBox richTextBox)
                        {
                            // Cambiar el color de fondo del Label
                            richTextBox.ForeColor = ColorTranslator.FromHtml("#868686");
                            //  richTextBox.ForeColor = ColorTranslator.FromHtml("#267f79");
                            richTextBox.BackColor = ColorTranslator.FromHtml("#444444");
                        }

                        if (control is CustomControls.RJControls.RJTextBox rjcontrol)
                        {
                            // Cambiar el color de fondo del Label
                            // rjcontrol.BackColor = Color.Transparent;
                            rjcontrol.ForeColor = Color.White;
                            rjcontrol.BackColor = ColorTranslator.FromHtml("#696969");
                            rjcontrol.BorderColor = Color.White;
                        }



                    }

                    break;
                default:
                    break;
            }


        }
        private void refrescaGrid()
        {
            foreach (DataGridViewRow itemFechaUltimaVenta in DgvFichero.Rows)
            {
              
                    if (!itemFechaUltimaVenta.Cells[8].Value.ToString().ToLower().Contains("-"))
                    {
                        if (modo == 1)
                        {
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#444444");
                            itemFechaUltimaVenta.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#fdccd4");
                        }
                        else
                        {
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fdccd4");
                            itemFechaUltimaVenta.DefaultCellStyle.ForeColor = Color.Black;


                        }
                    }
                    else
                    {
                        if (modo == 1) // naranja
                        {
                            
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#444444");
                            itemFechaUltimaVenta.DefaultCellStyle.ForeColor = Color.Orange;
                        }
                        else
                        {
                            itemFechaUltimaVenta.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ffd971");
                            itemFechaUltimaVenta.DefaultCellStyle.ForeColor = Color.Black;

                        }
                    }


                

                // comprobamos si tiene la hora de la celda ultimamedion

            }



            DgvFichero.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (modo == 1)
            {
                DgvFichero.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#444444");
                DgvFichero.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DgvFichero.BackgroundColor = ColorTranslator.FromHtml("#444444");

            }
            else
            {
                DgvFichero.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                DgvFichero.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                DgvFichero.BackgroundColor = ColorTranslator.FromHtml("#ffffff");


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
         private void SwOscuro_Click(object sender, EventArgs e)
        {
             switch (SwOscuro.Value)
            {
                case true:
                    modo = 1;

                    break;
                case false:
                    modo = 0;
                    break;

                default:
                    break;
            }
            EstablecerModo(modo);
            refrescaGrid();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
     
