using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Выберите фотографию водителя";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Загружаем изображение в PictureBox
                        pictureBox2.Image = Image.FromFile(openFileDialog.FileName);

                        // Можно сохранить путь к файлу или само изображение в базу
                        // Сохраняем путь к файлу во временную переменную или Tag
                        pictureBox2.Tag = openFileDialog.FileName;

                        MessageBox.Show("Фотография загружена!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string lastName = "", firstName = "", middleName = "", passport = "", phone = "", email = "", city = "", address = "";
                byte[] photoBytes = null;

                // Конвертируем фото в байты
                if (pictureBox2.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        photoBytes = ms.ToArray();
                    }
                }

                // Получаем данные из текстбоксов
                foreach (Control control in tableLayoutPanel1.Controls)
                {
                    if (control is TextBox textBox && textBox.Text != "Введите данные")
                    {
                        if (string.IsNullOrEmpty(lastName)) lastName = textBox.Text;
                        else if (string.IsNullOrEmpty(firstName)) firstName = textBox.Text;
                        else if (string.IsNullOrEmpty(middleName)) middleName = textBox.Text;
                        else if (string.IsNullOrEmpty(passport)) passport = textBox.Text;
                        else if (string.IsNullOrEmpty(phone)) phone = textBox.Text;
                        else if (string.IsNullOrEmpty(email)) email = textBox.Text;
                        else if (string.IsNullOrEmpty(city)) city = textBox.Text;
                        else if (string.IsNullOrEmpty(address)) address = textBox.Text;
                    }
                }

                if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName))
                {
                    MessageBox.Show("Заполните фамилию и имя");
                    return;
                }

                DatabaseHelper db = new DatabaseHelper();

                if (photoBytes != null && photoBytes.Length > 0)
                {
                    string query = @"INSERT INTO Drivers (LastName, FirstName, MiddleName, Passport, Phone, Email, City, Address, Photo) 
                           VALUES (@LastName, @FirstName, @MiddleName, @Passport, @Phone, @Email, @City, @Address, @Photo)";

                    // Используем параметризованный запрос
                    var parameters = new Dictionary<string, object>
            {
                {"@LastName", lastName},
                {"@FirstName", firstName},
                {"@MiddleName", middleName ?? ""},
                {"@Passport", passport ?? ""},
                {"@Phone", phone ?? ""},
                {"@Email", email ?? ""},
                {"@City", city ?? ""},
                {"@Address", address ?? ""},
                {"@Photo", photoBytes}
            };

                    db.ExecuteNonQueryWithParameters(query, parameters);
                }
                else
                {
                    string query = @"INSERT INTO Drivers (LastName, FirstName, MiddleName, Passport, Phone, Email, City, Address) 
                           VALUES (@LastName, @FirstName, @MiddleName, @Passport, @Phone, @Email, @City, @Address)";

                    var parameters = new Dictionary<string, object>
            {
                {"@LastName", lastName},
                {"@FirstName", firstName},
                {"@MiddleName", middleName ?? ""},
                {"@Passport", passport ?? ""},
                {"@Phone", phone ?? ""},
                {"@Email", email ?? ""},
                {"@City", city ?? ""},
                {"@Address", address ?? ""}
            };

                    db.ExecuteNonQueryWithParameters(query, parameters);
                }

                MessageBox.Show("Водитель успешно добавлен!");
                // Сброс полей...
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n\nПодробности: {ex.InnerException?.Message}");
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
