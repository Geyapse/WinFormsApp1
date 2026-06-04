using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WinFormsApp1.ProducerClient.Models;
using WinFormsApp1.ProducerClient.Services;

namespace WinFormsApp1.ProducerClient.Forms
{
    public partial class ProducerForm : Form
    {
        private readonly KafkaProducerService _producerService;
        private readonly string _bootstrapServers;
        private readonly string _topic;
        public ProducerForm()
        {
            InitializeComponent();

            _producerService =
                new KafkaProducerService();

            IConfiguration config =
                new ConfigurationBuilder()
                    .SetBasePath(
                        AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(
                        "appsettings.json",
                        optional: false,
                        reloadOnChange: true)
                    .Build();

            _bootstrapServers =
                config["Kafka:BootstrapServers"]!;

            _topic =
                config["Kafka:Topic"]!;
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

                string result =
                await _producerService.SendAsync(
                message,
                txtKafkaServer.Text,
                txtTopic.Text);

                txtLog.AppendText(
                    $"전송 성공 : {result}\r\n\r\n");
            }
            catch (Exception ex)
            {
                txtLog.AppendText(
                    $"오류 타입 : {ex.GetType().Name}\r\n");

                txtLog.AppendText(
                    $"오류 내용 : {ex.Message}\r\n\r\n");
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
