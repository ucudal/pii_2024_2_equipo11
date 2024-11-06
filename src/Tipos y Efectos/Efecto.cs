using DefaultNamespace;

namespace Library.Tipos;

public abstract class Efecto
{
    protected Efecto()
    {
        
    }

    public virtual void HacerEfecto(Pokemon pokemon)
    {
        
    }
    public static Efecto CrearCopia(Type tipoEfecto)
    {
        // Usamos Activator para crear una instancia del tipo de efecto
        return (Efecto)Activator.CreateInstance(tipoEfecto);
    }

}