using Library.Combate;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.ClasesUtilizadas.Reglas_Personalizadas;
/// <summary>
/// Esta clase la uso para poder implementar las reglas_personalizadas que cada jugador decide, decidi crear una clase aparte ya que facade es una clase que ya esta muy cargada cumpliendo con varias responsabilidades,
/// por lo tanto para respetar SRP cree esta clase, ademas respeta el OCP ya que si quiero agregar otro detalles a las reglas tengo que modificar esta clase u agregar una nueva en vez de modificar mas a facade generando un mayor
/// acoplamiento y baja cohesion
/// </summary>
public class Reglas_Personalizadas
{
    
    public List<string> reglas;
    
    private static Reglas_Personalizadas? instance;
    
    public static Reglas_Personalizadas Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Reglas_Personalizadas();
            }

            return instance;
        }
    }
    public static void Reset()
    {
        instance = null;
    }
    /// <summary>
    /// Lamentablemente no tuve tiempo para completar la defensa, puediendo lograr solo crear la regla de eliminar un item en una instancia de batalla, su hubiera tenido mas tiempo lo que hubiera hecho seria,
    /// dentro de cada metodo como por ejemplo "EliminarPokemon" seria crear una ruta para acceder a Pokedex respetando Demeter y acceder a su lista a traves de un metodo de Pokedex para copiarla y modificarla
    /// eliminando ese Pokemon para que luego crear una ruta para cuando el metodo agregarpokemon en jugador acceda a esa lista en vez de la lista de Pokedex. Tampoco tuve tiempo para solucionar los tests por problemas de
    /// instancias
    /// </summary>
    public string EliminarPokemon(string pokemon)
    {
        
        reglas.Add($"{pokemon} eliminado de los pokemones");
        return "regla añadida";
    }

    public string EliminarTipo(string tipo)
    {
        reglas.Add($"{tipo} eliminado de los tipos");
        return "regla añadida";
    }

    public string SoloUnTipo(string tipo)
    {
        reglas.Add($"solo tipo {tipo} se puede usar");
        return "regla añadida";
    }

    public string EliminarItems(string item)
    {
        GetMenu().EliminarItem(item);
        reglas.Add($"{item} eliminado de los items");
        return "regla añadida";
    }
    

    public List<string> GetReglas()
    {
        return this.reglas;
    }

    public void ReglasConvencionales()
    {
        this.reglas.Add("Todos los tipos");
        this.reglas.Add("Todos los pokemons");
        this.reglas.Add("Todos los items");
    }

    public Menu GetMenu()
    {
        return Facade.Instance.GetMenu();
    }
    
}