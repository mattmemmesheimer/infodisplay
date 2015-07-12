namespace InfoDisplay.Common.Util
{
    /// <summary>
    /// <see cref="string"/> extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a copy of this string with the first letter uppercased.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>The upper case equivalent of this string.</returns>
        public static string UppercaseFirstLetter(this string input)
        {
            if (input.Length == 0)
            {
                return string.Empty;
            }
            return string.Format("{0}{1}", 
                char.ToUpper(input[0]), input.Substring(1));
        }
    }
}
