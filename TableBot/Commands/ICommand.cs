using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableBot.Commands
{
    internal interface ICommand
    {
        Task HandleCommand(SocketSlashCommand command);
        SlashCommandBuilder SlashCommandBuilder();
        string GetCommandName();
    }
}
