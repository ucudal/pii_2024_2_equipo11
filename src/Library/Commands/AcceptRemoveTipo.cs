using AdapterNamespace;
using static DefaultNamespace.Pokemon;
using Discord.Commands;
using Library.Combate;
using Ucu.Poo.DiscordBot.Domain;
using Library.Tipos;
using Ucu.Poo.Pokemon;
namespace Ucu.Poo.DiscordBot.Commands;

public class AcceptRTipo: ModuleBase<SocketCommandContext>
{
    [Command("acceptremoveT")]
    [Summary("AceptaEliminar un tipo")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        if (Facade.Instance.IsBattleOngoing())
        {
            await ReplyAsync("La batalla ya ha iniciado");
        }
        string userName = CommandHelper.GetDisplayName(Context);
        if (userName == Facade.Instance.JugadorA())
        {
            Facade.Instance.SetRTA();
        }
        if (userName == Facade.Instance.JugadorD())
        {
            Facade.Instance.SetRTD();
        }
    }
}