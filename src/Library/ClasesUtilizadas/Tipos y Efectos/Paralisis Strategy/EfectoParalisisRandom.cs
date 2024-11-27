namespace Library.Tipos.Paralisis_Strategy;
//Cumple con SRP ya que solo tiene la responsabilidad de setear un valor en donde no importa si el pokemon ataca o no estando paralizado.
//Cumple con Expert ya que tiene la información necesario para devolver dicho valor

/// <summary>
/// Representa una estrategia para manejar la parálisis donde la posibilidad de que el Pokémon ataque se decide de forma aleatoria.
/// </summary>
public class EfectoParalisisRandom:IEfectoParalisisStrategy
{
    /// <summary>
    /// Devuelve un valor booleano indicando si el Pokémon puede atacar o no debido a la parálisis.
    /// La decisión se toma de forma aleatoria, con una probabilidad de 1 en 3 de permitir el ataque.
    /// </summary>
    /// <returns><c>true</c> si el Pokémon puede atacar; de lo contrario, <c>false</c>.</returns>
    public bool GetValor()
    { 
        Random random = new Random();
        int numero= random.Next(1, 4);
        if(numero == 1)
        {
            return true;
        }
        return false;
    }
}