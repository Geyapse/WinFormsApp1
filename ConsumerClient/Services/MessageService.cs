using System.Data;
using ConsumerClient.Repositories;

namespace ConsumerClient.Services;

public class MessageService
{
    private readonly MessageRepository _repository;

    public MessageService(
        MessageRepository repository)
    {
        _repository = repository;
    }

    public void SaveMessage(
        NotificationMessage notification,
        string topic)
    {
        _repository.SaveMessage(
            notification,
            topic);
    }

    public DataTable GetMessages(
        string? userId,
        DateTime startDate,
        DateTime endDate,
        string? keyword)
    {
        return _repository.GetMessages(
            userId,
            startDate,
            endDate,
            keyword);
    }
}