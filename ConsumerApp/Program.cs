using Confluent.Kafka;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using ConsumerApp;

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "notification-consumer",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer =
    new ConsumerBuilder<Ignore, string>(config).Build();

consumer.Subscribe("winform-sample-topic");

Console.WriteLine("Consumer 시작");

string connectionString =
    "Server=localhost;Database=KafkaTest;Trusted_Connection=True;TrustServerCertificate=True;";

while (true)
{
    var result = consumer.Consume();

    Console.WriteLine(result.Message.Value);

    try
    {
        var notification = JsonSerializer.Deserialize<NotificationMessage>(
            result.Message.Value);

        using var connection =
            new SqlConnection(connectionString);

        connection.Open();

        string sql = @"
            INSERT INTO KafkaMessageSample
            (
                UserId,
                Title,
                MessageBody,
                KafkaTopic
            )
            VALUES
            (
                @UserId,
                @Title,
                @MessageBody,
                @KafkaTopic
            )";

        using var command =
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
            result.Topic);

        command.ExecuteNonQuery();

        Console.WriteLine($"Topic : {result.Topic}");
        Console.WriteLine($"Message : {result.Message.Value}");
        Console.WriteLine("DB 저장 완료");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}