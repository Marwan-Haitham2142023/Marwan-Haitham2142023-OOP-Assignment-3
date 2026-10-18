using RefactoringLab;

var processor = new OrderProcessor(
    new SqlOrderRepository(),
    new SmtpEmailSender());

processor.Process(123, "customer@example.com");

var notif = new Notification(new EmailChannel(), urgent: true);
notif.Send("customer@example.com", "hello");

var calc = new ShippingCostCalculator(new IShippingCarrier[]
{
    new AramexCarrier(),
    new FedExCarrier(),
    new DhlCarrier(),
    new AramexExpressCarrier(),
});

Console.WriteLine(calc.Calculate("Aramex", 5m));
Console.WriteLine(calc.Calculate("AramexExpress", 5m));