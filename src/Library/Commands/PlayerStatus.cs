using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showplayerstatus' del bot.
/// Permite al jugador obtener el estado actual de su equipo Pokémon.
/// </summary>
// ReSharper disable once UnusedType.Global
public class PlayerStatusCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'Playerstatus'.
    /// </summary>
    [Command("Playerstatus")]
    [Summary(
        """
        Muestra el estado actual del equipo Pokémon del jugador
        que envía el comando.
        """)]
    public async Task ExecuteAsync()
    {
        try
        {
            string userName = CommandHelper.GetDisplayName(Context);;

            if (userName == Facade.Instance.JugadorA())
            {
                string status = Facade.Instance.ShowPlayerStatus();

                await ReplyAsync(status);
            }
            else
            {
                await ReplyAsync("No estás actualmente en una batalla o no es tu turno master");
            }
        }
        catch (Exception ex)
        {
            await ReplyAsync($"Ocurrió un error: {ex.Message}");
        }
    }
}