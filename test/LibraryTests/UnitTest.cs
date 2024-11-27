using System;
using System.Collections.Generic;
using System.ComponentModel;
using DefaultNamespace;
using Library.Combate;
using Library.Tipos;
using Library.Tipos.Paralisis_Strategy;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Ucu.Poo.DiscordBot.ClasesUtilizadas.Characters.Strategy_Ataque;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.Pokemon;

namespace Program.Tests.Combate;

[TestFixture]
// [TestSubject(typeof(Menu))]
public class UnitTest
{
    /// <summary>
    /// Prueba de la clase <see cref="Menu"/>.
    /// Estos test nos permiten verificar que fragmentos del codigo anden bien detectando errores tempranamente.
    /// </summary>

    [Test]
    public void JugadorTrataDeUsarPokemonQueNoTiene()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("Ash");
        menu.UnirJugadores("yo");
        menu.AgregarPokemonesA("Arbok"); // Solo Ash tiene este Pokémon.
        menu.AgregarPokemonesD("Squirtle");
        menu.IniciarEnfrentamiento();
        
        var resultado = menu.CambiarPokemon(1); // Intento de usar un Pokémon no disponible.
        
        Assert.That(resultado, Is.EqualTo("No tienes ese pokemon")); 
    }

    [Test]
    public void JugadorTrataDeCambiarAPokemonQueEstaPeleando()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");
        juego.AgregarPokemonesA("Squirtle"); // Squirtle es el Pokémon actual al inicio.
        juego.AgregarPokemonesD("Charmander");
        juego.AgregarPokemonesA("Bulbasaur"); // Bulbasaur es el segundo Pokémon del equipo.
        juego.IniciarEnfrentamiento();
        
        juego.CambiarPokemon(0); // Intenta cambiar Squirtle por sí mismo.
        
        // Verifica que el Pokémon actual sigue siendo Squirtle.
        string pokemonEsperado = "Squirtle";
        string pokemonObtenido = juego.GetPokemonActual().GetName();
        Assert.That(pokemonEsperado, Is.EqualTo(pokemonObtenido));
    }

    [Test]
    public void JugadorTrataDeCambiarAPokemonDebilitado()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");
        juego.AgregarPokemonesA("Pikachu");
        juego.AgregarPokemonesD("Pidgey");
        juego.AgregarPokemonesD("Bulbasaur");
        juego.IniciarEnfrentamiento();
        
        juego.UsarMovimientos(1); // Pikachu usa Rayo y Pidgey es derrotado.
        juego.CambiarPokemon(1); // Intenta cambiar a Pidgey (debilitado).
        
        // Verifica que Bulbasaur es ahora el Pokémon actual.
        string pokemonEsperado = "Bulbasaur";
        string pokemonObtenido = juego.GetPokemonActual().GetName();
        Assert.That(pokemonObtenido, Is.EqualTo(pokemonEsperado));
    }

    [Test]
    public void PokemonParalizado()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("player1");
        menu.UnirJugadores("player2");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        Pokemon charmander = menu.GetPokemonRival();
        Pokemon pikachu = menu.GetPokemonActual();
        pikachu.SetStrategy(new AtaqueNoCritico()); // seteo el ataque para que no haga crítico
        menu.UsarMovimientos(1); // Pikachu Paraliza a Charmander
        Assert.That(charmander.GetEfecto().GetType(), Is.EqualTo(typeof(Paralizar)));
    }
    [Test]
    public void TrataDeUsarSuperPocionEnPokemonDebilitado()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");
        juego.AgregarPokemonesA("Pikachu");
        juego.AgregarPokemonesD("Pidgey");
        juego.AgregarPokemonesA("Bulbasaur");
        juego.IniciarEnfrentamiento();
        juego.UsarMovimientos(1); //Jugador 1 usa Rayo y pidgey es debilitado
        juego.UsarItem("superpocion", 1); //Trata de curar a Pidgey
        
        //Verifica que la vida de Pidgey es 0 aun siendo curado con pocion después de ser debilitado 
        Assert.That(juego.GetPokemonActual().GetVidaActual(), Is.EqualTo(0));
    }
    

    [Test]
    public void PokemonQuemado()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("yo");
        menu.UnirJugadores("diego");
        menu.AgregarPokemonesA("Charmander");
        menu.AgregarPokemonesD("Squirtle");
        menu.IniciarEnfrentamiento();
        
        menu.UsarMovimientos(2); // Charmander usa Lanzallamas (quema al rival).
        menu.UsarMovimientos(4); // Squirtle usa Protección.
        
        // Verificar que Squirtle tiene el HP esperado después de usar Protección.
        int hpEsperado = 72; 
        Assert.That(menu.GetHpDefensor(), Is.EqualTo(hpEsperado));

        // Verificar que Squirtle está quemado.
        Pokemon defensor = menu.GetPokemonRival();
        Assert.That(defensor.GetEfecto().GetType(), Is.EqualTo(typeof(Quemar)));
    }

    [Test]
    public void PokemonDormido()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");
        juego.AgregarPokemonesA("Stufful");
        juego.AgregarPokemonesD("Squirtle");
        juego.IniciarEnfrentamiento();
        
        // Stufful usa un movimiento que duerme al rival (squirtle).
        juego.UsarMovimientos(1);

        // Obtiene el Pokémon rival y su efecto después del movimiento.
        Pokemon rival = juego.GetPokemonRival();
        
        // Verifica que el tipo de efecto aplicado es del mismo tipo que 'Dormir'.
        Assert.That(rival.GetEfecto().GetType(), Is.EqualTo(typeof(Dormir)));
    }

    [Test]
    public void UsoCuraTotal()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");
        juego.AgregarPokemonesA("Arbok");
        juego.AgregarPokemonesD("Squirtle");
        juego.IniciarEnfrentamiento();
        
        // Arbok usa un movimiento que envenena al rival (Squirtle).
        juego.UsarMovimientos(1);
        juego.UsarItem("curatotal", 0); //aplica curatotal en el pokemon squirtle
        Pokemon actual = juego.GetPokemonActual();
        Pokemon rival = juego.GetPokemonRival();

        Assert.That(actual.GetEfecto(), Is.EqualTo(rival.GetEfecto()));
    }

    [Test]
    public void MuestroItems()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");
        juego.AgregarPokemonesA("Stufful");
        juego.AgregarPokemonesD("Squirtle");
        juego.IniciarEnfrentamiento();

        string items = juego.MostrarItemsDisponibles();
        Assert.That(items,Is.EqualTo("superpocion: 4 disponibles\nrevivir: 1 disponibles\ncuratotal: 2 disponibles\n"));
    }

    [Test]
    public void TratoDeAtacarSinIniciarBatalla() //Verificacion Cambio de Pokemon de Turno
    {
        Menu juego= new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");
        juego.AgregarPokemonesA("Squirtle"); //Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        juego.AgregarPokemonesD("Charmander");
        
        juego.UsarMovimientos(1);
        
        // Verifica que la batalla no fue iniciada y no uso el movimiento
        Assert.That(juego.UsarMovimientos(1),Is.EqualTo("La batalla no ha iniciado"));
        
        // Verifica que la vida de Charmander esta completa
        Assert.That(juego.GetHpDefensor(),Is.EqualTo(85));
    }

    [Test]
    /// <summary>
    /// Este test verifica la primer historia de usuario y verifica la historia de usuario que no suma a una lista a los usuarios que no pueden combatir
    /// </summary>
    public void NoAgregoPokemons()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Don Dimadon");
        juego.UnirJugadores("Timmy Turner");
        juego.AgregarPokemonesD("Squirtle");
        juego.IniciarEnfrentamiento();
        
        // Verifica que devuelve un mensaje avisando que no tiene pokemons un jugador 
        Assert.That(juego.IniciarEnfrentamiento(),Is.EqualTo("La batalla ya ha comenzado o uno de los jugadores no tiene Pokémon."));
    }

    [Test]
    public void JugadorUsaPocionParaPokemonConVidaCompleta()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Don Dimadon");
        juego.UnirJugadores("Bellota");
        juego.AgregarPokemonesA("Charmander"); //85
        juego.UsarItem("Superpocion", 1);
        
        int vidatotalCharmander = 85;
        
        // Verifica que la superpocion no le agrego vida de mas
        Assert.That(vidatotalCharmander, Is.EqualTo(juego.GetHpAtacante()));
    }

    [Test]
    /// <summary>
    /// Este test verifica la sexta historia de usuario ya que la batalla inicia y termina
    /// El mensaje impreso en programa pasará a ser un string pasado al bot de discord
    /// </summary>
    public void PierdoBatalla()
    {
        Menu juego = new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");
        juego.AgregarPokemonesA("Pikachu");
        juego.AgregarPokemonesD("Pidgey");
        juego.IniciarEnfrentamiento();
        juego.UsarMovimientos(1); //Pikachu usa royo
       
        bool batallaperdida = juego.GetBatallaI() && juego.GetBatallaT();
        
        // Verifica que la batalla fue terminada al perder un jugador
        Assert.That(batallaperdida, Is.EqualTo(true));
    }

    [Test]
    /// <summary>
    /// Este test verifica la  historia de usuario que nos permite usar varios items
    /// </summary>
    public void JugadorAgrega7Pokemons()
    {
        StringWriter consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        Menu juego = new Menu();
        juego.UnirJugadores("Ash");
        juego.UnirJugadores("Red");

        juego.AgregarPokemonesA("Squirtle");
        juego.AgregarPokemonesA("Pidgey");
        juego.AgregarPokemonesA("Larvitar");
        juego.AgregarPokemonesA("Caterpie");
        juego.AgregarPokemonesA("Charmander");
        juego.AgregarPokemonesA("Dratini");
        juego.AgregarPokemonesA("Gengar");

        List<Pokemon> listapokemonsatacante = juego.GetEquipoA();
        int numero = listapokemonsatacante.Count;
        
        // Verifica que agrego los pokemones al jugador correctamente
        Assert.That(6, Is.EqualTo(numero));

    }
    [Test]
    /// <summary>
    /// Este test verifica el efecto Envenenar
    /// </summary>
    public void UsoDeEnvenenamiento()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("quien");
        menu.UnirJugadores("yo");
        menu.AgregarPokemonesA("Arbok");
        menu.AgregarPokemonesD("Squirtle");
        menu.IniciarEnfrentamiento();
        menu.UsarMovimientos(1);
        
        Pokemon rival = menu.GetPokemonActual();
        
        //Verifica que el pokemon rival esta envenenado
        Assert.That(rival.GetEfecto().GetType(),Is.EqualTo(typeof(Envenenar)));
    }
    [Test]
    /// <summary>
    /// Este test verifica que se respeta el danio segun el tipo de ataque y el tipo de pokemon atacado,
    /// en este caso al combatir 2 electricos, la vida del que es atacado no es afectada.
    /// </summary>
    public void Inmune() 
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Pikachu");
        //Usamos a pikachu porque electrico es inmune a electrico y el ataque Rayo es de tipo electrico
        menu.AgregarPokemonesD("Pikachu");
        menu.IniciarEnfrentamiento();
        menu.UsarMovimientos(1);//Jugador 1 usa Rayo(electrico)
        menu.UsarMovimientos(1);//Jugador2 usa Rayo(electrico)
        int vidaesperadadefensor = 80;
        double vidaObtenidaDefensor = menu.GetHpDefensor();
        
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }
    [Test]
    /// <summary>
    /// Este test verifica que Un ataque pueda ser Critico, y que aumenta en danio un 20%
    /// </summary>
    public void DanioCritico() 
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Gengar");
        menu.AgregarPokemonesD("Charmander"); // 85 vida, 60 def 
        menu.IniciarEnfrentamiento();
        Pokemon charmander = menu.GetPokemonRival();
        charmander.SetStrategy(new AtaqueCritico());
        string retorno = menu.UsarMovimientos(3); //daño 80 * 1.2 = 96
        int vidaesperadadefensor = 85 - 36 ;
        double vidaObtenidaDefensor = menu.GetHpAtacante();
        Assert.That(retorno, Does.Contain("Además ha sido un ataque crítico"));
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }
    [Test]
    /// <summary>
    /// Este test verifica que un ataque tambien puede ser No Critico y noaumentar el danio del ataque
    /// </summary>
    public void DanioNoCritico() 
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Gengar");
        menu.AgregarPokemonesD("Charmander"); // 85 vida, 60 def 
        menu.IniciarEnfrentamiento();
        Pokemon charmander = menu.GetPokemonRival();
        charmander.SetStrategy(new AtaqueNoCritico());
        menu.UsarMovimientos(3); //daño 80 * 1.2 = 96
        int vidaesperadadefensor = 85 - 20 ;
        double vidaObtenidaDefensor = menu.GetHpAtacante();
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }

    [Test]
    /// <summary>
    /// Este test verifica que Un ataque puede ser preciso a la hora de usarlo y critico al mismo tiempo
    /// </summary>
    public void PresicionAciertaYAtaqueCritico()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Pidgey");
        menu.AgregarPokemonesD("Charmander"); 
        menu.IniciarEnfrentamiento();
        menu.SetStrategyPresicion(new StrategyPreciso());
        Pokemon charmander = menu.GetPokemonRival();
        charmander.SetStrategy(new AtaqueCritico());
        string mensajeObtenido = menu.UsarMovimientos(1);
        Assert.That(mensajeObtenido, Does.Contain("Y ha acertado."));
        double numeroesperado = 85 - (60 * 1.2 - 60);// Calculo de danio con critico
        double numeroObtenido = menu.GetHpAtacante();//Vida de charmander ya que pasa a ser el atacante
        Assert.That(numeroesperado,Is.EqualTo(numeroObtenido));
    }
    
    [Test]
    /// <summary>
    /// Este test verifica que Un ataque puede ser preciso a la hora de usarlo y tambien puede ser no critico
    /// </summary>
    public void PresicionAciertaYAtaqueNoCritico()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Pidgey");
        menu.AgregarPokemonesD("Charmander"); 
        menu.IniciarEnfrentamiento();
        menu.SetStrategyPresicion(new StrategyPreciso());
        string mensajeObtenido = menu.UsarMovimientos(1);
        Assert.That(mensajeObtenido, Does.Contain("Y ha acertado."));
    }
    
    [Test]
    /// <summary>
    /// Este test verifica que Un ataque puede ser no preciso a la hora de usarlo
    /// </summary>
    public void PresicionNoAcierta()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Pidgey");
        menu.AgregarPokemonesD("Charmander"); 
        menu.IniciarEnfrentamiento();
        menu.SetStrategyPresicion(new StrategyNoPreciso());
        string mensajeObtenido = menu.UsarMovimientos(1);
        Assert.That(mensajeObtenido, Does.Contain("Y ha fallado."));
        double numeroesperado = 85;// Vita totalya que el ataque ha fallado y no le ha hecho danio
        double numeroObtenido = menu.GetHpAtacante();//Vida de charmander ya que pasa a ser el atacante
        Assert.That(numeroesperado,Is.EqualTo(numeroObtenido));
    }

    [Test]
    /// <summary>
    /// Este test verifica que Un ataque puede ser no preciso a la hora de usarlo y que aunque sea critico
    /// esto no afecta al pokemon atacado y se respeta que fallo el ataque
    /// </summary>
    public void PresicionNoAciertaYAtaqueCritico()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Pidgey");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        menu.SetStrategyPresicion(new StrategyNoPreciso());
        Pokemon charmander = menu.GetPokemonRival();
        charmander.SetStrategy(new AtaqueCritico());
        string mensajeObtenido = menu.UsarMovimientos(1);
        Assert.That(mensajeObtenido, Does.Contain("Y ha fallado."));
        double numeroesperado = 85; // Vita totalya que el ataque ha fallado y no le ha hecho danio
        double numeroObtenido = menu.GetHpAtacante(); //Vida de charmander ya que pasa a ser el atacante
        Assert.That(numeroesperado, Is.EqualTo(numeroObtenido));
    }

    [Test]
    public void ProbarMovimientoDefensa()
    {
        string nombreesperado = "Escudo Epico";
        int defensaesperada = 50;
        Tipo tipoesperado = new Tipo("Hielo");
        
        MovimientoDeDefensa movimiento = new MovimientoDeDefensa(nombreesperado, defensaesperada, tipoesperado);

        Assert.That(nombreesperado, Is.EqualTo(movimiento.GetName()));
        Assert.That(defensaesperada,Is.EqualTo(movimiento.GetDefensa()));
        Assert.That(tipoesperado, Is.EqualTo(movimiento.GetTipo()));
    }
    
    [Test]
    public void GettersStrategyCriticos()
    {
        IAtaqueDanioStrategy critico = new AtaqueCritico();
        int esperadoCritico = critico.GetNumero();
        Assert.That(esperadoCritico,Is.EqualTo(0));
        
        IAtaqueDanioStrategy noCritico = new AtaqueNoCritico();
        int esperadoNoCritico = noCritico.GetNumero();
        Assert.That(esperadoNoCritico,Is.EqualTo(1));

        IAtaqueDanioStrategy random = new AtaqueRandom();
        int esperadoRandom = random.GetNumero();
        Assert.That(esperadoRandom, Is.InRange(0, 9));
    }
 [Test]
    /// <summary>
    /// Este test verifica que los Getters de Strategy de la precision de los ataques den el valor requerido
    /// </summary>
    public void GettersStrategyPrecision()
    {
        IStrategyPresicion preciso = new StrategyPreciso();
        int numpreciso = preciso.GetNumber();
        Assert.That(numpreciso,Is.EqualTo(1));

        IStrategyPresicion noPreciso = new StrategyNoPreciso();
        int numNoPreciso = noPreciso.GetNumber();
        Assert.That(numNoPreciso,Is.EqualTo(100));

        IStrategyPresicion random = new StrategyPrecisoRandom();
        int numRandom = random.GetNumber();
        Assert.That(numRandom, Is.InRange(1, 100));
    }

    [Test]
    /// <summary>
    /// Este test verifica que los Getters de Strategy del efecto Paralisis den el valor requerido
    /// </summary>
    public void GettersStrategyParalisis()
    {
        IEfectoParalisisStrategy paralisisTrue = new EfectoParalisisTrue();
        bool valorTrue = paralisisTrue.GetValor();
        Assert.That(valorTrue,Is.EqualTo(true));
        
        IEfectoParalisisStrategy paralisisFalse = new EfectoParalisisFalse();
        bool valorFalse = paralisisFalse.GetValor();
        Assert.That(valorFalse,Is.EqualTo(false));
    }
    [Test]
    public void AtaqueConParalisis()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("player1");
        menu.UnirJugadores("player2");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        Pokemon charmander = menu.GetPokemonRival();
        Paralizar paralizar = new Paralizar();
        paralizar.SetStrategyParalisis(new EfectoParalisisFalse());
        charmander.AgregarEfecto(paralizar);
        string primerpokemon = menu.GetPokemonActual().GetName();
        menu.UsarMovimientos(3);
        string segundopokemon = menu.GetPokemonActual().GetName();
        Assert.That(primerpokemon, Is.EqualTo(segundopokemon));
    }

    [Test]
    public void AtaqueConParalisisPeroPermitoJugar()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("player1");
        menu.UnirJugadores("player2");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        Pokemon charmander = menu.GetPokemonRival();
        Paralizar paralizar = new Paralizar();
        paralizar.SetStrategyParalisis(new EfectoParalisisTrue());
        charmander.AgregarEfecto(paralizar);
        string primerpokemon = menu.GetPokemonActual().GetName(); //Pikachu
        menu.UsarMovimientos(3);
        string segundopokemon = menu.GetPokemonActual().GetName(); //Charmander
        string pokemon1esperado = "Pikachu";
        string pokemon2esperado = "Charmander";
        Assert.That(primerpokemon, Is.EqualTo(pokemon1esperado));
        Assert.That(segundopokemon, Is.EqualTo(pokemon2esperado));
    }
    
    [Test]
    /// <summary>
    /// Este test verifica que el MetodoMostrarNum funcione correctamente, diciendole al jugador quien
    /// es el pokemon en turno y los numeros de los otrospokemones del equipo, para que pueda usar por ejemplo
    // el comando de change pokemon, el cual funciona solo co el numero del pokemon
    /// </summary>
    public void MostratNumPokemon()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("player1");
        menu.UnirJugadores("player2");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesA("Bulbasaur");
        menu.AgregarPokemonesA("Arbok");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        string mensaje=menu.MostrarNumPokemon();
        Assert.That(mensaje, Does.Contain("Pikachu está en turno\n el número 1 es Bulbasaur \nel número 2 es Arbok "));
    }

    [Test]
    /// <summary>
    /// Este test verifica que Mostrar el estadodel equipo lo haga correctamente, asi el jugador puede ver la vida de los pokemones que tiene
    /// </summary>
    public void MostrarEstadoEquipo()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("player1");
        menu.UnirJugadores("player2");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Stufful");
        menu.SetStrategyPresicion(new StrategyPreciso());
        Pokemon pikachu = menu.GetPokemonActual();
        pikachu.SetStrategy(new AtaqueNoCritico());
        Pokemon stufful = menu.GetPokemonRival();
        stufful.SetStrategy(new AtaqueNoCritico());
        menu.IniciarEnfrentamiento();
        Console.WriteLine(menu.UsarMovimientos(2));
        Console.WriteLine(menu.UsarMovimientos(2));
        string mensaje = menu.MostrarEstadoEquipo();

        Assert.That(mensaje, Does.Contain("Pikachu 65/80"));

    }
    
    [Test]
    /// <summary>
    /// Este test verifica que Mostrar el estado del equipo contrincante lo haga correctamente,
    /// asi el jugador puede ver la vida de los pokemones que tiene el rival
    /// </summary>
    public void MostrarEstadoRival()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("player1");
        menu.UnirJugadores("player2");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Stufful");
        menu.SetStrategyPresicion(new StrategyPreciso());
        Pokemon pikachu = menu.GetPokemonActual();
        pikachu.SetStrategy(new AtaqueNoCritico());
        Pokemon stufful = menu.GetPokemonRival();
        stufful.SetStrategy(new AtaqueNoCritico());
        menu.IniciarEnfrentamiento();
        Console.WriteLine(menu.UsarMovimientos(2));
        Console.WriteLine(menu.UsarMovimientos(2));
        string mensaje = menu.MostrarEstadoRival();

        Assert.That(mensaje, Does.Contain("Stufful 55/70"));

    }
    [Test]
    /// <summary>
    /// Este test verifica que si se intenta usar el Item de revivir,
    /// si el pokemon no etsa muerto este item nopodra usarse
    /// </summary>
    public void UsarItemCuandoPokemonEstaVivo()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Pidgey");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        string item = "revivir";

        // Act & Assert
        string mensaje = menu.UsarItem(item, 0);
        Assert.That("No se puede revivir a un Pokémon que no está debilitado.", Is.EqualTo(mensaje));
    }
    [Test]
    /// <summary>
    /// Este test verifica que si se intenta usar el Item de Superpocion,
    /// si el pokemon no tiene danio alguno,este no la podra usar
    /// </summary>
    public void UsarItemCurarFull()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Pidgey");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        
        string mensaje = menu.UsarItem("superpocion", 0);
        Assert.That("No deberías de curar a un pokemon que ya tiene toda su vida.", Is.EqualTo(mensaje));
    }
    
    [Test]
    /// <summary>
    /// Este test verifica que si se intenta usar el Item de CuraTotal,
    /// si el pokemon no tiene ningun efecto, este no la podra usar.
    /// </summary>
    public void UsarItemCuraTotal()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        menu.AgregarPokemonesA("Pikachu");
        menu.AgregarPokemonesD("Pidgey");
        menu.AgregarPokemonesD("Charmander");
        menu.IniciarEnfrentamiento();
        
        string mensaje = menu.UsarItem("curatotal", 0);
        Assert.That("El pokemon no está bajo ningún efecto, no hay porque usar un curatotal", Is.EqualTo(mensaje));
    }

    [Test]

    public void EliminarTipocorrectamente()
    {
        Menu menu = new Menu();
        menu.UnirJugadores("ash");
        menu.UnirJugadores("red");
        string mensaje = menu.EliminarTipo("Fuego");
        Assert.That(mensaje,Does.Contain("Se ha removido el tipo Fuego"));
    }

    [Test]
    public void EliminarTipoNoExiste()
    {
        Menu menu = new Menu();
        string mensaje=menu.EliminarTipo("Hola");
        Assert.That(mensaje,Does.Contain("Este tipo no existe"));
    }

    [Test]
    public void EliminarPokemonCorrectamente()
    {
        Menu menu = new Menu();
        string mensaje = menu.EliminarPokemon("Pikachu");
        Assert.That(mensaje,Does.Contain("Se ha removido el pokemon "));
    }
    
    [Test]
    public void EliminarPokemonIncorrectamente()
    {
        Menu menu = new Menu();
        string mensaje = menu.EliminarPokemon("Hola");
        Assert.That(mensaje,Does.Contain("Este pokemon no existe"));
    }

    [Test]
    public void EliminarItemCorrectamente()
    {
        Menu menu = new Menu();
        string mensaje = menu.EliminarItem("revivir");
        Assert.That(mensaje,Does.Contain("Se ha eliminado el item revivir"));
    }
    
    [Test]
    public void EliminarItemIncorrectamente()
    {
        Menu menu = new Menu();
        string mensaje = menu.EliminarItem("hola");
        Assert.That(mensaje,Does.Contain("Este item no existe"));
    }
    
    //Mi idea era crearuna nueva lista escluyendo el tipo y el pkemon elegidos
    //y a esa lista cargarla en la pokedex haciendo listatipo=nuevalista
    //ya que el remove no funciona con un static y de esomi di cuenta a ultimo momento cunado no tenia tiempo.
    //en los metodos de Menu para eliminar cosas iba a verificar si esas cosas a eliminar existian y si es
    //asi se eliminas, sinosalta un mensaje con que no existe
    //Con respectoa  que el otro jugador acepte lo del otro hacer un nuevo atributo al jugador de acpeto cambiar tipo, pokemones e items
    //cad uno por separado
    //Y para hacer que acepten se me ocurrio hacer comados de cada uno De AcceptRemveT(para aceeptar remover el tipo)
    //y en el otro comando de modificar eso verifica si el juagdoroponente acepto coambiarlos antes de que el que lo usa los cambie
    //Esto repetirlo con todos los Remove, solo me diotiempo de hacer el AcceptRemoveTipo y RemoveTipo, peroesa es mi idea central.
    //Se me ocurrio que antes de llamar al metodo de iniciar batalla en start battle, que salga un string concatenado de
    //todo lo que se quito, concatenando con cada metodo un nuevo sting llamado cambios, al cual se le suma el resultadode cada metodo de
    //eliminar. 
    //Por ultimo eliminar item no me dio tiempo para verificarlo pero segui la continuidad entre las clases y supuestamente tendria que funcionar de esa forma
    //Espero que tengan en cuenta mis ideas, ya que no me dio el tipo de ponerlas en prueba a todas y mis tests no funcionad debido a que
    //use Remove en lugar de crear una nueva lista y poner el nuevo valor de esa  como la listadetipos, y de pokemones.
    //Con toda mi sinceridad les digo que el codigo lo entiendo perfectamente, que colabore con el mismo constantemente, y que se como hacer las cosas pero
    //debido al tiempo no las puede ejecutar como hubiera querido.Muchas gracias.
    
}

