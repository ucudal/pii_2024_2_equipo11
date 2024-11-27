using Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;
//Cumple con SRP ya que solo tiene la responsabilidad de setear el numero necesario para que el ataque no haga crítico
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor

/// <summary>
/// Representa una estrategia para determinar un ataque que no sea crítico.
/// </summary>
public class AtaqueNoCritico : IAtaqueDanioStrategy
{
    /// <summary>
    /// Obtiene un número fijo que representa un ataque no crítico.
    /// </summary>
    /// <returns>El número 1, indicando que el ataque no es crítico.</returns>
    public int GetNumero()
    {
        return 1; // Siempre devuelve no crítico.
    }
}
