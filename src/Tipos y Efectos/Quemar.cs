using DefaultNamespace;

namespace Library.Tipos;

public class Quemar:Efecto
{
    private Pokemon pokemon;
    public Quemar()
    {
        
    }

    public override void HacerEfecto()
    {
        Console.WriteLine(pokemon.GetName()," ha sido Quemado");
        pokemon.RecibirDanioDeEfecto(10);
    }
}