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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }
        private void SetupMenu()
        {
            int leftMargin = 158;
            int rightMargin = ClientSize.Width - 772;

            button2.Location = new Point((this.ClientSize.Width - button2.Width) / 2, button2.Location.Y);
            button5.Location = new Point((this.ClientSize.Width - button5.Width) / 2, button5.Location.Y);
            button1.Location = new Point((this.ClientSize.Width - button1.Width) / 2, button1.Location.Y);
        }
        private void mainMenu_Load(object sender, EventArgs e)
        {
            SetupMenu();
        }
private void button3_Click(object sender, EventArgs e)
{
    string lastName = ShowSearchDialog();
    if (string.IsNullOrWhiteSpace(lastName))
        return;

    DatabaseHelper db = new DatabaseHelper();
    string query = $"SELECT TOP 1 * FROM Drivers WHERE LastName LIKE N'%{lastName}%'";
    DataTable result = db.ExecuteQuery(query);

    if (result.Rows.Count > 0)
    {
        DataRow driverRow = result.Rows[0];

        this.Close();
        workwFines finesForm = new workwFines(driverRow);
        finesForm.Show();
    }
    else
    {
        MessageBox.Show("Водитель не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            makeDriver makeDr = new makeDriver();
            makeDr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Сначала поиск водителя
            string searchText = ShowSearchDialog();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                // Ищем водителя в базе
                DatabaseHelper db = new DatabaseHelper();
                string query = $"SELECT * FROM Drivers WHERE LastName LIKE N'%{searchText}%'";
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count > 0)
                {
                    // Если нашли - открываем DriverCard с данными
                    this.Close();
                    DriverCard driverCard = new DriverCard();

                    if (result.Rows.Count == 1)
                    {
                        // Если один - сразу загружаем
                        driverCard.LoadDriverData(result.Rows[0]);
                    }
                    else
                    {
                        // Если несколько - показываем выбор
                        DataRow selectedDriver = ShowDriverSelectionDialog(result);
                        if (selectedDriver != null)
                        {
                            driverCard.LoadDriverData(selectedDriver);
                        }
                        else
                        {
                            return; // Пользователь не выбрал
                        }
                    }

                    driverCard.Show();
                }
                else
                {
                    MessageBox.Show("Водитель не найден");
                }
            }
        }

        private DataRow ShowDriverSelectionDialog(DataTable drivers)
        {
            Form selectionForm = new Form()
            {
                Width = 500,
                Height = 400,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Выбор водителя",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label label = new Label() { Text = "Найдено несколько водителей. Выберите нужного:", Left = 20, Top = 20, Width = 450 };

            ListBox listBox = new ListBox() { Left = 20, Top = 50, Width = 450, Height = 250 };

            // Заполняем список водителями
            foreach (DataRow driver in drivers.Rows)
            {
                string driverInfo = $"{driver["LastName"]} {driver["FirstName"]} {driver["MiddleName"]} | Паспорт: {driver["Passport"]} | Город: {driver["City"]}";
                listBox.Items.Add(driverInfo);
            }

            Button okButton = new Button() { Text = "Выбрать", Left = 350, Top = 310, Width = 120, DialogResult = DialogResult.OK };
            Button cancelButton = new Button() { Text = "Отмена", Left = 220, Top = 310, Width = 120, DialogResult = DialogResult.Cancel };

            DataRow selectedDriver = null;

            okButton.Click += (sender, e) => {
                if (listBox.SelectedIndex >= 0)
                {
                    selectedDriver = drivers.Rows[listBox.SelectedIndex];
                }
                selectionForm.Close();
            };

            selectionForm.Controls.AddRange(new Control[] { label, listBox, okButton, cancelButton });
            selectionForm.AcceptButton = okButton;
            selectionForm.CancelButton = cancelButton;

            return selectionForm.ShowDialog() == DialogResult.OK ? selectedDriver : null;
        }

        private string ShowSearchDialog()
        {
            Form searchForm = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Поиск водителя",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label label = new Label() { Text = "Введите фамилию водителя:", Left = 20, Top = 20, Width = 260 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 260 };
            Button okButton = new Button() { Text = "Найти", Left = 200, Top = 80, Width = 80, DialogResult = DialogResult.OK };

            okButton.Click += (sender, e) => { searchForm.Close(); };
            searchForm.Controls.Add(label);
            searchForm.Controls.Add(textBox);
            searchForm.Controls.Add(okButton);
            searchForm.AcceptButton = okButton;

            return searchForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu mainMenu = new mainMenu();
            mainMenu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Form1 = new Form1();
            Form1.Show();
        }
    }
}