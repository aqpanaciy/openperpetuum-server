using Perpetuum.EntityFramework;
using Perpetuum.Zones.NpcSystem.AI.Behaviors;
using System;

namespace Perpetuum.Zones.NpcSystem.Flocks
{
    public interface IFlockConfiguration
    {
        int ID { get; }

        int PresenceID { get; }

        double RespawnMultiplierLow { get; }

        int HomeRange { get; }

        TimeSpan RespawnTime { get; }

        int FlockMemberCount { get; }

        int TotalSpawnCount { get; }

        string Name { get; }

        bool Enabled { get; }

        IntRange SpawnRange { get; }

        EntityDefault EntityDefault { get; }

        Position SpawnOrigin { get; }

        string Note { get; }

        bool IsCallForHelp { get; }

        BehaviorType BehaviorType { get; }

        NpcSpecialType SpecialType { get; }

        NpcBossInfo BossInfo { get; }
    }
}