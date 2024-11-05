using Library.Tipos;
using Ucu.Poo.Pokemon;
using Dormir = Library.Tipos.Dormir;
using Envenenar = Library.Tipos.Envenenar;
using Paralizar = Library.Tipos.Paralizar;
using Quemar = Library.Tipos.Quemar;

namespace DefaultNamespace;

public static class Pokedex
{
    private static List<Tipo> listatiposdisponibles = new List<Tipo>();
    private static List<Pokemon> pokemonsdisponibles = new List<Pokemon>();
    private static List<IMovimiento> listaMovimientos = new List<IMovimiento>();
    private static List<Efecto> listaEfectos = new List<Efecto>();


    static Pokedex()
    {
        RegularTipos();
        CrearMovimientos();
        CrearPokemones();
    }

    public static void MostrarCatalogo()
    {
        foreach (Pokemon pokemon in pokemonsdisponibles)
        {
            Console.WriteLine(pokemon.GetName());
        }
    }

    public static Pokemon EntregarPokemon(string nombrepokemon)
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

    private static void RegularEfectos()
    {
        Efecto dormir = new Dormir();
        Efecto paralizar = new Paralizar();
        Efecto envenenar = new Envenenar();
        Efecto quemar = new Quemar();
        listaEfectos.Add(dormir);//0
        listaEfectos.Add(paralizar);//1
        listaEfectos.Add(envenenar);//2
        listaEfectos.Add(quemar);//3
    }
    

    private static void RegularTipos()
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
        Tipo bicho = new Tipo("Bicho");
        Tipo dragon = new Tipo("Dragon");
        Tipo fantasma = new Tipo("Fantasma");
        Tipo hielo = new Tipo("Hielo");
        Tipo lucha = new Tipo("Lucha");
        Tipo psiquico = new Tipo("Psiquico");
        Tipo veneno = new Tipo("Veneno");
        

        // Definir efectividades del tipo Electrico
        electrico.CrearEfectividad(agua, 2.0);    // Electrico contra Agua -> Súper efectivo (200%)
        electrico.CrearEfectividad(planta, 0.5);  // Electrico contra Planta -> Poco efectivo (50%)
        electrico.CrearEfectividad(volador, 2.0); // Electrico contra Volador -> Súper efectivo (200%)
        electrico.CrearEfectividad(tierra, 0.5);  // Electrico contra Tierra -> Inmune (0%)
        electrico.CrearEfectividad(dragon,0.5);   //Electrico contra Dragon -> Poco efectivo (50%)
        electrico.CrearEfectividad(electrico,0.0);//Electrico contra Electrico -> Inmune(0%)
        

        // Definir efectividades del tipo Fuego
        fuego.CrearEfectividad(agua, 0.5);       // Fuego contra Agua -> Poco efectivo (50%)
        fuego.CrearEfectividad(planta, 2.0);     // Fuego contra Planta -> Súper efectivo (200%)
        fuego.CrearEfectividad(roca, 0.5);       // Fuego contra Roca -> Poco efectivo (50%)
        fuego.CrearEfectividad(bicho,2.0);       // Fuego contra Bicho -> Super efectivo (200%)
        fuego.CrearEfectividad(dragon,0.5);      //Fuego contra Dragon -> Poco efectivo (50%)
        fuego.CrearEfectividad(fuego,0.5);       //Fuego contra Fuego -> Poco efectivo (50%)
        fuego.CrearEfectividad(hielo,2.0);       //Fuego contra Hielo -> Super efectivo (200%)

        // Definir efectividades del tipo Agua
        agua.CrearEfectividad(fuego, 2.0);       // Agua contra Fuego -> Súper efectivo (200%)
        agua.CrearEfectividad(planta, 0.5);      // Agua contra Planta -> Poco efectivo (50%)
        agua.CrearEfectividad(roca, 2.0);        // Agua contra Roca -> Súper efectivo (200%)
        agua.CrearEfectividad(tierra, 2.0);      // Agua contra Tierra -> Súper efectivo (200%)
        agua.CrearEfectividad(agua,0.5);         // Agua contra Agua -> Poco efectivo (50%)
        agua.CrearEfectividad(dragon,0.5);       // Agua contra Dragon -> Poco efectivo (50%)
        
