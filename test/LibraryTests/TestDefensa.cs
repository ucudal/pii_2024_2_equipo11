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
public class TestDefensa
{
    /// <summary>
    /// Prueba de la clase <see cref="Menu"/>.
    /// Estos test nos permiten verificar que fragmentos del codigo anden bien detectando errores tempranamente.
    /// </summary>
    [Test]
    public void EliminoTipoAgua()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.RestringeType("Agua");
        string catalogo = Facade.Instance.ShowCatolog();
        string catalogoesperado =
            "Los pokemones disponibles son:\nPikachu \nPidgey \nLarvitar \nBulbasaur \nCharmander \nCaterpie " +
            "\nDratini \nGengar \nRegice \nStufful \nGardevoir \nArbok \n";
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
    /// <summary>
    /// Prueba de la clase <see cref="Menu"/>.
    /// Estos test nos permiten verificar que fragmentos del codigo anden bien detectando errores tempranamente.
    /// </summary>

    [Test]
    public void EliminoSquirtleDelCatalogo()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.RestringePokemon("Squirtle");
        string catalogo = Facade.Instance.ShowCatolog();
        string catalogoesperado =
            "Los pokemones disponibles son:\nPikachu \nPidgey \nLarvitar \nBulbasaur \nCharmander \nCaterpie " +
            "\nDratini \nGengar \nRegice \nStufful \nGardevoir \nArbok \n";
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
    [Test]
    public void UsoItemEnBatalla2()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        //Este test muestra el uso de la CuraTotal en batalla
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        Facade.Instance.RestringeItem("superpocion");
        Facade.Instance.InitializeBattle();
        string textoesperado = "revivir: 1 disponibles\ncuratotal: 2 disponibles\n";
        string texto = Facade.Instance.ShowAviableItems();
        Assert.That(textoesperado, Is.EqualTo(texto)); 
        Facade.Instance.UsePokemonMove(1);
        string esperado = "El item se ha removido";
        string real =   Facade.Instance.UseItem("superpocion", 0);  //No logra curar no existe en esta batalla el item
        Assert.That(real, Is.EqualTo(esperado)); 
    }
    [Test]
    public void EliminoPikachu()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        string textoesperado = "Se ha prohibido a Pikachu para este combate";
        string texto = Facade.Instance.RestringePokemon("Pikachu");
        string mensaje= Facade.Instance.AddPokemosA("Pikachu");
        string mensajeesperado = "Ese pokemon no existe";
        Assert.That(mensajeesperado, Is.EqualTo(mensaje));
        Assert.That(textoesperado, Is.EqualTo(texto));
    }
    [Test]
    
    public void EliminoTiposFuego()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        string textoesperado = "Se ha prohibido a Charmander para este combate por ser de tipo Fuego\n";
        string texto = Facade.Instance.RestringeType("Fuego");
        string mensaje= Facade.Instance.AddPokemosA("Charmander");
        string mensajeesperado = "Ese pokemon no existe";
        Assert.That(mensajeesperado, Is.EqualTo(mensaje)); 
        Assert.That(textoesperado, Is.EqualTo(texto));
    }
    [Test]
    public void EliminoTipoAguaBatallaIniciada()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        Facade.Instance.InitializeBattle();
        string catalogo = Facade.Instance.RestringeType("Agua");;
        string catalogoesperado = "La batalla ya ha iniciado";
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
    [Test]
    public void EliminoTipoFuegoBatallaTerminada()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        string catalogo = Facade.Instance.RestringeType("Fuego");;
        string catalogoesperado = "La batalla ya ha terminado";
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
    [Test]
    public void EliminoBulbasorBatallaTerminada()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        string catalogo = Facade.Instance.RestringePokemon("Bulbasaur");;
        string catalogoesperado = "La batalla ya ha terminado";
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
    [Test]
    public void EliminoArbokBatallaIniciada()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        Facade.Instance.InitializeBattle();
        string catalogo = Facade.Instance.RestringePokemon("Arbok");;
        string catalogoesperado = "La batalla ya ha iniciado";
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
    [Test]
    public void EliminoCuraTotalBatallaIniciada()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Pikachu");
        Facade.Instance.InitializeBattle();
        string catalogo = Facade.Instance.RestringeItem("curatotal");;
        string catalogoesperado = "La batalla ya ha iniciado";
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
    [Test]
    public void EliminoRevivirBatallaTerminada()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Pikachu");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(3);
        string catalogo = Facade.Instance.RestringeItem("curatotal");;
        string catalogoesperado = "La batalla ya ha terminado";
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
    [Test]
    public void MostrarRestricciones()
    {
        Facade.Reset();
        Pokedex.Reiniciar();
        Facade.Instance.StartBattle("Ash", "Red");
        string catalogo = Facade.Instance.RestringeItem("curatotal");
        catalogo += "\n" + Facade.Instance.RestringePokemon("Pikachu");
        string catalogoesperado = "Se ha removido el item curatotal\nSe ha prohibido a Pikachu para este combate";
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        Assert.That(catalogo, Is.EqualTo(catalogoesperado));
    }
}
