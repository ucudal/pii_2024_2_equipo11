namespace Library.Tipos.Paralisis_Strategy;
//Cumple con SRP ya que solo tiene la responsabilidad de setear el valor para que el pokemon ataque estando paralizado.
//Cumple con Expert ya que tiene la información necesario para devolver dicho valor

/// <summary>
/// Representa una estrategia para manejar la parálisis donde el Pokémon no puede atacar.
/// </summary>
public class EfectoParalisisFalse : IEfectoParalisisStrategy
{
    /// <summary>
    /// Devuelve un valor booleano indicando que el Pokémon no puede atacar debido a la parálisis.
    /// </summary>
    /// <returns><c>false</c>, indicando que el Pokémon no puede atacar.</returns>
    public bool GetValor()
    {
        return false;
    }
}