        // Definir efectividades del tipo Planta
        planta.CrearEfectividad(fuego, 0.5);      // Planta contra Fuego -> Poco efectivo (50%)
        planta.CrearEfectividad(agua, 2.0);       // Planta contra Agua -> Súper efectivo (200%)
        planta.CrearEfectividad(volador, 0.5);    // Planta contra Volador -> Poco efectivo (50%)
        planta.CrearEfectividad(roca, 2.0);       // Planta contra Roca -> Súper efectivo (200%)
        planta.CrearEfectividad(tierra, 2.0);     // Planta contra Tierra -> Súper efectivo (200%)
        planta.CrearEfectividad(bicho,0.5);       //Planta contra Bicho-> Poco efectivo (50%)
        planta.CrearEfectividad(dragon,0.5);      //Planta contra Dragon-> Poco efectivo (50%)
        planta.CrearEfectividad(planta,0.5);      //Planta contra Planta-> Poco efectivo (50%)
        planta.CrearEfectividad(veneno,0.5);      // Planta contra Veneno -> Súper efectivo (200%)

        // Definir efectividades del tipo Volador
        volador.CrearEfectividad(electrico, 0.5); // Volador contra Electrico -> Poco efectivo (50%)
        volador.CrearEfectividad(planta, 2.0);    // Volador contra Planta -> Súper efectivo (200%)
        volador.CrearEfectividad(roca, 0.5);      // Volador contra Roca -> Poco efectivo (50%)
        volador.CrearEfectividad(bicho,2.0);      // Volador contra Bicho -> Súper efectivo (200%)
        volador.CrearEfectividad(lucha,2.0);      // Volador contra Lucha -> Súper efectivo (200%)
        
        //Definir efectividades del tipo Normal
        normal.CrearEfectividad(fantasma,0.5);    // Normal contra Fantasma -> Poco efectivo (50%)
        normal.CrearEfectividad(roca,0.5);        // Normal contra Roca -> Poco efectivo (50%)

        // Definir efectividades del tipo Roca
        roca.CrearEfectividad(fuego, 2.0);        // Roca contra Fuego -> Súper efectivo (200%)
        roca.CrearEfectividad(volador, 2.0);      // Roca contra Volador -> Súper efectivo (200%)
        roca.CrearEfectividad(bicho,2.0);         // Roca contra Bicho -> Súper efectivo (200%)
        roca.CrearEfectividad(hielo,2.0);         // Roca contra Hielo -> Súper efectivo (200%)
        roca.CrearEfectividad(lucha,2.0);         // Roca contra Lucha -> Súper efectivo (200%)
        roca.CrearEfectividad(tierra,2.0);        // Roca contra Tierra -> Súper efectivo (200%)

        // Definir efectividades del tipo Tierra
        tierra.CrearEfectividad(electrico, 2.0);  // Tierra contra Electrico -> Súper efectivo (200%)
        tierra.CrearEfectividad(fuego, 2.0);      // Tierra contra Fuego -> Súper efectivo (200%)
        tierra.CrearEfectividad(planta, 0.5);     // Tierra contra Planta -> Poco efectivo (50%)
        tierra.CrearEfectividad(volador, 0.5);    // Tierra contra Volador -> Inmune (0%)
        tierra.CrearEfectividad(roca, 2.0);       // Tierra contra Roca -> Súper efectivo (200%)
        tierra.CrearEfectividad(bicho,0.5);       // Tierra contra Bicho -> Poco efectivo (50%)
        tierra.CrearEfectividad(veneno,2.0);      // Tierra contra Veneno -> Súper efectivo (200%)
        
