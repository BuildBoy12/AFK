namespace AFK
{
    using Exiled.API.Features;
    using System;

    public class Afk : Plugin<Config>
    {
        public override Version RequiredExiledVersion => new Version(2, 1, 18);
        public override Version Version => new Version(1, 0, 0);
    }
}