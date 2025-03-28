# 🌤️ WeatherConsoleApp (.NET 8.0)

A simple and interactive .NET 8.0 console application that retrieves current weather data for one or more cities using the [Weatherstack API](https://weatherstack.com/).

---

## 🚀 Features

- ✅ Fetches real-time weather data for one or multiple cities.
- 🔁 Allows users to search for more cities or exit the application.
- 💧 Displays temperature, humidity, wind speed, and condition.
- 🧠 Handles null values and failed lookups gracefully.

---

## 🛠️ Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download)
- Internet connection
- A [Weatherstack](https://weatherstack.com/) API key (Free tier works!)

---

## 🔧 Setup Instructions

1. **Clone the repository** or copy the code files.
2. **Install .NET 8.0 SDK** if not already installed.
3. Replace the placeholder API key inside `Program.cs`:

   ```csharp
   string accessKey = "YOUR_ACCESS_KEY";

   Get your free API key here: weatherstack.com

   Run the application:

bash
Copy
Edit
dotnet run
💻 Usage
When the app starts, enter one or more city names separated by commas:

pgsql
Copy
Edit
Enter city name(s) (comma-separated, or type 'exit' to quit): London, Paris
You’ll see output like:

yaml
Copy
Edit
📍 Weather in London, United Kingdom:
🌡️ Temperature: 14°C
💨 Wind Speed: 15 km/h
💧 Humidity: 82%
🌤️ Condition: Partly Cloudy
Then choose whether to continue or exit:

pgsql
Copy
Edit
🔁 Would you like to check another city? (y/n):
✅ Example
yaml
Copy
Edit
Enter city name(s) (comma-separated, or type 'exit' to quit): Cape Town, Tokyo

📍 Weather in Cape Town, South Africa:
🌡️ Temperature: 22°C
💨 Wind Speed: 12 km/h
💧 Humidity: 65%
🌤️ Condition: Clear

📍 Weather in Tokyo, Japan:
🌡️ Temperature: 17°C
💨 Wind Speed: 20 km/h
💧 Humidity: 73%
🌤️ Condition: Light Rain
📁 File Structure
less
Copy
Edit
WeatherConsoleApp/
│
├── Program.cs        // Main application logic


📜 License
This project is open-source and free.

🙋‍♂️ Author
Ebrahim Solomon