        //Definir efectividades del tipo Bicho
        bicho.CrearEfectividad(fuego,0.5);        // Bicho contra Fuego -> Poco efectivo (50%)
        bicho.CrearEfectividad(lucha,2.0);        // Bicho contra Lucha -> Super efectivo (200%)
        bicho.CrearEfectividad(planta,2.0);       // Bicho contra Planta -> Super efectivo (200%)
        bicho.CrearEfectividad(psiquico,2.0);     // Bicho contra Psiquico -> Super efectivo (200%)
        bicho.CrearEfectividad(veneno,2.0);       // Bicho contra Veneno -> Super efectivo (200%)
        bicho.CrearEfectividad(volador,0.5);      // Bicho contra Volador -> Poco efectivo (50%)
        
        //Definir efectividades del tipo Dragon
        dragon.CrearEfectividad(dragon,2.0);      // Dragon contra Dragon -> Super efectivo (200%)
        
        //Definir efectividades del tipo Fantasma
        fantasma.CrearEfectividad(psiquico,2.0);  // Fantasma contra Psiquico -> Super efectivo (200%)
        
        //Definir efectividades del tipo Hielo
        hielo.CrearEfectividad(agua, 0.5);        // Hielo contra Agua -> Poco efectivo (50%)
        hielo.CrearEfectividad(dragon,2.0);       // Hielo contra Dragon -> Super efectivo (200%)
        hielo.CrearEfectividad(hielo,0.5);        // Hielo contra Hielo -> Poco efectivo (50%)
        hielo.CrearEfectividad(tierra,2.0);       // Hielo contra Tierra -> Super efectivo (200%)
        hielo.CrearEfectividad(volador,2.0);      // Hielo contra Volador -> Super efectivo (200%)
        
        //Definir efectividades del tipo Lucha
        lucha.CrearEfectividad(bicho,0.5);        // Lucha contra Bicho -> Poco efectivo (50%)
        lucha.CrearEfectividad(fantasma,0.5);     // Lucha contra Fantasma -> Poco efectivo (50%)
        lucha.CrearEfectividad(hielo,2.0);        // Lucha contra Hielo -> Super efectivo (200%)
        lucha.CrearEfectividad(normal,2.0);       // Lucha contra Normal -> Super efectivo (200%)
        lucha.CrearEfectividad(psiquico,2.0);     // Lucha contra Psiquico -> Super efectivo (200%)
        lucha.CrearEfectividad(roca,2.0);         // Lucha contra Roca -> Super efectivo (200%)
        lucha.CrearEfectividad(veneno,2.0);       // Lucha contra Veneno -> Super efectivo (200%)
        lucha.CrearEfectividad(volador,0.5);      // Lucha contra Volador -> Poco efectivo (50%)
        
        //Definir efectividades del tipo Psiquico
        psiquico.CrearEfectividad(lucha,2.0);     // Psiquico contra Lucha -> Super efectivo (200%)
        psiquico.CrearEfectividad(veneno,2.0);    // Psiquico contra Veneno -> Super efectivo (200%)
        
        //Definir efectividades del tipo Veneno
        veneno.CrearEfectividad(bicho,2.0);       // Veneno contra Bicho -> Super efectivo (200%)
        veneno.CrearEfectividad(fantasma,0.5);    // Veneno contra Fantasma -> Poco efectivo (50%)
        veneno.CrearEfectividad(planta,2.0);      // Veneno contra Planta -> Super efectivo (200%)
        veneno.CrearEfectividad(roca,0.5);        // Veneno contra Roca -> Poco efectivo (50%)
        veneno.CrearEfectividad(tierra,2.0);      // Veneno contra Tierra -> Super efectivo (200%)
        veneno.CrearEfectividad(veneno,0.5);      // Veneno contra Veneno -> Poco efectivo (50%)
        
