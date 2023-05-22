
namespace _4GLCuadroDeMandoRevisionDeAjustesGarum
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LblAviso = new System.Windows.Forms.Label();
            this.DgvFichero = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblAviso1 = new System.Windows.Forms.Label();
            this.Lblconsulta = new System.Windows.Forms.Label();
            this.TmrRefresco = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbSalidaLog = new System.Windows.Forms.RichTextBox();
            this.TmrParpadeo = new System.Windows.Forms.Timer(this.components);
            this.TmrHora = new System.Windows.Forms.Timer(this.components);
            this.TControldeRetardos = new System.Windows.Forms.Timer(this.components);
            this.LOGO = new System.Windows.Forms.PictureBox();
            this.TmrConsulta = new System.Windows.Forms.Timer(this.components);
            this.BtnRefrescarDatos = new ns1.BunifuFlatButton();
            this.BtnSalir = new ns1.BunifuFlatButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SwOscuro = new ns1.BunifuSwitch();
            this.label16 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BarraProgreso = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ChkEsConProblemas = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TxtFechaFinal = new CustomControls.RJControls.RJTextBox();
            this.TxtFechaInicial = new CustomControls.RJControls.RJTextBox();
            this.TxtHoraRevVersion = new CustomControls.RJControls.RJTextBox();
            this.TxtHora = new CustomControls.RJControls.RJTextBox();
            this.TxtVersion = new CustomControls.RJControls.RJTextBox();
            this.TxtBusqueda = new CustomControls.RJControls.RJTextBox();
            this.TxtEsOffline = new CustomControls.RJControls.RJTextBox();
            this.TxtEsconProblemas = new CustomControls.RJControls.RJTextBox();
            this.TxtEsOnline = new CustomControls.RJControls.RJTextBox();
            this.TxtTotalES = new CustomControls.RJControls.RJTextBox();
            this.TxtToken = new CustomControls.RJControls.RJTextBox();
            this.TxtUsuario = new CustomControls.RJControls.RJTextBox();
            this.Txtpassword = new CustomControls.RJControls.RJTextBox();
            this.TxtMail = new CustomControls.RJControls.RJTextBox();
            this.TxtUrl2 = new CustomControls.RJControls.RJTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFichero)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LOGO)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblAviso
            // 
            this.LblAviso.AutoSize = true;
            this.LblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.LblAviso.Location = new System.Drawing.Point(141, 719);
            this.LblAviso.Name = "LblAviso";
            this.LblAviso.Size = new System.Drawing.Size(620, 20);
            this.LblAviso.TabIndex = 210;
            this.LblAviso.Text = "Texto de Busqueda relleno.. DETENEMOS REFRESCO DE DATOS DEL API";
            this.LblAviso.Visible = false;
            // 
            // DgvFichero
            // 
            this.DgvFichero.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvFichero.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFichero.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvFichero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFichero.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvFichero.Location = new System.Drawing.Point(14, 19);
            this.DgvFichero.Name = "DgvFichero";
            this.DgvFichero.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFichero.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvFichero.RowHeadersVisible = false;
            this.DgvFichero.Size = new System.Drawing.Size(893, 257);
            this.DgvFichero.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblAviso1);
            this.groupBox2.Controls.Add(this.Lblconsulta);
            this.groupBox2.Controls.Add(this.DgvFichero);
            this.groupBox2.Location = new System.Drawing.Point(4, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(913, 317);
            this.groupBox2.TabIndex = 207;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Estaciones";
            // 
            // LblAviso1
            // 
            this.LblAviso1.AutoSize = true;
            this.LblAviso1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAviso1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.LblAviso1.Location = new System.Drawing.Point(11, 296);
            this.LblAviso1.Name = "LblAviso1";
            this.LblAviso1.Size = new System.Drawing.Size(422, 13);
            this.LblAviso1.TabIndex = 68;
            this.LblAviso1.Text = "El estudio de los ajustes se realiza a las 07:30 , a las 15:30 y a las 23:30";
            // 
            // Lblconsulta
            // 
            this.Lblconsulta.AutoSize = true;
            this.Lblconsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblconsulta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.Lblconsulta.Location = new System.Drawing.Point(263, 0);
            this.Lblconsulta.Name = "Lblconsulta";
            this.Lblconsulta.Size = new System.Drawing.Size(417, 25);
            this.Lblconsulta.TabIndex = 17;
            this.Lblconsulta.Text = "CONSULTANDO DATOS EN CENTRAL";
            this.Lblconsulta.Visible = false;
            // 
            // TmrRefresco
            // 
            this.TmrRefresco.Interval = 10000;
            this.TmrRefresco.Tick += new System.EventHandler(this.TmrRefresco_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbSalidaLog);
            this.groupBox3.Location = new System.Drawing.Point(4, 530);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(913, 97);
            this.groupBox3.TabIndex = 208;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs";
            // 
            // rtbSalidaLog
            // 
            this.rtbSalidaLog.Location = new System.Drawing.Point(14, 15);
            this.rtbSalidaLog.Name = "rtbSalidaLog";
            this.rtbSalidaLog.Size = new System.Drawing.Size(893, 79);
            this.rtbSalidaLog.TabIndex = 4;
            this.rtbSalidaLog.Text = "";
            // 
            // TmrParpadeo
            // 
            this.TmrParpadeo.Interval = 500;
            this.TmrParpadeo.Tick += new System.EventHandler(this.TmrParpadeo_Tick);
            // 
            // TmrHora
            // 
            this.TmrHora.Enabled = true;
            this.TmrHora.Interval = 1000;
            this.TmrHora.Tick += new System.EventHandler(this.TmrHora_Tick);
            // 
            // TControldeRetardos
            // 
            this.TControldeRetardos.Enabled = true;
            this.TControldeRetardos.Interval = 30000;
            this.TControldeRetardos.Tick += new System.EventHandler(this.TControldeRetardos_Tick);
            // 
            // LOGO
            // 
            this.LOGO.Image = ((System.Drawing.Image)(resources.GetObject("LOGO.Image")));
            this.LOGO.Location = new System.Drawing.Point(740, 637);
            this.LOGO.Name = "LOGO";
            this.LOGO.Size = new System.Drawing.Size(170, 42);
            this.LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LOGO.TabIndex = 209;
            this.LOGO.TabStop = false;
            // 
            // TmrConsulta
            // 
            this.TmrConsulta.Interval = 2000;
            this.TmrConsulta.Tick += new System.EventHandler(this.TmrConsulta_Tick);
            // 
            // BtnRefrescarDatos
            // 
            this.BtnRefrescarDatos.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.BtnRefrescarDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.BtnRefrescarDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRefrescarDatos.BorderRadius = 7;
            this.BtnRefrescarDatos.ButtonText = "Refrescar Datos";
            this.BtnRefrescarDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRefrescarDatos.DisabledColor = System.Drawing.Color.Gray;
            this.BtnRefrescarDatos.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnRefrescarDatos.Iconimage = null;
            this.BtnRefrescarDatos.Iconimage_right = null;
            this.BtnRefrescarDatos.Iconimage_right_Selected = null;
            this.BtnRefrescarDatos.Iconimage_Selected = null;
            this.BtnRefrescarDatos.IconMarginLeft = 0;
            this.BtnRefrescarDatos.IconMarginRight = 0;
            this.BtnRefrescarDatos.IconRightVisible = true;
            this.BtnRefrescarDatos.IconRightZoom = 0D;
            this.BtnRefrescarDatos.IconVisible = true;
            this.BtnRefrescarDatos.IconZoom = 90D;
            this.BtnRefrescarDatos.IsTab = false;
            this.BtnRefrescarDatos.Location = new System.Drawing.Point(167, 637);
            this.BtnRefrescarDatos.Name = "BtnRefrescarDatos";
            this.BtnRefrescarDatos.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.BtnRefrescarDatos.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.BtnRefrescarDatos.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnRefrescarDatos.selected = false;
            this.BtnRefrescarDatos.Size = new System.Drawing.Size(241, 48);
            this.BtnRefrescarDatos.TabIndex = 211;
            this.BtnRefrescarDatos.Text = "Refrescar Datos";
            this.BtnRefrescarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnRefrescarDatos.Textcolor = System.Drawing.Color.White;
            this.BtnRefrescarDatos.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefrescarDatos.Click += new System.EventHandler(this.BtnRefrescarDatos_Click_1);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.BtnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.BorderRadius = 7;
            this.BtnSalir.ButtonText = "Salir";
            this.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalir.DisabledColor = System.Drawing.Color.Gray;
            this.BtnSalir.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnSalir.Iconimage = null;
            this.BtnSalir.Iconimage_right = null;
            this.BtnSalir.Iconimage_right_Selected = null;
            this.BtnSalir.Iconimage_Selected = null;
            this.BtnSalir.IconMarginLeft = 0;
            this.BtnSalir.IconMarginRight = 0;
            this.BtnSalir.IconRightVisible = true;
            this.BtnSalir.IconRightZoom = 0D;
            this.BtnSalir.IconVisible = true;
            this.BtnSalir.IconZoom = 90D;
            this.BtnSalir.IsTab = false;
            this.BtnSalir.Location = new System.Drawing.Point(443, 637);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.BtnSalir.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.BtnSalir.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnSalir.selected = false;
            this.BtnSalir.Size = new System.Drawing.Size(241, 48);
            this.BtnSalir.TabIndex = 212;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnSalir.Textcolor = System.Drawing.Color.White;
            this.BtnSalir.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtFechaFinal);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.TxtFechaInicial);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.SwOscuro);
            this.groupBox1.Controls.Add(this.TxtHoraRevVersion);
            this.groupBox1.Controls.Add(this.TxtHora);
            this.groupBox1.Controls.Add(this.TxtVersion);
            this.groupBox1.Controls.Add(this.TxtBusqueda);
            this.groupBox1.Controls.Add(this.TxtEsOffline);
            this.groupBox1.Controls.Add(this.TxtEsconProblemas);
            this.groupBox1.Controls.Add(this.TxtEsOnline);
            this.groupBox1.Controls.Add(this.TxtTotalES);
            this.groupBox1.Controls.Add(this.TxtToken);
            this.groupBox1.Controls.Add(this.TxtUsuario);
            this.groupBox1.Controls.Add(this.Txtpassword);
            this.groupBox1.Controls.Add(this.TxtMail);
            this.groupBox1.Controls.Add(this.TxtUrl2);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.maskedTextBox2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.BarraProgreso);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ChkEsConProblemas);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 204);
            this.groupBox1.TabIndex = 213;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuracion";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label20.Location = new System.Drawing.Point(511, 149);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 13);
            this.label20.TabIndex = 208;
            this.label20.Text = "Fecha Hora Final";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label18.Location = new System.Drawing.Point(17, 149);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 13);
            this.label18.TabIndex = 206;
            this.label18.Text = "Fecha Hora Inicial";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label19.Location = new System.Drawing.Point(733, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 13);
            this.label19.TabIndex = 205;
            this.label19.Text = "Modo Oscuro";
            // 
            // SwOscuro
            // 
            this.SwOscuro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SwOscuro.BorderRadius = 10;
            this.SwOscuro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwOscuro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SwOscuro.Location = new System.Drawing.Point(818, 114);
            this.SwOscuro.Name = "SwOscuro";
            this.SwOscuro.Oncolor = System.Drawing.Color.DarkGray;
            this.SwOscuro.Onoffcolor = System.Drawing.Color.DarkGray;
            this.SwOscuro.Size = new System.Drawing.Size(51, 19);
            this.SwOscuro.TabIndex = 204;
            this.SwOscuro.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SwOscuro.Value = false;
            this.SwOscuro.Click += new System.EventHandler(this.SwOscuro_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label16.Location = new System.Drawing.Point(409, 182);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "Mas tickets que lecturas";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.BackColor = System.Drawing.Color.Orange;
            this.maskedTextBox2.Enabled = false;
            this.maskedTextBox2.Location = new System.Drawing.Point(386, 178);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(16, 20);
            this.maskedTextBox2.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label15.Location = new System.Drawing.Point(44, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(146, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = "Mas lecturas que tickets";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BackColor = System.Drawing.Color.LightCoral;
            this.maskedTextBox1.Enabled = false;
            this.maskedTextBox1.Location = new System.Drawing.Point(20, 177);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(18, 20);
            this.maskedTextBox1.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label12.Location = new System.Drawing.Point(252, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Hora Rev Version";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label13.Location = new System.Drawing.Point(17, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Hora";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label14.Location = new System.Drawing.Point(733, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Descarga";
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.Location = new System.Drawing.Point(818, 81);
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(88, 23);
            this.BarraProgreso.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label11.Location = new System.Drawing.Point(561, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Version";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label10.Location = new System.Drawing.Point(315, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Buscar";
            // 
            // ChkEsConProblemas
            // 
            this.ChkEsConProblemas.AutoSize = true;
            this.ChkEsConProblemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkEsConProblemas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.ChkEsConProblemas.Location = new System.Drawing.Point(736, 26);
            this.ChkEsConProblemas.Name = "ChkEsConProblemas";
            this.ChkEsConProblemas.Size = new System.Drawing.Size(170, 17);
            this.ChkEsConProblemas.TabIndex = 25;
            this.ChkEsConProblemas.Text = "Mostrar Solo ES a revisar";
            this.ChkEsConProblemas.UseVisualStyleBackColor = true;
            this.ChkEsConProblemas.CheckedChanged += new System.EventHandler(this.ChkEsConProblemas_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label9.Location = new System.Drawing.Point(733, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Es a Revisar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label8.Location = new System.Drawing.Point(176, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Es Offline";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label7.Location = new System.Drawing.Point(17, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Es Online";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label6.Location = new System.Drawing.Point(561, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Total Es";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Url Servidor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label5.Location = new System.Drawing.Point(319, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Token";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label4.Location = new System.Drawing.Point(561, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label2.Location = new System.Drawing.Point(17, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.label3.Location = new System.Drawing.Point(332, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mail";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // TxtFechaFinal
            // 
            this.TxtFechaFinal.BackColor = System.Drawing.Color.White;
            this.TxtFechaFinal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtFechaFinal.BorderFocusColor = System.Drawing.Color.White;
            this.TxtFechaFinal.BorderRadius = 10;
            this.TxtFechaFinal.BorderSize = 1;
            this.TxtFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtFechaFinal.Location = new System.Drawing.Point(628, 142);
            this.TxtFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFechaFinal.Multiline = false;
            this.TxtFechaFinal.Name = "TxtFechaFinal";
            this.TxtFechaFinal.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtFechaFinal.PasswordChar = false;
            this.TxtFechaFinal.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtFechaFinal.PlaceholderText = "";
            this.TxtFechaFinal.Size = new System.Drawing.Size(241, 30);
            this.TxtFechaFinal.TabIndex = 209;
            this.TxtFechaFinal.Texts = "";
            this.TxtFechaFinal.UnderlinedStyle = false;
            // 
            // TxtFechaInicial
            // 
            this.TxtFechaInicial.BackColor = System.Drawing.Color.White;
            this.TxtFechaInicial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtFechaInicial.BorderFocusColor = System.Drawing.Color.White;
            this.TxtFechaInicial.BorderRadius = 10;
            this.TxtFechaInicial.BorderSize = 1;
            this.TxtFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFechaInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtFechaInicial.Location = new System.Drawing.Point(161, 142);
            this.TxtFechaInicial.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFechaInicial.Multiline = false;
            this.TxtFechaInicial.Name = "TxtFechaInicial";
            this.TxtFechaInicial.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtFechaInicial.PasswordChar = false;
            this.TxtFechaInicial.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtFechaInicial.PlaceholderText = "";
            this.TxtFechaInicial.Size = new System.Drawing.Size(289, 30);
            this.TxtFechaInicial.TabIndex = 207;
            this.TxtFechaInicial.Texts = "";
            this.TxtFechaInicial.UnderlinedStyle = false;
            // 
            // TxtHoraRevVersion
            // 
            this.TxtHoraRevVersion.BackColor = System.Drawing.Color.White;
            this.TxtHoraRevVersion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtHoraRevVersion.BorderFocusColor = System.Drawing.Color.White;
            this.TxtHoraRevVersion.BorderRadius = 10;
            this.TxtHoraRevVersion.BorderSize = 1;
            this.TxtHoraRevVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHoraRevVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtHoraRevVersion.Location = new System.Drawing.Point(365, 111);
            this.TxtHoraRevVersion.Margin = new System.Windows.Forms.Padding(4);
            this.TxtHoraRevVersion.Multiline = false;
            this.TxtHoraRevVersion.Name = "TxtHoraRevVersion";
            this.TxtHoraRevVersion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtHoraRevVersion.PasswordChar = false;
            this.TxtHoraRevVersion.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtHoraRevVersion.PlaceholderText = "";
            this.TxtHoraRevVersion.Size = new System.Drawing.Size(188, 30);
            this.TxtHoraRevVersion.TabIndex = 67;
            this.TxtHoraRevVersion.Texts = "";
            this.TxtHoraRevVersion.UnderlinedStyle = false;
            // 
            // TxtHora
            // 
            this.TxtHora.BackColor = System.Drawing.Color.White;
            this.TxtHora.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtHora.BorderFocusColor = System.Drawing.Color.White;
            this.TxtHora.BorderRadius = 10;
            this.TxtHora.BorderSize = 1;
            this.TxtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtHora.Location = new System.Drawing.Point(95, 111);
            this.TxtHora.Margin = new System.Windows.Forms.Padding(4);
            this.TxtHora.Multiline = false;
            this.TxtHora.Name = "TxtHora";
            this.TxtHora.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtHora.PasswordChar = false;
            this.TxtHora.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtHora.PlaceholderText = "";
            this.TxtHora.Size = new System.Drawing.Size(150, 30);
            this.TxtHora.TabIndex = 66;
            this.TxtHora.Texts = "";
            this.TxtHora.UnderlinedStyle = false;
            // 
            // TxtVersion
            // 
            this.TxtVersion.BackColor = System.Drawing.Color.White;
            this.TxtVersion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtVersion.BorderFocusColor = System.Drawing.Color.White;
            this.TxtVersion.BorderRadius = 10;
            this.TxtVersion.BorderSize = 1;
            this.TxtVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtVersion.Location = new System.Drawing.Point(627, 81);
            this.TxtVersion.Margin = new System.Windows.Forms.Padding(4);
            this.TxtVersion.Multiline = false;
            this.TxtVersion.Name = "TxtVersion";
            this.TxtVersion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtVersion.PasswordChar = false;
            this.TxtVersion.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtVersion.PlaceholderText = "";
            this.TxtVersion.Size = new System.Drawing.Size(96, 30);
            this.TxtVersion.TabIndex = 65;
            this.TxtVersion.Texts = "";
            this.TxtVersion.UnderlinedStyle = false;
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.BackColor = System.Drawing.Color.White;
            this.TxtBusqueda.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtBusqueda.BorderFocusColor = System.Drawing.Color.DarkGray;
            this.TxtBusqueda.BorderRadius = 10;
            this.TxtBusqueda.BorderSize = 1;
            this.TxtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtBusqueda.Location = new System.Drawing.Point(365, 80);
            this.TxtBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.TxtBusqueda.Multiline = false;
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtBusqueda.PasswordChar = false;
            this.TxtBusqueda.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtBusqueda.PlaceholderText = "";
            this.TxtBusqueda.Size = new System.Drawing.Size(188, 30);
            this.TxtBusqueda.TabIndex = 64;
            this.TxtBusqueda.Texts = "";
            this.TxtBusqueda.UnderlinedStyle = false;
            this.TxtBusqueda._TextChanged += new System.EventHandler(this.TxtBusqueda__TextChanged);
            // 
            // TxtEsOffline
            // 
            this.TxtEsOffline.BackColor = System.Drawing.Color.White;
            this.TxtEsOffline.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtEsOffline.BorderFocusColor = System.Drawing.Color.White;
            this.TxtEsOffline.BorderRadius = 10;
            this.TxtEsOffline.BorderSize = 1;
            this.TxtEsOffline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEsOffline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtEsOffline.Location = new System.Drawing.Point(237, 80);
            this.TxtEsOffline.Margin = new System.Windows.Forms.Padding(4);
            this.TxtEsOffline.Multiline = false;
            this.TxtEsOffline.Name = "TxtEsOffline";
            this.TxtEsOffline.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtEsOffline.PasswordChar = false;
            this.TxtEsOffline.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtEsOffline.PlaceholderText = "";
            this.TxtEsOffline.Size = new System.Drawing.Size(71, 30);
            this.TxtEsOffline.TabIndex = 63;
            this.TxtEsOffline.Texts = "";
            this.TxtEsOffline.UnderlinedStyle = false;
            // 
            // TxtEsconProblemas
            // 
            this.TxtEsconProblemas.BackColor = System.Drawing.Color.White;
            this.TxtEsconProblemas.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtEsconProblemas.BorderFocusColor = System.Drawing.Color.White;
            this.TxtEsconProblemas.BorderRadius = 10;
            this.TxtEsconProblemas.BorderSize = 1;
            this.TxtEsconProblemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEsconProblemas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtEsconProblemas.Location = new System.Drawing.Point(816, 47);
            this.TxtEsconProblemas.Margin = new System.Windows.Forms.Padding(4);
            this.TxtEsconProblemas.Multiline = false;
            this.TxtEsconProblemas.Name = "TxtEsconProblemas";
            this.TxtEsconProblemas.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtEsconProblemas.PasswordChar = false;
            this.TxtEsconProblemas.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtEsconProblemas.PlaceholderText = "";
            this.TxtEsconProblemas.Size = new System.Drawing.Size(93, 30);
            this.TxtEsconProblemas.TabIndex = 61;
            this.TxtEsconProblemas.Texts = "";
            this.TxtEsconProblemas.UnderlinedStyle = false;
            // 
            // TxtEsOnline
            // 
            this.TxtEsOnline.BackColor = System.Drawing.Color.White;
            this.TxtEsOnline.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtEsOnline.BorderFocusColor = System.Drawing.Color.White;
            this.TxtEsOnline.BorderRadius = 10;
            this.TxtEsOnline.BorderSize = 1;
            this.TxtEsOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEsOnline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtEsOnline.Location = new System.Drawing.Point(95, 80);
            this.TxtEsOnline.Margin = new System.Windows.Forms.Padding(4);
            this.TxtEsOnline.Multiline = false;
            this.TxtEsOnline.Name = "TxtEsOnline";
            this.TxtEsOnline.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtEsOnline.PasswordChar = false;
            this.TxtEsOnline.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtEsOnline.PlaceholderText = "";
            this.TxtEsOnline.Size = new System.Drawing.Size(74, 30);
            this.TxtEsOnline.TabIndex = 62;
            this.TxtEsOnline.Texts = "";
            this.TxtEsOnline.UnderlinedStyle = false;
            // 
            // TxtTotalES
            // 
            this.TxtTotalES.BackColor = System.Drawing.Color.White;
            this.TxtTotalES.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtTotalES.BorderFocusColor = System.Drawing.Color.White;
            this.TxtTotalES.BorderRadius = 10;
            this.TxtTotalES.BorderSize = 1;
            this.TxtTotalES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtTotalES.Location = new System.Drawing.Point(627, 50);
            this.TxtTotalES.Margin = new System.Windows.Forms.Padding(4);
            this.TxtTotalES.Multiline = false;
            this.TxtTotalES.Name = "TxtTotalES";
            this.TxtTotalES.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtTotalES.PasswordChar = false;
            this.TxtTotalES.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtTotalES.PlaceholderText = "";
            this.TxtTotalES.Size = new System.Drawing.Size(96, 30);
            this.TxtTotalES.TabIndex = 60;
            this.TxtTotalES.Texts = "";
            this.TxtTotalES.UnderlinedStyle = false;
            // 
            // TxtToken
            // 
            this.TxtToken.BackColor = System.Drawing.Color.White;
            this.TxtToken.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtToken.BorderFocusColor = System.Drawing.Color.White;
            this.TxtToken.BorderRadius = 10;
            this.TxtToken.BorderSize = 1;
            this.TxtToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtToken.Location = new System.Drawing.Point(366, 50);
            this.TxtToken.Margin = new System.Windows.Forms.Padding(4);
            this.TxtToken.Multiline = false;
            this.TxtToken.Name = "TxtToken";
            this.TxtToken.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtToken.PasswordChar = false;
            this.TxtToken.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtToken.PlaceholderText = "";
            this.TxtToken.Size = new System.Drawing.Size(187, 30);
            this.TxtToken.TabIndex = 59;
            this.TxtToken.Texts = "";
            this.TxtToken.UnderlinedStyle = false;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BackColor = System.Drawing.Color.White;
            this.TxtUsuario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtUsuario.BorderFocusColor = System.Drawing.Color.White;
            this.TxtUsuario.BorderRadius = 10;
            this.TxtUsuario.BorderSize = 1;
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtUsuario.Location = new System.Drawing.Point(95, 49);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUsuario.Multiline = false;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtUsuario.PasswordChar = false;
            this.TxtUsuario.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtUsuario.PlaceholderText = "";
            this.TxtUsuario.Size = new System.Drawing.Size(212, 30);
            this.TxtUsuario.TabIndex = 58;
            this.TxtUsuario.Texts = "";
            this.TxtUsuario.UnderlinedStyle = false;
            // 
            // Txtpassword
            // 
            this.Txtpassword.BackColor = System.Drawing.Color.White;
            this.Txtpassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.Txtpassword.BorderFocusColor = System.Drawing.Color.White;
            this.Txtpassword.BorderRadius = 10;
            this.Txtpassword.BorderSize = 1;
            this.Txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Txtpassword.Location = new System.Drawing.Point(628, 18);
            this.Txtpassword.Margin = new System.Windows.Forms.Padding(4);
            this.Txtpassword.Multiline = false;
            this.Txtpassword.Name = "Txtpassword";
            this.Txtpassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.Txtpassword.PasswordChar = true;
            this.Txtpassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.Txtpassword.PlaceholderText = "";
            this.Txtpassword.Size = new System.Drawing.Size(95, 30);
            this.Txtpassword.TabIndex = 57;
            this.Txtpassword.Texts = "astrid_1812";
            this.Txtpassword.UnderlinedStyle = false;
            // 
            // TxtMail
            // 
            this.TxtMail.BackColor = System.Drawing.Color.White;
            this.TxtMail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtMail.BorderFocusColor = System.Drawing.Color.White;
            this.TxtMail.BorderRadius = 10;
            this.TxtMail.BorderSize = 1;
            this.TxtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtMail.Location = new System.Drawing.Point(366, 18);
            this.TxtMail.Margin = new System.Windows.Forms.Padding(4);
            this.TxtMail.Multiline = false;
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtMail.PasswordChar = false;
            this.TxtMail.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtMail.PlaceholderText = "";
            this.TxtMail.Size = new System.Drawing.Size(187, 30);
            this.TxtMail.TabIndex = 56;
            this.TxtMail.Texts = "";
            this.TxtMail.UnderlinedStyle = false;
            // 
            // TxtUrl2
            // 
            this.TxtUrl2.BackColor = System.Drawing.Color.White;
            this.TxtUrl2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(174)))));
            this.TxtUrl2.BorderFocusColor = System.Drawing.Color.White;
            this.TxtUrl2.BorderRadius = 10;
            this.TxtUrl2.BorderSize = 1;
            this.TxtUrl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUrl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtUrl2.Location = new System.Drawing.Point(96, 18);
            this.TxtUrl2.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUrl2.Multiline = false;
            this.TxtUrl2.Name = "TxtUrl2";
            this.TxtUrl2.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.TxtUrl2.PasswordChar = false;
            this.TxtUrl2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TxtUrl2.PlaceholderText = "";
            this.TxtUrl2.Size = new System.Drawing.Size(211, 30);
            this.TxtUrl2.TabIndex = 55;
            this.TxtUrl2.Texts = "";
            this.TxtUrl2.UnderlinedStyle = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(924, 705);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnRefrescarDatos);
            this.Controls.Add(this.LblAviso);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.LOGO);
            this.Name = "Form1";
            this.Text = "4GL Cuadro de Mando GARUM . Revision de Ajustes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFichero)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LOGO)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblAviso;
        private System.Windows.Forms.DataGridView DgvFichero;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblAviso1;
        private System.Windows.Forms.Label Lblconsulta;
        private System.Windows.Forms.Timer TmrRefresco;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbSalidaLog;
        private System.Windows.Forms.Timer TmrParpadeo;
        private System.Windows.Forms.Timer TmrHora;
        private System.Windows.Forms.Timer TControldeRetardos;
        private System.Windows.Forms.PictureBox LOGO;
        private System.Windows.Forms.Timer TmrConsulta;
        private ns1.BunifuFlatButton BtnRefrescarDatos;
        private ns1.BunifuFlatButton BtnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label19;
        private ns1.BunifuSwitch SwOscuro;
        private CustomControls.RJControls.RJTextBox TxtHoraRevVersion;
        private CustomControls.RJControls.RJTextBox TxtHora;
        private CustomControls.RJControls.RJTextBox TxtVersion;
        private CustomControls.RJControls.RJTextBox TxtBusqueda;
        private CustomControls.RJControls.RJTextBox TxtEsOffline;
        private CustomControls.RJControls.RJTextBox TxtEsconProblemas;
        private CustomControls.RJControls.RJTextBox TxtEsOnline;
        private CustomControls.RJControls.RJTextBox TxtTotalES;
        private CustomControls.RJControls.RJTextBox TxtToken;
        private CustomControls.RJControls.RJTextBox TxtUsuario;
        private CustomControls.RJControls.RJTextBox Txtpassword;
        private CustomControls.RJControls.RJTextBox TxtMail;
        private CustomControls.RJControls.RJTextBox TxtUrl2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ProgressBar BarraProgreso;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ChkEsConProblemas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private CustomControls.RJControls.RJTextBox TxtFechaFinal;
        private System.Windows.Forms.Label label20;
        private CustomControls.RJControls.RJTextBox TxtFechaInicial;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
    }
}

