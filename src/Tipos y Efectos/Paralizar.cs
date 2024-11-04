﻿using DefaultNamespace;

namespace Library.Tipos;

public class Paralizar:Efecto
{
    private Pokemon pokemon;
    private Random random = new Random();
    public Paralizar()
    {
        
    }
    public bool Jugar()
    {
       int numero= random.Next(1, 6);
       if (numero == 1)
       {
           return true;
       }

       return false;
    }

    public override void HacerEfecto()
    {
        if (!this.Jugar())
        {
            Console.WriteLine(pokemon.GetName(), " ha sido paralizado y no puede atacar");
        }

        Console.WriteLine(pokemon.GetName(), " puede atacar");
    }
}