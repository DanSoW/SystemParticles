namespace SystemParticles
{
	partial class Window
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.picDisplay = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this._btnNext = new System.Windows.Forms.Button();
			this._btnOneNext = new System.Windows.Forms.Button();
			this._tbSpeedNext = new System.Windows.Forms.TrackBar();
			this._txtLabelRadius = new System.Windows.Forms.Label();
			this._txtRadiusValue = new System.Windows.Forms.Label();
			this._tbrRadiusParticle = new System.Windows.Forms.TrackBar();
			this._txtLabelLife = new System.Windows.Forms.Label();
			this._txtLifeValue = new System.Windows.Forms.Label();
			this._tbrLifeParticle = new System.Windows.Forms.TrackBar();
			this._txtSpeedNext = new System.Windows.Forms.Label();
			this._btnMovieBack = new System.Windows.Forms.Button();
			this._btnOneBack = new System.Windows.Forms.Button();
			this._txtLabelSpeedXParticle = new System.Windows.Forms.Label();
			this._txtSpeedXParticle = new System.Windows.Forms.Label();
			this._tbrSpeedXParticle = new System.Windows.Forms.TrackBar();
			this._tbrSpeedYParticle = new System.Windows.Forms.TrackBar();
			this._txtSpeedYParticle = new System.Windows.Forms.Label();
			this._txtLabelSpeedYParticle = new System.Windows.Forms.Label();
			this._txtLabelGraviton = new System.Windows.Forms.Label();
			this._cmbTypeGraviton = new System.Windows.Forms.ComboBox();
			this._txtLabelTypeGraviton = new System.Windows.Forms.Label();
			this._txtLabelPower = new System.Windows.Forms.Label();
			this._txtInputPower = new System.Windows.Forms.TextBox();
			this._btnClearGraviton = new System.Windows.Forms.Button();
			this._txtLabelPoints = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this._txtLabelAddEmitter = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this._cmbStandType = new System.Windows.Forms.ComboBox();
			this._txtLabelEmitterX = new System.Windows.Forms.Label();
			this._txtEmitterX = new System.Windows.Forms.TextBox();
			this._txtEmitterY = new System.Windows.Forms.TextBox();
			this._txtLabelEmitterY = new System.Windows.Forms.Label();
			this._txtLabelFromColor = new System.Windows.Forms.Label();
			this._picFromColor = new System.Windows.Forms.PictureBox();
			this._picToColor = new System.Windows.Forms.PictureBox();
			this._txtLabelToColor = new System.Windows.Forms.Label();
			this._cdFromColor = new System.Windows.Forms.ColorDialog();
			this._cdToColor = new System.Windows.Forms.ColorDialog();
			this._txtLabelCount = new System.Windows.Forms.Label();
			this._txtCountParticle = new System.Windows.Forms.TextBox();
			this._btnAddEmitter = new System.Windows.Forms.Button();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this._btnDeleteAllEmitter = new System.Windows.Forms.Button();
			this._txtLabelGrX = new System.Windows.Forms.Label();
			this._txtLabelGrY = new System.Windows.Forms.Label();
			this._txtGravitationX = new System.Windows.Forms.TextBox();
			this._txtGravitationY = new System.Windows.Forms.TextBox();
			this._txtDirection = new System.Windows.Forms.TextBox();
			this._txtLabelDirection = new System.Windows.Forms.Label();
			this._txtSpreading = new System.Windows.Forms.TextBox();
			this._txtLabelSpreading = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbSpeedNext)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrRadiusParticle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrLifeParticle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrSpeedXParticle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrSpeedYParticle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._picFromColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._picToColor)).BeginInit();
			this.SuspendLayout();
			// 
			// picDisplay
			// 
			this.picDisplay.Location = new System.Drawing.Point(13, 13);
			this.picDisplay.Name = "picDisplay";
			this.picDisplay.Size = new System.Drawing.Size(553, 374);
			this.picDisplay.TabIndex = 0;
			this.picDisplay.TabStop = false;
			this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
			this.picDisplay.MouseLeave += new System.EventHandler(this.picDisplay_MouseLeave);
			this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 40;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// _btnNext
			// 
			this._btnNext.Location = new System.Drawing.Point(12, 426);
			this._btnNext.Name = "_btnNext";
			this._btnNext.Size = new System.Drawing.Size(75, 23);
			this._btnNext.TabIndex = 3;
			this._btnNext.Text = "Вперёд";
			this._btnNext.UseVisualStyleBackColor = true;
			this._btnNext.Click += new System.EventHandler(this.button1_Click);
			// 
			// _btnOneNext
			// 
			this._btnOneNext.Location = new System.Drawing.Point(94, 425);
			this._btnOneNext.Name = "_btnOneNext";
			this._btnOneNext.Size = new System.Drawing.Size(75, 23);
			this._btnOneNext.TabIndex = 4;
			this._btnOneNext.Text = "Шаг";
			this._btnOneNext.UseVisualStyleBackColor = true;
			this._btnOneNext.Click += new System.EventHandler(this.button2_Click);
			// 
			// _tbSpeedNext
			// 
			this._tbSpeedNext.Location = new System.Drawing.Point(189, 426);
			this._tbSpeedNext.Maximum = 1000;
			this._tbSpeedNext.Minimum = 40;
			this._tbSpeedNext.Name = "_tbSpeedNext";
			this._tbSpeedNext.Size = new System.Drawing.Size(104, 45);
			this._tbSpeedNext.TabIndex = 5;
			this._tbSpeedNext.Value = 40;
			this._tbSpeedNext.Scroll += new System.EventHandler(this._tbSpeed_Scroll);
			// 
			// _txtLabelRadius
			// 
			this._txtLabelRadius.AutoSize = true;
			this._txtLabelRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelRadius.Location = new System.Drawing.Point(578, 236);
			this._txtLabelRadius.Name = "_txtLabelRadius";
			this._txtLabelRadius.Size = new System.Drawing.Size(52, 15);
			this._txtLabelRadius.TabIndex = 6;
			this._txtLabelRadius.Text = "Radius: ";
			// 
			// _txtRadiusValue
			// 
			this._txtRadiusValue.AutoSize = true;
			this._txtRadiusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtRadiusValue.Location = new System.Drawing.Point(644, 236);
			this._txtRadiusValue.Name = "_txtRadiusValue";
			this._txtRadiusValue.Size = new System.Drawing.Size(14, 15);
			this._txtRadiusValue.TabIndex = 7;
			this._txtRadiusValue.Text = "1";
			// 
			// _tbrRadiusParticle
			// 
			this._tbrRadiusParticle.Location = new System.Drawing.Point(572, 256);
			this._tbrRadiusParticle.Name = "_tbrRadiusParticle";
			this._tbrRadiusParticle.Size = new System.Drawing.Size(104, 45);
			this._tbrRadiusParticle.TabIndex = 8;
			this._tbrRadiusParticle.Scroll += new System.EventHandler(this._tbrRadiusParticle_Scroll);
			// 
			// _txtLabelLife
			// 
			this._txtLabelLife.AutoSize = true;
			this._txtLabelLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelLife.Location = new System.Drawing.Point(581, 308);
			this._txtLabelLife.Name = "_txtLabelLife";
			this._txtLabelLife.Size = new System.Drawing.Size(30, 15);
			this._txtLabelLife.TabIndex = 9;
			this._txtLabelLife.Text = "Life:";
			// 
			// _txtLifeValue
			// 
			this._txtLifeValue.AutoSize = true;
			this._txtLifeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLifeValue.Location = new System.Drawing.Point(644, 308);
			this._txtLifeValue.Name = "_txtLifeValue";
			this._txtLifeValue.Size = new System.Drawing.Size(14, 15);
			this._txtLifeValue.TabIndex = 10;
			this._txtLifeValue.Text = "1";
			// 
			// _tbrLifeParticle
			// 
			this._tbrLifeParticle.Location = new System.Drawing.Point(572, 328);
			this._tbrLifeParticle.Name = "_tbrLifeParticle";
			this._tbrLifeParticle.Size = new System.Drawing.Size(104, 45);
			this._tbrLifeParticle.TabIndex = 11;
			this._tbrLifeParticle.Scroll += new System.EventHandler(this._tbrLifeParticle_Scroll);
			// 
			// _txtSpeedNext
			// 
			this._txtSpeedNext.AutoSize = true;
			this._txtSpeedNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtSpeedNext.Location = new System.Drawing.Point(299, 430);
			this._txtSpeedNext.Name = "_txtSpeedNext";
			this._txtSpeedNext.Size = new System.Drawing.Size(0, 15);
			this._txtSpeedNext.TabIndex = 12;
			// 
			// _btnMovieBack
			// 
			this._btnMovieBack.Location = new System.Drawing.Point(12, 455);
			this._btnMovieBack.Name = "_btnMovieBack";
			this._btnMovieBack.Size = new System.Drawing.Size(75, 23);
			this._btnMovieBack.TabIndex = 13;
			this._btnMovieBack.Text = "Назад";
			this._btnMovieBack.UseVisualStyleBackColor = true;
			this._btnMovieBack.Click += new System.EventHandler(this._btnMovieBack_Click);
			// 
			// _btnOneBack
			// 
			this._btnOneBack.Location = new System.Drawing.Point(94, 455);
			this._btnOneBack.Name = "_btnOneBack";
			this._btnOneBack.Size = new System.Drawing.Size(75, 23);
			this._btnOneBack.TabIndex = 14;
			this._btnOneBack.Text = "Шаг";
			this._btnOneBack.UseVisualStyleBackColor = true;
			this._btnOneBack.Click += new System.EventHandler(this._btnOneBack_Click);
			// 
			// _txtLabelSpeedXParticle
			// 
			this._txtLabelSpeedXParticle.AutoSize = true;
			this._txtLabelSpeedXParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelSpeedXParticle.Location = new System.Drawing.Point(695, 236);
			this._txtLabelSpeedXParticle.Name = "_txtLabelSpeedXParticle";
			this._txtLabelSpeedXParticle.Size = new System.Drawing.Size(57, 15);
			this._txtLabelSpeedXParticle.TabIndex = 17;
			this._txtLabelSpeedXParticle.Text = "Speed X:";
			// 
			// _txtSpeedXParticle
			// 
			this._txtSpeedXParticle.AutoSize = true;
			this._txtSpeedXParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtSpeedXParticle.Location = new System.Drawing.Point(758, 236);
			this._txtSpeedXParticle.Name = "_txtSpeedXParticle";
			this._txtSpeedXParticle.Size = new System.Drawing.Size(14, 15);
			this._txtSpeedXParticle.TabIndex = 18;
			this._txtSpeedXParticle.Text = "1";
			// 
			// _tbrSpeedXParticle
			// 
			this._tbrSpeedXParticle.Location = new System.Drawing.Point(686, 256);
			this._tbrSpeedXParticle.Name = "_tbrSpeedXParticle";
			this._tbrSpeedXParticle.Size = new System.Drawing.Size(104, 45);
			this._tbrSpeedXParticle.TabIndex = 19;
			this._tbrSpeedXParticle.Scroll += new System.EventHandler(this._tbrSpeedXParticle_Scroll);
			// 
			// _tbrSpeedYParticle
			// 
			this._tbrSpeedYParticle.Location = new System.Drawing.Point(686, 328);
			this._tbrSpeedYParticle.Name = "_tbrSpeedYParticle";
			this._tbrSpeedYParticle.Size = new System.Drawing.Size(104, 45);
			this._tbrSpeedYParticle.TabIndex = 22;
			this._tbrSpeedYParticle.Scroll += new System.EventHandler(this._tbrSpeedYParticle_Scroll);
			// 
			// _txtSpeedYParticle
			// 
			this._txtSpeedYParticle.AutoSize = true;
			this._txtSpeedYParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtSpeedYParticle.Location = new System.Drawing.Point(758, 308);
			this._txtSpeedYParticle.Name = "_txtSpeedYParticle";
			this._txtSpeedYParticle.Size = new System.Drawing.Size(14, 15);
			this._txtSpeedYParticle.TabIndex = 21;
			this._txtSpeedYParticle.Text = "1";
			// 
			// _txtLabelSpeedYParticle
			// 
			this._txtLabelSpeedYParticle.AutoSize = true;
			this._txtLabelSpeedYParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelSpeedYParticle.Location = new System.Drawing.Point(695, 308);
			this._txtLabelSpeedYParticle.Name = "_txtLabelSpeedYParticle";
			this._txtLabelSpeedYParticle.Size = new System.Drawing.Size(56, 15);
			this._txtLabelSpeedYParticle.TabIndex = 20;
			this._txtLabelSpeedYParticle.Text = "Speed Y:";
			// 
			// _txtLabelGraviton
			// 
			this._txtLabelGraviton.AutoSize = true;
			this._txtLabelGraviton.BackColor = System.Drawing.Color.Green;
			this._txtLabelGraviton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelGraviton.ForeColor = System.Drawing.Color.Yellow;
			this._txtLabelGraviton.Location = new System.Drawing.Point(572, 13);
			this._txtLabelGraviton.Name = "_txtLabelGraviton";
			this._txtLabelGraviton.Size = new System.Drawing.Size(115, 15);
			this._txtLabelGraviton.TabIndex = 23;
			this._txtLabelGraviton.Text = "Добавление точки";
			// 
			// _cmbTypeGraviton
			// 
			this._cmbTypeGraviton.FormattingEnabled = true;
			this._cmbTypeGraviton.Location = new System.Drawing.Point(575, 105);
			this._cmbTypeGraviton.Name = "_cmbTypeGraviton";
			this._cmbTypeGraviton.Size = new System.Drawing.Size(121, 21);
			this._cmbTypeGraviton.TabIndex = 24;
			// 
			// _txtLabelTypeGraviton
			// 
			this._txtLabelTypeGraviton.AutoSize = true;
			this._txtLabelTypeGraviton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelTypeGraviton.Location = new System.Drawing.Point(572, 85);
			this._txtLabelTypeGraviton.Name = "_txtLabelTypeGraviton";
			this._txtLabelTypeGraviton.Size = new System.Drawing.Size(95, 15);
			this._txtLabelTypeGraviton.TabIndex = 25;
			this._txtLabelTypeGraviton.Text = "Тип гравитона:";
			// 
			// _txtLabelPower
			// 
			this._txtLabelPower.AutoSize = true;
			this._txtLabelPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelPower.Location = new System.Drawing.Point(572, 45);
			this._txtLabelPower.Name = "_txtLabelPower";
			this._txtLabelPower.Size = new System.Drawing.Size(45, 15);
			this._txtLabelPower.TabIndex = 26;
			this._txtLabelPower.Text = "Power:";
			// 
			// _txtInputPower
			// 
			this._txtInputPower.Location = new System.Drawing.Point(630, 45);
			this._txtInputPower.Name = "_txtInputPower";
			this._txtInputPower.Size = new System.Drawing.Size(63, 20);
			this._txtInputPower.TabIndex = 27;
			this._txtInputPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtInputPower_KeyPress);
			// 
			// _btnClearGraviton
			// 
			this._btnClearGraviton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._btnClearGraviton.Location = new System.Drawing.Point(572, 140);
			this._btnClearGraviton.Name = "_btnClearGraviton";
			this._btnClearGraviton.Size = new System.Drawing.Size(147, 34);
			this._btnClearGraviton.TabIndex = 28;
			this._btnClearGraviton.Text = "Удалить все точки";
			this._btnClearGraviton.UseVisualStyleBackColor = true;
			this._btnClearGraviton.Click += new System.EventHandler(this._btnClearGraviton_Click);
			// 
			// _txtLabelPoints
			// 
			this._txtLabelPoints.AutoSize = true;
			this._txtLabelPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelPoints.Location = new System.Drawing.Point(569, 212);
			this._txtLabelPoints.Name = "_txtLabelPoints";
			this._txtLabelPoints.Size = new System.Drawing.Size(192, 15);
			this._txtLabelPoints.TabIndex = 29;
			this._txtLabelPoints.Text = "Параметры захваченной точки:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this.label2.Location = new System.Drawing.Point(10, 405);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 15);
			this.label2.TabIndex = 31;
			this.label2.Text = "Движение частиц";
			// 
			// _txtLabelAddEmitter
			// 
			this._txtLabelAddEmitter.AutoSize = true;
			this._txtLabelAddEmitter.BackColor = System.Drawing.Color.Green;
			this._txtLabelAddEmitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelAddEmitter.ForeColor = System.Drawing.Color.Yellow;
			this._txtLabelAddEmitter.Location = new System.Drawing.Point(810, 14);
			this._txtLabelAddEmitter.Name = "_txtLabelAddEmitter";
			this._txtLabelAddEmitter.Size = new System.Drawing.Size(139, 15);
			this._txtLabelAddEmitter.TabIndex = 32;
			this._txtLabelAddEmitter.Text = "Добавление эмиттера";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this.label1.Location = new System.Drawing.Point(810, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 15);
			this.label1.TabIndex = 33;
			this.label1.Text = "Специальные эмиттеры:";
			// 
			// _cmbStandType
			// 
			this._cmbStandType.FormattingEnabled = true;
			this._cmbStandType.Location = new System.Drawing.Point(813, 66);
			this._cmbStandType.Name = "_cmbStandType";
			this._cmbStandType.Size = new System.Drawing.Size(121, 21);
			this._cmbStandType.TabIndex = 34;
			this._cmbStandType.TextChanged += new System.EventHandler(this._cmbStandType_TextChanged);
			// 
			// _txtLabelEmitterX
			// 
			this._txtLabelEmitterX.AutoSize = true;
			this._txtLabelEmitterX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelEmitterX.Location = new System.Drawing.Point(813, 106);
			this._txtLabelEmitterX.Name = "_txtLabelEmitterX";
			this._txtLabelEmitterX.Size = new System.Drawing.Size(18, 15);
			this._txtLabelEmitterX.TabIndex = 35;
			this._txtLabelEmitterX.Text = "X:";
			// 
			// _txtEmitterX
			// 
			this._txtEmitterX.Location = new System.Drawing.Point(840, 105);
			this._txtEmitterX.Name = "_txtEmitterX";
			this._txtEmitterX.Size = new System.Drawing.Size(42, 20);
			this._txtEmitterX.TabIndex = 36;
			this._txtEmitterX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtEmitterX_KeyPress);
			// 
			// _txtEmitterY
			// 
			this._txtEmitterY.Location = new System.Drawing.Point(916, 105);
			this._txtEmitterY.Name = "_txtEmitterY";
			this._txtEmitterY.Size = new System.Drawing.Size(42, 20);
			this._txtEmitterY.TabIndex = 38;
			this._txtEmitterY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtEmitterY_KeyPress);
			// 
			// _txtLabelEmitterY
			// 
			this._txtLabelEmitterY.AutoSize = true;
			this._txtLabelEmitterY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelEmitterY.Location = new System.Drawing.Point(889, 106);
			this._txtLabelEmitterY.Name = "_txtLabelEmitterY";
			this._txtLabelEmitterY.Size = new System.Drawing.Size(17, 15);
			this._txtLabelEmitterY.TabIndex = 37;
			this._txtLabelEmitterY.Text = "Y:";
			// 
			// _txtLabelFromColor
			// 
			this._txtLabelFromColor.AutoSize = true;
			this._txtLabelFromColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelFromColor.Location = new System.Drawing.Point(809, 151);
			this._txtLabelFromColor.Name = "_txtLabelFromColor";
			this._txtLabelFromColor.Size = new System.Drawing.Size(110, 15);
			this._txtLabelFromColor.TabIndex = 39;
			this._txtLabelFromColor.Text = "Начальный цвет: ";
			// 
			// _picFromColor
			// 
			this._picFromColor.Location = new System.Drawing.Point(940, 143);
			this._picFromColor.Name = "_picFromColor";
			this._picFromColor.Size = new System.Drawing.Size(37, 32);
			this._picFromColor.TabIndex = 40;
			this._picFromColor.TabStop = false;
			this._picFromColor.Click += new System.EventHandler(this._picFromColor_Click);
			// 
			// _picToColor
			// 
			this._picToColor.Location = new System.Drawing.Point(940, 187);
			this._picToColor.Name = "_picToColor";
			this._picToColor.Size = new System.Drawing.Size(37, 32);
			this._picToColor.TabIndex = 42;
			this._picToColor.TabStop = false;
			this._picToColor.Click += new System.EventHandler(this._picToColor_Click);
			// 
			// _txtLabelToColor
			// 
			this._txtLabelToColor.AutoSize = true;
			this._txtLabelToColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelToColor.Location = new System.Drawing.Point(809, 195);
			this._txtLabelToColor.Name = "_txtLabelToColor";
			this._txtLabelToColor.Size = new System.Drawing.Size(102, 15);
			this._txtLabelToColor.TabIndex = 41;
			this._txtLabelToColor.Text = "Конечный цвет: ";
			// 
			// _txtLabelCount
			// 
			this._txtLabelCount.AutoSize = true;
			this._txtLabelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._txtLabelCount.Location = new System.Drawing.Point(809, 232);
			this._txtLabelCount.Name = "_txtLabelCount";
			this._txtLabelCount.Size = new System.Drawing.Size(122, 15);
			this._txtLabelCount.TabIndex = 43;
			this._txtLabelCount.Text = "Количество частиц:";
			// 
			// _txtCountParticle
			// 
			this._txtCountParticle.Location = new System.Drawing.Point(940, 232);
			this._txtCountParticle.Name = "_txtCountParticle";
			this._txtCountParticle.Size = new System.Drawing.Size(48, 20);
			this._txtCountParticle.TabIndex = 44;
			this._txtCountParticle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtCountParticle_KeyPress);
			// 
			// _btnAddEmitter
			// 
			this._btnAddEmitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._btnAddEmitter.Location = new System.Drawing.Point(813, 402);
			this._btnAddEmitter.Name = "_btnAddEmitter";
			this._btnAddEmitter.Size = new System.Drawing.Size(191, 34);
			this._btnAddEmitter.TabIndex = 45;
			this._btnAddEmitter.Text = "Добавить";
			this._btnAddEmitter.UseVisualStyleBackColor = true;
			this._btnAddEmitter.Click += new System.EventHandler(this._btnAddEmitter_Click);
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Interval = 40;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
			// 
			// _btnDeleteAllEmitter
			// 
			this._btnDeleteAllEmitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
			this._btnDeleteAllEmitter.Location = new System.Drawing.Point(814, 442);
			this._btnDeleteAllEmitter.Name = "_btnDeleteAllEmitter";
			this._btnDeleteAllEmitter.Size = new System.Drawing.Size(190, 33);
			this._btnDeleteAllEmitter.TabIndex = 46;
			this._btnDeleteAllEmitter.Text = "Удалить все эмиттеры";
			this._btnDeleteAllEmitter.UseVisualStyleBackColor = true;
			this._btnDeleteAllEmitter.Click += new System.EventHandler(this._btnDeleteAllEmitter_Click);
			// 
			// _txtLabelGrX
			// 
			this._txtLabelGrX.AutoSize = true;
			this._txtLabelGrX.Location = new System.Drawing.Point(809, 266);
			this._txtLabelGrX.Name = "_txtLabelGrX";
			this._txtLabelGrX.Size = new System.Drawing.Size(94, 13);
			this._txtLabelGrX.TabIndex = 47;
			this._txtLabelGrX.Text = "Гравитация по X:";
			// 
			// _txtLabelGrY
			// 
			this._txtLabelGrY.AutoSize = true;
			this._txtLabelGrY.Location = new System.Drawing.Point(809, 301);
			this._txtLabelGrY.Name = "_txtLabelGrY";
			this._txtLabelGrY.Size = new System.Drawing.Size(94, 13);
			this._txtLabelGrY.TabIndex = 48;
			this._txtLabelGrY.Text = "Гравитация по Y:";
			// 
			// _txtGravitationX
			// 
			this._txtGravitationX.Location = new System.Drawing.Point(909, 263);
			this._txtGravitationX.Name = "_txtGravitationX";
			this._txtGravitationX.Size = new System.Drawing.Size(48, 20);
			this._txtGravitationX.TabIndex = 49;
			this._txtGravitationX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtGravitationX_KeyPress);
			// 
			// _txtGravitationY
			// 
			this._txtGravitationY.Location = new System.Drawing.Point(909, 296);
			this._txtGravitationY.Name = "_txtGravitationY";
			this._txtGravitationY.Size = new System.Drawing.Size(48, 20);
			this._txtGravitationY.TabIndex = 50;
			this._txtGravitationY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtGravitationY_KeyPress);
			// 
			// _txtDirection
			// 
			this._txtDirection.Location = new System.Drawing.Point(929, 330);
			this._txtDirection.Name = "_txtDirection";
			this._txtDirection.Size = new System.Drawing.Size(48, 20);
			this._txtDirection.TabIndex = 52;
			this._txtDirection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtDirection_KeyPress);
			// 
			// _txtLabelDirection
			// 
			this._txtLabelDirection.AutoSize = true;
			this._txtLabelDirection.Location = new System.Drawing.Point(809, 333);
			this._txtLabelDirection.Name = "_txtLabelDirection";
			this._txtLabelDirection.Size = new System.Drawing.Size(115, 13);
			this._txtLabelDirection.TabIndex = 51;
			this._txtLabelDirection.Text = "Вектор направления:";
			// 
			// _txtSpreading
			// 
			this._txtSpreading.Location = new System.Drawing.Point(929, 362);
			this._txtSpreading.Name = "_txtSpreading";
			this._txtSpreading.Size = new System.Drawing.Size(48, 20);
			this._txtSpreading.TabIndex = 54;
			this._txtSpreading.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtSpreading_KeyPress);
			// 
			// _txtLabelSpreading
			// 
			this._txtLabelSpreading.AutoSize = true;
			this._txtLabelSpreading.Location = new System.Drawing.Point(809, 365);
			this._txtLabelSpreading.Name = "_txtLabelSpreading";
			this._txtLabelSpreading.Size = new System.Drawing.Size(90, 13);
			this._txtLabelSpreading.TabIndex = 53;
			this._txtLabelSpreading.Text = "Разброс частиц:";
			// 
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1045, 490);
			this.Controls.Add(this._txtSpreading);
			this.Controls.Add(this._txtLabelSpreading);
			this.Controls.Add(this._txtDirection);
			this.Controls.Add(this._txtLabelDirection);
			this.Controls.Add(this._txtGravitationY);
			this.Controls.Add(this._txtGravitationX);
			this.Controls.Add(this._txtLabelGrY);
			this.Controls.Add(this._txtLabelGrX);
			this.Controls.Add(this._btnDeleteAllEmitter);
			this.Controls.Add(this._btnAddEmitter);
			this.Controls.Add(this._txtCountParticle);
			this.Controls.Add(this._txtLabelCount);
			this.Controls.Add(this._picToColor);
			this.Controls.Add(this._txtLabelToColor);
			this.Controls.Add(this._picFromColor);
			this.Controls.Add(this._txtLabelFromColor);
			this.Controls.Add(this._txtEmitterY);
			this.Controls.Add(this._txtLabelEmitterY);
			this.Controls.Add(this._txtEmitterX);
			this.Controls.Add(this._txtLabelEmitterX);
			this.Controls.Add(this._cmbStandType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._txtLabelAddEmitter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._txtLabelPoints);
			this.Controls.Add(this._btnClearGraviton);
			this.Controls.Add(this._txtInputPower);
			this.Controls.Add(this._txtLabelPower);
			this.Controls.Add(this._txtLabelTypeGraviton);
			this.Controls.Add(this._cmbTypeGraviton);
			this.Controls.Add(this._txtLabelGraviton);
			this.Controls.Add(this._tbrSpeedYParticle);
			this.Controls.Add(this._txtSpeedYParticle);
			this.Controls.Add(this._txtLabelSpeedYParticle);
			this.Controls.Add(this._tbrSpeedXParticle);
			this.Controls.Add(this._txtSpeedXParticle);
			this.Controls.Add(this._txtLabelSpeedXParticle);
			this.Controls.Add(this._btnOneBack);
			this.Controls.Add(this._btnMovieBack);
			this.Controls.Add(this._txtSpeedNext);
			this.Controls.Add(this._tbrLifeParticle);
			this.Controls.Add(this._txtLifeValue);
			this.Controls.Add(this._txtLabelLife);
			this.Controls.Add(this._tbrRadiusParticle);
			this.Controls.Add(this._txtRadiusValue);
			this.Controls.Add(this._txtLabelRadius);
			this.Controls.Add(this._tbSpeedNext);
			this.Controls.Add(this._btnOneNext);
			this.Controls.Add(this._btnNext);
			this.Controls.Add(this.picDisplay);
			this.Name = "Window";
			this.Text = "Window";
			((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbSpeedNext)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrRadiusParticle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrLifeParticle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrSpeedXParticle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrSpeedYParticle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._picFromColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._picToColor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picDisplay;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button _btnNext;
		private System.Windows.Forms.Button _btnOneNext;
		private System.Windows.Forms.TrackBar _tbSpeedNext;
		private System.Windows.Forms.Label _txtLabelRadius;
		private System.Windows.Forms.Label _txtRadiusValue;
		private System.Windows.Forms.TrackBar _tbrRadiusParticle;
		private System.Windows.Forms.Label _txtLabelLife;
		private System.Windows.Forms.Label _txtLifeValue;
		private System.Windows.Forms.TrackBar _tbrLifeParticle;
		private System.Windows.Forms.Label _txtSpeedNext;
		private System.Windows.Forms.Button _btnMovieBack;
		private System.Windows.Forms.Button _btnOneBack;
		private System.Windows.Forms.Label _txtLabelSpeedXParticle;
		private System.Windows.Forms.Label _txtSpeedXParticle;
		private System.Windows.Forms.TrackBar _tbrSpeedXParticle;
		private System.Windows.Forms.TrackBar _tbrSpeedYParticle;
		private System.Windows.Forms.Label _txtSpeedYParticle;
		private System.Windows.Forms.Label _txtLabelSpeedYParticle;
		private System.Windows.Forms.Label _txtLabelGraviton;
		private System.Windows.Forms.ComboBox _cmbTypeGraviton;
		private System.Windows.Forms.Label _txtLabelTypeGraviton;
		private System.Windows.Forms.Label _txtLabelPower;
		private System.Windows.Forms.TextBox _txtInputPower;
		private System.Windows.Forms.Button _btnClearGraviton;
		private System.Windows.Forms.Label _txtLabelPoints;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label _txtLabelAddEmitter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _cmbStandType;
		private System.Windows.Forms.Label _txtLabelEmitterX;
		private System.Windows.Forms.TextBox _txtEmitterX;
		private System.Windows.Forms.TextBox _txtEmitterY;
		private System.Windows.Forms.Label _txtLabelEmitterY;
		private System.Windows.Forms.Label _txtLabelFromColor;
		private System.Windows.Forms.PictureBox _picFromColor;
		private System.Windows.Forms.PictureBox _picToColor;
		private System.Windows.Forms.Label _txtLabelToColor;
		private System.Windows.Forms.ColorDialog _cdFromColor;
		private System.Windows.Forms.ColorDialog _cdToColor;
		private System.Windows.Forms.Label _txtLabelCount;
		private System.Windows.Forms.TextBox _txtCountParticle;
		private System.Windows.Forms.Button _btnAddEmitter;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.Button _btnDeleteAllEmitter;
		private System.Windows.Forms.Label _txtLabelGrX;
		private System.Windows.Forms.Label _txtLabelGrY;
		private System.Windows.Forms.TextBox _txtGravitationX;
		private System.Windows.Forms.TextBox _txtGravitationY;
		private System.Windows.Forms.TextBox _txtDirection;
		private System.Windows.Forms.Label _txtLabelDirection;
		private System.Windows.Forms.TextBox _txtSpreading;
		private System.Windows.Forms.Label _txtLabelSpreading;
	}
}

