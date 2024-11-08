using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate;

public class Super_Pocion : Item
{
    public Super_Pocion(int cantidad) : base(cantidad) { }

    public override void AplicarEfecto(Pokemon pokemon)
    {
        pokemon.Curar(70);
        Console.WriteLine($"{pokemon.GetName()} recuperó 70 puntos de vida.");
    }
}

    
