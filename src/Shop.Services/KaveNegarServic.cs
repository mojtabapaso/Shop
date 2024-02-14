using Microsoft.Extensions.Options;
using Shop.services.Contracts;
using Shop.ViewModels.App;
using Microsoft.Extensions.Hosting;
namespace Shop.services;

public class KaveNegarServic : IKaveNegarServic
{
	private readonly IOptionsSnapshot<KaveNegarAPI> kaveNegarConfig;
	private readonly IHostEnvironment env;

	public KaveNegarServic(IOptionsSnapshot<KaveNegarAPI> kaveNegarConfig, IHostEnvironment env)
	{
		this.kaveNegarConfig = kaveNegarConfig;
		this.env = env;
	}

	public void SendCodeToPhoneNumber(string phoneNumber, string code)
	{
		string apiKey = kaveNegarConfig.Value.APIKey;

		if (env.IsDevelopment())
		{
			apiKey = "IIII";
		}

		//Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);
		//var result = api.Send(phoneNumber, "Your Receptor", code);
		//foreach (var r in result.Receptor)
		//{
		//	Console.Write($"{r.ToString()}");
		//}

	}
}
