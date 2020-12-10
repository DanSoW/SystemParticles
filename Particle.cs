using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemParticles
{
    public class Particle : ICloneable
    {
        public int Radius;
        public int RadiusMin = 2;
        public int RadiusMax = 10;

        public float X; 
        public float Y; 

        public float SpeedX; 
        public float SpeedY; 

        public float Life;
        public float LifeMin = 0;
        public float LifeMax = 100;

        //screen
        public int MousePositionX;
        public int MousePositionY;
        public int Height;
        public int Width;

        public static Random rand = new Random();

        public Particle(float x, float y, int radius, float life, float speedx, float speedy)
		{
            X = x;
            Y = y;
            Radius = radius;
            Life = life;
            SpeedX = speedx;
            SpeedY = speedy;
		}

        public Particle()
        {
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Radius = RadiusMin + rand.Next(RadiusMax);
            Life = LifeMin + rand.Next((int)LifeMax);
        }

        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            int alpha = (int)(k * 255);

  
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public bool MouseInParticle(float mouseX, float mouseY) // находится ли указатель мыши в частице
        {
            return (MousePositionX <= X + Radius) && (MousePositionX >= X - Radius)
                    && (MousePositionY <= Y + Radius) && (MousePositionY >= Y - Radius);
        }

        public object Clone()
        {
            return new Particle(X, Y, Radius, Life, SpeedX, SpeedY);
        }
    }

    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;

        public static Color MixColor(Color color1, Color color2, float k) //функция формирующая цвет
        {
            int alpha = (int)(color2.A * k + color1.A * (1 - k)),
                red = (int)(color2.R * k + color1.R * (1 - k)),
                green = (int)(color2.G * k + color1.G * (1 - k)),
                blue = (int)(color2.B * k + color1.B * (1 - k));

            //с помощью тернарных операторов было сделано ограничение значений для крайних точек
            alpha = (alpha < 0) ? 0 : (alpha > 255) ? 255 : alpha;
            red = (red < 0) ? 0 : (red > 255) ? 255 : red;
            green = (green < 0) ? 0 : (green > 255) ? 255 : green;
            blue = (blue < 0) ? 0 : (blue > 255) ? 255 : blue;

            return Color.FromArgb(alpha, red, green, blue);
        }

		public override void Draw(Graphics g) //рисование цветной частицы
        {
            float k = Math.Min(1f, Life / 100);
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }

    public class ParticleInformation : ParticleColorful
	{
		public override void Draw(Graphics g) //рисование цветной частицы с информацией
		{
            float k = Math.Min(1f, Life / 100);
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            float coordX = X + SpeedX, coordY = Y + SpeedY;
            if(Life >= LifeMin)
            {
                Pen pen = new Pen(Color.Yellow);
                g.DrawLine(pen, X, Y, coordX, coordY);

                if((MousePositionX <= X + Radius) && (MousePositionX >= X - Radius)
                    && (MousePositionY <= Y + Radius) && (MousePositionY >= Y - Radius))
                {
                    g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
                    var stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Near;

                    var text = $"X: {X}\nY: {Y}\nRadius: {Radius}\nLife: {Life}";
                    var font = new Font("Verdana", 10);

                    var size = g.MeasureString(text, font);

                    float x = MousePositionX + size.Width / 4,
                        y = MousePositionY + size.Height / 4;

                    if((x + size.Width) > Width)
                    {
                        if((y - size.Height / 4 - size.Height) < 0)
                        {
                            x -= (size.Width / 4 + size.Width);
                            y += size.Height / 4;
                        }
                        else
                        {
                            x -= (size.Width / 4 + size.Width);
                            y -= (size.Height / 4 + size.Height);
                        }
                    }
                    else if((y + size.Height) > Height)
                    {
                        if((x - size.Width / 4 - size.Width) < 0)
                        {
                            x += size.Width / 4;
                            y -= (size.Height / 4 + size.Height);
                        }
                        else
                        {
                            x -= (size.Width / 4 + size.Width);
                            y -= (size.Height / 4 + size.Height);
                        }
                    }

                    g.FillRectangle(
                        new SolidBrush(Color.OrangeRed),
                        x,
                        y,
                        size.Width,
                        size.Height
                    );

                    g.DrawString(
                        text,
                        font,
                        new SolidBrush(Color.Black),
                        x,
                        y,
                        stringFormat
                    );
                }

                pen.Dispose();
            }

            b.Dispose();
        }
	}
}
