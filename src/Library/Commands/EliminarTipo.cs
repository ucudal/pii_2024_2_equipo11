using AdapterNamespace;
using static DefaultNamespace.Pokemon;
using Discord.Commands;
using Library.Combate;
using Ucu.Poo.DiscordBot.Domain;
using Library.Tipos;
using Ucu.Poo.Pokemon;
namespace Ucu.Poo.DiscordBot.Commands;

public class ElimimarTipo: ModuleBase<SocketCommandContext>
{
    [Command("removetype")]
    [Summary("Elimina un tipo de pokemon")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("Nombre del Tipo")] string tipo)
    {
        if (Facade.Instance.IsBattleOngoing())
        {
            await ReplyAsync("La batalla ya ha iniciado");
        }
        string userName = CommandHelper.GetDisplayName(Context);
        if (userName == Facade.Instance.JugadorA())
        {
            if (Facade.Instance.GetRTA())
            {
                await ReplyAsync(Facade.Instance.EliminarTipo(tipo));
            }
            await ReplyAsync("Un jugador no ha aceptado");
        }
        if (userName == Facade.Instance.JugadorD())
        {
            if (Facade.Instance.GetRTD())
            {
                await ReplyAsync(Facade.Instance.EliminarTipo(tipo));
            }
            await ReplyAsync("Un jugador no ha aceptado");
        }
    }
}