// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Text.Json;
using TapApp;

Beer beer = new Beer();

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://random-data-api.com/");
client.DefaultRequestHeaders.Clear();

HttpResponseMessage response = await client.
    GetAsync("api/v2/beers");
if (response.IsSuccessStatusCode)
{
    var result = response.Content.ReadAsStringAsync().Result;
    beer = JsonSerializer.Deserialize<Beer>(result);
}

    Type type = beer.GetType();
    PropertyInfo[] properties = type.GetProperties();

    foreach (PropertyInfo property in properties)
    {
        string propertyName = property.Name;
        object propertyValue = property.GetValue(beer);

        Console.WriteLine($"{propertyName}: {propertyValue}");
    }


