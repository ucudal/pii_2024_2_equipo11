using System.Globalization;
using Microsoft.Extensions.Logging;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

// ReSharper disable once UnusedType.Global
public class RestringirPokemon : ModuleBase<SocketCommandContext>
{
    [Command("restringirPokemon")]
    [Summary("Elimina un item para que no se pueda utilizar en esa batalla")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("Nombre del pokemon")] string pokemon)
    {
        if (string.IsNullOrWhiteSpace(pokemon))
        {
            await ReplyAsync("Use: !restringir <nombrepokemon>");
            return;
        }
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string resultado = textInfo.ToTitleCase(pokemon.ToLower());
        
        string userName = CommandHelper.GetDisplayName(Context);
        string result = "";
        if (userName == Facade.Instance.JugadorA() || userName == Facade.Instance.JugadorD())
        {
            result += Facade.Instance.RestringePokemon(resultado);
        }
        if (result == "")
        {
            result += "No estás en la batalla";
        }
        // Envía el resultado al usuario
        await ReplyAsync(result);
    }
}