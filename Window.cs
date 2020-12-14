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
        bool radar = false;                 //режим радара
        Particle currentParticle = null;    //изменяемая частица

        List<string> typeGraviton = null;
        List<string> typeStandEmitter = null;
        ParticleRadar radarParticle = null; //объект радара

        int MouseClickX = 0;
        int MouseClickY = 0;
        int MousePositionX = -100;
        int MousePositionY = -100;

        public Window()
		{
			InitializeComponent();

            //первоначальная инициализация
            this.emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                Height = picDisplay.Height,
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                GravitationY = 0.25f,
                ColorFrom = Color.White,
                ColorTo = Color.FromArgb(0, Color.Black),
                ParticlesPerTick = 1,
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

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

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

            _txtStatusRadar.ForeColor = Color.Red;
            _txtStatusRadar.Text = "Не активен";
            radarParticle = new ParticleRadar{
                color = Color.YellowGreen
            };
            pictureBox1.BackColor = Color.YellowGreen;
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
            int counter = 0; //количество частиц из всех эммитеров, которые попали в область действия радара
            using(var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                foreach(var emit in emitters)
                {
                    if(start)
                        emit.UpdateState();
                    else if(previous)
                        emit.UpdateStatePrevious(); //обратное движение частиц

                    emit.Render(g);
                    counter += emit.CounterActiveRadar(); //подсчёт частиц, которые попали в область действия радара
                }

                if(counter > 0)
                {   //рисование чисел в области радара (количество частиц попавших в его область действия)
                    g.DrawString($"{counter}",
                    new Font("Verdana", 12),
                    new SolidBrush(Color.White),
                    MousePositionX,
                    MousePositionY + 15);
                }
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e) //обработка движений указателя мыши по холсту
        {
            foreach(var emit in emitters)
            {
                emit.MousePositionX = MousePositionX = e.X;
                emit.MousePositionY = MousePositionY = e.Y;
            }

			if(radar)
			{
                radarParticle.X = e.X;
                radarParticle.Y = e.Y;
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
                emit.MousePositionX = -100;
                emit.MousePositionY = -100;
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
		private void picDisplay_MouseClick(object sender, MouseEventArgs e) //обработка нажатий на клавишу мыши
		{
            MouseClickX = e.X;
            MouseClickY = e.Y;

            _txtEmitterX.Text = MouseClickX.ToString();
            _txtEmitterY.Text = MouseClickY.ToString();

            if(radar) //если включен режим радара прерываем обработку нажатия на клавишу мыши
                return; 

            if(e.Button == MouseButtons.Right) //система создания точки (при щелчке на левую кнопку мыши)
			{
                if((!ValidateComboBox(_cmbTypeGraviton, typeGraviton)) 
                    || (_txtInputPower.Text.Length == 0)){
                    MessageBox.Show("Ошибка: не корректное заполнение полей для добавления точки!");
                    return;
				}

                //добавление точек двух типов: гравитона и антигравитона
				if(_cmbTypeGraviton.Text.Equals(typeGraviton[0]))
				{
                    foreach(var emit in emitters)
					{
                        emit.impactPoints.Add(new GravityPoint
                        {
                            X = emit.MousePositionX,
                            Y = emit.MousePositionY,
                            Power = int.Parse(_txtInputPower.Text)
                        });
                    }
                }else if(_cmbTypeGraviton.Text.Equals(typeGraviton[1]))
				{
                    foreach(var emit in emitters)
                    {
                        emit.impactPoints.Add(new AntiGravityPoint
                        {
                            X = emit.MousePositionX,
                            Y = emit.MousePositionY,
                            Power = int.Parse(_txtInputPower.Text)
                        });
                    }
                }
            }else if(e.Button == MouseButtons.Left) //обработка нажатия на правую кнопку мыши
			{
                if((start == true) || (previous == true))
                {
                    MessageBox.Show("Ошибка: нельзя захватить частицу при движении частиц");
                    return;
                }

                foreach(var emit in emitters)
				{
                    currentParticle = emit.GetClickedParticle();
                    if(currentParticle != null)
                        break;
                }

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

		private void _txtInputPower_KeyPress(object sender, KeyPressEventArgs e) //обработка нажатия на клавишу
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }
        }

		private void _btnClearGraviton_Click(object sender, EventArgs e)
		{
			if(radar)
			{
                MessageBox.Show("Ошибка: вы находитесь в режиме радара, выйдите из него чтобы продолжить настройку холста");
                return;
			}
            foreach(var emit in emitters)
                emit.impactPoints.Clear();
		}

		private void _picFromColor_Click(object sender, EventArgs e)
		{
            //обработка выбора цвета
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

            _txtParticlePerTick.Text = "0";
        }

		private void timer2_Tick_1(object sender, EventArgs e) //обработка рендеринга
        {
            int counter = 0;
            using(var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                foreach(var emit in emitters)
                {
                    emit.Render(g);
                    counter += emit.CounterActiveRadar();
                }

                if(counter > 0)
                {
                    g.DrawString($"{counter}",
                    new Font("Verdana", 12),
                    new SolidBrush(Color.White),
                    MousePositionX,
                    MousePositionY + 15);
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

		private void _btnAddEmitter_Click(object sender, EventArgs e) //добавление эммитера
		{
            if(radar)
            {
                MessageBox.Show("Ошибка: вы находитесь в режиме радара, выйдите из него чтобы продолжить настройку холста");
                return;
            }

            if((_txtGravitationX.Text.Length == 0) || (_txtGravitationY.Text.Length == 0)
                || (_txtSpreading.Text.Length == 0) || (_txtDirection.Text.Length == 0)
                || (_txtCountParticle.Text.Length == 0) || (_txtParticlePerTick.Text.Length == 0))
			{
                MessageBox.Show("Ошибка: не корректное заполнение полей для добавления эмиттера!");
                return;
			}

            float grX = float.Parse(_txtGravitationX.Text), grY = float.Parse(_txtGravitationY.Text);
            int sp = int.Parse(_txtSpreading.Text), dir = int.Parse(_txtDirection.Text);
            int count = int.Parse(_txtCountParticle.Text), tick = int.Parse(_txtParticlePerTick.Text);
            int coordX = int.Parse(_txtEmitterX.Text), coordY = int.Parse(_txtEmitterY.Text);

            if(ValidateComboBox(_cmbStandType, typeStandEmitter))
			{
				if(_cmbStandType.Text.Equals(typeStandEmitter[0]))
				{
                    emitters.Add(new TopEmitter
                    {
                        Width = picDisplay.Width,
                        Height = picDisplay.Height,
                        Direction = dir,
                        Spreading = sp,
                        SpeedMin = 10,
                        SpeedMax = 10,
                        GravitationY = grY,
                        GravitationX = grX,
                        ColorFrom = _picFromColor.BackColor,
                        ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                        ParticlesPerTick = tick,
                        ParticlesCount = count,
                        X = picDisplay.Width / 2,
                        Y = picDisplay.Height / 2,
                    });
                }else if(_cmbStandType.Text.Equals(typeStandEmitter[1]))
                {
                    emitters.Add(new LeftEmitter
                    {
                        Width = picDisplay.Width,
                        Height = picDisplay.Height,
                        Direction = dir,
                        Spreading = sp,
                        SpeedMin = 10,
                        SpeedMax = 10,
                        GravitationY = grY,
                        GravitationX = grX,
                        ColorFrom = _picFromColor.BackColor,
                        ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                        ParticlesPerTick = tick,
                        ParticlesCount = count,
                        X = picDisplay.Width / 2,
                        Y = picDisplay.Height / 2,
                    });
                }
                else if(_cmbStandType.Text.Equals(typeStandEmitter[2]))
                {
                    emitters.Add(new BottomEmitter
                    {
                        Width = picDisplay.Width,
                        Height = picDisplay.Height,
                        Direction = dir,
                        Spreading = sp,
                        SpeedMin = 10,
                        SpeedMax = 10,
                        GravitationY = grY,
                        GravitationX = grX,
                        ColorFrom = _picFromColor.BackColor,
                        ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                        ParticlesPerTick = tick,
                        ParticlesCount = count,
                        X = picDisplay.Width / 2,
                        Y = picDisplay.Height / 2,
                    });
                }
                else if(_cmbStandType.Text.Equals(typeStandEmitter[3]))
                {
                    emitters.Add(new RightEmitter
                    {
                        Width = picDisplay.Width,
                        Height = picDisplay.Height,
                        Direction = dir,
                        Spreading = sp,
                        SpeedMin = 10,
                        SpeedMax = 10,
                        GravitationY = grY,
                        GravitationX = grX,
                        ColorFrom = _picFromColor.BackColor,
                        ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                        ParticlesPerTick = tick,
                        ParticlesCount = count,
                        X = picDisplay.Width / 2,
                        Y = picDisplay.Height / 2,
                    });
                }
			}
			else
			{
                emitters.Add(new Emitter
                {
                    Width = picDisplay.Width,
                    Height = picDisplay.Height,
                    Direction = dir,
                    Spreading = sp,
                    SpeedMin = 10,
                    SpeedMax = 10,
                    GravitationY = grY,
                    GravitationX = grX,
                    ColorFrom = _picFromColor.BackColor,
                    ColorTo = Color.FromArgb(0, _picToColor.BackColor),
                    ParticlesPerTick = tick,
                    ParticlesCount = count,
                    X = coordX,
                    Y = coordY,
                });
            }

            if(emitters.Count >= 2) //наследование точек притяжения/отторжения с предыдущего эмиттера
                foreach(var point in emitters[emitters.Count - 2].impactPoints)
                    emitters[emitters.Count - 1].impactPoints.Add(point);
        }

		private void _cmbStandType_TextChanged(object sender, EventArgs e) //установка специальных типов эммитера
		{
            if(!ValidateComboBox(_cmbStandType, typeStandEmitter))
                return;

            _txtEmitterX.Text = (picDisplay.Width / 2).ToString();
            _txtEmitterY.Text = (picDisplay.Height / 2).ToString();
            if(_cmbStandType.Text.Equals(typeStandEmitter[0]))
			{
                _txtGravitationX.Text = "0";
                _txtGravitationY.Text = "0,25";
			}else if(_cmbStandType.Text.Equals(typeStandEmitter[1]))
			{
                _txtGravitationX.Text = "0,25";
                _txtGravitationY.Text = "0";
            }
            else if(_cmbStandType.Text.Equals(typeStandEmitter[2]))
            {
                _txtGravitationX.Text = "0";
                _txtGravitationY.Text = "-0,25";
            }
            if(_cmbStandType.Text.Equals(typeStandEmitter[3]))
            {
                _txtGravitationX.Text = "-0,25";
                _txtGravitationY.Text = "0";
            }
            _txtCountParticle.Text = (100).ToString();
            _txtDirection.Text = "0";
            _txtSpreading.Text = "360";
            _txtParticlePerTick.Text = "1";
        }

		private void _btnDeleteAllEmitter_Click(object sender, EventArgs e)
		{
            if(radar)
            {
                MessageBox.Show("Ошибка: вы находитесь в режиме радара, выйдите из него чтобы продолжить настройку холста");
                return;
            }
            emitters.Clear();
		}

		private void _txtGravitationX_KeyPress(object sender, KeyPressEventArgs e)
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }

            if(((number == ',') || (number == '-')) && (_txtGravitationX.Text.IndexOf(number) < 0)
                && (_txtGravitationX.Text.Length > 0))
            {
                e.Handled = false;
            }
        }

		private void _txtGravitationY_KeyPress(object sender, KeyPressEventArgs e)
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }

            if(((number == ',') || (number == '-')) && (_txtGravitationY.Text.IndexOf(number) < 0)
                && (_txtGravitationY.Text.Length > 0))
			{
                e.Handled = false;
			}
        }

		private void _txtDirection_KeyPress(object sender, KeyPressEventArgs e)
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }
        }

		private void _txtSpreading_KeyPress(object sender, KeyPressEventArgs e)
		{
            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }
        }

		private void _txtParticlePerTick_KeyPress(object sender, KeyPressEventArgs e)
		{
            if(_txtCountParticle.Text.Length == 0)
			{
                e.Handled = true;
                return;
			}

            char number = e.KeyChar;
            if((!Char.IsDigit(number)) && (number != 8))
            {
                e.Handled = true;
            }

            if(number == 8)
			{
                return;
			}

            if(int.Parse(_txtParticlePerTick.Text + number) > int.Parse(_txtCountParticle.Text))
			{
                e.Handled = true;
			}
        }

		private void button1_Click_1(object sender, EventArgs e)
		{
            //активация / отключение радара
            radar = !radar;
			if(radar)
			{
                _txtStatusRadar.ForeColor = Color.Green;
                _txtStatusRadar.Text = "Активен";
                foreach(var emit in emitters)
                    emit.impactPoints.Add(radarParticle); //при активации радара, он добавляется
                //всем эмиттерам, для того, чтобы захватить все частицы
			}
			else
			{
                _txtStatusRadar.ForeColor = Color.Red;
                _txtStatusRadar.Text = "Не активен";
                foreach(var emit in emitters)
                {
                    int index = (-1);
                    for(int i = 0; (i < emit.impactPoints.Count) && (index < 0); i++)
                    {
                        if(emit.impactPoints[i] is ParticleRadar)
                            index = i;
                    }

                    if(index >= 0)
                        emit.impactPoints.RemoveAt(index);
                    emit.AllNoActiveParticle();
                }
            }
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
            if(_cdRadarColor.ShowDialog() == DialogResult.Cancel)
                return;

            pictureBox1.BackColor = _cdRadarColor.Color;
            radarParticle.color = _cdRadarColor.Color; //установка цвета, которым радар будет выделять 
            //частицы попавшие в область радара
        }

        //обработка движения ползунка мыши
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
		{
			if(radar)
			{
                int number = e.Delta * SystemInformation.MouseWheelScrollLines / 30;
                if((radarParticle.Power + number) >= 0)
                    radarParticle.Power += number;
			}
		}
	}
}
