/// <summary>
/// Define una interfaz para estrategias de precisión que determinan el número de un ataque o acción.
/// </summary>
public interface IStrategyPresicion
{
    /// <summary>
    /// Obtiene el número asociado con la estrategia de precisión.
    /// </summary>
    /// <returns>Un número entero que representa el valor de precisión.</returns>
    public int GetNumber();
}