//Cumple con SRP ya que solo tiene la responsabilidad de setear un numero en donde no importa si el ataque acierta  o no
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor

/// <summary>
/// Representa una estrategia de precisión aleatoria para determinar si el ataque acierta.
/// </summary>

public class StrategyPrecisoRandom : IStrategyPresicion
{
    /// <summary>
    /// Obtiene un número aleatorio entre 1 y 100 que representa la precisión del ataque.
    /// </summary>
    /// <returns>Un número aleatorio entre 1 y 100 que indica la probabilidad de que el ataque acierte.</returns>
    public int GetNumber()
    {
        Random random = new Random();
        return random.Next(1, 101);
    }
}