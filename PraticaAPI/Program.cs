
using PraticaAPI.Filtro;
using PraticaAPI.Modelos;
using System.Text.Json;


using (HttpClient client = new())
{
    string city = "London";
    string link = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={Function.chave()}";
    try
    {
        //MOSTRAR PRO BRUNO E CASSIA
        string resposta = await client.GetStringAsync(link);
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
    //FAZER ESSA MERDA DEPOIS kkkkkkkkkkkk
    try
    {
        string json = await harrypotter.GetStringAsync("https://hp-api.onrender.com/api/characters/house/gryffindor");
        Console.WriteLine(json);

    } catch (Exception) { }

}
*/

