namespace AFK
{
    using CommandSystem;
    using Components;
    using Exiled.API.Features;
    using System;

    [CommandHandler(typeof(ClientCommandHandler))]
    public class AfkCmd : ICommand
    {
        public string Command => "afk";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Toggles overwatch on the user to prevent respawn.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get((sender as CommandSender)?.SenderId);
            var component = ply.GameObject.GetComponent<AfkComponent>();
            if (component == null)
            {
                ply.GameObject.AddComponent<AfkComponent>();
                response = "\nYou have been set to AFK mode. You will not respawn.";
            }
            else
            {
                component.Destroy();
                response = "\nYou have been removed from AFK mode. You may now respawn.";
            }

            return true;
        }
    }
}