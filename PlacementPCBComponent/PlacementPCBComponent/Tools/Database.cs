using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace VKR.Tools
{
    public static class Database
    {
        /// <summary> Подключение к БД </summary>
        private static SqlConnection connection;

        #region Взаимодействие с базой данных

        /// <summary> Подключаемся к базе данных </summary>
        public static async void Connect()
        {
            string connectionString = "Server=LAPTOP-OPBCU4UK;Database=SAPR;Trusted_Connection=True;";

            // Создание подключения
            connection = new SqlConnection(connectionString);

            try
            {
                // Открываем подключение
                await connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary> Информация о подключении </summary>
        /// <returns> Возвращаем true, если подключение открыто, иначе false </returns>
        public static bool GetInfoConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> Информация о подключении </summary>
        public static void GetInfo()
        {
            if (connection.State == ConnectionState.Open)
            {
                string information = $"\nБаза данных: {connection.Database}" +
                $"\nСервер: {connection.DataSource}" +
                $"\nСостояние: {connection.State}" +
                $"\nWorkstationld: {connection.WorkstationId}";

                MessageBox.Show(
                        information,
                        "Информация",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

        /// <summary> Получение таблицы </summary>
        /// <param name="name_of_table">Название таблицы</param>
        /// <returns> Возвращаем объект таблицы </returns>
        public static object GetTable(string name_of_table)
        {
            var select = $"SELECT * FROM {name_of_table}";
            var dataAdapter = new SqlDataAdapter(select, connection);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            return ds.Tables[0];
        }

        /// <summary> Зыкрываем подключение к базе данных </summary>
        public static void Disconnect()
        {
            // проверяем открыто ли подключение
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #endregion

        #region Команды SQL запросов

        /// <summary> Выполнение запроса "SELECT" </summary>
        /// <param name="name_of_table">Название таблицы</param>
        /// <param name="where">Условие</param>
        /// <param name="order_by">Фильтрация</param>
        /// <returns> Возвращаем массив столбцов таблицы </returns>
        public static List<string>[] SelectCommand(string name_of_table, string where = null, string order_by = null)
        {
            List<string>[] data = null;

            string sqlExpression = $"SELECT * FROM {name_of_table}";

            if (where != null) sqlExpression += $" WHERE {where}";
            if (order_by != null) sqlExpression += $" ORDER BY {order_by}";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = null;

            try
            {
                reader = command.ExecuteReader();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error );

                return null;
            }

            if (reader.HasRows) // если есть данные
            {
                switch (name_of_table)
                {
                    case "PCB":
                        data = new List<string>[3];
                        data[0] = new List<string>();
                        data[1] = new List<string>();
                        data[2] = new List<string>();

                        while (reader.Read())
                        {
                            data[0].Add(reader.GetValue(0).ToString());
                            data[1].Add(reader.GetValue(1).ToString());
                            data[2].Add(reader.GetValue(2).ToString());
                        }

                        break;

                    case "Component":
                        data = new List<string>[4];
                        data[0] = new List<string>();
                        data[1] = new List<string>();
                        data[2] = new List<string>();
                        data[3] = new List<string>();

                        while (reader.Read()) 
                        {
                            data[0].Add(reader.GetValue(0).ToString());
                            data[1].Add(reader.GetValue(1).ToString());
                            data[2].Add(reader.GetValue(2).ToString());
                            data[3].Add(reader.GetValue(3).ToString());
                        }
                        break;

                    case "Footprint":
                        data = new List<string>[3];
                        data[0] = new List<string>();
                        data[1] = new List<string>();
                        data[2] = new List<string>();

                        while(reader.Read())
                        {
                            data[0].Add(reader.GetValue(0).ToString());
                            data[1].Add(reader.GetValue(1).ToString());
                            data[2].Add(reader.GetValue(2).ToString());
                        }
                        break;
                }
            }

            reader.Close();

            return data;
        }

        #endregion
    }
}
