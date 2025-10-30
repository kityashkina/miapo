using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ГИБДД
{
    public partial class DriverCard : Form
    {
        private int currentDriverId = -1;

        public DriverCard()
        {
            InitializeComponent();
        }

        private void SetupDriverCardButtons()
        {
            int leftMargin = 250;
            button1.Location = new Point(leftMargin, 543);
            button2.Location = new Point(ClientSize.Width - button2.Width - leftMargin, 543);
            button4.Location = new Point(ClientSize.Width - button4.Width - leftMargin, 647);
        }

        private void DriverCard_Load(object sender, EventArgs e)
        {
            SetupDriverCardButtons();
            button4.Enabled = false;
            ClearDriverLabels();
        }

        private void ClearDriverLabels()
        {
            label12.Text = "ФИО водителя";
            label7.Text = "Паспорт";
            label8.Text = "Телефон";
            label9.Text = "Email";
            label10.Text = "Город";
            label11.Text = "Статус штрафов";
            label11.ForeColor = Color.Black;
            pictureBox2.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentDriver.Id > 0)
            {
                FineManager finesForm = new FineManager(CurrentDriver.Id);
                finesForm.ShowDialog();
                CheckFinesStatus();
            }
            else
            {
                SearchDriver();
            }
        }

        private void SearchDriver()
        {
            string searchText = Interaction.InputBox("Введите фамилию водителя:", "Поиск водителя", "");
            if (string.IsNullOrWhiteSpace(searchText)) return;

            DatabaseHelper db = new DatabaseHelper();
            DataTable result = db.ExecuteQuery($"SELECT * FROM Drivers WHERE LastName LIKE N'%{searchText}%'");

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("Водитель не найден");
                button4.Enabled = false;
                ClearDriverLabels();
            }
            else if (result.Rows.Count == 1)
            {
                ShowDriverInfo(result.Rows[0]);
            }
            else
            {
                ShowDriverSelection(result);
            }
        }

        private void ShowDriverInfo(DataRow driver)
        {
            currentDriverId = Convert.ToInt32(driver["Id"]);
            CurrentDriver.Id = currentDriverId;
            CurrentDriver.LastName = driver["LastName"].ToString();
            CurrentDriver.FirstName = driver["FirstName"].ToString();
            CurrentDriver.MiddleName = driver["MiddleName"].ToString();
            CurrentDriver.Passport = driver["Passport"].ToString();

            label12.Text = $"{driver["LastName"]} {driver["FirstName"]} {driver["MiddleName"]}";
            label7.Text = driver["Passport"].ToString();
            label8.Text = driver["Phone"].ToString();
            label9.Text = driver["Email"].ToString();
            label10.Text = driver["City"].ToString();

            CheckFinesStatus();
            LoadDriverPhoto();
            button4.Enabled = true;
        }

        private void CheckFinesStatus()
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable result = db.ExecuteQuery($"SELECT COUNT(*) as FineCount FROM Fines WHERE DriverId = {currentDriverId}");
            int fineCount = Convert.ToInt32(result.Rows[0]["FineCount"]);

            label11.Text = fineCount > 0 ? $"Есть штрафы ({fineCount} шт.)" : "Штрафов нет";
            label11.ForeColor = fineCount > 0 ? Color.Red : Color.Green;
        }

        private void LoadDriverPhoto()
        {
            if (currentDriverId <= 0) return;

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                DataTable result = db.ExecuteQuery($"SELECT Photo FROM Drivers WHERE Id = {currentDriverId}");

                if (result.Rows.Count > 0 && result.Rows[0]["Photo"] != DBNull.Value)
                {
                    byte[] photoData = (byte[])result.Rows[0]["Photo"];
                    using (MemoryStream ms = new MemoryStream(photoData))
                    {
                        pictureBox2.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
            catch
            {
                pictureBox2.Image = null;
            }
        }

        private void ShowDriverSelection(DataTable drivers)
        {
            string selection = "Найдено несколько водителей:\n\n";
            for (int i = 0; i < drivers.Rows.Count; i++)
            {
                selection += $"{i + 1}. {drivers.Rows[i]["LastName"]} {drivers.Rows[i]["FirstName"]} {drivers.Rows[i]["MiddleName"]}\n";
            }
            selection += "\nВведите номер водителя:";

            string choice = Interaction.InputBox(selection, "Выбор водителя", "1");
            if (int.TryParse(choice, out int driverIndex) && driverIndex > 0 && driverIndex <= drivers.Rows.Count)
            {
                ShowDriverInfo(drivers.Rows[driverIndex - 1]);
            }
        }

        public void LoadDriverData(DataRow driver)
        {
            currentDriverId = Convert.ToInt32(driver["Id"]);
            CurrentDriver.Id = currentDriverId;
            CurrentDriver.LastName = driver["LastName"].ToString();
            CurrentDriver.FirstName = driver["FirstName"].ToString();
            CurrentDriver.MiddleName = driver["MiddleName"].ToString();
            CurrentDriver.Passport = driver["Passport"].ToString();

            label12.Text = $"{driver["LastName"]} {driver["FirstName"]} {driver["MiddleName"]}";
            label7.Text = driver["Passport"].ToString();
            label8.Text = driver["Phone"].ToString();
            label9.Text = driver["Email"].ToString();
            label10.Text = driver["City"].ToString();

            CheckFinesStatus();
            LoadDriverPhoto();
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrentDriver.Id > 0)
            {
                FineHistory historyForm = new FineHistory(CurrentDriver.Id);
                historyForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Сначала выберите водителя");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CurrentDriver.Id > 0)
            {
                workwFines finesForm = new workwFines();
                finesForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Сначала выберите водителя");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();

        }

        // Остальные пустые методы
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void DriverCard_Load_1(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}