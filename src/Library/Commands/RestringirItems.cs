using System.Globalization;
using Microsoft.Extensions.Logging;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon' del bot.
/// Este comando permite a los jugadores agregar un Pokémon a su equipo.
/// </summary>
// ReSharper disable once UnusedType.Global
public class RestringirItems : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'restringiritem'. Este comando permite eliminar un item de toda la batalla.
    /// </summary>
    /// <param name="ItemName">El nombre del Item a eliminar.</param>
    [Command("restringiritems")]
    [Summary("Elimina un item para que no se pueda utilizar en esa batalla")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("Nombre del item")] string item)
    {
        if (string.IsNullOrWhiteSpace(item))
        {
            await ReplyAsync("Use: !restringir <nombreitem>");
            return;
        }
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string resultado = textInfo.ToTitleCase(item.ToLower());
        
        string userName = CommandHelper.GetDisplayName(Context);
        string result = "";
        if (userName == Facade.Instance.JugadorA() || userName == Facade.Instance.JugadorD())
        {
            result += Facade.Instance.RestringeItem(resultado);
        }
        if (result == "")
        {
            result += "No estás en la batalla";
        }
        // Envía el resultado al usuario
        await ReplyAsync(result);
    }
}