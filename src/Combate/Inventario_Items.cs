using DefaultNamespace;
using Ucu.Poo.Pokemon;

namespace Library.Combate;
public class Inventario_Items
{
    private Dictionary<string, Item> items;

    public Inventario_Items()
    {
        items = new Dictionary<string, Item>
        {
            { "SuperPocion", new Super_Pocion(4) },
            { "Revivir", new Revivir(1) },
            { "CuraTotal", new Cura_Total(2) }
        };
    }

    public void MostrarItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Key}: {item.Value.Cantidad} disponibles");
        }
    }

    public void UsarItem(string nombre, Pokemon pokemon)
    {
        if (items.ContainsKey(nombre) && items[nombre].Cantidad > 0)
        {
            items[nombre].AplicarEfecto(pokemon);
            items[nombre].Cantidad--;
        }
        Console.WriteLine("Ítem no disponible o cantidad insuficiente.");
        
    }
}
