using PraticaAPI.Filtro;
using PraticaAPI.Modelos;
using System.Text.Json;


Console.Title = $"Tempo Local";
while (true)
{
    Console.WriteLine("Digite uma cidade");
    string? city = Console.ReadLine().ToUpper();
    using HttpClient chamada = new();
    string endPoint = $"https://api.openweathermap.org/data/2.5/weather?q={city}&lang=pt_br&appid={Functions.ApiKey()}&units=metric";
    try
    {
        string resposta = await chamada.GetStringAsync(endPoint);
        Root? cidade = JsonSerializer.Deserialize<Root>(resposta);
        double tempCelcius = Functions.KelvinToCelcius(cidade!.Main.Temp);
        double veloKM = Functions.MsToKm(cidade.Wind.Speed);
        double tempSensacao = Functions.KelvinToCelcius(cidade!.Main.FeelsLike);
        double tempMax = Functions.KelvinToCelcius(cidade!.Main.TempMax);
        double tempMin = Functions.KelvinToCelcius(cidade!.Main.TempMin);
        int umidade = cidade!.Main.Humidity;
        Weather listaTempo = cidade.Weather[0];
        string nome = cidade.Name.ToString();
        string? CeuAtual = listaTempo.Main;
        string? OlhaCeu = listaTempo.Description.ToUpperInvariant();
        int? tempo = cidade.Timezone;


        Console.Title = $"Tempo Local - {cidade.Name}";
        Console.Clear();
        Console.Beep(1020, 220);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n\t{cidade.Name}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Os ventos estão há {veloKM} Km/H");
        Console.WriteLine($"Temperatura de {cidade!.Main.Temp}°C\nSensação de {cidade!.Main.FeelsLike}°C");
        Console.WriteLine($"Umidade do ar: {umidade}%");
        

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n\tPrevisão ");
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write($"Temperatura Maxima: ");
        Functions.MostraVermelho(cidade!.Main.TempMax.ToString());
        Console.Write($"\nTemperatura Minima: ");
        Functions.MostraAzul(cidade!.Main.TempMin.ToString());
        int tt = Console.BufferHeight;
        int yy = Console.BufferWidth;

        Console.SetCursorPosition(19, 8);


        Functions.MostraAmarelo(OlhaCeu);

        ConsoleKeyInfo unused = Console.ReadKey();
        Console.Clear();
    }

    catch (HttpRequestException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Nome Nao Encontrado");
        Console.Beep(400, 320);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
/*FAZER ESSA DEPOIS

        string json = await harrypotter.GetStringAsync("https://hp-api.onrender.com/api/characters/house/gryffindor");
        Console.WriteLine(json);
}
*/

