using DefaultNamespace;
using Library.Combate;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Agrego6Pokemons()
    {
        Menu juego4 = new Menu();
        juego4.UnirJugadores("Don Dimadon");
        juego4.AgregarPokemonesA("Charmander");
        juego4.AgregarPokemonesA("Squirtle");
        juego4.AgregarPokemonesA("Bulbasaur");
        juego4.AgregarPokemonesA("Dratini");
        juego4.AgregarPokemonesA("Arbok");
        List<Pokemon> listadada = juego4.GetPokemonsAtacante();
        List<string> listadadaAstring = new List<string>();
        foreach (Pokemon pokemon in listadada)
        {
            listadadaAstring.Add(pokemon.GetName());
        }
        List<string> listaesperada = new List<string>
        {
            "Charmander",
            "Squirtle",
            "Bulbasaur",
            "Dratini",
            "Arbok"
        };

        foreach (string nombre in listaesperada)
        {
            Assert.That(listadadaAstring, Does.Contain(nombre));
        }
        
        // CollectionAssert.AreEqual(listaesperada,listadadaAstring);
    }
}