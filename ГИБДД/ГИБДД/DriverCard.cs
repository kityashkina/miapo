using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ГИБДД
{
	public partial class DriverCard : Form
	{
		public DriverCard()
		{
			InitializeComponent();
		}

		private void SetupDriverCardButtons()
		{
			int leftMargin = 250; // Отступ слева для button1 и button3
			int rightMargin = ClientSize.Width - 699; // Вычисляем отступ справа

			// Первый ряд
			button1.Location = new Point(leftMargin, 543);
			button2.Location = new Point(ClientSize.Width - button2.Width - leftMargin, 543);

			// Второй ряд
			button3.Location = new Point(leftMargin, 647);
			button4.Location = new Point(ClientSize.Width - button4.Width - leftMargin, 647);
		}

		private void DriverCard_Load(object sender, EventArgs e)
		{
			SetupDriverCardButtons();
		}
		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void DriverCard_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
