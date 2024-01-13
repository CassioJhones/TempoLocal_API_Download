using PraticaAPI.Filtro;
using PraticaAPI.Modelos;
using System.Text.Json;

Console.Title = "Tempo Local";
while (true)
{
    Console.WriteLine("\nInsira uma cidade: ");
    using HttpClient chamada = new();
    string endPoint = $"https://api.openweathermap.org/data/2.5/weather?q={Console.ReadLine()}&appid={Functions.Chave()}";
    try
    {
        string resposta = await chamada.GetStringAsync(endPoint);
        Root? cidade = JsonSerializer.Deserialize<Root>(resposta);
        double tempCelcius = Functions.KelvinToCelcius(cidade!.Main.Temp);
        double veloKM = Functions.MsToKm(cidade.Wind.Speed);
        double tempSensacao = Functions.KelvinToCelcius(cidade!.Main.FeelsLike);
        int umidade = cidade!.Main.Humidity;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n\t{cidade.Name}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Os ventos estão há {veloKM} Km/H");
        Console.WriteLine($"Temperatura de {tempCelcius} °C com Sensação de {tempSensacao}");
        Console.WriteLine($"Umidade do ar: {umidade}%");
        Console.WriteLine($"Geolocalização Lat: {cidade.Coord.Lat} Lon: {cidade.Coord.Lon}");

        var listaTempo = cidade.Weather[0];


        //overcast clouds

        Console.ReadKey();
        Console.Clear(); ;
    }

    catch (HttpRequestException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Nome Nao Encontrado");
        Console.ForegroundColor = ConsoleColor.White;

    }
}
/*

    //FAZER ESSA DEPOIS
   
        string json = await harrypotter.GetStringAsync("https://hp-api.onrender.com/api/characters/house/gryffindor");
        Console.WriteLine(json);

}
*/

