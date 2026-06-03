using System;
using System.Collections.Generic;
using System.Text;


namespace WinFormsApp1.ConsumerClient.Models;

public class NotificationMessage
{
    public string UserId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string MessageBody { get; set; } = string.Empty;

    public DateTime SendDateTime { get; set; }
}