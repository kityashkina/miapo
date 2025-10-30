using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ГИБДД
{
    public partial class FineHistory : Form
    {
        private int driverId;

        public FineHistory(int driverId)
        {
            InitializeComponent();
            this.driverId = driverId;
            LoadFineHistory();
        }

        private void LoadFineHistory()
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = $@"
        SELECT 
            Id,
            FineDate as 'Дата',
            FineType as 'Тип штрафа', 
            FineAmount as 'Сумма',
            FineStatus as 'Статус'
        FROM Fines 
        WHERE DriverId = {driverId}
        ORDER BY FineDate DESC";

            DataTable fines = db.ExecuteQuery(query);
            dataGridView1.DataSource = fines;

            // Добавляем кнопку "Посмотреть"
            DataGridViewButtonColumn viewButton = new DataGridViewButtonColumn();
            viewButton.Name = "ViewButton";
            viewButton.HeaderText = "Действие";
            viewButton.Text = "Посмотреть";
            viewButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(viewButton);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;

            // Обработчик клика по кнопке
            dataGridView1.CellClick += DataGridView1_CellClick;

            label1.Text = $"История штрафов (Всего: {fines.Rows.Count} шт.)";
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ViewButton"].Index)
            {
                // Получаем данные водителя из базы
                DatabaseHelper db = new DatabaseHelper();
                DataTable driverInfo = db.ExecuteQuery($"SELECT * FROM Drivers WHERE Id = {driverId}");

                if (driverInfo.Rows.Count > 0)
                {
                    // Открываем workwFines с данными водителя
                    workwFines workForm = new workwFines(driverInfo.Rows[0]);
                    workForm.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Кнопка "Закрыть"
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработка клика по ячейке (если нужно)
        }

        private void FineHistory_Load(object sender, EventArgs e)
        {
            // Дополнительная настройка при загрузке
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}