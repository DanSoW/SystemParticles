using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemParticles
{
	public partial class Window : Form
	{
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;        
        bool start = false;                 //началось ли движение частиц вперёд или нет
        bool previous = false;              //началось ли движение частиц назад или нет
        Particle currentParticle = null;    //изменяемая частица

        List<string> typeGraviton = null;
        List<string> typeStandEmitter = null;

        
        public Window()
		{
			InitializeComponent();

            /*emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };*/

            this.emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                GravitationY = 0.25f,
                ColorFrom = Color.White,
                ColorTo = Color.FromArgb(0, Color.Black),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);
            _tbrRadiusParticle.Maximum = emitter.RadiusMax;
            _tbrRadiusParticle.Minimum = emitter.RadiusMin;
            _tbrLifeParticle.Maximum   = emitter.LifeMax;
            _tbrLifeParticle.Minimum   = emitter.LifeMin;
            _tbrSpeedXParticle.Maximum = 100;
            _tbrSpeedXParticle.Minimum = -100;
            _tbrSpeedYParticle.Maximum = 100;
            _tbrSpeedYParticle.Minimum = -100;

            // привязка изображения
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            /*
            // гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2
            });

            // в центре антигравитон
            emitter.impactPoints.Add(new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            });*/

            // снова гравитон
            /*emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            });
            */
            //interface initializing

            typeGraviton = new List<string> { "гравитон", "антигравитон" };
            typeStandEmitter = new List<string> { "top", "left", "bottom", "right" };
            foreach(var type in typeGraviton)
                _cmbTypeGraviton.Items.Add(type);
            foreach(var type in typeStandEmitter)
                _cmbStandType.Items.Add(type);

            _cdFromColor.FullOpen = true;
            _picFromColor.BackColor = _cdFromColor.Color = Color.White;

            _cdToColor.FullOpen = true;
            _picToColor.BackColor = _cdToColor.Color = Color.Black;
        }

        private void EmptyParticleInterface()
		{
            _txtRadiusValue.Text = "";
            _txtLifeValue.Text = "";
            _txtSpeedXParticle.Text = "";
            _txtSpeedYParticle.Text = "";
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(var emit in emitters)
            {
                if(start)
                    emit.UpdateState();
                else if(previous)
                    emit.UpdateStatePrevious();

                using(var g = Graphics.FromImage(picDisplay.Image))
                {
                    g.Clear(Color.Black);
                    emit.Render(g);
                }
            }
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach(var emit in emitters)
            {
                emit.MousePositionX = e.X;
                emit.MousePositionY = e.Y;
            }
        }

		private void button1_Click(object sender, EventArgs e)
		{
            start = !start;
            previous = false;
            currentParticle = null;
            EmptyParticleInterface();
		}


		private void _tbSpeed_Scroll(object sender, EventArgs e)
		{
            timer1.Interval = _tbSpeedNext.Value;
            _txtSpeedNext.Text = _tbSpeedNext.Value.ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
            start = true;
            timer1_Tick(sender, e);
            start = false;
		}

		private void _tbrRadiusParticle_Scroll(object sender, EventArgs e)
		{
            if(currentParticle == null)
                return;
            currentParticle.Radius = _tbrRadiusParticle.Value;
            _txtRadiusValue.Text = currentParticle.Radius.ToString();
		}

		private void _tbrLifeParticle_Scroll(object sender, EventArgs e)
		{
            if(currentParticle == null)
                return;
            currentParticle.Life = _tbrLifeParticle.Value;
            _txtLifeValue.Text = currentParticle.Life.ToString();
        }

		private void _tbrSpeedXParticle_Scroll(object sender, EventArgs e)
		{
            if(currentParticle == null)
                return;
            currentParticle.SpeedX = _tbrSpeedXParticle.Value;
            _txtSpeedXParticle.Text = currentParticle.SpeedX.ToString();
        }

		private void _tbrSpeedYParticle_Scroll(object sender, EventArgs e)
		{
            if(currentParticle == null)
                return;
            currentParticle.SpeedY = _tbrSpeedYParticle.Value;
            _txtSpeedYParticle.Text = currentParticle.SpeedY.ToString();
        }

		private void picDisplay_MouseLeave(object sender, EventArgs e)
		{
            foreach(var emit in emitters)
            {
                emit.MousePositionX = -1;
                emit.MousePositionY = -1;
            }
        }

		private void _btnMovieBack_Click(object sender, EventArgs e)
		{
            start = false;
            previous = !previous;
		}

		private void _btnOneBack_Click(object sender, EventArgs e)
		{
            previous = true;
            timer1_Tick(sender, e);
            previous = false;
        }


        private bool ValidateComboBox(ComboBox cmb, List<string> lists)
		{
            return (lists.IndexOf(cmb.Text) >= 0);
		}
		private void picDisplay_MouseClick(object sender, MouseEventArgs e)
		{
            if(e.Button == MouseButtons.Right) //система создания точки
			{
                if((!ValidateComboBox(_cmbTypeGraviton, typeGraviton)) 
                    || (_txtInputPower.Text.Length == 0)){
                    MessageBox.Show("Ошибка: не корректное заполнение полей для создания точки!");
                    return;
				}

				if(_cmbTypeGraviton.Text.Equals(typeGraviton[0]))
				{
                    emitter.impactPoints.Add(new GravityPoint
                    {
                        X = emitter.MousePositionX,
                        Y = emitter.MousePositionY,
                        Power = int.Parse(_txtInputPower.Text)
                    });
                }else if(_cmbTypeGraviton.Text.Equals(typeGraviton[1]))
				{
                    emitter.impactPoints.Add(new AntiGravityPoint
                    {
                        X = emitter.MousePositionX,
                        Y = emitter.MousePositionY,
                        Power = int.Parse(_txtInputPower.Text)
                    });
				}
            }else if(e.Button == MouseButtons.Left)
			{
                if(start == true)
                {
                    MessageBox.Show("Ошибка: нельзя захватить частицу при движении частиц");
                    return;
                }
                currentParticle = emitter.GetClickedParticle();
                if(currentParticle == null)
                    return;
                //открытие режима корректирования частицы

                _tbrRadiusParticle.Value = currentParticle.Radius;
                _tbrLifeParticle.Value = (int)currentParticle.Life;
                _tbrSpeedXParticle.Value = (int)(currentParticle.SpeedX);
                _tbrSpeedYParticle.Value = (int)(currentParticle.SpeedY);

                _txtRadiusValue.Text = currentParticle.Radius.ToString();
                _txtLifeValue.Text = ((int)currentParticle.Life).ToString();
                _txtSpeedXParticle.Text = ((int)(currentParticle.SpeedX)).ToString();
                _txtSpeedYParticle.Text = ((int)(currentParticle.SpeedY)).ToString();
            }
		}

		private void _txtInputPower_KeyPress(object sender, KeyPressEventArgs e)
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }
        }

		private void _btnClearGraviton_Click(object sender, EventArgs e)
		{
            emitter.impactPoints.Clear();
		}

		private void _picFromColor_Click(object sender, EventArgs e)
		{
            if(_cdFromColor.ShowDialog() == DialogResult.Cancel)
                return;

            _picFromColor.BackColor = _cdFromColor.Color;
		}

		private void _picToColor_Click(object sender, EventArgs e)
		{
            if(_cdToColor.ShowDialog() == DialogResult.Cancel)
                return;

            _picToColor.BackColor = _cdToColor.Color;
		}

		private void _txtCountParticle_KeyPress(object sender, KeyPressEventArgs e)
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }
        }

		private void timer2_Tick_1(object sender, EventArgs e)
		{
            if(start || previous)
                return;
            foreach(var emit in emitters)
			{
                using(var g = Graphics.FromImage(picDisplay.Image))
                {
                    g.Clear(Color.Black);
                    emit.Render(g);
                }
            }

            picDisplay.Invalidate();
        }

		private void _txtEmitterY_KeyPress(object sender, KeyPressEventArgs e)
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }
        }

		private void _txtEmitterX_KeyPress(object sender, KeyPressEventArgs e)
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }
        }

		private void _btnAddEmitter_Click(object sender, EventArgs e)
		{
            /*if(((_cmbStandType.Text.Length != 0 ) && (!ValidateComboBox(_cmbStandType, typeStandEmitter)))
                || (_txtEmitterX.Text.Length == 0) || (_txtEmitterY.Text.Length == 0)
                || (_txtCountParticle.Text.Length == 0))
			{
                MessageBox.Show("Ошибка: не корректное заполнение полей для добавления эммитера!");
                return;
			}*/

            if(ValidateComboBox(_cmbStandType, typeStandEmitter))
			{
				if(_cmbStandType.Text.Equals(typeStandEmitter[0]))
				{
                    emitters.Add(new TopEmitter
                    {
                        Width = picDisplay.Width,
                        Height = picDisplay.Height,
                        Direction = 0,
                        Spreading = 10,
                        SpeedMin = 10,
                        SpeedMax = 10,
                        GravitationY = 0.25f,
                        ColorFrom = _picFromColor.BackColor,
                        ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                        ParticlesPerTick = 10,
                        X = picDisplay.Width / 2,
                        Y = picDisplay.Height / 2,
                    });
                }else if(_cmbStandType.Text.Equals(typeStandEmitter[1]))
				{
                    emitters.Add(new LeftEmitter
                    {
                        Width = picDisplay.Width,
                        Height = picDisplay.Height,
                        Direction = 0,
                        Spreading = 10,
                        SpeedMin = 10,
                        SpeedMax = 10,
                        GravitationX = 0.25f,
                        ColorFrom = _picFromColor.BackColor,
                        ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                        ParticlesPerTick = 10,
                        X = picDisplay.Width / 2,
                        Y = picDisplay.Height / 2,
                    });
                }else if(_cmbStandType.Text.Equals(typeStandEmitter[2]))
				{
                    emitters.Add(new BottomEmitter
                    {
                        Width = picDisplay.Width,
                        Height = picDisplay.Height,
                        Direction = 0,
                        Spreading = 10,
                        SpeedMin = 10,
                        SpeedMax = 10,
                        GravitationY = -0.25f,
                        ColorFrom = _picFromColor.BackColor,
                        ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                        ParticlesPerTick = 10,
                        X = picDisplay.Width / 2,
                        Y = picDisplay.Height / 2,
                    });
                }else if(_cmbStandType.Text.Equals(typeStandEmitter[3]))
				{
                    emitters.Add(new RightEmitter
                    {
                        Width = picDisplay.Width,
                        Height = picDisplay.Height,
                        Direction = 0,
                        Spreading = 10,
                        SpeedMin = 10,
                        SpeedMax = 10,
                        GravitationX = -0.25f,
                        ColorFrom = _picFromColor.BackColor,
                        ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                        ParticlesPerTick = 10,
                        X = picDisplay.Width / 2,
                        Y = picDisplay.Height / 2,
                    });
                }

                return;
			}

            emitters.Add(new Emitter{
                ColorFrom = _picFromColor.BackColor,
                ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                X = int.Parse(_txtEmitterX.Text),
                Y = int.Parse(_txtEmitterY.Text),
                ParticlesCount = int.Parse(_txtCountParticle.Text)
			});
		}

		private void _cmbStandType_TextChanged(object sender, EventArgs e)
		{
            if(!ValidateComboBox(_cmbStandType, typeStandEmitter))
                return;

            _txtEmitterX.Text = (picDisplay.Width / 2).ToString();
            _txtEmitterY.Text = (picDisplay.Height / 2).ToString();
            if(_cmbStandType.Text.Equals(typeStandEmitter[0]))
			{
                _txtEmitterX.Text = "";
                _txtEmitterY.Text = "";
			}
		}
	}
}
