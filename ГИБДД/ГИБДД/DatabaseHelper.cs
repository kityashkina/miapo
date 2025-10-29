using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ГИБДД
{
    public class DatabaseHelper
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GIBDD_DB.mdf;Integrated Security=True;Connect Timeout=30;";

        public DatabaseHelper()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string databasePath = Path.Combine(Application.StartupPath, "GIBDD_DB.mdf");

            if (!File.Exists(databasePath))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            try
            {
                string createDbQuery = @"
                    CREATE DATABASE [GIBDD_DB] ON PRIMARY 
                    (NAME = GIBDD_DB, FILENAME = '" + Path.Combine(Application.StartupPath, "GIBDD_DB.mdf") + @"')";

                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(createDbQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                CreateTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания базы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateTables()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                // Таблица Users
                string createUsersTable = @"
                    CREATE TABLE Users (
                        Id int IDENTITY(1,1) PRIMARY KEY,
                        Login nvarchar(50) NOT NULL,
                        Password nvarchar(50) NOT NULL
                    )";

                // Таблица Drivers
                string createDriversTable = @"
                    CREATE TABLE Drivers (
                        Id int IDENTITY(1,1) PRIMARY KEY,
                        LastName nvarchar(100) NOT NULL,
                        FirstName nvarchar(100) NOT NULL,
                        MiddleName nvarchar(100),
                        Passport nvarchar(50) NOT NULL,
                        Phone nvarchar(20),
                        Email nvarchar(100),
                        City nvarchar(100),
                        Address nvarchar(200)
                    )";

                // Таблица Fines
                string createFinesTable = @"
                    CREATE TABLE Fines (
                        Id int IDENTITY(1,1) PRIMARY KEY,
                        DriverId int NOT NULL,
                        FineDate date NOT NULL,
                        FineType nvarchar(100) NOT NULL,
                        FineAmount decimal(10,2) NOT NULL,
                        FineStatus nvarchar(50) NOT NULL,
                        FOREIGN KEY (DriverId) REFERENCES Drivers(Id)
                    )";

                // Таблица Exports
                string createExportsTable = @"
                    CREATE TABLE Exports (
                        Id int IDENTITY(1,1) PRIMARY KEY,
                        DriverId int NOT NULL,
                        ExportDate date NOT NULL,
                        ExportStatus nvarchar(50) NOT NULL,
                        FOREIGN KEY (DriverId) REFERENCES Drivers(Id)
                    )";

                using (SqlCommand command = new SqlCommand(createUsersTable + createDriversTable + createFinesTable + createExportsTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Добавляем тестового пользователя
                string insertUser = "INSERT INTO Users (Login, Password) VALUES (N'ИванЗоло', N'12345')";
                using (SqlCommand command = new SqlCommand(insertUser, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }
            return dataTable;
        }

        public int ExecuteNonQuery(string query)
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения команды: {ex.Message}");
            }
            return result;
        }
    }
}