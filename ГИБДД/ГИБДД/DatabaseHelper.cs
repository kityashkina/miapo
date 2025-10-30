using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ГИБДД
{
    public class DatabaseHelper
    {
        private string databaseName = "GIBDD_DB.mdf";
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=GIBDD_DB;Integrated Security=True;Connect Timeout=30";

            // Добавляем колонку Photo если ее нет
            AddPhotoColumnIfNotExists();

            CheckDatabase();
        }

        private void CheckDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем есть ли данные в Drivers
                    string checkDataQuery = "SELECT COUNT(*) FROM Drivers";
                    using (SqlCommand command = new SqlCommand(checkDataQuery, connection))
                    {
                        int dataCount = (int)command.ExecuteScalar();

                        if (dataCount == 0)
                        {
                            // Данных нет - добавляем тестовые
                            AddTestData();
                        }
                    }
                }
            }
            catch
            {
                // Если базы нет - создаем с тестовыми данными
                CreateSimpleDatabase();
            }
        }
        private void CreateSimpleDatabase()
        {
            try
            {
                string createScript = @"
            CREATE DATABASE [GIBDD_DB];
            
            USE [GIBDD_DB];
            
            CREATE TABLE Users (
                Id int IDENTITY(1,1) PRIMARY KEY,
                Login nvarchar(50) NOT NULL,
                Password nvarchar(50) NOT NULL
            );
            
            CREATE TABLE Drivers (
                Id int IDENTITY(1,1) PRIMARY KEY,
                LastName nvarchar(100) NOT NULL,
                FirstName nvarchar(100) NOT NULL,
                MiddleName nvarchar(100),
                Passport nvarchar(50) NOT NULL,
                Phone nvarchar(20),
                Email nvarchar(100),
                City nvarchar(100),
                Address nvarchar(200),
                Photo varbinary(MAX) NULL  -- ДОБАВЬ ЭТУ СТРОЧКУ!
            );
            
            CREATE TABLE Fines (
                Id int IDENTITY(1,1) PRIMARY KEY,
                DriverId int NOT NULL,
                FineDate date NOT NULL,
                FineType nvarchar(100) NOT NULL,
                FineAmount decimal(10,2) NOT NULL,
                FineStatus nvarchar(50) NOT NULL
            );
            
            CREATE TABLE Exports (
                Id int IDENTITY(1,1) PRIMARY KEY,
                DriverId int NOT NULL,
                ExportDate date NOT NULL,
                ExportStatus nvarchar(50) NOT NULL
            );";

                using (SqlConnection masterConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True"))
                {
                    masterConnection.Open();

                    string[] commands = createScript.Split(new[] { ";\r\n", ";\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string command in commands)
                    {
                        if (!string.IsNullOrWhiteSpace(command))
                        {
                            using (SqlCommand sqlCommand = new SqlCommand(command.Trim(), masterConnection))
                            {
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Добавляем тестовые данные
                AddTestData();

                MessageBox.Show("База данных создана с тестовыми данными!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания базы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddPhotoColumnIfNotExists()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();

                    // Проверяем есть ли колонка Photo
                    string checkColumnQuery = @"
                SELECT COUNT(*) 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = 'Drivers' AND COLUMN_NAME = 'Photo'";

                    using (SqlCommand command = new SqlCommand(checkColumnQuery, connection))
                    {
                        int columnExists = (int)command.ExecuteScalar();

                        if (columnExists == 0)
                        {
                            // Добавляем колонку если ее нет
                            string alterTableQuery = "ALTER TABLE Drivers ADD Photo VARBINARY(MAX) NULL";
                            using (SqlCommand alterCommand = new SqlCommand(alterTableQuery, connection))
                            {
                                alterCommand.ExecuteNonQuery();
                                MessageBox.Show("Колонка Photo добавлена в таблицу Drivers", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления колонки Photo: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddTestData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Добавляем пользователей
                    string usersQuery = @"
                        INSERT INTO Users (Login, Password) VALUES 
                        (N'ИванЗоло', N'12345'),
                        (N'ПетровА', N'54321'),
                        (N'СидороваМ', N'qwerty')";

                    // Добавляем водителей
                    string driversQuery = @"
                        INSERT INTO Drivers (LastName, FirstName, MiddleName, Passport, Phone, Email, City, Address) VALUES 
                        (N'Иванов', N'Иван', N'Иванович', N'4510123456', N'89991234567', N'ivanov@mail.ru', N'Москва', N'ул. Ленина, д. 10'),
                        (N'Петров', N'Петр', N'Петрович', N'4510987654', N'89997654321', N'petrov@gmail.com', N'Санкт-Петербург', N'пр. Победы, д. 25'),
                        (N'Сидорова', N'Мария', N'Сергеевна', N'4520112233', N'89995556677', N'sidorova@yandex.ru', N'Казань', N'ул. Баумана, д. 5'),
                        (N'Козлов', N'Алексей', N'Владимирович', N'4520445566', N'89998887766', N'kozlov@mail.ru', N'Новосибирск', N'пл. Ленина, д. 1'),
                        (N'Новиков', N'Дмитрий', N'Олегович', N'4530778899', N'89993332211', N'novikov@gmail.com', N'Екатеринбург', N'ул. Мира, д. 15')";

                    // Добавляем штрафы
                    string finesQuery = @"
                        INSERT INTO Fines (DriverId, FineDate, FineType, FineAmount, FineStatus) VALUES 
                        (1, '2024-01-15', N'Превышение скорости', 500.00, N'Не оплачен'),
                        (2, '2024-01-10', N'Проезд на красный свет', 1000.00, N'Не оплачен'),
                        (3, '2024-03-05', N'Отсутствие ремня безопасности', 500.00, N'Оплачен')";

                    using (SqlCommand command = new SqlCommand(usersQuery + driversQuery + finesQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления тестовых данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Ошибка запроса: {ex.Message}\nЗапрос: {query}");
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
                MessageBox.Show($"Ошибка команды: {ex.Message}");
            }
            return result;
        }
        public int ExecuteNonQueryWithPhoto(string query, byte[] photo)
        {
            int result = -1;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = photo;
                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка команды: {ex.Message}");
            }
            return result;
        }
        public void ExecuteNonQueryWithParameters(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}