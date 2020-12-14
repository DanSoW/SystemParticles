using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemParticles
{
    /// <summary>
    /// Класс частицы
    /// </summary>
    public class Particle : ICloneable //подключение ICloneable для возможности создания клонов объекта (его копий)
    {
        public bool ActiveRadar = false; //находится ли частица под действием радара
        public Color FromColor;
        public Color ToColor;

        //количественное значение радиуса и его ограничение
        public int Radius;
        public int RadiusMin = 2;
        public int RadiusMax = 10;

        //координаты центра частицы
        public float X; 
        public float Y; 

        //скорость
        public float SpeedX; 
        public float SpeedY; 

        //количество жизней и её ограничение
        public float Life;
        public float LifeMin = 0;
        public float LifeMax = 100;

        //координаты экрана
        public int MousePositionX;
        public int MousePositionY;

        //параметры экрана
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

        public virtual void DrawRadar(Graphics g) //функция рисования используемая радаром
        {
            Draw(g);
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

        /// <summary>
        /// Метод определяющий находится ли указатель мыши в области частицы
        /// </summary>
        /// <param name="mouseX">Координата X мыши на холсте PictureBox</param>
        /// <param name="mouseY">Координата Y мыши на холсте PictureBox</param>
        /// <returns>true - если указатель мыши находится в области частицы, и false - в другом случае</returns>
        public bool MouseInParticle(float mouseX, float mouseY)
        {
            return (MousePositionX <= X + Radius) && (MousePositionX >= X - Radius)
                    && (MousePositionY <= Y + Radius) && (MousePositionY >= Y - Radius);
        }

        /// <summary>
        /// Метод создающий копию текущего объекта частицы
        /// </summary>
        /// <returns>Новый объект, содержащий данные текущего объекта</returns>
        public object Clone()
        {
            return new Particle(X, Y, Radius, Life, SpeedX, SpeedY);
        }
    }

    public class ParticleColorful : Particle
    {
        public static Color MixColor(Color color1, Color color2, float k) //ункция формирующая цвет
        {
            int alpha = (int)(color2.A * k + color1.A * (1 - k)),
                red = (int)(color2.R * k + color1.R * (1 - k)),
                green = (int)(color2.G * k + color1.G * (1 - k)),
                blue = (int)(color2.B * k + color1.B * (1 - k));

            //с помощью тернарных операторов сделано ограничение значений, для
            //автоматической обработки ситуаций "крайних" границ
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

    /// <summary>
    /// Класс частиц, информирующих пользователя о своём состоянии
    /// </summary>
    public class ParticleInformation : ParticleColorful
	{
		public override void DrawRadar(Graphics g)
		{
            float k = Math.Min(1f, Life / 100);
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }

		public override void Draw(Graphics g) //рисование цветной частицы с информацией
		{
            float k = Math.Min(1f, Life / 100);
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            float coordX = X + SpeedX, coordY = Y + SpeedY;
            if(Life >= LifeMin) //рисование частиц с информацией доступно только если количество жизни у частицы
                //больше её минимального ограничителя
            {
                Pen pen = new Pen(Color.Yellow);        //создание кисти
                g.DrawLine(pen, X, Y, coordX, coordY);  //создание линии (вектор направления частицы)

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

                    //вычисление позиции четырёхугольника с информацией на холсте
                    float x = MousePositionX + size.Width / 4,
                        y = MousePositionY + size.Height / 4;

                    while((x + size.Width) > Width)
                        x--;
                    while((y + size.Height) > Height)
                        y--;

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
