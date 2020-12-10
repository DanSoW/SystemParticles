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
        
        public Window()
		{
			InitializeComponent();

            /*emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };*/

            this.emitter = new InformationEmitter
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
            });

            // снова гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            });*/
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
			if(start)
                emitter.UpdateState();
            else if(previous)
                emitter.UpdateStatePrevious();

            using(var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach(var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
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
            MessageBox.Show(emitter.particles.Count.ToString() + "\n" + 
                emitter.beginStateParticle.Count.ToString());
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
            if(start)
                return;
            using(var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            picDisplay.Invalidate();
        }

		private void picDisplay_Click(object sender, EventArgs e)
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
            _tbrLifeParticle.Value   = (int)currentParticle.Life;
            _tbrSpeedXParticle.Value = (int)(currentParticle.SpeedX);
            _tbrSpeedYParticle.Value = (int)(currentParticle.SpeedY);

            _txtRadiusValue.Text = currentParticle.Radius.ToString();
            _txtLifeValue.Text = ((int)currentParticle.Life).ToString();
            _txtSpeedXParticle.Text = ((int)(currentParticle.SpeedX)).ToString();
            _txtSpeedYParticle.Text = ((int)(currentParticle.SpeedY)).ToString();
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
            foreach(var emitter in emitters)
            {
                emitter.MousePositionX = -1;
                emitter.MousePositionY = -1;
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
	}
}
