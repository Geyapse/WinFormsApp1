using Confluent.Kafka;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace ConsumerClient
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cts;

        private IConsumer<Ignore, string>? _consumer;


        private readonly string _connectionString =
            "Server=localhost;Database=KafkaTest;Trusted_Connection=True;TrustServerCertificate=True;";
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
        private void SaveToDatabase(
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
                    
                       SaveToDatabase(notification, result.Topic);
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

            // 사용자 ID 조건
            if (!string.IsNullOrWhiteSpace(txtSearchUserId.Text))
            {
                sql += " AND UserId = @UserId";

                command.Parameters.AddWithValue(
                    "@UserId",
                    txtSearchUserId.Text);
            }

            // 기간 조건
            sql += @" AND ReceivedAt >= @StartDate
              AND ReceivedAt < @EndDate";

            command.Parameters.AddWithValue(
                "@StartDate",
                dtpStartDate.Value.Date);

            command.Parameters.AddWithValue(
                "@EndDate",
                dtpEndDate.Value.Date.AddDays(1));

            // 검색어 조건
            if (!string.IsNullOrWhiteSpace(txtKeyword.Text))
            {
                sql += @" AND
                 (
                    Title LIKE @Keyword
                    OR MessageBody LIKE @Keyword
                 )";

                command.Parameters.AddWithValue(
                    "@Keyword",
                    "%" + txtKeyword.Text + "%");
            }

            sql += " ORDER BY Id DESC";

            command.CommandText = sql;

            SqlDataAdapter adapter =
                new SqlDataAdapter(command);

            DataTable table =
                new DataTable();

            adapter.Fill(table);

            dgvMessages.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
