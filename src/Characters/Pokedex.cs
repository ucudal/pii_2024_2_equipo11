using Library.Tipos;
using Ucu.Poo.Pokemon;

namespace DefaultNamespace;

public class Pokedex
{
    private List<Tipo> listatiposdisponibles = new List<Tipo>();
    private List<Pokemon> pokemonsdisponibles = new List<Pokemon>();
    private List<IMovimiento> listaMovimientos = new List<IMovimiento>();

    public void MostrarCatalogo()
    {
        foreach (Pokemon pokemon in pokemonsdisponibles)
        {
            Console.WriteLine(pokemon.GetName());
        }
    }

    public Pokemon EntregarPokemon(string nombrepokemon)
    {
        foreach (Pokemon pokemon in pokemonsdisponibles)
        {
            if (nombrepokemon == pokemon.GetName())
            {
                return pokemon;
            }
        }
        Console.WriteLine("No se ha encontrado al pokemon");
        return null;
    }

    public Pokedex()
    {
        RegularTipos();
        CrearMovimientos();
        CrearPokemones();
    }

    private void RegularTipos()
    { 
        // Crear los tipos
        Tipo electrico = new Tipo("Electrico");
        Tipo fuego = new Tipo("Fuego");
        Tipo agua = new Tipo("Agua");
        Tipo planta = new Tipo("Planta");
        Tipo volador = new Tipo("Volador");
        Tipo normal = new Tipo("Normal");
        Tipo roca = new Tipo("Roca");
        Tipo tierra = new Tipo("Tierra");

        // Definir efectividades del tipo Electrico
        electrico.CrearEfectividad(agua, 2.0);    // Electrico contra Agua -> Súper efectivo (200%)
        electrico.CrearEfectividad(planta, 0.5);  // Electrico contra Planta -> Poco efectivo (50%)
        electrico.CrearEfectividad(volador, 2.0); // Electrico contra Volador -> Súper efectivo (200%)
        electrico.CrearEfectividad(tierra, 0.0);  // Electrico contra Tierra -> Inmune (0%)

        // Definir efectividades del tipo Fuego
        fuego.CrearEfectividad(agua, 0.5);       // Fuego contra Agua -> Poco efectivo (50%)
        fuego.CrearEfectividad(planta, 2.0);     // Fuego contra Planta -> Súper efectivo (200%)
        fuego.CrearEfectividad(roca, 0.5);       // Fuego contra Roca -> Poco efectivo (50%)

        // Definir efectividades del tipo Agua
        agua.CrearEfectividad(fuego, 2.0);       // Agua contra Fuego -> Súper efectivo (200%)
        agua.CrearEfectividad(planta, 0.5);      // Agua contra Planta -> Poco efectivo (50%)
        agua.CrearEfectividad(roca, 2.0);        // Agua contra Roca -> Súper efectivo (200%)
        agua.CrearEfectividad(tierra, 2.0);      // Agua contra Tierra -> Súper efectivo (200%)

        // Definir efectividades del tipo Planta
        planta.CrearEfectividad(fuego, 0.5);      // Planta contra Fuego -> Poco efectivo (50%)
        planta.CrearEfectividad(agua, 2.0);       // Planta contra Agua -> Súper efectivo (200%)
        planta.CrearEfectividad(volador, 0.5);    // Planta contra Volador -> Poco efectivo (50%)
        planta.CrearEfectividad(roca, 2.0);       // Planta contra Roca -> Súper efectivo (200%)
        planta.CrearEfectividad(tierra, 2.0);     // Planta contra Tierra -> Súper efectivo (200%)

        // Definir efectividades del tipo Volador
        volador.CrearEfectividad(electrico, 0.5); // Volador contra Electrico -> Poco efectivo (50%)
        volador.CrearEfectividad(planta, 2.0);    // Volador contra Planta -> Súper efectivo (200%)
        volador.CrearEfectividad(roca, 0.5);      // Volador contra Roca -> Poco efectivo (50%)

        // Definir efectividades del tipo Roca
        roca.CrearEfectividad(fuego, 2.0);        // Roca contra Fuego -> Súper efectivo (200%)
        roca.CrearEfectividad(volador, 2.0);      // Roca contra Volador -> Súper efectivo (200%)

        // Definir efectividades del tipo Tierra
        tierra.CrearEfectividad(electrico, 2.0);  // Tierra contra Electrico -> Súper efectivo (200%)
        tierra.CrearEfectividad(fuego, 2.0);      // Tierra contra Fuego -> Súper efectivo (200%)
        tierra.CrearEfectividad(planta, 0.5);     // Tierra contra Planta -> Poco efectivo (50%)
        tierra.CrearEfectividad(volador, 0.0);    // Tierra contra Volador -> Inmune (0%)
        tierra.CrearEfectividad(roca, 2.0);       // Tierra contra Roca -> Súper efectivo (200%)
        
        // Se agragan a la lista todos los tipos
        listatiposdisponibles.Add(electrico); //0
        listatiposdisponibles.Add(fuego);
        listatiposdisponibles.Add(agua);
        listatiposdisponibles.Add(planta);
        listatiposdisponibles.Add(volador);
        listatiposdisponibles.Add(normal);
        listatiposdisponibles.Add(roca);
        listatiposdisponibles.Add(tierra); //7
    }

