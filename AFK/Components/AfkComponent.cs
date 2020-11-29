namespace AFK.Components
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
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
            PlayerEvents.ChangingRole += OnChangingRole;
            ServerEvents.RespawningTeam += OnRespawningTeam;
        }

        private void Update()
        {
            if (_ply == null)
                Destroy();
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            ev.NewRole = RoleType.Spectator;
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            ev.Players.Remove(_ply);
        }

        public void Destroy()
        {
            PlayerEvents.ChangingRole -= OnChangingRole;
            ServerEvents.RespawningTeam -= OnRespawningTeam;
            Destroy(this);
        }
    }
}