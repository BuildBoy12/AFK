namespace AFK
{
    using CommandSystem;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using RemoteAdmin;
    using System;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class AfkCmd : ICommand
    {
        public string Command => "afk";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Gives a player overwatch mode to prevent afk kicking";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                Player p = Player.Get(player.SenderId);
                if (!p.CheckPermission("afk"))
                {
                    response = "you should have access to this, dm me. TypicalIllusion#5726";
                    return false;
                }

                p.IsOverwatchEnabled = !p.IsOverwatchEnabled;
                response = p.IsOverwatchEnabled
                    ? "You have been set to overwatch mode.\nYou will not respawn."
                    : "You have been removed from overwatch mode.\nYou may now respawn.";
                return true;
            }

            response = "This command must be executed from the game level.";
            return false;
        }
    }
}