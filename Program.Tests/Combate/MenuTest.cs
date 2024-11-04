using JetBrains.Annotations;
using Library.Combate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Program.Tests.Combate;

[TestClass]
[TestSubject(typeof(Menu))]
public class MenuTest
{
    [TestMethod]
    public void PikachuDañaAPidgey()
    {
        // 95 de daño del ataque rayo * efectividad (2) 
        int vidaesperada = 0; // tiene 60 de vida y 40 de defensa así que aguantría un golpe de 99 de daño como mucho 
        Menu menuPP = new Menu();
        menuPP.AgregarPokemonesA("Pikachu");
        menuPP.AgregarPokemonesD("Pidgey");
        menuPP.UsarMovimientos(1); //Pikachu usa royo
        
        Assert.AreEqual(vidaesperada, menuPP.GetHpDefensor()); // Verificar que la vida de Pidgey es 0
        Assert.AreEqual(80, menuPP.GetHpAtacante()); // Verificar que Pikachu mantiene su HP
    }
    [TestMethod]
    public void PidgeyPorCharmanderParaAguantarAPikachu()
    {
        // Arrange
        int dañoPorAtaque = 95; // Daño de rayo
        int defensaCharmander = 60; // Defensa de Charmander
        int hpCharmanderEsperado = 85; // Charmander arranca con 85 de vida
        int vidaCharmanderRestanteEsperada = hpCharmanderEsperado - (dañoPorAtaque - defensaCharmander); // Calculos de supuesta vida charmander
        int vidaPidgeyEsperada = 60; // Pidgey debería iniciar con 60 de vida

        Menu menuPP = new Menu();
        menuPP.AgregarPokemonesA("Pidgey"); 
        menuPP.AgregarPokemonesD("Pikachu");
        menuPP.AgregarPokemonesA("Charmander");
        menuPP.CambiarPokemon(1); // Cambia a Charmander
        menuPP.UsarMovimientos(1);

        // Assert
        Assert.AreEqual(vidaCharmanderRestanteEsperada, menuPP.GetHpAtacante()); // Verificar que la vida de Charmander es la esperada
        menuPP.CambiarPokemon(1);
        Assert.AreEqual( menuPP.GetHpDefensor(), vidaPidgeyEsperada); //Verifica que pidgey sigue intecto
    }
    [TestMethod]
    public void BulbasaurPorSquirtleParaAguantarAPikachu()
    {
        
            // Arrange
            int dañoPorAtaque = 95 / 2 ;
            int defensaBulbasaur = 70; 
            int hpBulbasaurEsperado = 90;
            int vidabulbasaurRestanteEsperada = 90; // Sabemos que no alzcanza para romper su defensa
            int vidatortugaEsperada = 80; 

            Menu menuPP = new Menu();
            menuPP.AgregarPokemonesA("Squirtle"); 
            menuPP.AgregarPokemonesD("Pikachu"); 
            menuPP.AgregarPokemonesA("Bulbasaur"); 
            menuPP.CambiarPokemon(1); // Cambia a bulbasaur
            menuPP.UsarMovimientos(1); // Pikachu usa rayo, daño de 95/2 = 48 (redondeo)
            
            
            Assert.AreEqual(vidabulbasaurRestanteEsperada, menuPP.GetHpAtacante()); // Verificar que la vida de bulbasaur es la esperada
            menuPP.CambiarPokemon(1); // Cambiar de vuelta a Squirtle
            Assert.AreEqual(vidatortugaEsperada,  menuPP.GetHpDefensor()); //Verifica que squiertle sigue intecto
    }
    [TestMethod]
    public void Especial() //En este test se puede ver que cuando eljugador 1 intenta usar el ataque especial de nueo no puedehacerlo
    {
        Menu juego1 = new Menu();
        juego1.AgregarPokemonesA("Pikachu");
        
        juego1.AgregarPokemonesD("Pikachu");
        
        juego1.IniciarEnfrentamiento();
        juego1.UsarMovimientos(1);//Jugador 1 usa Rayo(especial), vida del contrincante en 45
        juego1.UsarMovimientos(1);//Jugador2 usa Rayo (especial)
        juego1.UsarMovimientos(1);//Jugador 1 intenta usar el Rayo nuevamente pero no puede, vida del contrincante se mantiene
        int vidaesperadadefensor = 45;
        double vidaObtenidaDefensor = juego1.GetHpDefensor();
        Assert.AreEqual(vidaesperadadefensor,vidaObtenidaDefensor);
    }

    [TestMethod]
    public void Defensa()//Demuestra que defensa nohace daño
    {
        Menu juego2 = new Menu();
        juego2.AgregarPokemonesA("Pikachu");
        juego2.AgregarPokemonesD("Charmander");
        juego2.IniciarEnfrentamiento();
        juego2.UsarMovimientos(4);//El movimiento 4 siempre es de defensa, por lo que no provoca daño al contrincante
        double vidaesperadadefensor = 80;
        double vidaObtenidaDefensor = juego2.GetHpDefensor();
        Assert.AreEqual(vidaesperadadefensor,vidaObtenidaDefensor);
    }

    [TestMethod]
    public void CambioPokemon()//Verificacion Cambio de Pokemon de Turno
    {
        Menu juego3 = new Menu();
        juego3.AgregarPokemonesA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        juego3.AgregarPokemonesD("Charmander");
        juego3.AgregarPokemonesA("Bulbasaur");//Bulbasaur era el segundo pokemon del equipo
        juego3.IniciarEnfrentamiento();
        juego3.CambiarPokemon(1);//Bulbasaur para a ser el Pokemon en Turno
        juego3.UsarMovimientos(1);
        string pokemonesperado = "Bulbasaur";
        string pokemonobtenido = juego3.GetPokemonActual().GetName();
        Assert.AreEqual(pokemonesperado,pokemonobtenido);
    }
}