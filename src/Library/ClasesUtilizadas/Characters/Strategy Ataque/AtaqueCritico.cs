namespace Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;
/// Cumple con SRP ya que solo tiene la responsabilidad de devolver un número necesario para que el ataque sea crítico.
/// Cumple con Expert ya que tiene la información necesaria para devolver dicho valor.
/// <summary>
/// Representa una estrategia para determinar si un ataque es crítico.
/// </summary>

public class AtaqueCritico : IAtaqueDanioStrategy
{
    /// <summary>
    /// Obtiene el número que indica si el ataque es crítico.
    /// </summary>
    /// <returns>El número 0, indicando que el ataque es crítico.</returns>
    public int GetNumero()
    {
        return 0;
    }
}
