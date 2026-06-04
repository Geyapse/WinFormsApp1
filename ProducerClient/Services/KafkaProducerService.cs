using Confluent.Kafka;
using System.Text.Json;
using WinFormsApp1.ProducerClient.Models;

namespace WinFormsApp1.ProducerClient.Services;

public class KafkaProducerService
{
    public async Task<string> SendAsync(
    KafkaMessage message,
    string bootstrapServers,
    string topic)
    {
        string json =
        JsonSerializer.Serialize(message);

    var config =
        new ProducerConfig
        {
            BootstrapServers =
                bootstrapServers,

                MessageTimeoutMs = 3000,

            SocketTimeoutMs = 3000
        };

        using var producer =
            new ProducerBuilder<Null, string>(config)
                .Build();

        var result =
            await producer.ProduceAsync(
                topic,
                new Message<Null, string>
                {
                    Value = json
                });

        return result.TopicPartitionOffset.ToString();
    }


}
