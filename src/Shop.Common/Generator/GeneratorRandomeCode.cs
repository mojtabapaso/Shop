namespace Shop.Common.Generator;

public static class GeneratorRandomeCode
{
	public static string RandomeCode(int count)
	{
		Random rand = new Random();
		string code = "";
		for (int i = 0; i < count; i++)
		{
			code += rand.Next(10);
		}
		return code;
	}

}
