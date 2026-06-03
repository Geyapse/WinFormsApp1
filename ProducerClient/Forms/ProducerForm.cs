using System.Text.Json;
using Confluent.Kafka;
using WinFormsApp1.ProducerClient.Models;

namespace WinFormsApp1
{
    public partial class ProducerForm : Form
    {
        public ProducerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                KafkaMessage message = new KafkaMessage
                {
                    UserId = txtUserId.Text,
                    Title = txtTitle.Text,
                    MessageBody = txtMessage.Text,
                    SendDateTime = DateTime.Now
                };

                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string json = JsonSerializer.Serialize(message);

                var config = new ProducerConfig
                {
                    BootstrapServers = "localhost:9092"
                };

                using var producer =
                    new ProducerBuilder<Null, string>(config).Build();

                var result = await producer.ProduceAsync(
                    "winform-sample-topic",
                    new Message<Null, string>
                    {
                        Value = json
                    });

                txtLog.AppendText(
                    $"전송 성공 : {result.TopicPartitionOffset}\r\n");

                txtLog.AppendText(
                    $"{json}\r\n\r\n");
            }
            catch (Exception ex)
            {
                txtLog.AppendText(
                    $"오류 : {ex.Message}\r\n");
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
