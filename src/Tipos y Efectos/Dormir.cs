using DefaultNamespace;

namespace Library.Tipos;

public class Dormir:Efecto
{
    public Dormir()
    {
        
    }
    private int Turnos;
    private Random random = new Random();
    
    public void CalcularTurnos()
    {
        this.Turnos = random.Next(1, 5);
    }
    public override void HacerEfecto(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.GetName()} dormira durante {Turnos} turnos");
        this.Turnos -= 1;
    }
}