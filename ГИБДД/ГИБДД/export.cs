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
            int buttonWidth = 314;
            int buttonHeight = 61;
            int margin = 265;

            button2.Location = new Point(margin, 668);
            button3.Location = new Point(this.ClientSize.Width - margin - buttonWidth, 668);
        }
        private void export_Load(object sender, EventArgs e)
        {
            locationButtons();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
        }
    }
}
