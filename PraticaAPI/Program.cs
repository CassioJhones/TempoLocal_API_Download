using PraticaAPI.Filtro;
using PraticaAPI.Modelos;
using System.Text.Json;

Console.Title = $"Tempo Local";
while (true)
{
    Console.WriteLine("\nInsira uma cidade: ");

    string? city = Console.ReadLine();
    using HttpClient chamada = new();
    string endPoint = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={Functions.Chave()}";
    try
    {
        string resposta = await chamada.GetStringAsync(endPoint);
        Root? cidade = JsonSerializer.Deserialize<Root>(resposta);
        double tempCelcius = Functions.KelvinToCelcius(cidade!.Main.Temp);
        double veloKM = Functions.MsToKm(cidade.Wind.Speed);
        double tempSensacao = Functions.KelvinToCelcius(cidade!.Main.FeelsLike);
        int umidade = cidade!.Main.Humidity;
        Weather listaTempo = cidade.Weather[0];
        string nome = cidade.Name.ToString();
        string? CeuAtual = listaTempo.Main;
        string? OlhaCeu = listaTempo.Description;


        Console.Title = $"Tempo Local - {cidade.Name}";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n\t{cidade.Name}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Os ventos estão há {veloKM} Km/H");
        Console.WriteLine($"Temperatura de {tempCelcius}°C\nSensação de {tempSensacao}°C");
        Console.WriteLine($"Umidade do ar: {umidade}%");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"     Previsão ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"Temperatura Maxima: {Functions.KelvinToCelcius(cidade.Main.TempMax)}°C");
        Console.Write($"Temperatura Minima: {Functions.KelvinToCelcius(cidade.Main.TempMin)}°C");

        if (CeuAtual.Contains("overcast")) CeuAtual = "Nublado";
        if (CeuAtual.Contains("Clouds")) CeuAtual = "Nuvens";
        if (CeuAtual.Contains("Rain")) CeuAtual = "Chuva";
        if (CeuAtual.Contains("Clear")) CeuAtual = "Tempo Limpo";

        Functions.MostraRed(tempCelcius.ToString());
        //overcast clouds
        ;
        ConsoleKeyInfo unused = Console.ReadKey();
        Console.Clear();
    }

    catch (HttpRequestException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Nome Nao Encontrado");
        Console.ForegroundColor = ConsoleColor.White;

    }
}
/*

    //FAZER ESSA DEPOIS
   
        string json = await harrypotter.GetStringAsync("https://hp-api.onrender.com/api/characters/house/gryffindor");
        Console.WriteLine(json);

}
*/

