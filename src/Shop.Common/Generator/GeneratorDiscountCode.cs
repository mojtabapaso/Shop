namespace Shop.Common.Generator;

public static class GeneratorCoupon
{
	public static string DiscountCode(int count)
	{
        Random rand = new Random();
        string code = "";
        string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(characters.Length);
            code += characters[index];
        }
        return code;
    }
}
