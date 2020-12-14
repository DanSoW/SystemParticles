using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemParticles
{
	public class Emitter
	{
		public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
		public int Y; // соответствующая координата Y 
		public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
		public int Spreading = 360; // разброс частиц относительно Direction
		public int SpeedMin = 0; // начальная минимальная скорость движения частицы
		public int SpeedMax = 10; // начальная максимальная скорость движения частицы
		public int RadiusMin = 6; // минимальный радиус частицы
		public int RadiusMax = 20; // максимальный радиус частицы
		public int LifeMin = 10; // минимальное количество жизни частицы
		public int LifeMax = 200; // максимальное количество жизни частицы
		public int ParticlesPerTick = 1; // кол-во частиц, создаваемых при каждом тике

		public Color ColorFrom = Color.White; // начальный цвет частицы
		public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

		public List<Particle> particles = new List<Particle>(); //структура данных List, содержащая все частицы эмиттера
		public List<Particle> beginStateParticle = new List<Particle>(); //структура данных List
		//содержащая начальное состояние всех частиц (историю при их создании)
		public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); //структура данных List,
		//содержащая точки притяжения/отторжения

		public float GravitationX = 0;
		public float GravitationY = 0;

		public int MousePositionX;
		public int MousePositionY;

		public int Height;
		public int Width;

		public int ParticlesCount = 100; //кол-во частиц, которое будет создано эмиттером

		public virtual Particle CreateParticle()
		{
			var particle = new ParticleInformation();
			particle.FromColor = ColorFrom;
			particle.ToColor = ColorTo;
			particle.Life = Particle.rand.Next(LifeMin, LifeMax);
			particle.LifeMax = LifeMax;
			particle.LifeMin = LifeMin;
			particle.RadiusMax = RadiusMax;
			particle.RadiusMin = RadiusMin;
			particle.Height = Height;
			particle.Width = Width;

			return particle;
		}

		public virtual void ResetParticle(Particle particle)
		{
			particle.Life = Particle.rand.Next(LifeMin, LifeMax);

			particle.X = X;
			particle.Y = Y;
			particle.Height = Height;
			particle.Width = Width;
			var direction = Direction
				+ (double)Particle.rand.Next(Spreading)
				- Spreading / 2;

			var speed = Particle.rand.Next(SpeedMin, SpeedMax);

			particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
			particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

			particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
		}

		public void UpdateState()
		{
			int particlesToCreate = ParticlesPerTick; //сколько нужно создать частиц за 1 тик

			for(int i = 0; i < particles.Count; i++)
			{
				//частицы живут либо до конца работы программы, либо до возвращения их назад (обратное движение)
				particles[i].Life -= 1;
				particles[i].X += particles[i].SpeedX;
				particles[i].Y += particles[i].SpeedY;

				foreach(var point in impactPoints)
				{
					point.ImpactParticle(particles[i]);
				}

				particles[i].SpeedX += GravitationX;
				particles[i].SpeedY += GravitationY;
			}

			//цикл начальной инициализации всех данных
			while((particlesToCreate >= 1) && (particles.Count < ParticlesCount)) 
			{
				particlesToCreate -= 1;
				var particle = CreateParticle();
				ResetParticle(particle);
				particles.Add(particle);
				beginStateParticle.Add((Particle)particle.Clone());
			}
		}

		public void Render(Graphics g)
		{
			foreach(var particle in particles)
			{
				//каждой частице передаём позицию указателя мыши на холстке pictureDisplay
				particle.MousePositionX = MousePositionX;
				particle.MousePositionY = MousePositionY;
				particle.FromColor = ColorFrom;
				particle.ToColor = ColorTo;

				foreach(var point in impactPoints)
				{
					if(point is ParticleRadar)
					{
						point.ImpactParticle(particle);
					}
				}

				if(particle.ActiveRadar)
				{
					particle.DrawRadar(g);
				}
				else
					particle.Draw(g);
			}

			foreach(var point in impactPoints)
			{
				point.Render(g);
			}
		}

		//возврат к обратному состоянию всех частиц
		public void UpdateStatePrevious()
		{
			if(particles.Count == 0)
				return;

			List<int> particleDeleted = new List<int>(); //элементы, которые необходимо удалить из 
			//beginLife и particles

			for(int i = 0; i < particles.Count; i++)
			{
				particles[i].Life += 1;
				//перемещение будет происходить до тех пор, пока динамически изменяемые величины каждой частицы
				//не окажутся равными начальным (относительно истории их создания) значениям
				if((particles[i].X == beginStateParticle[i].X) && (particles[i].Y == beginStateParticle[i].Y)
					|| (particles[i].Life > beginStateParticle[i].Life))
				{
					particleDeleted.Add(i);
				}
				else if (particles[i].Life < beginStateParticle[i].Life)
				{
					//обратное действие движению
					particles[i].X -= particles[i].SpeedX;
					particles[i].Y -= particles[i].SpeedY;

					foreach(var point in impactPoints)
					{
						point.AntiImpactParticle(particles[i]); //обратное притяжению действие
					}

					//обратное действие притяжению
					particles[i].SpeedX -= GravitationX;
					particles[i].SpeedY -= GravitationY;
				}
			}

			Particle part = new Particle(-1, -1, 0, 0, 0, 0);
			foreach(var index in particleDeleted)
			{
				particles[index] = part;
				beginStateParticle[index] = part;
			}

			//удаление частиц
			while(particles.IndexOf(part) >= 0)
				particles.Remove(part);
			while(beginStateParticle.IndexOf(part) >= 0)
				beginStateParticle.Remove(part);
		}

		/// <summary>
		/// Поиск частицы, на которую был совершён клик
		/// </summary>
		/// <returns>Частица на которую был совершён клик</returns>
		public Particle GetClickedParticle()
		{
			Particle part = null;
			foreach(var particle in particles)
			{
				if(particle.MouseInParticle(MousePositionX, MousePositionY)
					&& (particle.Life >= LifeMin))
				{
					part = particle;
					break;
				}
			}

			return part;
		}

		/// <summary>
		/// Подсчёт количества частиц принадлежащих области действия радара
		/// </summary>
		/// <returns>Количество частиц принадлежащих области действия радара</returns>
		public int CounterActiveRadar()
		{
			int counter = 0; //возврат числа частиц, которые попали в область действия радара
			foreach(var particle in particles)
			{
				if(particle.ActiveRadar)
					counter++;
			}

			return counter;
		}

		/// <summary>
		/// Отменяет принадлежность к области радара всем частицам
		/// </summary>
		public void AllNoActiveParticle()
		{
			foreach(var particle in particles)
			{
				particle.ActiveRadar = false;
			}
		}
	}

	/// <summary>
	/// Эмиттер, генерирующий частицы с верхней части холста
	/// </summary>
	public class TopEmitter : Emitter 
	{
		public override void ResetParticle(Particle particle)
		{
			base.ResetParticle(particle); 

			particle.X = Particle.rand.Next(Width);
			particle.Y = 0; 

			particle.SpeedY = 1; 
			particle.SpeedX = Particle.rand.Next(-2, 2); 
		}
	}

	/// <summary>
	/// Эмиттер, генерирующий частицы с левой части холста
	/// </summary>
	public class LeftEmitter : Emitter
	{
		public override void ResetParticle(Particle particle)
		{
			base.ResetParticle(particle);

			particle.X = 0;
			particle.Y = Particle.rand.Next(Height);

			particle.SpeedY = Particle.rand.Next(-2, 2);
			particle.SpeedX = 1;
		}
	}

	/// <summary>
	/// Эмиттер, генерирующий частицы с правой части холста
	/// </summary>
	public class RightEmitter : Emitter
	{
		public override void ResetParticle(Particle particle)
		{
			base.ResetParticle(particle);

			particle.X = Width;
			particle.Y = Particle.rand.Next(Height);

			particle.SpeedY = Particle.rand.Next(-2, 2);
			particle.SpeedX = -1;
		}
	}

	/// <summary>
	/// Эмиттер, генерирующий частицы с нижней части холста
	/// </summary>
	public class BottomEmitter : Emitter
	{
		public override void ResetParticle(Particle particle)
		{
			base.ResetParticle(particle);

			particle.X = Particle.rand.Next(Width);
			particle.Y = Height;

			particle.SpeedY = -1;
			particle.SpeedX = Particle.rand.Next(-2, 2);
		}
	}

	public abstract class IImpactPoint
	{
		public float X; 
		public float Y;

		public abstract void ImpactParticle(Particle particle);
		public abstract void AntiImpactParticle(Particle particle);

		public virtual void Render(Graphics g)
		{
			g.FillEllipse(
					new SolidBrush(Color.White),
					X - 5,
					Y - 5,
					10,
					10
				);
		}
	}

	/// <summary>
	/// Класс точек притяжения
	/// </summary>
	public class GravityPoint : IImpactPoint
	{
		public int Power = 100; 

		public override void ImpactParticle(Particle particle)
		{
			float gX = X - particle.X;
			float gY = Y - particle.Y;

			double r = Math.Sqrt(gX * gX + gY * gY);
			if(r + particle.Radius < Power / 2)
			{
				float r2 = (float)Math.Max(100, gX * gX + gY * gY);
				particle.SpeedX += gX * Power / r2;
				particle.SpeedY += gY * Power / r2;
			}
		}

		public override void AntiImpactParticle(Particle particle)
		{
			float gX = X - particle.X;
			float gY = Y - particle.Y;

			double r = Math.Sqrt(gX * gX + gY * gY);
			if(r + particle.Radius < Power / 2)
			{
				float r2 = (float)Math.Max(100, gX * gX + gY * gY);
				particle.SpeedX -= gX * Power / r2;
				particle.SpeedY -= gY * Power / r2;
			}
		}

		public override void Render(Graphics g)
		{
			g.DrawEllipse(
				   new Pen(Color.Red),
				   X - Power / 2,
				   Y - Power / 2,
				   Power,
				   Power
			   );
		}
	}

	/// <summary>
	/// Класс точек отторжения
	/// </summary>
	public class AntiGravityPoint : IImpactPoint
	{
		public int Power = 100;
		public override void AntiImpactParticle(Particle particle)
		{
			float gX = X - particle.X;
			float gY = Y - particle.Y;

			double r = Math.Sqrt(gX * gX + gY * gY);
			if(r + particle.Radius < Power / 2)
			{
				float r2 = (float)Math.Max(100, gX * gX + gY * gY);
				particle.SpeedX += gX * Power / r2;
				particle.SpeedY += gY * Power / r2;
			}
		}

		public override void ImpactParticle(Particle particle)
		{
			float gX = X - particle.X;
			float gY = Y - particle.Y;

			double r = Math.Sqrt(gX * gX + gY * gY);
			if(r + particle.Radius < Power / 2)
			{
				float r2 = (float)Math.Max(100, gX * gX + gY * gY);
				particle.SpeedX -= gX * Power / r2;
				particle.SpeedY -= gY * Power / r2;
			}
		}

		public override void Render(Graphics g)
		{
			g.DrawEllipse(
				   new Pen(Color.Yellow),
				   X - Power / 2,
				   Y - Power / 2,
				   Power,
				   Power
			   );
		}
	}

	/// <summary>
	/// Класс реализующий логику радара
	/// </summary>
	public class ParticleRadar : IImpactPoint
	{
		public int Power = 100;
		public Color color = Color.Green;	//цвет в который нужно перекрасить частицы
		public int count = 0;				//количество частиц
		public override void ImpactParticle(Particle particle)
		{
			float gX = X - particle.X;
			float gY = Y - particle.Y;

			double r = Math.Sqrt(gX * gX + gY * gY);
			if(r + particle.Radius < Power / 2)
			{
				particle.FromColor = color;
				particle.ToColor = color;
				particle.ActiveRadar = true;
			}
			else
				particle.ActiveRadar = false;
		}

		public override void AntiImpactParticle(Particle particle)
		{
			ImpactParticle(particle);
		}

		public override void Render(Graphics g)
		{
			g.DrawEllipse(
				   new Pen(Color.OrangeRed),
				   X - Power / 2,
				   Y - Power / 2,
				   Power,
				   Power
			   );
		}
	}
}


