using System;
using System.Data;
using System.Windows.Forms;

namespace ГИБДД
{
    public partial class FineManager : Form
    {
        private int driverId;

        public FineManager(int driverId)
        {
            InitializeComponent();
            this.driverId = driverId;
            SetupEvents();
            LoadFines();
        }

        private void SetupEvents()
        {
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += (s, e) => this.Close();
        }

        private void LoadFines()
        {
            var db = new DatabaseHelper();
            string query = $@"
        SELECT 
            Id,
            FineDate as 'Дата',
            FineType as 'Тип штрафа', 
            FineAmount as 'Сумма',
            FineStatus as 'Статус'
        FROM Fines 
        WHERE DriverId = {driverId}";

            dataGridView1.DataSource = db.ExecuteQuery(query);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string type = Microsoft.VisualBasic.Interaction.InputBox("Тип штрафа:", "Добавить штраф");
            if (!string.IsNullOrEmpty(type))
            {
                string amount = Microsoft.VisualBasic.Interaction.InputBox("Сумма:", "Добавить штраф");
                if (!string.IsNullOrEmpty(amount) && decimal.TryParse(amount, out decimal amt))
                {
                    var db = new DatabaseHelper();
                    string query = $@"
                        INSERT INTO Fines (DriverId, FineDate, FineType, FineAmount, FineStatus) 
                        VALUES ({driverId}, GETDATE(), N'{type}', {amt}, N'Не оплачен')";
                    db.ExecuteNonQuery(query);
                    LoadFines();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int fineId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                var db = new DatabaseHelper();
                db.ExecuteNonQuery($"DELETE FROM Fines WHERE Id = {fineId}");
                LoadFines();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Изменения сохранены!");
        }

        private void FineManager_Load(object sender, EventArgs e)
        {

        }
    }
}