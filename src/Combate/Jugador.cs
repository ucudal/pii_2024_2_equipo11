﻿using DefaultNamespace;using Ucu.Poo.Pokemon;namespace Library.Combate;public class Jugador{    private string name;    private List<Pokemon> lista_pokemons;    private Pokemon pokemonEnTurno;    private int turnosjugados;    private bool esMiTurno;    private bool teamIsAlive;    private Pokedex _pokedex;    public Jugador(string name, Pokedex pokedex)    {        this.name = name;        this.lista_pokemons = new List<Pokemon>();        this.turnosjugados = 0;        this.esMiTurno = false;        this.teamIsAlive = true;        _pokedex = pokedex;    }    public void PokemonAtacado(IMovimiento_Ataque ataque)    {        pokemonEnTurno.RecibirAtaque(ataque);    }    public string GetName()    {        return this.name;    }    public bool TeamIsAlive()    {        return this.teamIsAlive;    }    public void PasarTurno()    {        esMiTurno = !esMiTurno;    }    public bool EsMiTurno()    {        return esMiTurno;    }    public List<Pokemon> GetPokemons()    {        return lista_pokemons;    }        public void AgregarAlEquipo(string nombre)    {                if (lista_pokemons.Count < 6)        {            Pokemon pokemonencontrado = _pokedex.EntregarPokemon(nombre);            if (pokemonencontrado != null)            {                                lista_pokemons.Add(pokemonencontrado);                if (lista_pokemons.Count == 1)                {                    pokemonEnTurno = pokemonencontrado;                }                Console.WriteLine($"Se añadió el pokemon {pokemonencontrado.GetName()} a tu equipo, ¿vas a seguir añadiendo más?");            }        }        else        {            Console.WriteLine("Ya tienes 6 Pokemons!");        }    }    public void ActualizarEstadoEquipo()    {        bool equipoestado = lista_pokemons.Any(pokemon => pokemon.GetIsAlive());        this.teamIsAlive = equipoestado;    }    public void CambiarPokemon(Pokemon pokemon)    {        if (lista_pokemons.Contains(pokemon))        {            int indicepokemonAremplazar = lista_pokemons.IndexOf(pokemon);            Pokemon pokemonAnterior = lista_pokemons[0];            lista_pokemons[0] = pokemon;            lista_pokemons[indicepokemonAremplazar] = pokemonAnterior;            pokemonEnTurno = pokemon;        }    }    public Pokemon GetPokemonEnTurno()    {        return pokemonEnTurno;    }    public int HpPokemonEnTurno()    {        return pokemonEnTurno.GetVidaActual();    }    public void MostarEstadoEquipo()    {        Console.WriteLine($"El esta del equipo de {name} es:");        foreach (Pokemon pokemon in lista_pokemons)        {            if (pokemon.GetIsAlive())            {                Console.WriteLine($"{pokemon.GetName()} {pokemon.GetVidaActual()}/{pokemon.GetVidaTotal()}");            }            else            {                Console.WriteLine($"{pokemon.GetName()} ha muerto");            }        }    }}