namespace Mymento.App.Shared
{
    using System;

    public static class Ensure
    {
        public static void ArgumentIsNotNullOrWhitespace(string argumentName, string argumentValue)
        {
            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException($"{argumentName} is null or whitespace.");
            }
        }
    }
}
