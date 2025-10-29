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
            try
            {
                // Получаем данные из текстбоксов (предполагая, что они в tableLayoutPanel1)
                string lastName = "", firstName = "", middleName = "", passport = "", phone = "", email = "", city = "", address = "";

                foreach (Control control in tableLayoutPanel1.Controls)
                {
                    if (control is TextBox textBox)
                    {

                        if (textBox.Text != "Введите данные" && !string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            if (lastName == "") lastName = textBox.Text;
                            else if (firstName == "") firstName = textBox.Text;
                            else if (middleName == "") middleName = textBox.Text;
                            else if (passport == "") passport = textBox.Text;
                            else if (phone == "") phone = textBox.Text;
                            else if (email == "") email = textBox.Text;
                            else if (city == "") city = textBox.Text;
                            else if (address == "") address = textBox.Text;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(passport))
                {
                    MessageBox.Show("Заполните фамилию, имя и паспорт");
                    return;
                }

                DatabaseHelper db = new DatabaseHelper();
                string query = $@"
            INSERT INTO Drivers (LastName, FirstName, MiddleName, Passport, Phone, Email, City, Address) 
            VALUES (N'{lastName}', N'{firstName}', N'{middleName}', N'{passport}', N'{phone}', N'{email}', N'{city}', N'{address}')";

                int result = db.ExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Водитель успешно добавлен!");
                    // Очищаем поля
                    foreach (Control control in tableLayoutPanel1.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            textBox.Text = "Введите данные";
                            textBox.ForeColor = Color.Gray;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении водителя");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
