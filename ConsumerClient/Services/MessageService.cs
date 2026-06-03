using System.Data;
using WinFormsApp1.ConsumerClient.Repositories;
using WinFormsApp1.ConsumerClient.Models;

namespace WinFormsApp1.ConsumerClient.Services;

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