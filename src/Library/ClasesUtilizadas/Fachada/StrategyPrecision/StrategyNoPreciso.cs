namespace Library.Combate;
//Cumple con SRP ya que solo tiene la responsabilidad de setear un numero necesario para que el ataque no acierte
//Cumple con Expert ya que tiene la información necesaria para devolver dicho valor

/// <summary>
/// Representa una estrategia de precisión donde el ataque no acierta.
/// </summary>
public class StrategyNoPreciso: IStrategyPresicion
{
    /// <summary>
    /// Obtiene el número asociado con esta estrategia de precisión, que asegura que el ataque no acierte.
    /// </summary>
    /// <returns>Un número que representa la precisión del ataque, en este caso, siempre 100.</returns>
    public int GetNumber()
    {
        return 100;
    }
}
