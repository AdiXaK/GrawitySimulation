using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Gravity_simulation
{

	public partial class MainForm : Form
	{
		Point loc = new Point(0, 0);
		Point loc1 = new Point(312,  108);
		Point loc2 = new Point(312,  108);
		public float speed = 1.0f;
		int fuel = 140;
		bool v1 = false;
		bool v2 = true;
		
		public MainForm()
		{
			InitializeComponent();
		} 
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Space && fuel > 0)
			{
				pictureBox2.Location = loc;
				pictureBox3.Location = loc1;
				pictureBox4.Location = loc2;
				loc.Y -= (int) speed+(int) speed;
				loc1.Y -= (int) speed+(int) speed;
				loc2.Y -= (int) speed+(int) speed ;
				v1 = true;
				v2 = false;
				fuel--;	
				label1.Text = "Топливо: "+fuel+"000";//обновление топлива
				label2.Text = "Скорость: "+speed+" км/c ";//обновление скорости
				pictureBox3.Visible = true;
			}
		}	
		void Timer1Tick(object sender, EventArgs e)
		{
			getacceleration();
			pictureBox3.Visible = false;
			update();
			pictureBox4.Visible = false;
		}
		private float getacceleration()
		{
			//здесь должна быть логика ускорения
			if(v1 == true && v2 == false)
			{
				speed -= 0.3f;
				return speed;				
			}
			else if(v1 == false && v2 == true)
			{ 
				speed += 0.1f;
				return speed;
			}
			else
			{
				speed = 0;
				return speed;
			}
		}
		void update()
		{
			
			label2.Text = "Скорость: "+speed+" км/c ";//обнов 	ление скорости
			pictureBox2.Location = loc;
			pictureBox3.Location = loc1;
			pictureBox4.Location = loc2;
				loc.Y += (int) speed+(int) speed;
				loc1.Y += (int) speed+(int) speed ;
				loc2.Y += (int) speed+(int) speed;
			v1 = false;
			v2 = true;
			if(loc.Y+109 >= pictureBox1.Location.Y)/*109 это размер пикчербокса по оси Y корабля,это условие колизии c луной внутри которого подсчёт итоговых результатов*/ 
				{
	
				timer1.Enabled = false;
				v1 = false;
				v2 = false;
				if(speed<2f)
				{	
								speed = 344;
				loc2.Y = (int) speed;loc2.X = 0;
					     gameresult gr = new  gameresult ();
          				  gr.Show();
				}
				else if(speed<4f && speed>2f)
				{
								speed = 344;
				loc2.Y = (int) speed;loc2.X = 0;
					     gameresult1 gr1 = new  gameresult1 ();
          				  gr1.Show();
				}
				else
				{
								speed = 344;
				loc2.Y = (int) speed;loc2.X = 0;
					     gameresult2 gr2 = new  gameresult2 ();
          				  gr2.Show();
				}
			}
		}
	}
}
