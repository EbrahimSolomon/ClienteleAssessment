using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

string accessKey = "26ae0631804728cc290b0a00d3091677";
using HttpClient client = new();

while (true)
{
    Console.Write("\nEnter city name(s) (comma-separated, or type 'exit' to quit): ");
    string? input = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(input) || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("👋 Exiting weather app. Stay safe!");
        break;
    }

    var cities = input.Split(',').Select(c => c.Trim()).Where(c => !string.IsNullOrWhiteSpace(c)).ToList();

    foreach (var city in cities)
    {
        string url = $"http://api.weatherstack.com/current?access_key={accessKey}&query={city}&units=m";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var weather = await response.Content.ReadFromJsonAsync<WeatherStackResponse>(options);

            if (weather?.Location?.Name != null && weather.Current != null)
            {
                Console.WriteLine($"\n📍 Weather in {weather.Location.Name}, {weather.Location.Country}:");
                Console.WriteLine($"🌡️ Temperature: {weather.Current.Temperature}°C");
                Console.WriteLine($"💨 Wind Speed: {weather.Current.WindSpeed} km/h");
                Console.WriteLine($"💧 Humidity: {weather.Current.Humidity}%");

                var descriptions = weather.Current.WeatherDescriptions;
                Console.WriteLine($"🌤️ Condition: {string.Join(", ", descriptions ?? new List<string> { "N/A" })}");
            }
            else
            {
                Console.WriteLine($"\n❌ Could not retrieve data for: {city}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error fetching data for {city}: {ex.Message}");
        }
    }

    Console.Write("\n🔁 Would you like to check another city? (y/n): ");
    var choice = Console.ReadLine()?.Trim().ToLower();
    if (choice != "y" && choice != "yes")
    {
        Console.WriteLine("👋 Thanks for using Ebrahim's weather app!");
        break;
    }
}


// Models
public class WeatherStackResponse
{
    [JsonPropertyName("location")]
    public Location? Location { get; set; }

    [JsonPropertyName("current")]
    public CurrentWeather? Current { get; set; }
}

public class Location
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; }

    [JsonPropertyName("weather_descriptions")]
    public List<string>? WeatherDescriptions { get; set; }

    [JsonPropertyName("wind_speed")]
    public int WindSpeed { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
}
