using Microsoft.Data.SqlClient;
using System.Data;
using WinFormsApp1.ConsumerClient.Models;
namespace WinFormsApp1.ConsumerClient.Repositories;

public class MessageRepository
{
    private readonly string _connectionString;

    public MessageRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void SaveMessage(
        NotificationMessage notification,
        string topic)
    {
        using SqlConnection connection =
            new SqlConnection(_connectionString);

        connection.Open();

        string sql =
        @"INSERT INTO KafkaMessageSample
          (
              UserId,
              Title,
              MessageBody,
              KafkaTopic,
              SendDateTime
          )
          VALUES
          (
              @UserId,
              @Title,
              @MessageBody,
              @KafkaTopic,
              @SendDateTime
          )";

        using SqlCommand command =
            new SqlCommand(sql, connection);

        command.Parameters.AddWithValue(
            "@UserId",
            notification.UserId);

        command.Parameters.AddWithValue(
            "@Title",
            notification.Title);

        command.Parameters.AddWithValue(
            "@MessageBody",
            notification.MessageBody);

        command.Parameters.AddWithValue(
            "@KafkaTopic",
            topic);

        command.Parameters.AddWithValue(
            "@SendDateTime",
            notification.SendDateTime);

        command.ExecuteNonQuery();
    }
    public DataTable GetMessages(
    string? userId,
    DateTime startDate,
    DateTime endDate,
    string? keyword)
    {
        using SqlConnection connection =
            new SqlConnection(_connectionString);

        connection.Open();

        string sql =
        @"SELECT *
      FROM KafkaMessageSample
      WHERE 1 = 1";

        SqlCommand command =
            new SqlCommand();

        command.Connection = connection;

        if (!string.IsNullOrWhiteSpace(userId))
        {
            sql += " AND UserId = @UserId";

            command.Parameters.AddWithValue(
                "@UserId",
                userId);
        }

        sql += @" AND ReceivedAt >= @StartDate
              AND ReceivedAt < @EndDate";

        command.Parameters.AddWithValue(
            "@StartDate",
            startDate.Date);

        command.Parameters.AddWithValue(
            "@EndDate",
            endDate.Date.AddDays(1));

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            sql += @" AND
                (
                    Title LIKE @Keyword
                    OR MessageBody LIKE @Keyword
                )";

            command.Parameters.AddWithValue(
                "@Keyword",
                "%" + keyword + "%");
        }

        sql += " ORDER BY Id DESC";

        command.CommandText = sql;

        SqlDataAdapter adapter =
            new SqlDataAdapter(command);

        DataTable table =
            new DataTable();

        adapter.Fill(table);

        return table;
    }
}