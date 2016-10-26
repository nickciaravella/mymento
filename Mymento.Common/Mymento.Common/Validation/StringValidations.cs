namespace Mymento.Common.Validation
{
    using System;

    public static class StringValidations
    {
        public static void ArgumentShouldNotBeNullOrEmpty(this string obj, string paramName)
        {
            obj.ArgumentShouldNotBeNull(paramName);
            if (string.IsNullOrEmpty(obj))
            {
                throw new ArgumentException("Argument should not be empty.", paramName);
            }
        }

        public static void ArgumentShouldNotBeNullOrWhitespace(this string obj, string paramName)
        {
            obj.ArgumentShouldNotBeNull(paramName);
            if (string.IsNullOrWhiteSpace(obj))
            {
                throw new ArgumentException("Argument should not be whitespace.", paramName);
            }
        }
    }
}
