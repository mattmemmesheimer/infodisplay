namespace InfoDisplay.Common.Util
{
    public static class StringExtensions
    {
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
