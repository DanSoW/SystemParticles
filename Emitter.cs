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
		public int LifeMin = 20; // минимальное время жизни частицы
		public int LifeMax = 200; // максимальное время жизни частицы
		public int ParticlesPerTick = 1; // добавил новое поле

		public Color ColorFrom = Color.White; // начальный цвет частицы
		public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

		public List<Particle> particles = new List<Particle>();
		public List<Particle> beginStateParticle = new List<Particle>(); //массив содержащий начальное состояние всех частиц

		public List<IImpactPoint> impactPoints = new List<IImpactPoint>();
		public float GravitationX = 0;
		public float GravitationY = 0;

		public int MousePositionX;
		public int MousePositionY;

		public int Height;
		public int Width;

		public virtual Particle CreateParticle()
		{
			var particle = new ParticleColorful();
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

		public int ParticlesCount = 100;
		public virtual void ResetParticle(Particle particle)
		{
			particle.Life = Particle.rand.Next(LifeMin, LifeMax);

			particle.X = X;
			particle.Y = Y;

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
			int particlesToCreate = ParticlesPerTick; //сколько нужно создать частиц

			for(int i = 0; i < particles.Count; i++)
			{
				particles[i].Life -= 1;
				if(particles[i].Life < LifeMin) //если кол-во жизней у частицы < LifeMin
				{
					if(particlesToCreate > 0) //а кол-во создаваемых частиц больше 0
					{
						particlesToCreate -= 1;  //то вычитаем из кол-ва создаваемых частиц 1
						ResetParticle(particles[i]); //и ставим частицу на стандартное место
						beginStateParticle[i] = (Particle)particles[i].Clone();
					}
				}
				else
				{
					particles[i].X += particles[i].SpeedX;
					particles[i].Y += particles[i].SpeedY;

					foreach(var point in impactPoints)
					{
						point.ImpactParticle(particles[i]);
					}

					particles[i].SpeedX += GravitationX;
					particles[i].SpeedY += GravitationY;
				}
			}

			while(particlesToCreate >= 1) //первоначальная инициализация всех данных
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
				particle.MousePositionX = MousePositionX;
				particle.MousePositionY = MousePositionY;
				particle.Draw(g);
			}

			foreach(var point in impactPoints)
			{
				point.Render(g);
			}
		}

		//возврат к обратному состоянию частиц частиц
		public void UpdateStatePrevious()
		{
			if(particles.Count == 0)
				return;

			List<int> particleDeleted = new List<int>(); //элементы, которые необходимо удалить из 
			//beginLife и particles

			for(int i = 0; i < particles.Count; i++)
			{
				particles[i].Life += 1;
				if((particles[i].X == beginStateParticle[i].X) && (particles[i].Y == beginStateParticle[i].Y)
					|| (particles[i].Life > beginStateParticle[i].Life))
				{
					particleDeleted.Add(i);
				}
				else if (particles[i].Life < beginStateParticle[i].Life)
				{
					particles[i].X -= particles[i].SpeedX;
					particles[i].Y -= particles[i].SpeedY;

					foreach(var point in impactPoints) //сделать обратное притяжению действие
					{
						point.AntiImpactParticle(particles[i]);
					}

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

			while(particles.IndexOf(part) >= 0)
				particles.Remove(part);
			while(beginStateParticle.IndexOf(part) >= 0)
				beginStateParticle.Remove(part);
		}

		public Particle GetClickedParticle() //возвращяет ссылку на частицу, на которую был совершён клик
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
	}

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

	public class InformationEmitter : TopEmitter
	{
		public override Particle CreateParticle()
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

	public class GravityPoint : IImpactPoint
	{
		public int Power = 100; 

		/*public override void ImpactParticle(Particle particle)
		{
			float gX = X - particle.X;
			float gY = Y - particle.Y;
			float r2 = (float)Math.Max(100, gX * gX + gY * gY);

			particle.SpeedX += gX * Power / r2;
			particle.SpeedY += gY * Power / r2;
		}*/

		public override void ImpactParticle(Particle particle)
		{
			float gX = X - particle.X;
			float gY = Y - particle.Y;

			double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
			if(r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
			{
				// то притягиваем ее
				float r2 = (float)Math.Max(100, gX * gX + gY * gY);
				particle.SpeedX += gX * Power / r2;
				particle.SpeedY += gY * Power / r2;
			}
		}

		public override void AntiImpactParticle(Particle particle)
		{
			float gX = X - particle.X;
			float gY = Y - particle.Y;
			float r2 = (float)Math.Max(100, gX * gX + gY * gY);

			particle.SpeedX -= gX * Power / r2;
			particle.SpeedY -= gY * Power / r2;
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
}
