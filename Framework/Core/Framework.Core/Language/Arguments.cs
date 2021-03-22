namespace Framework.Core.Language
{
	public static class Arguments
	{
		public static bool NotNull<T>(T argument) => argument is not null;

	}
}
