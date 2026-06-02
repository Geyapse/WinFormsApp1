using System;
using System.Collections.Generic;
using System.Text;


namespace ConsumerApp;

public class NotificationMessage
{
    public string UserId { get; set; }

    public string Title { get; set; }

    public string MessageBody { get; set; }

    public DateTime SendDateTime { get; set; }
}