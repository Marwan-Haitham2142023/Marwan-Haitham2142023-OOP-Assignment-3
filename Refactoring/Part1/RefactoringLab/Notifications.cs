using RefactoringLab;

public class Notification
{
    private readonly INotificationChannel _channel;
    private readonly bool _urgent;
    private readonly DateTime? _sendAt;

    public Notification(
        INotificationChannel channel,
        bool urgent = false,
        DateTime? sendAt = null)
    {
        _channel = channel;
        _urgent = urgent;
        _sendAt = sendAt;
    }

    public void Send(string to, string message)
    {
        var finalMessage = _urgent ? $"[URGENT] {message}" : message;

        var label = _sendAt.HasValue
            ? $"{_channel.Name} scheduled {_sendAt.Value:g}"
            : _channel.Name;

        _channel.Deliver(to, label, finalMessage);
    }
}