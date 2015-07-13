using InfoDisplay.Common.Util.Json;
using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    /// <summary>
    /// Concrete implementation of <see cref="IForecastResults"/> for Open Weather Map service.
    /// </summary>
    public class ForecastResults : BindableBase, IForecastResults
    {
        #region Properties

        /// <see cref="IForecastResults.Days"/>
        [JsonProperty(PropertyName = "list")]
        [JsonConverter(typeof (ConcreteTypeConverter<ForecastResult[]>))]
        public IForecastResult[] Days
        {
            get { return _days; }
            set { SetProperty(ref _days, value); }
        }

        #endregion

        #region Fields

        private IForecastResult[] _days;

        #endregion
    }
}
