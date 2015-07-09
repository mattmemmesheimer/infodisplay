using Microsoft.Practices.Prism.Mvvm;
using Newtonsoft.Json;

namespace InfoDisplay.WeatherService.Models
{
    public class Weather : BindableBase
    {
        [JsonProperty(PropertyName = "main")]
        public string Main
        {
            get { return _main; }
            set { SetProperty(ref _main, value); }
        }

        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private string _main;
        private string _description;
    }
}
