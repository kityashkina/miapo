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
    public partial class export : Form
    {
        public export()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void locationButtons()
        {
            int buttonWidth = 272;
            int buttonHeight = 52;
            int margin = 150;

			button1.Location = new Point(margin, 450);
			button2.Location = new Point(this.ClientSize.Width - margin - buttonWidth, 450);
		}
        private void export_Load(object sender, EventArgs e)
        {
            locationButtons();
        }



		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
			mainMenu mainMenu = new mainMenu();
			mainMenu.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
