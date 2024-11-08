using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate;

public class SuperPocion : Item
{
    public SuperPocion(int cantidad) : base(cantidad) { }

    public override void AplicarEfecto(Pokemon pokemon)
    {
        pokemon.Curar(70);
        Console.WriteLine($"{pokemon.GetName()} recuperó 70 puntos de vida.");
    }
}

    
