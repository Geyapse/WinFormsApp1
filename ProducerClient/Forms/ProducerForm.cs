using System.Text.Json;
using WinFormsApp1.ProducerClient.Models;
using WinFormsApp1.ProducerClient.Services;

namespace WinFormsApp1.ProducerClient.Forms
{
    public partial class ProducerForm : Form
    {
        private readonly KafkaProducerService _producerService;
        public ProducerForm()
        {
            InitializeComponent();
            _producerService = new KafkaProducerService();
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
                   "localhost:9092",
                   "winform-sample-topic");

                txtLog.AppendText(
                    $"전송 성공 : {result}\r\n\r\n");
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
