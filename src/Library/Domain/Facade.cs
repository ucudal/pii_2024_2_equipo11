using Library.Combate;
using Ucu.Poo.DiscordBot.ClasesUtilizadas.Reglas_Personalizadas;

namespace Ucu.Poo.DiscordBot.Domain;
//Clase de Facade cumple con SRP ya que tiene la única responsabilidad de manejar las funciones de menu que teníamos 
//para que se adapten al bot, también cumple con Expert ya que es la que tiene toda esa información para actuar de esa manera
//Cumple con OCP ya que está abierto a extensiones pero cerrado a modificaciones,
//ya que por ejemplo puedes adaptar nuevas funcionalidades de menu que añadas sin que esto afecte a lo que ya está hecho



/// <summary>
/// Esta clase recibe las acciones y devuelve los resultados que permiten
/// implementar las historias de usuario. Otras clases que implementan el bot
/// usan esta <see cref="Facade"/> pero no conocen el resto de las clases del
/// dominio. Esta clase es un singleton.
/// </summary>
public class Facade
{
    private static Facade? _instance;

    // Este constructor privado impide que otras clases puedan crear instancias
    // de esta.
    private Facade()
    {
        this.WaitingList = new WaitingList();
        this.BattlesList = new BattlesList();
        this.Menu = new Menu();
        this.ReglasPersonalizadas = new Reglas_Personalizadas();

    }

