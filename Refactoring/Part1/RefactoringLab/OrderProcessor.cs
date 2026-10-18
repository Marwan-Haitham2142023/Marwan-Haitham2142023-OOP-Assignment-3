namespace RefactoringLab;

public class OrderProcessor
{
    private readonly IOrderRepository _repository;
    private readonly IEmailSender _emailSender;

    public OrderProcessor(IOrderRepository repository, IEmailSender emailSender)
    {
        _repository = repository;
        _emailSender = emailSender;
    }

    public void Process(int orderId, string customerEmail)
    {
        var processedAt = DateTime.Now;
        _repository.Save(orderId, processedAt);
        _emailSender.Send(customerEmail, $"Order {orderId} confirmed at {processedAt}");
    }
}