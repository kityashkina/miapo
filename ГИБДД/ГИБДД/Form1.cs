using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ГИБДД
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		public class RoundBtn : Control
		{
			public RoundBtn()
			{

			}
		}

		private void CenterPanelWithOffset()
		{
			panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2, 25);
			label2.Location = new Point((this.ClientSize.Width - label2.Width) / 2, label2.Location.Y);
			label3.Location = new Point((this.ClientSize.Width - label3.Width) / 2, label3.Location.Y);
			textBox1.Location = new Point((this.ClientSize.Width - textBox1.Width) / 2, textBox1.Location.Y);
			textBox2.Location = new Point((this.ClientSize.Width - textBox2.Width) / 2, textBox2.Location.Y);
			button1.Location = new Point((this.ClientSize.Width - button1.Width) / 2, button1.Location.Y);
		}
		private void SetupTextBoxPlaceholders()
		{
			// Для логина
			textBox1.Text = "Введите логин";
			textBox1.ForeColor = Color.Gray;
			textBox1.Enter += (s, e) =>
			{
				if (textBox1.Text == "Введите логин")
				{
					textBox1.Text = "";
					textBox1.ForeColor = Color.Black;
				}
			};
			textBox1.Leave += (s, e) =>
			{
				if (string.IsNullOrWhiteSpace(textBox1.Text))
				{
					textBox1.Text = "Введите логин";
					textBox1.ForeColor = Color.Gray;
				}
			};

			// Для пароля
			textBox2.Text = "Введите пароль";
			textBox2.ForeColor = Color.Gray;
			textBox2.Enter += (s, e) =>
			{
				if (textBox2.Text == "Введите пароль")
				{
					textBox2.Text = "";
					textBox2.ForeColor = Color.Black;
					textBox2.UseSystemPasswordChar = true; // Включаем звездочки для пароля
				}
			};
			textBox2.Leave += (s, e) =>
			{
				if (string.IsNullOrWhiteSpace(textBox2.Text))
				{
					textBox2.Text = "Введите пароль";
					textBox2.ForeColor = Color.Gray;
					textBox2.UseSystemPasswordChar = false; // Выключаем звездочки
				}
			};
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			CenterPanelWithOffset();
			SetupTextBoxPlaceholders();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			mainMenu menu = new mainMenu();
			menu.Show();
			this.Hide();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}
	}
}
