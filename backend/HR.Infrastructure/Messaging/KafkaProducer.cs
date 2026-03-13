using System.Text.Json;
using Confluent.Kafka;

namespace HR.Infrastructure.Messaging;

public class KafkaProducer
{
  private readonly ProducerConfig _config;

  public KafkaProducer()
  {
    _config = new ProducerConfig
    {
      BootstrapServers = "kafka:9092"
    };
  }

  public async Task ProduceAsync(string topic, object message)
  {
    using var producer = new ProducerBuilder<string, string>(_config).Build();

    var json = JsonSerializer.Serialize(message);

    await producer.ProduceAsync(topic, new Message<string, string>
    {
      Key = Guid.NewGuid().ToString(),
      Value = json
    });
  }
}