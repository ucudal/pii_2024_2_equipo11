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
        menuPP.AgregarPokemones1("Pikachu");
        menuPP.AgregarPokemones2("Pidgey");
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
        menuPP.AgregarPokemones1("Pidgey"); 
        menuPP.AgregarPokemones2("Pikachu");
        menuPP.AgregarPokemones1("Charmander");
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
            menuPP.AgregarPokemones1("Squirtle"); 
            menuPP.AgregarPokemones2("Pikachu"); 
            menuPP.AgregarPokemones1("Bulbasaur"); 
            menuPP.CambiarPokemon(1); // Cambia a bulbasaur
            menuPP.UsarMovimientos(1); // Pikachu usa rayo, daño de 95/2 = 48 (redondeo)
            
            
            Assert.AreEqual(vidabulbasaurRestanteEsperada, menuPP.GetHpAtacante()); // Verificar que la vida de bulbasaur es la esperada
            menuPP.CambiarPokemon(1); // Cambiar de vuelta a Squirtle
            Assert.AreEqual(vidatortugaEsperada,  menuPP.GetHpDefensor()); //Verifica que squiertle sigue intecto
    }
    
}