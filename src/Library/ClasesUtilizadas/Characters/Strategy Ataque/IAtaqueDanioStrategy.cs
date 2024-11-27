/// <summary>
/// Interfaz que define la estrategia para calcular el número asociado al daño de un ataque.
/// </summary>
public interface IAtaqueDanioStrategy
{
    /// <summary>
    /// Obtiene el número asociado al cálculo del daño de un ataque.
    /// </summary>
    /// <returns>Un número entero que representa el resultado del ataque.</returns>
    public int GetNumero();
}