﻿using Perpetuum.Zones.NpcSystem.Presences;

namespace Perpetuum.Zones.NpcSystem.Flocks
{
    /// <summary>
    /// This Flock is to be used with the DynamicePresenceExtended class to take advantage of a settable spawn location separate from its HomePosition
    /// </summary>
    public class RemoteSpawningFlock : Flock
    {
        public RemoteSpawningFlock(IFlockConfiguration configuration, Presence presence) : base(configuration, presence)
        {
        }

        protected override Position GetSpawnPosition(Position spawnOrigin)
        {
            if (Presence is DynamicPresenceExtended presence)
            {
                spawnOrigin = presence.SpawnLocation.Clamp(Presence.Zone.Size);
            }
            return base.GetSpawnPosition(spawnOrigin);
        }

        protected override Position GetHomePosition(Position spawnOrigin)
        {
            if (Presence is DynamicPresenceExtended presence)
            {
                spawnOrigin = presence.DynamicPosition.Clamp(Presence.Zone.Size);
            }
            return base.GetSpawnPosition(spawnOrigin);
        }
    }
}
