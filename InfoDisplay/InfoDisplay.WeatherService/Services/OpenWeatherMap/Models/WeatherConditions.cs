using InfoDisplay.WeatherService.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace InfoDisplay.WeatherService.Services.OpenWeatherMap.Models
{
    public class WeatherConditions : BindableBase, IWeatherConditions
    {
        public int Id { get; set; }

        public string Main
        {
            get { return _main; }
            set
            {
                SetProperty(ref _main, value);
                Condition = StringToWeatherCondition(value);
            }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public WeatherCondition Condition
        {
            get { return _condition; }
            set { SetProperty(ref _condition, value); }
        }

        private WeatherCondition StringToWeatherCondition(string conditionStr)
        {
            var condition = WeatherCondition.DayClear;
            switch (conditionStr)
            {
                case "Clouds":
                    return  WeatherCondition.DayCloudy;
                    break;
            }
            return condition;
        }

        private string _main;
        private string _description;
        private WeatherCondition _condition;
    }
}
