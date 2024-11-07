﻿using DefaultNamespace;using Ucu.Poo.Pokemon;namespace Library.Combate;public class Jugador{    private string name;    private List<Pokemon> lista_pokemons;    private Pokemon pokemonEnTurno;    private bool teamIsAlive;    private Inventario_Items inventario_del_jugador;    public Jugador(string name)    {        this.name = name;        this.lista_pokemons = new List<Pokemon>();        this.teamIsAlive = true;        this.inventario_del_jugador = new Inventario_Items();    }    public void PokemonAtacado(IMovimientoAtaque ataque)    {        pokemonEnTurno.RecibirAtaque(ataque);    }    public string GetName()    {        return this.name;    }    public bool TeamIsAlive()    {        return this.teamIsAlive;    }       public List<Pokemon> GetPokemons()    {        return lista_pokemons;    }        public List<IMovimiento> GetMovimientos(Pokemon pokemon)    {        return pokemon.GetListaMovimientos();    }        public void AgregarAlEquipo(string nombre)    {                if (lista_pokemons.Count < 6)        {            Pokemon pokemonencontrado = Pokedex.EntregarPokemon(nombre);            if (pokemonencontrado != null)            {                                lista_pokemons.Add(pokemonencontrado);                if (lista_pokemons.Count == 1)                {                    pokemonEnTurno = pokemonencontrado;                }                Console.WriteLine($"Se añadió el pokemon {pokemonencontrado.GetName()} a tu equipo, ¿vas a seguir añadiendo más?");            }        }        else        {            Console.WriteLine("Ya tienes 6 Pokemons!");        }    }    public void ActualizarEstadoEquipo()    {        bool equipoestado = lista_pokemons.Any(pokemon => pokemon.GetIsAlive());        this.teamIsAlive = equipoestado;    }    public void CambiarPokemon(Pokemon pokemon)    {        if (lista_pokemons.Contains(pokemon))        {            int indicepokemonAremplazar = lista_pokemons.IndexOf(pokemon);            Pokemon pokemonAnterior = lista_pokemons[0];            lista_pokemons[0] = pokemon;            lista_pokemons[indicepokemonAremplazar] = pokemonAnterior;            pokemonEnTurno = pokemon;        }    }    public Pokemon GetPokemonEnTurno()    {        return pokemonEnTurno;    }    public double HpPokemonEnTurno()    {        return pokemonEnTurno.GetVidaActual();    }    public void MostarEstadoEquipo()    {        Console.WriteLine($"El estado del equipo de {name} es:");        foreach (Pokemon pokemon in lista_pokemons)        {            if (pokemon.GetIsAlive())            {                Console.WriteLine($"{pokemon.GetName()} {pokemon.GetVidaActual()}/{pokemon.GetVidaTotal()}");            }            else            {                Console.WriteLine($"{pokemon.GetName()} ha muerto");            }        }    }    public void Revivir(Pokemon pokemon)     {        if (lista_pokemons.Contains(pokemon))        {            int indice_pokemon_a_revivir = lista_pokemons.IndexOf(pokemon);            Pokemon Pokemon_a_revivir = lista_pokemons[indice_pokemon_a_revivir];            inventario_del_jugador.UsarItem("Revivir", Pokemon_a_revivir);        }    }    public void Curar_estado(Pokemon pokemon)    {        if (lista_pokemons.Contains(pokemon))        {            int indice_pokemon_a_curar_estado = lista_pokemons.IndexOf(pokemon);            Pokemon Pokemon_a_curar_estado = lista_pokemons[indice_pokemon_a_curar_estado];            inventario_del_jugador.UsarItem("Curatotal", Pokemon_a_curar_estado);        }    }    public void Curar(Pokemon pokemon)    {        if (lista_pokemons.Contains(pokemon))        {            int indice_pokemon_a_curar = lista_pokemons.IndexOf(pokemon);            Pokemon Pokemon_a_curar = lista_pokemons[indice_pokemon_a_curar];            inventario_del_jugador.UsarItem("Superpocion", Pokemon_a_curar);        }    }    public void Mostrar_items()    {        inventario_del_jugador.MostrarItems();    }}