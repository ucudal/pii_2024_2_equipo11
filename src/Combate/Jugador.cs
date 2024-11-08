﻿using DefaultNamespace;using Ucu.Poo.Pokemon;namespace Library.Combate;public class Jugador{    private string name;    private List<Pokemon> lista_pokemons;    private Pokemon pokemonEnTurno;    private bool teamIsAlive;    private InventarioItems inventario_del_jugador;    public Jugador(string name)    {        this.name = name;        this.lista_pokemons = new List<Pokemon>();        this.teamIsAlive = true;        this.inventario_del_jugador = new InventarioItems();    }    public void PokemonAtacado(IMovimientoAtaque ataque)    {        pokemonEnTurno.RecibirAtaque(ataque);    }    public string GetName()    {        return this.name;    }    public bool TeamIsAlive()    {        return this.teamIsAlive;    }       public List<Pokemon> GetPokemons()    {        return lista_pokemons;    }        public void AgregarAlEquipo(string nombre)    {                if (lista_pokemons.Count < 6)        {            Pokemon pokemonencontrado = Pokedex.EntregarPokemon(nombre);            if (pokemonencontrado != null)            {                                lista_pokemons.Add(pokemonencontrado);                if (lista_pokemons.Count == 1)                {                    pokemonEnTurno = pokemonencontrado;                }                Console.WriteLine($"Se añadió el pokemon {pokemonencontrado.GetName()} a tu equipo, ¿vas a seguir añadiendo más?");            }        }        else        {            Console.WriteLine("Ya tienes 6 Pokemons!");        }    }    public void ActualizarEstadoEquipo()    {        bool equipoestado = lista_pokemons.Any(pokemon => pokemon.GetIsAlive());        this.teamIsAlive = equipoestado;    }    public void CambiarPokemon(Pokemon pokemon)    {        if (lista_pokemons.Contains(pokemon))        {            int indicepokemonAremplazar = lista_pokemons.IndexOf(pokemon);            Pokemon pokemonAnterior = lista_pokemons[0];            lista_pokemons[0] = pokemon;            lista_pokemons[indicepokemonAremplazar] = pokemonAnterior;            pokemonEnTurno = pokemon;        }    }    public Pokemon GetPokemonEnTurno()    {        return pokemonEnTurno;    }    public double HpPokemonEnTurno()    {        return pokemonEnTurno.GetVidaActual();    }    public void MostarEstadoEquipo()    {        Console.WriteLine($"El estado del equipo de {name} es:");        foreach (Pokemon pokemon in lista_pokemons)        {            if (pokemon.GetIsAlive())            {                Console.WriteLine($"{pokemon.GetName()} {pokemon.GetVidaActual()}/{pokemon.GetVidaTotal()}");            }            else            {                Console.WriteLine($"{pokemon.GetName()} ha muerto");            }        }    }    public void UsarItem(string item, Pokemon pokemon)    {        if (lista_pokemons.Contains(pokemon))        {            int IndicePokemonAEfectuar = lista_pokemons.IndexOf(pokemon);            Pokemon PokemonAEfectuar = lista_pokemons[IndicePokemonAEfectuar];            inventario_del_jugador.UsarItem(item, PokemonAEfectuar);        }    }    public void Mostrar_items() //Este método llama al mostrar items de InventarioItems para mostrar los items disponibles que tiene el jugador    {        inventario_del_jugador.MostrarItems();    }}