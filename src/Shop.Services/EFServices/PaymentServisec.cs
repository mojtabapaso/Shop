using System.Text;
using Newtonsoft.Json;

namespace Shop.Services.EFServices;


public interface IPaymentServisec
{
    public Task<HttpResponseMessage> PaymentAsync(string amount, string CallbackURL, string phoneNumber, string description);

}

public class PaymentServisec : IPaymentServisec
{
    private static readonly HttpClient client = new HttpClient();
    public async Task<HttpResponseMessage> PaymentAsync(string amount, string CallbackURL, string phoneNumber, string description)
    {
        var _url = "https://www.zarinpal.com/pg/rest/WebGate/PaymentRequest.json";
        var _values = new Dictionary<string, string>
                {
                    { "MerchantID", "99999999-9999-9999-9999-999999999999" },
                    { "Amount", $"{amount}" },
                    { "CallbackURL", $"{CallbackURL}" },
                    { "Mobile", $"{phoneNumber}" },
                    { "Description", $"{description}" }
                };

        var _paymentRequestJsonValue = JsonConvert.SerializeObject(_values);
        var content = new StringContent(_paymentRequestJsonValue, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(_url, content);
        //var responseString = await response.Content.ReadAsStringAsync();

        //var StatusCode = response.StatusCode;

        return response;
    }
}
