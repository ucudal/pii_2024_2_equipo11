namespace DefaultNamespace;

public interface IPokemon: 
{
    string name;
    List<IMovimiento> lista_movimientos;

    List<ITipo> tipos;
    int vida_actual;
    int vida_total;
    int ataque;
    int defensa;
    bool is_alive;
    public void UsarMovimiento(IMovimiento movimiento);
    public void RecibirAtaque(IMovimiento movimiento);
}