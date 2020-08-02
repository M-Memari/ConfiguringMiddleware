using Microsoft.Extensions.Options;

namespace ConfiguringMiddleware
{
    public class MessageOptions 
    {
        public string CityName { get; set; } = "Tehran";
        public string CountryName { get; set; } = "Iran";

        public void Deconstruct(out string city, out string country)
        {
            city = CityName;
            country = CountryName;
        }
    }
}
