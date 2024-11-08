﻿using Library.Combate;
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
    private Efecto estado;
    private bool puedeatacar;
    

    public Pokemon(string nombre, List<IMovimiento> movimientos, List<Tipo> tipos, double vida, double defensa)
    {
        name = nombre;
        lista_movimientos = movimientos;
        lista_tipos = tipos;
        vida_actual = vida;
        vida_total = vida;
        is_alive = true;
        this.defensa = defensa;
        puedeatacar = true;
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

                if (accion.GetName() == movimiento.GetName() && movimiento is IMovimientoAtaque ataque)
                {
                    
                }
                if (movimiento is IMovimientoDefensa defensamovimiento)
                {
                    defensa += defensamovimiento.GetDefensa();
                    Console.WriteLine($"{GetName()} ha usado su {movimiento.GetName()} para subir su defensa {defensamovimiento.GetDefensa()} puntos");
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

        double danio = (movimiento.GetAtaque() * efectividadTipo);
        int numero = new Random().Next(10);
        Console.WriteLine(numero);
        if (numero == 0)
        {
            danio *= 1.2;
            Console.WriteLine($"Ha sido un ataque crítico");
        }
        
        // Aplicar el daño a la defensa o vida o un poco y un poco
        if (defensa > danio)
        {
            defensa -= danio;
            Console.WriteLine($"{GetName()} ha perdido {danio} de defensa, quedandose a {defensa} de defensa y {vida_actual} de vida");
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
                return;
            }
            Console.WriteLine($"{GetName()} ha perdido toda su defensa y se ha quedado con {vida_actual}");
        }
        if (movimiento is IMovimientoEspecial movimientoEspecial)
        {
            AgregarEfecto(movimientoEspecial.GetEfecto());
        }
    }

    public void RecibirDanioDeEfecto(double numero)
    {
        double porcentaje = (this.vida_actual * 100)/numero;
        this.vida_actual -= porcentaje;
    }

    public void SetPuedeAtacar(bool valor) //Funciona para cambiar el valor dentro de los efectos de paralisis y de dormir
    {
        puedeatacar = valor; 
    }

    public void AgregarEfecto(Efecto efecto)
    {
        if (estado == null)
        {
            estado = Efecto.CrearCopia(efecto.GetType()); // Usa el tipo del efecto para crear una nueva instancia
            Console.WriteLine($"{GetName()} caído bajo el efecto {efecto.GetType().Name}");
        }
    }
    public void EliminarEfectoActual()
    {
        estado = null;
        // Acá iría el método para eliminar el cambio de estado del pokemon
    }

    public Efecto GetEfecto()
    {
        return estado;
    }
    public void Curar(int vidacurada)
    {
        this.vida_actual += vidacurada;
        if (vida_actual > vida_total)
        {
            vida_actual = vida_total;
        }
    }

    public void Revivir()
    {
        this.vida_actual = vida_total/2;
    }

    public bool GetPuedeAtacar()
    {
        return puedeatacar;
    }

    public double GetDefensa()
    {
        return this.defensa;
    }
    
}