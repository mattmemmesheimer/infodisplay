using System;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.SystemStatsService.Models
{
    /// <summary>
    /// Concrete implementation of <see cref="IProcessorStats"/>.
    /// </summary>
    public class ProcessorStats : BindableBase, IProcessorStats
    {
        #region Properties

        /// <see cref="IProcessorStats.TotalUsage"/>
        public UInt64 TotalUsage
        {
            get { return _totalUsage; }
            set { SetProperty(ref _totalUsage, value); }
        }

        #endregion

        #region Fields

        private UInt64 _totalUsage;

        #endregion
    }

}