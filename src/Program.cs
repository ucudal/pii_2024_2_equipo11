using DefaultNamespace;
using Library.Combate;
using Library.Tipos;
using Ucu.Poo.Pokemon;
namespace Ucu.Poo.Pokemon
//En esta clase creamos los personajes, realizamos las acciones e imprimimos el estado de los personajes para obvservar si las
//demas clases funcionan efectivamente.
{
    class Program
    {
        static void Main(string[] args)
        {
            int dañoPorAtaque = 95 / 2 ;
            int defensaBulbasaur = 70; 
            int hpBulbasaurEsperado = 90;
            int vidabulbasaurRestanteEsperada = 90; // Sabemos que no alzcanza para romper su defensa
            int vidatortugaEsperada = 80; 

            Menu menuPP = new Menu();
            menuPP.UnirJugadores("Ash");
            menuPP.UnirJugadores("Red");
            menuPP.AgregarPokemonesA("Squirtle"); 
            menuPP.AgregarPokemonesD("Pikachu"); 
            menuPP.AgregarPokemonesA("Bulbasaur"); 
            Console.WriteLine(menuPP.GetPokemonActual().GetName());
            menuPP.CambiarPokemon(1); // Cambia a bulbasaur
            Console.WriteLine(menuPP.GetPokemonActual().GetName());
            menuPP.UsarMovimientos(1);
            Console.WriteLine($"El que ataca ahora es {menuPP.GetPokemonActual().GetName()}"); //El que ataca es
            Console.WriteLine(menuPP.GetHpDefensor());

        }
        
    }
}