using PraticaAPI.Filtro;
using PraticaAPI.Modelos;
using System.Text.Json;

using (HttpClient chamada = new())
{
    string city = "London";
    string endPoint = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={Function.chave()}";
    try
    {
        string resposta = await chamada.GetStringAsync(endPoint);
        Root? cidade = JsonSerializer.Deserialize<Root>(resposta);
        double tempCelcius = Function.KelvinToCelcius(cidade!.Main.Temp);
        double veloKM = Function.MsToKm(cidade.Wind.Speed);

        Console.WriteLine($"Bem vindo a {cidade.Name}");
        Console.WriteLine($"Os ventos estão há {veloKM} Km/H");
        Console.WriteLine($"Temperatura de {tempCelcius} °C");
        Console.WriteLine($"Geolocalização {cidade.Coord.Lat} {cidade.Coord.Lon}");
    }

    catch (HttpRequestException)
    {
        Console.WriteLine("Nome Nao Encontrado");
    }

}
/*
using (HttpClient harrypotter = new())
{
    //FAZER ESSA DEPOIS
    try
    {
        string json = await harrypotter.GetStringAsync("https://hp-api.onrender.com/api/characters/house/gryffindor");
        Console.WriteLine(json);

    } catch (Exception) { }

}
*/

