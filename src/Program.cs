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
            Console.WriteLine("--------------------------------------------------------------");
            Menu juego3 = new Menu();
            juego3.UnirJugadores("Red");
            juego3.UnirJugadores("Ash");
            juego3.AgregarPokemonesA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
            juego3.AgregarPokemonesD("Charmander");
            juego3.AgregarPokemonesA("Bulbasaur");//Bulbasaur era el segundo pokemon del equipo
            juego3.MostrarEstadoEquipo();
            juego3.MostrarEstadoRival();
           
        }
        
    }
}