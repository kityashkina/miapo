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
	public partial class makeDriver : Form
	{
		public makeDriver()
		{
			InitializeComponent();
		}

		private void makeDriver_Load(object sender, EventArgs e)
		{
			locationButtons();
		}

		private void locationButtons()
		{
			int buttonWidth = 314;
			int buttonHeight = 61;
			int margin = 265;

			button2.Location = new Point(margin, 668);
			button3.Location = new Point(this.ClientSize.Width - margin - buttonWidth, 668);
		}
		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

        private void makeDriver_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
        }
    }
}
