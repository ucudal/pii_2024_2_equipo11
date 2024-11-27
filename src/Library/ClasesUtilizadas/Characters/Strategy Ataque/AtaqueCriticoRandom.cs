using Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;
//Cumple con SRP ya que solo tiene la responsabilidad de setear un numero necesario en el que no importa si da crítico o no
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor

/// <summary>
/// Representa una estrategia para determinar un ataque aleatorio.
/// </summary>
public class AtaqueRandom : IAtaqueDanioStrategy
{
    private static readonly Random random = new Random(); // Instancia compartida

    /// <summary>
    /// Obtiene un número aleatorio para determinar el daño de un ataque.
    /// </summary>
    /// <returns>Un número aleatorio entre 0 y 9, indicando el daño del ataque.</returns>
    public int GetNumero()
    {
        return random.Next(10); // Genera un número entre 0 y 9.
    }
}
