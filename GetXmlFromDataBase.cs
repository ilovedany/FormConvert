using Npgsql;
namespace FormConvert
{
    internal class GetXmlFromDataBase
    {
        //метод для получения xml из поля таблицы
        public string GetStringXmlFromDB(string connectionString, string tableName, string columnName, int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT {columnName} FROM {tableName} WHERE id=@id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    object result = cmd.ExecuteScalar();
                    return result.ToString();
                }
            }
        }
    }
}
