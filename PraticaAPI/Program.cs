using PraticaAPI.Filtro;
using PraticaAPI.Modelos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

Console.Title = "Tempo Local";
while (true)
{
    Console.WriteLine("\nInsira uma cidade: ");
    using (HttpClient chamada = new())
    {
        string endPoint = $"https://api.openweathermap.org/data/2.5/weather?q={Console.ReadLine()}&appid={Function.Chave()}";
        try
        {
            string resposta = await chamada.GetStringAsync(endPoint);
            Root? cidade = JsonSerializer.Deserialize<Root>(resposta);
            double tempCelcius = Function.KelvinToCelcius(cidade!.Main.Temp);
            double veloKM = Function.MsToKm(cidade.Wind.Speed);

            Console.WriteLine($"\n{cidade.Name} com pressão atmosferica de {cidade.Main.Pressure / 1000}bar");
            Console.WriteLine($"Os ventos estão há {veloKM} Km/H");
            Console.WriteLine($"Temperatura de {tempCelcius} °C");
            Console.WriteLine($"Geolocalização {cidade.Coord.Lat} {cidade.Coord.Lon}");

            Console.ReadKey();
            Console.Clear();
        }

        catch (HttpRequestException)
        {
            Console.WriteLine("Nome Nao Encontrado");
        }

    }
}
/*

    //FAZER ESSA DEPOIS
   
        string json = await harrypotter.GetStringAsync("https://hp-api.onrender.com/api/characters/house/gryffindor");
        Console.WriteLine(json);

}
*/