    private void CrearMovimientos()
    {
        // Movimientos de Pidgey 
        MovimientoDeAtaque picotazo = new MovimientoDeAtaque("Picotazo", 60, listatiposdisponibles[4], false); // Volador
        MovimientoDeAtaque vendaval = new MovimientoDeAtaque("Vendaval", 110, listatiposdisponibles[4], true); // Volador (especial)
        MovimientoDeAtaque golpeCabeza = new MovimientoDeAtaque("Golpe Cabeza", 70, listatiposdisponibles[5], false); // Normal

        // Movimientos de Pikachu 
        MovimientoDeAtaque rayo = new MovimientoDeAtaque("Rayo", 95, listatiposdisponibles[0], true); // Electrico (especial)
        MovimientoDeAtaque electroBola = new MovimientoDeAtaque("Electro Bola", 65, listatiposdisponibles[0], false); // Electrico
        MovimientoDeAtaque ataqueRapido = new MovimientoDeAtaque("Ataque Rápido", 60, listatiposdisponibles[5], false); // Normal

        // Movimientos de Larvitar 
        MovimientoDeAtaque lanzaRocas = new MovimientoDeAtaque("LanzaRocas", 50, listatiposdisponibles[6], false); // Roca
        MovimientoDeAtaque terremoto = new MovimientoDeAtaque("Terremoto", 100, listatiposdisponibles[7], true);   // Tierra (especial)
        MovimientoDeAtaque mordisco = new MovimientoDeAtaque("Mordisco", 60, new Tipo("Siniestro"), false); // Siniestro

        // Movimientos de Bulbasaur 
        MovimientoDeAtaque lluevehojas = new MovimientoDeAtaque("Lluevehojas", 95, listatiposdisponibles[3], true); // Planta (especial)
        MovimientoDeAtaque bombaLodo = new MovimientoDeAtaque("BombaLodo", 70, new Tipo("Veneno"), false); // Veneno
        MovimientoDeAtaque golpeCuerpo = new MovimientoDeAtaque("Golpe Cuerpo", 65, listatiposdisponibles[5], false); // Normal

        // Movimientos de Charmander 
        MovimientoDeAtaque furiaDragon = new MovimientoDeAtaque("Furia Dragon", 40, new Tipo("Dragon"), false); // Daño fijo (o lo ajustamos a 100)
        MovimientoDeAtaque lanzallamas = new MovimientoDeAtaque("Lanzallamas", 70, listatiposdisponibles[1], false); // Fuego
        MovimientoDeAtaque garraDragon = new MovimientoDeAtaque("Garra Dragon", 60, new Tipo("Dragon"), false); // Dragon

        // Movimientos de Squirtle 
        MovimientoDeAtaque hidropulso = new MovimientoDeAtaque("Hidropulso", 60, listatiposdisponibles[2], false); // Agua
        MovimientoDeAtaque hidrobomba = new MovimientoDeAtaque("Hidrobomba", 95, listatiposdisponibles[2], true); // Agua (especial)
        MovimientoDeAtaque cabezazo = new MovimientoDeAtaque("Cabezazo", 40, listatiposdisponibles[5], false); // Normal + bonificación defensa
        
        MovimientoDefensivo proteccion = new MovimientoDefensivo("Protección", 40, listatiposdisponibles[5], false); // Normal + bonificación defensa

        // Agregar movimientos a la lista
        listaMovimientos.Add(picotazo); // 0
        listaMovimientos.Add(vendaval); //1
        listaMovimientos.Add(golpeCabeza);
        listaMovimientos.Add(rayo);
        listaMovimientos.Add(electroBola);
        listaMovimientos.Add(ataqueRapido);
        listaMovimientos.Add(lanzaRocas);
        listaMovimientos.Add(terremoto);
        listaMovimientos.Add(mordisco);
        listaMovimientos.Add(lluevehojas);
        listaMovimientos.Add(bombaLodo);
        listaMovimientos.Add(golpeCuerpo);
        listaMovimientos.Add(furiaDragon);
        listaMovimientos.Add(lanzallamas);
        listaMovimientos.Add(garraDragon);
        listaMovimientos.Add(hidropulso);
        listaMovimientos.Add(hidrobomba);
        listaMovimientos.Add(cabezazo);
        listaMovimientos.Add(proteccion);
    }

