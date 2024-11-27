using System.Globalization;
using Microsoft.Extensions.Logging;
using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

// ReSharper disable once UnusedType.Global
public class RestringirTipos : ModuleBase<SocketCommandContext>
{
    [Command("restringirTipos")]
    [Summary("Elimina a todos los pokemones de un tipo para que no se puedan utilizar en esa batalla")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("Nombre del pokemon")] string tipo)
    {
        if (string.IsNullOrWhiteSpace(tipo))
        {
            await ReplyAsync("Use: !restringir <tipo>");
            return;
        }
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string resultado = textInfo.ToTitleCase(tipo.ToLower());
        
        string userName = CommandHelper.GetDisplayName(Context);
        string result = "";
        if (userName == Facade.Instance.JugadorA() || userName == Facade.Instance.JugadorD())
        {
            result += Facade.Instance.RestringeType(resultado);
        }
        if (result == "")
        {
            result += "No estás en la batalla";
        }
        // Envía el resultado al usuario
        await ReplyAsync(result);
    }
}