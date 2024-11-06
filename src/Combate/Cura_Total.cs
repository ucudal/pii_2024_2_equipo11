using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate;
public class Cura_Total : Item
{
    public Cura_Total(int cantidad) : base( cantidad) { }

    public override void AplicarEfecto(Pokemon pokemon)
    {
        if (pokemon.GetIsAlive())
        {
            //Acá iría la lógica de curar el Cambio de estado
            Console.WriteLine($"{pokemon.GetName()} ha sido curado de todos los efectos de estado.");
        }
        else
        {
            Console.WriteLine($"{pokemon.GetName()} no puede curar su cambio de estado porque está debilitado");
        }
    }
}
