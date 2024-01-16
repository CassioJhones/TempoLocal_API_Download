using PraticaAPI.Util;
using PraticaAPI.Modelos;
using System.Text.Json;

Console.Title = $"Tempo Local";
while (true)
{
    Console.WriteLine("Digite uma cidade");
    string? city = Console.ReadLine().ToUpperInvariant();
    using HttpClient chamada = new();
    string endPoint = $"https://api.openweathermap.org/data/2.5/weather?q={city}&lang=pt_br&appid={Functions.ApiKey()}&units=metric";

    try
    {
        string resposta = await chamada.GetStringAsync(endPoint);
        Root? cidade = JsonSerializer.Deserialize<Root>(resposta);
        double tempCelcius = cidade!.Main.Temp;
        double veloKM = cidade.Wind.Speed;
        double tempSensacao = cidade!.Main.FeelsLike;
        double tempMax = cidade!.Main.TempMax;
        double tempMin = cidade!.Main.TempMin;
        int umidade = cidade!.Main.Humidity;
        string nome = cidade.Name.ToString();
        string? OlhaCeu = cidade.Weather[0].Description.ToUpperInvariant();

        MostraNaTela(cidade, veloKM, umidade, OlhaCeu);
    }

    catch (HttpRequestException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Local Não Encontrado");
        Console.Beep(400, 320);
        Console.ForegroundColor = ConsoleColor.White;
        FecharApp();
        Console.Clear();

    }
}

static void MostraNaTela(Root? cidade, double veloKM, int umidade, string OlhaCeu)
{
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

    Console.Write($"Temperatura Máxima: ");
    Functions.MostraVermelho(cidade!.Main.TempMax.ToString());
    Console.Write($"\nTemperatura Mínima: ");
    Functions.MostraAzul(cidade!.Main.TempMin.ToString());

    Console.SetCursorPosition(19, 7);
    Functions.MostraAmarelo(OlhaCeu);
    FecharApp();

    Console.Clear();
}

static void FecharApp()
{
    Console.SetCursorPosition(3, 10);

    Console.WriteLine($"\nPressione Insert para fechar");
    ConsoleKeyInfo tecla = Console.ReadKey();

    if (tecla.Key == ConsoleKey.Insert || tecla.KeyChar == '\0')
        Environment.Exit(0);
}