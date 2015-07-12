using System;

namespace InfoDisplay.Common.Util
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0,
            DateTimeKind.Utc);

        /// <summary>
        /// Converts a Unix timestamp to a DateTime.
        /// </summary>
        /// <remarks>
        /// Technically not an extension method.  Sue me.
        /// </remarks>
        /// <param name="timestamp">Unix timestamp.</param>
        /// <returns>DateTime represented by the Unix timestamp.</returns>
        public static DateTime FromUnixTimestamp(int timestamp)
        {
            return UnixEpoch.AddSeconds(timestamp).ToLocalTime();
        }
    }
}
