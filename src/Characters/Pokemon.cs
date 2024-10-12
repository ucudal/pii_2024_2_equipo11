using Library.Combate;
using Library.Tipos;
using Ucu.Poo.Pokemon;

namespace DefaultNamespace;

public class Pokemon
{
    private string name;
    private List<IMovimiento> lista_movimientos = new List<IMovimiento>();
    private List<Tipo> lista_tipos = new List<Tipo>();
    private int vida_actual;
    private int vida_total;
    private int defensa;
    private bool is_alive;

    public Pokemon(string nombre, List<IMovimiento> movimientos, List<Tipo> tipos, int vida, int defensa)
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
        return this.lista_tipos;
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
    public List<Tipo> GetListaTipos()
    {
        return lista_tipos;
    }
    public int GetVidaTotal()
    {
        return vida_total;
    }
    public int GetVidaActual()
    {
        return vida_actual;
    }


    public void UsarMovimiento(IMovimiento movimiento)
    {
        if (is_alive)
        {
            foreach (IMovimiento accion in lista_movimientos)
            {
                if (accion == movimiento)
                {
                    accion.Usado_Anteriormente(true);
                }
                else
                {
                    accion.Usado_Anteriormente(false);
                }
            }

            if (movimiento is IMovimiento_Defensa defensamovimiento)
            {
                defensa += defensamovimiento.GetDefensa();
            }
            
        }
    }

    public void RecibirAtaque(IMovimiento_Ataque movimiento)
    {
            if (defensa > movimiento.GetAtaque())
            {
                Tipo tipoAtaque = movimiento.GetTipo();
                double efectividadTipo = 1.0;
                foreach (Tipo tipoDefensor in GetTipos())
                {
                    efectividadTipo *= tipoAtaque.DarEfectividad(tipoDefensor);
                }
                int danio = (int)(movimiento.GetAtaque() * efectividadTipo);
                defensa = -danio;
            }
            if (defensa + vida_actual >= movimiento.GetAtaque())
            {
                defensa = 0;
                Tipo tipoAtaque = movimiento.GetTipo();
                double efectividadTipo = 1.0;

                foreach (Tipo tipoDefensor in GetTipos())
                {
                    efectividadTipo *= tipoAtaque.DarEfectividad(tipoDefensor);
                }

                int danio = (int)(movimiento.GetAtaque() * efectividadTipo)-defensa;

                vida_actual -= danio;
            }
            else
            {
                defensa = 0;
                is_alive = false;
                vida_actual = 0;
            }
    }
    
}