using AdapterNamespace;
using static DefaultNamespace.Pokemon;
using Discord.Commands;
using Library.Combate;
using Ucu.Poo.DiscordBot.Domain;
using Library.Tipos;
using Ucu.Poo.Pokemon;
namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'useitem' del bot.
/// Permite al jugador usar items para sus pokemons durante la batalla
/// usando un turno
/// </summary>
// ReSharper disable once UnusedType.Global
public class UseItem: ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando "useitem"
    /// este comando permite usar items durante la batalla
    /// </summary>
    /// <param name="item">el item a usar</param>
    /// <param name="pokemon">pokemon que recibe el item</param>
    [Command("useitem")]
    [Summary("Usa un item disponible del jugador en el pokemon elegido segun su numero")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Summary("Nombre del Item")] string item, 
        [Remainder][Summary("Nombre del Item")] int pokemon)
    {
        try
        {
            string nameplayer =  CommandHelper.GetDisplayName(Context);
            if (nameplayer == Facade.Instance.JugadorA())
            {
                await ReplyAsync(Facade.Instance.UseItem(item.ToLower(), pokemon));
            }
            else
            {
                await ReplyAsync("No es tu turno capo, no te toca");
            }
        }
        catch (FormatException ex)
        {
            await ReplyAsync("El formato de la cadena no es válido.");
        }
    }
}