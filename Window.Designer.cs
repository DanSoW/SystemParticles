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
			((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbSpeedNext)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrRadiusParticle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrLifeParticle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrSpeedXParticle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._tbrSpeedYParticle)).BeginInit();
			this.SuspendLayout();
			// 
			// picDisplay
			// 
			this.picDisplay.Location = new System.Drawing.Point(13, 13);
			this.picDisplay.Name = "picDisplay";
			this.picDisplay.Size = new System.Drawing.Size(621, 374);
			this.picDisplay.TabIndex = 0;
			this.picDisplay.TabStop = false;
			this.picDisplay.Click += new System.EventHandler(this.picDisplay_Click);
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
			this._btnNext.Location = new System.Drawing.Point(13, 394);
			this._btnNext.Name = "_btnNext";
			this._btnNext.Size = new System.Drawing.Size(75, 23);
			this._btnNext.TabIndex = 3;
			this._btnNext.Text = "Вперёд";
			this._btnNext.UseVisualStyleBackColor = true;
			this._btnNext.Click += new System.EventHandler(this.button1_Click);
			// 
			// _btnOneNext
			// 
			this._btnOneNext.Location = new System.Drawing.Point(95, 393);
			this._btnOneNext.Name = "_btnOneNext";
			this._btnOneNext.Size = new System.Drawing.Size(75, 23);
			this._btnOneNext.TabIndex = 4;
			this._btnOneNext.Text = "Шаг";
			this._btnOneNext.UseVisualStyleBackColor = true;
			this._btnOneNext.Click += new System.EventHandler(this.button2_Click);
			// 
			// _tbSpeedNext
			// 
			this._tbSpeedNext.Location = new System.Drawing.Point(188, 394);
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
			this._txtLabelRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtLabelRadius.Location = new System.Drawing.Point(664, 35);
			this._txtLabelRadius.Name = "_txtLabelRadius";
			this._txtLabelRadius.Size = new System.Drawing.Size(60, 17);
			this._txtLabelRadius.TabIndex = 6;
			this._txtLabelRadius.Text = "Radius: ";
			// 
			// _txtRadiusValue
			// 
			this._txtRadiusValue.AutoSize = true;
			this._txtRadiusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtRadiusValue.Location = new System.Drawing.Point(730, 35);
			this._txtRadiusValue.Name = "_txtRadiusValue";
			this._txtRadiusValue.Size = new System.Drawing.Size(16, 17);
			this._txtRadiusValue.TabIndex = 7;
			this._txtRadiusValue.Text = "1";
			// 
			// _tbrRadiusParticle
			// 
			this._tbrRadiusParticle.Location = new System.Drawing.Point(658, 55);
			this._tbrRadiusParticle.Name = "_tbrRadiusParticle";
			this._tbrRadiusParticle.Size = new System.Drawing.Size(104, 45);
			this._tbrRadiusParticle.TabIndex = 8;
			this._tbrRadiusParticle.Scroll += new System.EventHandler(this._tbrRadiusParticle_Scroll);
			// 
			// _txtLabelLife
			// 
			this._txtLabelLife.AutoSize = true;
			this._txtLabelLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtLabelLife.Location = new System.Drawing.Point(667, 107);
			this._txtLabelLife.Name = "_txtLabelLife";
			this._txtLabelLife.Size = new System.Drawing.Size(35, 17);
			this._txtLabelLife.TabIndex = 9;
			this._txtLabelLife.Text = "Life:";
			// 
			// _txtLifeValue
			// 
			this._txtLifeValue.AutoSize = true;
			this._txtLifeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtLifeValue.Location = new System.Drawing.Point(730, 107);
			this._txtLifeValue.Name = "_txtLifeValue";
			this._txtLifeValue.Size = new System.Drawing.Size(16, 17);
			this._txtLifeValue.TabIndex = 10;
			this._txtLifeValue.Text = "1";
			// 
			// _tbrLifeParticle
			// 
			this._tbrLifeParticle.Location = new System.Drawing.Point(658, 127);
			this._tbrLifeParticle.Name = "_tbrLifeParticle";
			this._tbrLifeParticle.Size = new System.Drawing.Size(104, 45);
			this._tbrLifeParticle.TabIndex = 11;
			this._tbrLifeParticle.Scroll += new System.EventHandler(this._tbrLifeParticle_Scroll);
			// 
			// _txtSpeedNext
			// 
			this._txtSpeedNext.AutoSize = true;
			this._txtSpeedNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtSpeedNext.Location = new System.Drawing.Point(298, 398);
			this._txtSpeedNext.Name = "_txtSpeedNext";
			this._txtSpeedNext.Size = new System.Drawing.Size(0, 17);
			this._txtSpeedNext.TabIndex = 12;
			// 
			// _btnMovieBack
			// 
			this._btnMovieBack.Location = new System.Drawing.Point(12, 423);
			this._btnMovieBack.Name = "_btnMovieBack";
			this._btnMovieBack.Size = new System.Drawing.Size(75, 23);
			this._btnMovieBack.TabIndex = 13;
			this._btnMovieBack.Text = "Назад";
			this._btnMovieBack.UseVisualStyleBackColor = true;
			this._btnMovieBack.Click += new System.EventHandler(this._btnMovieBack_Click);
			// 
			// _btnOneBack
			// 
			this._btnOneBack.Location = new System.Drawing.Point(93, 423);
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
			this._txtLabelSpeedXParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtLabelSpeedXParticle.Location = new System.Drawing.Point(667, 179);
			this._txtLabelSpeedXParticle.Name = "_txtLabelSpeedXParticle";
			this._txtLabelSpeedXParticle.Size = new System.Drawing.Size(66, 17);
			this._txtLabelSpeedXParticle.TabIndex = 17;
			this._txtLabelSpeedXParticle.Text = "Speed X:";
			// 
			// _txtSpeedXParticle
			// 
			this._txtSpeedXParticle.AutoSize = true;
			this._txtSpeedXParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtSpeedXParticle.Location = new System.Drawing.Point(730, 179);
			this._txtSpeedXParticle.Name = "_txtSpeedXParticle";
			this._txtSpeedXParticle.Size = new System.Drawing.Size(16, 17);
			this._txtSpeedXParticle.TabIndex = 18;
			this._txtSpeedXParticle.Text = "1";
			// 
			// _tbrSpeedXParticle
			// 
			this._tbrSpeedXParticle.Location = new System.Drawing.Point(658, 210);
			this._tbrSpeedXParticle.Name = "_tbrSpeedXParticle";
			this._tbrSpeedXParticle.Size = new System.Drawing.Size(104, 45);
			this._tbrSpeedXParticle.TabIndex = 19;
			this._tbrSpeedXParticle.Scroll += new System.EventHandler(this._tbrSpeedXParticle_Scroll);
			// 
			// _tbrSpeedYParticle
			// 
			this._tbrSpeedYParticle.Location = new System.Drawing.Point(658, 292);
			this._tbrSpeedYParticle.Name = "_tbrSpeedYParticle";
			this._tbrSpeedYParticle.Size = new System.Drawing.Size(104, 45);
			this._tbrSpeedYParticle.TabIndex = 22;
			this._tbrSpeedYParticle.Scroll += new System.EventHandler(this._tbrSpeedYParticle_Scroll);
			// 
			// _txtSpeedYParticle
			// 
			this._txtSpeedYParticle.AutoSize = true;
			this._txtSpeedYParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtSpeedYParticle.Location = new System.Drawing.Point(730, 261);
			this._txtSpeedYParticle.Name = "_txtSpeedYParticle";
			this._txtSpeedYParticle.Size = new System.Drawing.Size(16, 17);
			this._txtSpeedYParticle.TabIndex = 21;
			this._txtSpeedYParticle.Text = "1";
			// 
			// _txtLabelSpeedYParticle
			// 
			this._txtLabelSpeedYParticle.AutoSize = true;
			this._txtLabelSpeedYParticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this._txtLabelSpeedYParticle.Location = new System.Drawing.Point(667, 261);
			this._txtLabelSpeedYParticle.Name = "_txtLabelSpeedYParticle";
			this._txtLabelSpeedYParticle.Size = new System.Drawing.Size(66, 17);
			this._txtLabelSpeedYParticle.TabIndex = 20;
			this._txtLabelSpeedYParticle.Text = "Speed Y:";
			// 
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(791, 487);
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
	}
}

