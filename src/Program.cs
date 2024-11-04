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
            // Arrange
            int dañoPorAtaque = 95; // Daño de rayo
            int defensaCharmander = 60; // Defensa de Charmander
            int hpCharmanderEsperado = 80; // Charmander debe iniciar con 80 de HP
            int vidaCharmanderRestanteEsperada = hpCharmanderEsperado - (dañoPorAtaque - defensaCharmander); // Calculamos vida restante de Charmander
            int vidaPidgeyEsperada = 60; // Pidgey debería iniciar con 60 HP

            Menu menuPP = new Menu();
            menuPP.AgregarPokemonesA("Pidgey"); // Pidgey es el segundo Pokémon
            menuPP.AgregarPokemonesD("Pikachu"); // Pikachu es el primero
            menuPP.AgregarPokemonesA("Charmander"); // Charmander es el segundo Pokémon también
            menuPP.CambiarPokemon(1); // Cambia a Charmander
            menuPP.UsarMovimientos(1); // Pikachu usa rayo

            // Assert
            Console.WriteLine(vidaPidgeyEsperada);
            Console.WriteLine(menuPP.GetHpAtacante());
            Console.WriteLine(vidaCharmanderRestanteEsperada);
            Console.WriteLine();
            menuPP.MostrarEstadoRival();
            menuPP.MostrarEstadoEquipo();
        }
        
    }
}