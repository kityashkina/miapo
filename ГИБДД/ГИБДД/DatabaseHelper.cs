using System;
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
            // Простая строка подключения без AttachDbFilename
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=GIBDD_DB;Integrated Security=True;Connect Timeout=30";
            CheckDatabase();
        }

        private void CheckDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Если подключилось - база существует
                }
            }
            catch
            {
                // Если базы нет - создаем простую
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
                        Address nvarchar(200)
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
                    );
                    
                    INSERT INTO Users (Login, Password) VALUES (N'ИванЗоло', N'12345');";

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

                MessageBox.Show("База данных создана! Логин: ИванЗоло, Пароль: 12345", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания базы: {ex.Message}\n\nУбедитесь, что LocalDB установлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Ошибка запроса: {ex.Message}");
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
    }
}