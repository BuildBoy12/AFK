namespace AFK
{
    using CommandSystem;
    using Exiled.API.Features;
    using System;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class AfkCmd : ICommand
    {
        public string Command => "afk";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Gives a player overwatch mode to prevent afk kicking";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get((sender as CommandSender)?.SenderId);
            ply.IsOverwatchEnabled = !ply.IsOverwatchEnabled;
            response = ply.IsOverwatchEnabled
                ? "You have been set to overwatch mode.\nYou will not respawn."
                : "You have been removed from overwatch mode.\nYou may now respawn.";
            return true;
        }
    }
}