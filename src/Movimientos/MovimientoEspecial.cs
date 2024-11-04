using Library.Tipos;

namespace Ucu.Poo.Pokemon;

public class MovimientoEspecial
{
    private string name { get; set; }
    private int ataque { get; set; }
    private Efecto efecto { get; set; }
    private Tipo tipo { get; set; }
    private int precision { get; set; }
    private bool usado_anteriormente { get; set; }

    //public void UsadoAnteriormente(bool){} QUE VA ACAAAA!!

    public bool GetUsadoAnteriormente()
    {
        return usado_anteriormente;
    }
}