using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;

namespace FunctionAppKafkaW
{
    public static class ConsumerKafka
    {
        [FunctionName("ConsumerKafka")]
        public static void Run([KafkaTrigger(
            "BrokerKafka", "topic-testes",
            ConsumerGroup = "azfunctions0",
            Protocol = BrokerProtocol.SaslSsl,
            AuthenticationMode = BrokerAuthenticationMode.Plain,
            Username = "UserKafka",
            Password = "PasswordKafka"
            )]KafkaEventData<string> kafkaEvent,
            ILogger log)
        {
            log.LogInformation("Azure Functions + Apache Kafka + Azure Event Hubs | " +
                $"Mensagem recebida: {kafkaEvent.Value.ToString()}");
        }
    }
}