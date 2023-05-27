var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:5000");

app.MapGet("/", () => "Hello World!");

app.MapGet("/{countryName}/{cityName}/weather", GetWeatherByCity);

app.Run();


Weather GetWeatherByCity(string cityName, string countryName)
{
    app.Logger.LogInformation($"Weather requested for {cityName}, {countryName}.");
    var weather = new Weather(cityName, countryName);
    return weather;
}

public record Weather
{
    public string City { get; set; }

    public Weather(string city, string country)
    {
        this.Country = country;
        City = city;
        Conditions = "Cloudy";
        // Temperature here is in celsius degrees, hence the 0-40 range.
        Temperature = new Random().Next(0,40).ToString();
    }

    public string Conditions { get; set; }
    public string Temperature { get; set; }
    /// <summary>
    /// The country
    /// <summary>
    public string Country { get; set; }
}