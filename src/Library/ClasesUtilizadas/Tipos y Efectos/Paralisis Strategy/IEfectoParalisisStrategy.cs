namespace Library.Tipos.Paralisis_Strategy;
/// <summary>
/// Define una interfaz para estrategias de manejo de parálisis que determinan si un Pokémon puede atacar.
/// </summary>
public interface IEfectoParalisisStrategy
{
    /// <summary>
    /// Obtiene un valor booleano que indica si el Pokémon puede atacar mientras está paralizado.
    /// </summary>
    /// <returns><c>true</c> si el Pokémon puede atacar; de lo contrario, <c>false</c>.</returns>
    public bool GetValor();
}