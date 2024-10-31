using Library.Combate;
using Library.Tipos;
using Ucu.Poo.Pokemon;

namespace DefaultNamespace;

public class Pokemon
{
    private string name;
    private List<IMovimiento> listamovimientos;
    private List<Tipo> listatipos;
    private int vidaactual;
    private int vidatotal;
    private int defensa;
    private bool is_alive;

    public Pokemon(string nombre, List<IMovimiento> movimientos, List<Tipo> tipos, int vida, int defensa)
    {
        name = nombre;
        listamovimientos = movimientos;
        listatipos = tipos;
        vidaactual = vida;
        vidatotal = vida;
        is_alive = true;
        this.defensa = defensa;
    }

    public List<Tipo> GetTipos()
    {
        return listatipos;
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
        return listamovimientos;
    }

    public int GetVidaTotal()
    {
        return vidatotal;
    }

    public int GetVidaActual()
    {
        return vidaactual;
    }

    // Método para usar un movimiento, incluyendo los de defensa
    public void UsarMovimiento(IMovimiento movimiento)
    {
        if (is_alive)
        {
            foreach (IMovimiento accion in listamovimientos)
            {
                if (accion.GetName() == movimiento.GetName())
                {
                    accion.UsadoAnteriormente(true);
                }
                else
                {
                    accion.UsadoAnteriormente(false);
                }
            }

            if (movimiento is IMovimientoDefensa defensamovimiento)
            {
                defensa += defensamovimiento.GetDefensa();
            }
        }
    }
    
    public void RecibirAtaque(IMovimientoAtaque movimiento)
    {
        double efectividadTipo = 1.0;
        Tipo tipoAtaque = movimiento.GetTipo();

        foreach (Tipo tipoDefensor in listatipos)
        {
            efectividadTipo *= tipoAtaque.DarEfectividad(tipoDefensor);
        }

        int danio = (int)(movimiento.GetAtaque() * efectividadTipo);

        // Aplicar el daño a la defensa o vida o un poco y un poco
        if (defensa > danio)
        {
            defensa -= danio;
        }
        else
        {
            danio -= defensa; // Resta el daño restante a la vida
            defensa = 0;
            vidaactual -= danio;

            if (vidaactual <= 0)
            {
                is_alive = false;
                vidaactual = 0;
                Console.WriteLine($"El pokemon {name} se ha debilitado, por que no podrá combatir más");
            }
        }
    }
}
