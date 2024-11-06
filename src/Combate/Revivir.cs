using DefaultNamespace;
using Ucu.Poo.Pokemon;
namespace Library.Combate;

public class Revivir : Item
{
    public Revivir(int cantidad) : base(cantidad) { }

    public override void AplicarEfecto(Pokemon pokemon)
    {
        if (pokemon.GetIsAlive() == false)
        {
            double vidaActual = pokemon.GetVidaActual();
            double vidaTotal = pokemon.GetVidaTotal();
            vidaActual = vidaTotal / 2;
            Console.WriteLine($"{pokemon.GetName()} ha revivido con la mitad de su HP.");
        }
        else
        {
            Console.WriteLine($"{pokemon.GetName()} no está debilitado, no se puede usar Revivir.");
        }
    }
}


