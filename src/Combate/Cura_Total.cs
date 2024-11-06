using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate;
public class Cura_Total : Item
{
    public Cura_Total(int cantidad) : base( cantidad) { }

    public override void AplicarEfecto(Pokemon pokemon)
    {
        pokemon.EliminarEfectoActual();
        Console.WriteLine($"{pokemon.GetName()} ha sido curado de todos los efectos de estado.");
    }
}
