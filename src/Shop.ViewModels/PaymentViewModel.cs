namespace Shop.ViewModels;

public class PaymentViewModel
{
    public decimal Amount { get; set; }
    public string CallbackURL { get; set; }
    public string Mobile { get ; set; }
    public string Description { get; set; }
}
