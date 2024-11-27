/// Cumple con SRP ya que solo tiene la responsabilidad de establecer un número necesario para que el ataque acierte.
/// Cumple con Expert ya que tiene la información necesaria para devolver dicho valor.

/// <summary>
/// Representa una estrategia de precisión donde el ataque acierta.
/// </summary>

public class StrategyPreciso: IStrategyPresicion
{
    /// <summary>
    /// Obtiene el número asociado con esta estrategia de precisión, que asegura que el ataque acierte.
    /// </summary>
    /// <returns>Un número que representa la precisión del ataque, en este caso, siempre 1.</returns>
    public int GetNumber()
    {
        return 1;
    }
}