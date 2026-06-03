using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.ProducerClient.Models
{
    internal class KafkaMessage
    {
        public string UserId { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string MessageBody { get; set; } = string.Empty;

        public DateTime SendDateTime { get; set; }
    }
}
