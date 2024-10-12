using Library.Tipos;

namespace Ucu.Poo.Pokemon;

public class MovimientoDeAtaqueDefensa: IMovimiento_Defensa, IMovimiento_Ataque
{
    private string name { get; set; }
    private int ataque { get; set; }
    private int defensa { get; set; }
    private Tipo tipo { get; set; }
    private bool usado_anteriormente { get; set; }
    private bool es_especial { get; set; }

    public MovimientoDeAtaqueDefensa(string name, int ataque,int defensa, Tipo tipo, bool es_especial)
    {
        this.name = name;
        this.ataque = ataque;
        this.defensa = defensa;
        this.tipo = tipo;
        this.usado_anteriormente = false;;
        this.es_especial = es_especial;
    }
    public int GetAtaque()
    {
        return this.ataque;
    }

    public int GetDefensa()
    {
        return this.defensa;
    }

    public string GetName()
    {
        return this.name;
    }

    public bool GetesEspecial()
    {
        return this.es_especial;
    }

    public Tipo GetTipo()
    {
        return this.tipo;
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