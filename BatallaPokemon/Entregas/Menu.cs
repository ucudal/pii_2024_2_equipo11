namespace DefaultNamespace;

public class Menu
{
    private Batalla batallaActual { get; set; }

    public void AgregarAlEquipo(IPokemon pokemon)
    {
        //En este metodo se agregan pokemons al equipo de un jugador accediendo a la lista de pokemons del mismo, siempre se tienen que agregar 6 para comenzar la batalla
        
        //AGREGAMOS UN METODO EN JUGADOR PARA AGREGAR POKEMONS A SU EQUIPO??? asi dejamosen privado la lista
    }
    
    pulic void IniciarEnfrentamiento()
    {
        //NO ES LO MISMO QUE INICIAR BATALLA EN BATALLA??
    }

    public void MostrarEstadoRival()
    {
        //con este metodo el jugador del turno puede ver el estado de vida de los pokemons del equipo rival sin perder su turno
    }

    public void MostrarEstadoEquipo()
    {
        //con este metodo el jugador del turno puede ver el estado de vida de los pokemons de su equipo sin perder el turno
    }

    public void CambiarPokemon(IPokemon pokemon)
    {
        //Con este metodo el jugador puede cambiar el pokemon que esta en uso por otro de su equipo a traves del metodo de Jugador "CambiarPokemonEnTurno" y pierde su turno al hacerlo.
    }

    public void MostrarAtaquesDisponibles()
    {
        //con este metodo se activa el metodo "MostarAtaquesDisponibles" de Jugador para mostar los atques disponibles que el jugador tiene de cada pokemon de su equipo que se encuentre vivo.
    }

    public void UsarMovimientos()
    {
        
    }
    //podriamos poner un input en el que le damos todas estas opciones al jugador y el elige una de ellas y coloca su  letra corresponndiente, por ejemplo si quiere mostar estedo del rival que 
    //escriba una "m"y si uiere cambiar de pokeon que escriba una "c" IDEAAAAAAAAAAAAAAA LEERLAAAAAAAAAAAAAAA
}