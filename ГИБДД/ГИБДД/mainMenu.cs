using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ГИБДД
{
	public partial class mainMenu : Form
	{
		public mainMenu()
		{
			InitializeComponent();
		}
		private void SetupMenu()
		{
			int leftMargin = 158; // Отступ слева для button1 и button3
			int rightMargin = ClientSize.Width - 772; // Вычисляем отступ справа

			button2.Location = new Point(ClientSize.Width - button2.Width - leftMargin, button2.Location.Y);
			button4.Location = new Point(ClientSize.Width - button4.Width - leftMargin, button4.Location.Y);
			button5.Location = new Point((this.ClientSize.Width - button5.Width) / 2, button5.Location.Y);
		}
		private void mainMenu_Load(object sender, EventArgs e)
		{
			SetupMenu();
		}
		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			makeDriver makeDr = new makeDriver();
			makeDr.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}
	}
}
