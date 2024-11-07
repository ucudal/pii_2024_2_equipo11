using DefaultNamespace;

namespace Library.Tipos;

public class Envenenar:Efecto
{
    public Envenenar()
    {
    }

    public override void HacerEfecto(Pokemon pokemon)
    {
        Console.WriteLine(pokemon.GetName()," Está envenenado");
        pokemon.RecibirDanioDeEfecto(5);
    }
}