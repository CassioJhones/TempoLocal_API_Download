namespace PraticaAPI.Util;
public class Functions
{
    /// <summary>
    /// Chave disponibilizada para uso gratuito da API
    /// </summary>
    public static string ApiKey() => "INSIRA SUA CHAVE AQUI";
    /// <summary>
    /// Realiza a conversao de temperatura Kelvin para Celcius.
    /// </summary>
    /// <param name="KelvinTemp">Temperatura em Escala Kelvin</param>
    /// <returns>Temperatura em Escala Celcius</returns>
    public static double KelvinToCelcius(double KelvinTemp) => Math.Round(KelvinTemp - 273.15, 2);
    /// <summary>
    /// Realiza a conversao de M/S para Km/H
    /// </summary>
    /// <param name="Speed">Velocidade em Metros por Segundo</param>
    /// <returns>Velocidade em Kilometro por Hora</returns>
    public static double MsToKm(double Speed) => Math.Round(Speed * 3.6, 2);
    public static void MostraVermelho(string palavra)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{palavra}°C");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void MostraAzul(string palavra)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{palavra}°C");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void MostraAmarelo(string palavra)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{palavra}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}