    private void CrearPokemones()
    {

        List<IMovimiento> movimientosPikachu = new List<IMovimiento>
        {
            listaMovimientos[3],
            listaMovimientos[4],
            listaMovimientos[5],
            listaMovimientos[18]
        };
        List<Tipo> tiposPikachu = new List<Tipo>{listatiposdisponibles[0]};
        Pokemon Pikachu = new Pokemon("Pikachu", movimientosPikachu, tiposPikachu, 80, 60);
        pokemonsdisponibles.Add(Pikachu);
        // Crear los movimientos para Pidgey
        List<IMovimiento> movimientosPidgey = new List<IMovimiento>
        {
            listaMovimientos[0],  // Picotazo
            listaMovimientos[1],  // Vendaval
            listaMovimientos[2],  // Golpe Cabeza
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposPidgey = new List<Tipo> { listatiposdisponibles[4], listatiposdisponibles[5] }; // Volador, Normal
        Pokemon Pidgey = new Pokemon("Pidgey", movimientosPidgey, tiposPidgey, 60, 40);
        pokemonsdisponibles.Add(Pidgey);

        // Crear los movimientos para Larvitar
        List<IMovimiento> movimientosLarvitar = new List<IMovimiento>
        {
            listaMovimientos[6],  // LanzaRocas
            listaMovimientos[7],  // Terremoto
            listaMovimientos[8],  // Mordisco
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposLarvitar = new List<Tipo> { listatiposdisponibles[6], listatiposdisponibles[7] }; // Roca, Tierra
        Pokemon Larvitar = new Pokemon("Larvitar", movimientosLarvitar, tiposLarvitar, 80, 70);
        pokemonsdisponibles.Add(Larvitar);

        // Crear los movimientos para Bulbasaur
        List<IMovimiento> movimientosBulbasaur = new List<IMovimiento>
        {
            listaMovimientos[9],  // Lluevehojas
            listaMovimientos[10], // Bomba Lodo
            listaMovimientos[11],  // Golpe Cuerpo
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposBulbasaur = new List<Tipo> { listatiposdisponibles[3], new Tipo("Veneno") }; // Planta, Veneno
        Pokemon Bulbasaur = new Pokemon("Bulbasaur", movimientosBulbasaur, tiposBulbasaur, 90, 70);
        pokemonsdisponibles.Add(Bulbasaur);

        // Crear los movimientos para Charmander
        List<IMovimiento> movimientosCharmander = new List<IMovimiento>
        {
            listaMovimientos[12], // Furia Dragon
            listaMovimientos[13], // Lanzallamas
            listaMovimientos[14],  // Garra Dragon
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposCharmander = new List<Tipo> { listatiposdisponibles[1], new Tipo("Dragon") }; // Fuego, Dragon
        Pokemon Charmander = new Pokemon("Charmander", movimientosCharmander, tiposCharmander, 85, 60);
        pokemonsdisponibles.Add(Charmander);

        // Crear los movimientos para Squirtle
        List<IMovimiento> movimientosSquirtle = new List<IMovimiento>
        {
            listaMovimientos[15], // Hidropulso
            listaMovimientos[16], // Hidrobomba
            listaMovimientos[17], // Cabezazo
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposSquirtle = new List<Tipo> { listatiposdisponibles[2] }; // Agua
        Pokemon Squirtle = new Pokemon("Squirtle", movimientosSquirtle, tiposSquirtle, 80, 70);
        pokemonsdisponibles.Add(Squirtle);
    }
    
}
