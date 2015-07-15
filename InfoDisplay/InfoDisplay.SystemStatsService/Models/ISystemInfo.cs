namespace InfoDisplay.SystemStatsService.Models
{
    /// <summary>
    /// Defines an interface for system information.
    /// </summary>
    public interface ISystemInfo
    {
        /// <summary>
        /// System name.
        /// </summary>
        string Name { get; set; }
    }

}