    /// <summary>
    /// Obtiene la única instancia de la clase <see cref="Facade"/>.
    /// </summary>
    public static Facade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Facade();
            }

            return _instance;
        }
    }
    /// <summary>
    /// Metodo para poder acceder a la instancia de menu
    /// </summary>
    public Menu GetMenu()
    {
        return Menu;
    }

    /// <summary>
    /// Inicializa este singleton. Es necesario solo en los tests.
    /// </summary>
    public static void Reset()
    {
        _instance = null;
    }
    
    private WaitingList WaitingList { get; }
    
    private BattlesList BattlesList { get; }
    public Menu Menu { get; private set; }
    
    public Reglas_Personalizadas ReglasPersonalizadas { get; set; }

    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string AddTrainerToWaitingList(string displayName)
    {
        if (this.WaitingList.AddTrainer(displayName))
        {
            return $"{displayName} agregado a la lista de espera";
        }
        return $"{displayName} ya está en la lista de espera";
    }

    /// <summary>
    /// Remueve un jugador de la lista de espera.
    /// </summary>
    /// <param name="displayName">El jugador a remover.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string RemoveTrainerFromWaitingList(string displayName)
    {
        if (this.WaitingList.RemoveTrainer(displayName))
        {
            return $"{displayName} removido de la lista de espera";
        }
        else
        {
            return $"{displayName} no está en la lista de espera";
        }
    }

    /// <summary>
    /// Obtiene la lista de jugadores esperando.
    /// </summary>
    /// <returns>Un mensaje con el resultado.</returns>
    public string GetAllTrainersWaiting()
    {
        if (this.WaitingList.Count == 0)
        {
            return "No hay nadie esperando";
        }

        string result = "Esperan: ";
        foreach (Trainer trainer in this.WaitingList.GetAllWaiting())
        {
            result = result + trainer.DisplayName + "; ";
        }
        
        return result;
    }

    /// <summary>
    /// Determina si un jugador está esperando para jugar.
    /// </summary>
    /// <param name="displayName">El jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string TrainerIsWaiting(string displayName)
    {
        Trainer? trainer = this.WaitingList.FindTrainerByDisplayName(displayName);
        if (trainer == null)
        {
            return $"{displayName} no está esperando";
        }
        
        return $"{displayName} está esperando";
    }


    private string CreateBattle(string playerDisplayName, string opponentDisplayName)
    {
        // Aunque playerDisplayName y opponentDisplayName no estén en la lista
        // esperando para jugar los removemos igual para evitar preguntar si
        // están para luego removerlos.
        this.WaitingList.RemoveTrainer(playerDisplayName);
        this.WaitingList.RemoveTrainer(opponentDisplayName);
        
        BattlesList.AddBattle(playerDisplayName, opponentDisplayName);
        return $"Comienza {playerDisplayName} vs {opponentDisplayName}";
    }

    /// <summary>
    /// Crea una batalla entre dos jugadores.
    /// </summary>
    /// <param name="playerDisplayName">El primer jugador.</param>
    /// <param name="opponentDisplayName">El oponente.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string StartBattle(string playerDisplayName, string? opponentDisplayName)
    {
        Menu = new Menu();
        //Une a los jugadores a la partida de manera aleatoria
        string result = this.Menu.UnirJugadores(playerDisplayName);
        result += "\n" + this.Menu.UnirJugadores(opponentDisplayName);
        // El símbolo ? luego de Trainer indica que la variable opponent puede
        // referenciar una instancia de Trainer o ser null.
        Trainer? opponent;

        if (!OpponentProvided() && !SomebodyIsWaiting())
        {
            return "No hay nadie esperando";
        }

        if (!OpponentProvided()) // && SomebodyIsWaiting
        {
            opponent = this.WaitingList.GetAnyoneWaiting();

            // El símbolo ! luego de opponent indica que sabemos que esa
            // variable no es null. Estamos seguros porque SomebodyIsWaiting
            // retorna true si y solo si hay usuarios esperando y en tal caso
            // GetAnyoneWaiting nunca retorna null.
            return this.CreateBattle(playerDisplayName, opponent!.DisplayName);
        }

        // El símbolo ! luego de opponentDisplayName indica que sabemos que esa
        // variable no es null. Estamos seguros porque OpponentProvided hubiera
        // retorna false antes y no habríamos llegado hasta aquí.
        opponent = this.WaitingList.FindTrainerByDisplayName(opponentDisplayName!);

        if (!OpponentFound())
        {
            return $"{opponentDisplayName} no está esperando";
        }

        return this.CreateBattle(playerDisplayName, opponent!.DisplayName) + "\n" + result;

        // Funciones locales a continuación para mejorar la legibilidad

        bool OpponentProvided()
        {
            return !string.IsNullOrEmpty(opponentDisplayName);
        }

        bool SomebodyIsWaiting()
        {
            return this.WaitingList.Count != 0;
        }

        bool OpponentFound()
        {
            return opponent != null;
        }
    }
    public string InitializeBattle()
    {
        if (GetReglasPersonalizadas() == "")
        {
            return "Alguno debe asignar unas reglas primero o elegir las reglas convencionales para empezar la batalla";
        }
        return this.Menu.IniciarEnfrentamiento();
    }

    public string UsePokemonMove(int moveIndex)
    {
        return this.Menu.UsarMovimientos(moveIndex);
    }

    public string ShowAvailableMoves()
    {
        return this.Menu.MostrarAtaquesDisponibles();
    }

    public string ChangePokemon(int pokemonIndex)
    {
        return this.Menu.CambiarPokemon(pokemonIndex);
    }

    public string ShowPlayerStatus()
    {
        return this.Menu.MostrarEstadoEquipo();
    }

    public string ShowOpponentStatus()
    {
        return this.Menu.MostrarEstadoRival();
    }

    public bool IsBattleOngoing()
    {
        return this.Menu.GetBatallaI() && !this.Menu.GetBatallaT();
    }
    public string AddPokemosA(string pokemon)
    {
        return this.Menu.AgregarPokemonesA(pokemon);
    }
    public string JugadorA()
    {
        return Menu.JugadorA().GetName();
    }
    public string AddPokemosD(string pokemon)
    {
        return this.Menu.AgregarPokemonesD(pokemon);
    }
    public string JugadorD()
    {
        return Menu.JugadorD().GetName();
    }
    
    public string ShowPokemonNum()
    {
        return this.Menu.MostrarNumPokemon();
    }

    public string ShowAviableItems()
    {
        return this.Menu.MostrarItemsDisponibles();
    }

    public string ShowCatolog()
    {
        return Menu.MostrarCatalogo();
    }

    public string UseItem(string item, int numeroPokemon)
    {
        return this.Menu.UsarItem(item, numeroPokemon);
    }
    public string ShowAtualPokemonA()
    {
        return Menu.GetNamePokemonA();
    }
    
    public string ShowAtualPokemonD()
    {
        return Menu.GetNamePokemonD();
    }
    
    /// <summary>
    /// Con este metodo accedo al atributo reglaspersonalizadas que a traves de un metodo en su clase trae las reglas y en este metodo las ordeno para mostrarsela a los jugadores
    /// </summary>
    public string GetReglasPersonalizadas()
    {
        string texto = "";
        int num = 0;
        foreach (string regla in ReglasPersonalizadas.GetReglas())
        {
            num += 1;
            texto += $"{num}.{regla}\n";
        }

        return texto;
    }
    
    /// <summary>
    /// Metodo que verifica que si las reglas estan vacias, el usuario puede usar las reglas convencionales
    /// </summary>
    public string SetReglasConvencionales()
    {
        if (GetReglasPersonalizadas()=="")
        {
            ReglasPersonalizadas.ReglasConvencionales();
            ReglasPersonalizadas.GetReglas();
            return GetReglasPersonalizadas();
        }

        return $"Ya hay reglas elegidas";
    }
    /// <summary>
    /// metodo para prohibir pokemons antes de comenzar la batalla
    /// </summary>
    public string SetReglasProhibirPokemons(string pokemon)
    {
        if (IsBattleOngoing())
        {
            return "Ya empezo la batalla";
        }
        return ReglasPersonalizadas.EliminarPokemon(pokemon);
    }
    /// <summary>
    /// metodo para permitir solo un tipo antes de comnezar la batalla
    /// </summary>
    public string SetReglaSoloUnTipo(string tipo)
    {
        if (IsBattleOngoing())
        {
            return "Ya empezo la batalla";
        }
        return ReglasPersonalizadas.SoloUnTipo(tipo);
    }
    /// <summary>
    /// metodo para prohibir un item eliminandolo en la instancia de esta batalla antes de que comience, luego en otra instancia el item vuelve a aparacer
    /// </summary>
    public string SetReglaProhibirItem(string item)
    {
        if (IsBattleOngoing())
        {
            return "Ya empezo la batalla";
        }
        return ReglasPersonalizadas.EliminarItems(item);
    }

    /// <summary>
    /// metodo para prohibir un tipo antes de que comience la batalla
    /// </summary>
    public string SetReglaProhibirTipo(string tipo)
    {
        if (IsBattleOngoing())
        {
            return "Ya empezo la batalla";
        }
        return ReglasPersonalizadas.EliminarTipo(tipo);
    }
    
}