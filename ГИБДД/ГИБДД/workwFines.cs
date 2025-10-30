using System;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ГИБДД
{
    public partial class workwFines : Form
    {
        private DataRow driverData;

        public workwFines()
        {
            InitializeComponent();
        }

        // Новый конструктор
        public workwFines(DataRow driverRow)
        {
            InitializeComponent();
            driverData = driverRow;
        }

        private void workwFines_Load(object sender, EventArgs e)
        {
            if (driverData != null)
                LoadDriverFines(driverData);
        }

        private void LoadDriverFines(DataRow driver)
        {
            string driverName = $"{driver["LastName"]} {driver["FirstName"]} {driver["MiddleName"]}";
            labelNumber.Text = driver["Passport"].ToString();
            labelDate.Text = DateTime.Now.ToShortDateString();
            labelUserName.Text = driverName;

            // Загружаем детальную информацию о штрафах
            DatabaseHelper db = new DatabaseHelper();
            DataTable fines = db.ExecuteQuery($@"
        SELECT FineType, FineAmount, FineStatus, FineDate 
        FROM Fines WHERE DriverId = {driver["Id"]}");

            // Показываем информацию о штрафах (можно в dataGridView или labels)
            if (fines.Rows.Count > 0)
            {
                DataRow firstFine = fines.Rows[0];
                // Например, показываем первый штраф в деталях
                label7.Text = $"Тип: {firstFine["FineType"]}\nСумма: {firstFine["FineAmount"]} руб.\nСтатус: {firstFine["FineStatus"]}";
            }

            labelNumber.ForeColor = Color.Gray;
            labelUserName.ForeColor = Color.Gray;
            labelDate.ForeColor = Color.Gray;
        }


        private void label7_Click(object sender, EventArgs e)
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

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
			mainMenu mainMenu = new mainMenu();
			mainMenu.Show();
		}
    }
}
