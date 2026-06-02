using Confluent.Kafka;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;
using ConsumerClient.Repositories;
using ConsumerClient;
using ConsumerClient.Services;
using Microsoft.Extensions.Configuration;

namespace ConsumerClient
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cts;

        private IConsumer<Ignore, string>? _consumer;


        private readonly string _connectionString;
        private readonly MessageRepository _repository;
        private readonly MessageService _service;

        private void AddLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(() => AddLog(message));
                return;
            }

            lstMessages.Items.Add(
                $"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        public Form1()
        {
            InitializeComponent();

            IConfiguration config =
      new ConfigurationBuilder()
      .SetBasePath(
          AppDomain.CurrentDomain.BaseDirectory)
      .AddJsonFile(
          "appsettings.json",
          optional: false,
          reloadOnChange: true)
      .Build();

            _connectionString =
                 config.GetConnectionString(
                    "DefaultConnection")!;

            txtBootstrapServer.Text =
                config["Kafka:BootstrapServers"];

            txtTopic.Text =
                config["Kafka:Topic"];

            txtGroupId.Text =
                config["Kafka:GroupId"];


            _repository =
                 new MessageRepository(
                    _connectionString);
            _service =
                 new MessageService(
                     _repository);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cts?.Cancel();
            _consumer?.Close();
            _consumer?.Dispose();

            base.OnFormClosing(e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStartConsumer_Click(object sender, EventArgs e)
        {
            if (_consumer != null)
            {
                _consumer.Resume(_consumer.Assignment);

                AddLog("수신 재개");

                return;
            }

            _cts = new CancellationTokenSource();

            var config = new ConsumerConfig
            {
                BootstrapServers = txtBootstrapServer.Text,
                GroupId = txtGroupId.Text,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer =
                new ConsumerBuilder<Ignore, string>(config)
                .Build();

            _consumer.Subscribe(txtTopic.Text);

            AddLog("Consumer 시작");
            StartConsumerLoop();
        }

        private void StartConsumerLoop()
        {
            Task.Run(() =>
           {
               try
               {
                   while (!_cts!.IsCancellationRequested)
                   {

                       var result = _consumer!.Consume(_cts.Token);

                       var notification =
                        JsonSerializer.Deserialize<NotificationMessage>(
                            result.Message.Value);

                       AddLog(
                           $"{notification!.UserId} - {notification.Title}");

                       _service.SaveMessage(notification, result.Topic);
                   }
               }

               catch (OperationCanceledException)
               {

               }

               catch (ConsumeException ex)
               {
                   AddLog(
                       $"Kafka 오류 : {ex.Error.Reason}");
               }

               catch (JsonException ex)
               {
                   AddLog(
                       $"JSON 오류 : {ex.Message}");
               }

               catch (SqlException ex)
               {
                   AddLog(
                       $"DB 오류 : {ex.Message}");
               }

               catch (Exception ex)
               {
                   AddLog(
                       $"기타 오류 : {ex.Message}");
               }


               finally
               {
                   _consumer?.Close();
                   _consumer?.Dispose();
                   _consumer = null;
               }
           });
        }


        private void btnStopConsumer_Click(object sender, EventArgs e)
        {
            if (_consumer == null)
                return;

            _consumer.Pause(_consumer.Assignment);

            AddLog("수신 중지");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvMessages.DataSource =
                _service.GetMessages(
                    txtSearchUserId.Text,
                    dtpStartDate.Value,
                    dtpEndDate.Value,
                    txtKeyword.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtBootstrapServer_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
