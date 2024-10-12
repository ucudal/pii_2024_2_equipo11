using Library.Tipos;

namespace Ucu.Poo.Pokemon;

public class MovimientoDeAtaque: IMovimiento_Ataque
{
    private string name { get; set; }
    private int ataque { get; set; }
    private Tipo tipo { get; set; }
    private bool usado_anteriormente { get; set; }
    private bool es_especial { get; set; }

    public MovimientoDeAtaque(string name, int ataque, Tipo tipo, bool es_especial)
    {
        this.name = name;
        this.ataque = ataque;
        this.tipo = tipo;
        usado_anteriormente = false;
        this.es_especial = es_especial;
    }
    public int GetAtaque()
    {
        return ataque;
    }

    public string GetName()
    {
        return name;
    }

    public bool GetesEspecial()
    {
        return es_especial;
    }

    public Tipo GetTipo()
    {
        return tipo;
    }

    public void Usado_Anteriormente(bool usado)
    {
        usado_anteriormente = usado;
    }

    public bool GetUsado_Anteriormente()
    {
        return usado_anteriormente;
    }
}