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
			SetupTextBoxPlaceholders();
		}

		private void locationButtons()
		{
			int buttonWidth = 272;
			int buttonHeight = 52;
			int margin = 150;

			button2.Location = new Point(margin, 450);
			button3.Location = new Point(this.ClientSize.Width - margin - buttonWidth, 450);
		}
		private void SetupTextBoxPlaceholders()
		{
			foreach (Control control in tableLayoutPanel1.Controls)
			{
				if (control is TextBox textBox)
				{
					SetupSingleTextBox(textBox);
				}
			}
		}

		private void SetupSingleTextBox(TextBox textBox)
		{
			textBox.Text = "Введите данные";
			textBox.ForeColor = Color.Gray;

			textBox.Enter += (s, e) =>
			{
				if (textBox.Text == "Введите данные")
				{
					textBox.Text = "";
					textBox.ForeColor = Color.Black;
				}
			};

			textBox.Leave += (s, e) =>
			{
				if (string.IsNullOrWhiteSpace(textBox.Text))
				{
					textBox.Text = "Введите данные";
					textBox.ForeColor = Color.Gray;
				}
			};
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


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
        }
    }
}
