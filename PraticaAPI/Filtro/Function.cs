namespace PraticaAPI.Filtro;
public class Function
{
    /// <summary>
    /// Chave disponibilizada para uso gratuito da API
    /// </summary>
    public static string chave() => "f24e3b3b88dc280e84e540c4500113d5";

    /// <summary>
    /// Realiza a conversao de temperatura Kelvin para Celcius.
    /// </summary>
    /// <param name="KelvinTemp">Temperatura em Escala Kelvin</param>
    /// <returns>Temperatura em Escala Celcius</returns>
    public static double KelvinToCelcius(double KelvinTemp) => Math.Round((KelvinTemp - 273.15), 2);

    /// <summary>
    /// Realiza a conversao de M/S para Km/H
    /// </summary>
    /// <param name="Speed">Velocidade em Metros por Segundo</param>
    /// <returns>Velocidade em Kilometro por Hora</returns>
    public static double MsToKm(double Speed) => Math.Round((Speed * 3.6), 2);
}
