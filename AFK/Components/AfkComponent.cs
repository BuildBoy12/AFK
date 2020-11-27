namespace AFK.Components
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using UnityEngine;
    using ServerEvents = Exiled.Events.Handlers.Server;

    public class AfkComponent : MonoBehaviour
    {
        private Player _ply;

        private void Awake()
        {
            _ply = Player.Get(gameObject);
            _ply.Role = RoleType.Spectator;
            ServerEvents.RespawningTeam += OnRespawningTeam;
        }

        private void Update()
        {
            if (_ply == null)
                Destroy();
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.Players.Contains(_ply))
                ev.Players.Remove(_ply);
        }

        public void Destroy()
        {
            ServerEvents.RespawningTeam -= OnRespawningTeam;
            Destroy(this);
        }
    }
}