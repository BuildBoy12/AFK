namespace AFK.Components
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using UnityEngine;
    using PlayerEvents = Exiled.Events.Handlers.Player;
    using ServerEvents = Exiled.Events.Handlers.Server;

    public class AfkComponent : MonoBehaviour
    {
        private Player _ply;

        private void Awake()
        {
            _ply = Player.Get(gameObject);
            _ply.Role = RoleType.Spectator;
            PlayerEvents.Spawning += OnSpawning;
            ServerEvents.RespawningTeam += OnRespawningTeam;
        }

        private void Update()
        {
            if (_ply == null)
                Destroy();
        }

        public void OnSpawning(SpawningEventArgs ev)
        {
            Timing.CallDelayed(0.3f, () =>
            {
                _ply.ClearInventory();
                _ply.Role = RoleType.Spectator;
            });
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            ev.Players.Remove(_ply);
        }

        public void Destroy()
        {
            PlayerEvents.Spawning -= OnSpawning;
            ServerEvents.RespawningTeam -= OnRespawningTeam;
            Destroy(this);
        }
    }
}