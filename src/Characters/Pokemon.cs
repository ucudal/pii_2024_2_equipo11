using Library.Combate;
using Library.Tipos;
using Ucu.Poo.Pokemon;

namespace DefaultNamespace;

public class Pokemon
{
    private string name;
    private List<IMovimiento> lista_movimientos;
    private List<Tipo> lista_tipos;
    private double vida_actual;
    private double vida_total;
    private double defensa;
    private bool is_alive;

    public Pokemon(string nombre, List<IMovimiento> movimientos, List<Tipo> tipos, double vida, double defensa)
    {
        name = nombre;
        lista_movimientos = movimientos;
        lista_tipos = tipos;
        vida_actual = vida;
        vida_total = vida;
        is_alive = true;
        this.defensa = defensa;
    }

    public List<Tipo> GetTipos()
    {
        return lista_tipos;
    }
    
    public bool GetIsAlive()
    {
        return is_alive;
    }

    public string GetName()
    {
        return name;
    }
    
    public List<IMovimiento> GetListaMovimientos()
    {
        return lista_movimientos;
    }

    public double GetVidaTotal()
    {
        return vida_total;
    }

    public double GetVidaActual()
    {
        return vida_actual;
    }

    // Método para usar un movimiento, incluyendo los de defensa
    public void UsarMovimiento(IMovimiento movimiento)
    {
        if (is_alive)
        {
            foreach (IMovimiento accion in lista_movimientos)
            {
                if (accion is MovimientoEspecial accionEspecial)
                {
                    if (accion.GetName() == movimiento.GetName())
                    {
                        accionEspecial.UsadoAnteriormente(true);
                    }
                    else
                    {
                        accionEspecial.UsadoAnteriormente(false);
                    }
                }
                if (movimiento is IMovimientoDefensa defensamovimiento)
                {
                    defensa += defensamovimiento.GetDefensa();
                }
            }

            
        }
    }
    
    public void RecibirAtaque(IMovimientoAtaque movimiento)
    {
        double efectividadTipo = 1.0;
        Tipo tipoAtaque = movimiento.GetTipo();

        foreach (Tipo tipoDefensor in lista_tipos)
        {
            efectividadTipo *= tipoAtaque.DarEfectividad(tipoDefensor);
        }

        double danio = (double)(movimiento.GetAtaque() * efectividadTipo);

        // Aplicar el daño a la defensa o vida o un poco y un poco
        if (defensa > danio)
        {
            defensa -= danio;
        }
        else
        {
            danio -= defensa; // Resta el daño restante a la vida
            defensa = 0;
            vida_actual -= danio;

            if (vida_actual <= 0)
            {
                is_alive = false;
                vida_actual = 0;
                Console.WriteLine($"El pokemon {name} se ha debilitado, por que no podrá combatir más");
            }
        }
    }

    public void RecibirDanioDeEfecto(double numero)
    {
        double porcentaje = (this.vida_actual * 100)/numero;
        this.vida_actual -= porcentaje;
    }
}