        // Se agragan a la lista todos los tipos
       listatiposdisponibles.Add(electrico); //0
        listatiposdisponibles.Add(fuego);
        listatiposdisponibles.Add(agua);
        listatiposdisponibles.Add(planta);
        listatiposdisponibles.Add(volador);
        listatiposdisponibles.Add(normal);
        listatiposdisponibles.Add(roca);
        listatiposdisponibles.Add(tierra); //7
        listatiposdisponibles.Add(bicho);
        listatiposdisponibles.Add(dragon);
        listatiposdisponibles.Add(fantasma);
        listatiposdisponibles.Add(hielo);
        listatiposdisponibles.Add(lucha);
        listatiposdisponibles.Add(psiquico);
        listatiposdisponibles.Add(veneno);//14
    }

    private static void CrearMovimientos()
    {
        // Movimientos de Pidgey 
        MovimientoDeAtaque picotazo = new MovimientoDeAtaque("Picotazo", 60, listatiposdisponibles[4], 100); // Volador
        MovimientoEspecial vendaval = new MovimientoEspecial("Vendaval", 110, listatiposdisponibles[4], 70,listaEfectos[0]); // Volador (especial)
        MovimientoDeAtaque golpeCabeza = new MovimientoDeAtaque("Golpe Cabeza", 70, listatiposdisponibles[5], 100); // Normal

        // Movimientos de Pikachu 
        MovimientoEspecial rayo = new MovimientoEspecial("Rayo", 95, listatiposdisponibles[0], 100,listaEfectos[1]); // Electrico (especial)
        MovimientoDeAtaque electroBola = new MovimientoDeAtaque("Electro Bola", 65, listatiposdisponibles[0], 100); // Electrico
        MovimientoDeAtaque ataqueRapido = new MovimientoDeAtaque("Ataque Rápido", 60, listatiposdisponibles[5], 100); // Normal

        // Movimientos de Larvitar 
        MovimientoDeAtaque lanzaRocas = new MovimientoDeAtaque("LanzaRocas", 50, listatiposdisponibles[6], 90); // Roca
        MovimientoEspecial terremoto = new MovimientoEspecial("Terremoto", 100, listatiposdisponibles[7], 100,listaEfectos[1]);   // Tierra (especial)
        MovimientoDeAtaque mordisco = new MovimientoDeAtaque("Mordisco", 60, listatiposdisponibles[5], 100); // Siniestro

        // Movimientos de Bulbasaur 
        MovimientoEspecial lluevehojas = new MovimientoEspecial("Lluevehojas", 95, listatiposdisponibles[3], 90,listaEfectos[2]); // Planta (especial)
        MovimientoDeAtaque bombaLodo = new MovimientoDeAtaque("BombaLodo", 70, listatiposdisponibles[3], 100); // Planta
        MovimientoDeAtaque golpeCuerpo = new MovimientoDeAtaque("Golpe Cuerpo", 65, listatiposdisponibles[5], 100); // Normal

        // Movimientos de Charmander 
        MovimientoDeAtaque furiaDragon = new MovimientoDeAtaque("Furia Dragon", 40, listatiposdisponibles[9], 100); // Daño fijo (o lo ajustamos a 100)
        MovimientoEspecial lanzallamas = new MovimientoEspecial("Lanzallamas", 70, listatiposdisponibles[1], 100,listaEfectos[3]); // Fuego
        MovimientoDeAtaque garraDragon = new MovimientoDeAtaque("Garra Dragon", 60, listatiposdisponibles[9], 100); // Dragon

        // Movimientos de Squirtle 
        MovimientoDeAtaque hidropulso = new MovimientoDeAtaque("Hidropulso", 60, listatiposdisponibles[2], 100); // Agua
        MovimientoEspecial hidrobomba = new MovimientoEspecial("Hidrobomba", 95, listatiposdisponibles[2], 80,listaEfectos[0]); // Agua (especial)
        MovimientoDeAtaque cabezazo = new MovimientoDeAtaque("Cabezazo", 40, listatiposdisponibles[5], 100); // Normal
        
        MovimientoDeDefensa proteccion = new MovimientoDeDefensa("Protección", 40, listatiposdisponibles[5], false); // Normal + bonificación defensa

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

    private static void CrearPokemones()
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
        List<Tipo> tiposBulbasaur = new List<Tipo> { listatiposdisponibles[3]}; // Planta
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
        List<Tipo> tiposCharmander = new List<Tipo> { listatiposdisponibles[1] }; // Fuego
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
