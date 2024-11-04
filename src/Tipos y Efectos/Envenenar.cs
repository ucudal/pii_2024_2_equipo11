using DefaultNamespace;

namespace Library.Tipos;

public class Envenenar:Efecto
{
    private Pokemon pokemon;
    public Envenenar()
    {
        
    }

    public override void HacerEfecto()
    {
        Console.WriteLine(pokemon.GetName()," ha sido envenenado");
        pokemon.RecibirDanioDeEfecto(5);
    }
}