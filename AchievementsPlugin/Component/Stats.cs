using Rocket.API;
using Rocket.Core.Logging;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace AchievementsPlugin
{
    [Serializable]
    public class Stats : IDefaultable
    {
        public int NONE { get; set; }
        public int KILLS_ZOMBIES_NORMAL { get; set; }
        public int KILLS_PLAYERS { get; set; }
        public int FOUND_ITEMS { get; set; }
        public int FOUND_RESOURCES { get; set; }
        public int FOUND_EXPERIENCE { get; set; }
        public int KILLS_ZOMBIES_MEGA { get; set; }
        public int DEATHS_PLAYERS { get; set; }
        public int KILLS_ANIMALS { get; set; }
        public int FOUND_CRAFTS { get; set; }
        public int FOUND_FISHES { get; set; }
        public int FOUND_PLANTS { get; set; }
        public int ACCURACY { get; set; }
        public int HEADSHOTS { get; set; }
        public int TRAVEL_FOOT { get; set; }
        public int TRAVEL_VEHICLE { get; set; }
        public int ARENA_WINS { get; set; }
        public int FOUND_BUILDABLES { get; set; }
        public int FOUND_THROWABLES { get; set; }

        public int NONE_Progress { get; set; }
        public int KILLS_ZOMBIES_NORMAL_Progress { get; set; }
        public int KILLS_PLAYERS_Progress { get; set; }
        public int FOUND_ITEMS_Progress { get; set; }
        public int FOUND_RESOURCES_Progress { get; set; }
        public int FOUND_EXPERIENCE_Progress { get; set; }
        public int KILLS_ZOMBIES_MEGA_Progress { get; set; }
        public int DEATHS_PLAYERS_Progress { get; set; }
        public int KILLS_ANIMALS_Progress { get; set; }
        public int FOUND_CRAFTS_Progress { get; set; }
        public int FOUND_FISHES_Progress { get; set; }
        public int FOUND_PLANTS_Progress { get; set; }
        public int ACCURACY_Progress { get; set; }
        public int HEADSHOTS_Progress { get; set; }
        public int TRAVEL_FOOT_Progress { get; set; }
        public int TRAVEL_VEHICLE_Progress { get; set; }
        public int ARENA_WINS_Progress { get; set; }
        public int FOUND_BUILDABLES_Progress { get; set; }
        public int FOUND_THROWABLES_Progress { get; set; }

        public ulong SteamID { get; set; } = 0;

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public DateTime Created { get; set; } = DateTime.Now;

        public int TimeSpentOnServerSeconds { get; set; }

        public DateTime JoinTime { get; set; }


        public void SetSteamId(ulong steamID)
        {
            this.SteamID = steamID;
        }

        public int IncrementStat(EPlayerStat stat)
        {
            LastUpdated = DateTime.Now;

            switch (stat)
            {
                case EPlayerStat.KILLS_ZOMBIES_NORMAL:
                    return ++KILLS_ZOMBIES_NORMAL;
                case EPlayerStat.KILLS_PLAYERS:
                    return ++KILLS_PLAYERS;
                case EPlayerStat.FOUND_ITEMS:
                    return ++FOUND_ITEMS;
                case EPlayerStat.FOUND_RESOURCES:
                    return ++FOUND_RESOURCES;
                case EPlayerStat.FOUND_EXPERIENCE:
                    return ++FOUND_EXPERIENCE;
                case EPlayerStat.KILLS_ZOMBIES_MEGA:
                    return ++KILLS_ZOMBIES_MEGA;
                case EPlayerStat.DEATHS_PLAYERS:
                    return ++DEATHS_PLAYERS;
                case EPlayerStat.KILLS_ANIMALS:
                    return ++KILLS_ANIMALS;
                case EPlayerStat.FOUND_CRAFTS:
                    return ++FOUND_CRAFTS;
                case EPlayerStat.FOUND_FISHES:
                    return ++FOUND_FISHES;
                case EPlayerStat.FOUND_PLANTS:
                    return ++FOUND_PLANTS;
                case EPlayerStat.ACCURACY:
                    return ++ACCURACY;
                case EPlayerStat.HEADSHOTS:
                    return ++HEADSHOTS;
                case EPlayerStat.TRAVEL_FOOT:
                    return ++TRAVEL_FOOT;
                case EPlayerStat.TRAVEL_VEHICLE:
                    return ++TRAVEL_VEHICLE;
                case EPlayerStat.ARENA_WINS:
                    return ++ARENA_WINS;
                case EPlayerStat.FOUND_BUILDABLES:
                    return ++FOUND_BUILDABLES;
                case EPlayerStat.FOUND_THROWABLES:
                    return ++FOUND_THROWABLES;
                default:
                    throw new ArgumentException("Invalid stat value.", nameof(stat));
            }

        }

        public int GetStatCount(EPlayerStat stat)
        {
            switch (stat)
            {
                case EPlayerStat.KILLS_ZOMBIES_NORMAL:
                    return KILLS_ZOMBIES_NORMAL;
                case EPlayerStat.KILLS_PLAYERS:
                    return KILLS_PLAYERS;
                case EPlayerStat.FOUND_ITEMS:
                    return FOUND_ITEMS;
                case EPlayerStat.FOUND_RESOURCES:
                    return FOUND_RESOURCES;
                case EPlayerStat.FOUND_EXPERIENCE:
                    return FOUND_EXPERIENCE;
                case EPlayerStat.KILLS_ZOMBIES_MEGA:
                    return KILLS_ZOMBIES_MEGA;
                case EPlayerStat.DEATHS_PLAYERS:
                    return DEATHS_PLAYERS;
                case EPlayerStat.KILLS_ANIMALS:
                    return KILLS_ANIMALS;
                case EPlayerStat.FOUND_CRAFTS:
                    return FOUND_CRAFTS;
                case EPlayerStat.FOUND_FISHES:
                    return FOUND_FISHES;
                case EPlayerStat.FOUND_PLANTS:
                    return FOUND_PLANTS;
                case EPlayerStat.ACCURACY:
                    return ACCURACY;
                case EPlayerStat.HEADSHOTS:
                    return HEADSHOTS;
                case EPlayerStat.TRAVEL_FOOT:
                    return TRAVEL_FOOT;
                case EPlayerStat.TRAVEL_VEHICLE:
                    return TRAVEL_VEHICLE;
                case EPlayerStat.ARENA_WINS:
                    return ARENA_WINS;
                case EPlayerStat.FOUND_BUILDABLES:
                    return FOUND_BUILDABLES;
                case EPlayerStat.FOUND_THROWABLES:
                    return FOUND_THROWABLES;
                default:
                    throw new ArgumentException("Invalid stat value.", nameof(stat));
            }
        }

        // Method to update progress for a specific property
        public void SetProgress(string propertyName, int value)
        {
            switch (propertyName)
            {
                case "NONE":
                    NONE_Progress = value;
                    break;
                case "KILLS_ZOMBIES_NORMAL":
                    KILLS_ZOMBIES_NORMAL_Progress = value;
                    break;
                case "KILLS_PLAYERS":
                    KILLS_PLAYERS_Progress = value;
                    break;
                case "FOUND_ITEMS":
                    FOUND_ITEMS_Progress = value;
                    break;
                case "FOUND_RESOURCES":
                    FOUND_RESOURCES_Progress = value;
                    break;
                case "FOUND_EXPERIENCE":
                    FOUND_EXPERIENCE_Progress = value;
                    break;
                case "KILLS_ZOMBIES_MEGA":
                    KILLS_ZOMBIES_MEGA_Progress = value;
                    break;
                case "DEATHS_PLAYERS":
                    DEATHS_PLAYERS_Progress = value;
                    break;
                case "KILLS_ANIMALS":
                    KILLS_ANIMALS_Progress = value;
                    break;
                case "FOUND_CRAFTS":
                    FOUND_CRAFTS_Progress = value;
                    break;
                case "FOUND_FISHES":
                    FOUND_FISHES_Progress = value;
                    break;
                case "FOUND_PLANTS":
                    FOUND_PLANTS_Progress = value;
                    break;
                case "ACCURACY":
                    ACCURACY_Progress = value;
                    break;
                case "HEADSHOTS":
                    HEADSHOTS_Progress = value;
                    break;
                case "TRAVEL_FOOT":
                    TRAVEL_FOOT_Progress = value;
                    break;
                case "TRAVEL_VEHICLE":
                    TRAVEL_VEHICLE_Progress = value;
                    break;
                case "ARENA_WINS":
                    ARENA_WINS_Progress = value;
                    break;
                case "FOUND_BUILDABLES":
                    FOUND_BUILDABLES_Progress = value;
                    break;
                case "FOUND_THROWABLES":
                    FOUND_THROWABLES_Progress = value;
                    break;
                // Handle invalid property name or provide an error message.
                default:
                    Console.WriteLine($"Property '{propertyName}' does not exist.");
                    break;
            }
        }

        public int GetProgress(string propertyName)
        {
            switch (propertyName)
            {
                case "NONE":
                    return NONE_Progress;
                case "KILLS_ZOMBIES_NORMAL":
                    return KILLS_ZOMBIES_NORMAL_Progress;
                case "KILLS_PLAYERS":
                    return KILLS_PLAYERS_Progress;
                case "FOUND_ITEMS":
                    return FOUND_ITEMS_Progress;
                case "FOUND_RESOURCES":
                    return FOUND_RESOURCES_Progress;
                case "FOUND_EXPERIENCE":
                    return FOUND_EXPERIENCE_Progress;
                case "KILLS_ZOMBIES_MEGA":
                    return KILLS_ZOMBIES_MEGA_Progress;
                case "DEATHS_PLAYERS":
                    return DEATHS_PLAYERS_Progress;
                case "KILLS_ANIMALS":
                    return KILLS_ANIMALS_Progress;
                case "FOUND_CRAFTS":
                    return FOUND_CRAFTS_Progress;
                case "FOUND_FISHES":
                    return FOUND_FISHES_Progress;
                case "FOUND_PLANTS":
                    return FOUND_PLANTS_Progress;
                case "ACCURACY":
                    return ACCURACY_Progress;
                case "HEADSHOTS":
                    return HEADSHOTS_Progress;
                case "TRAVEL_FOOT":
                    return TRAVEL_FOOT_Progress;
                case "TRAVEL_VEHICLE":
                    return TRAVEL_VEHICLE_Progress;
                case "ARENA_WINS":
                    return ARENA_WINS_Progress;
                case "FOUND_BUILDABLES":
                    return FOUND_BUILDABLES_Progress;
                case "FOUND_THROWABLES":
                    return FOUND_THROWABLES_Progress;
                default:
                    // Handle invalid property name or provide an error message.
                    Console.WriteLine($"Property '{propertyName}' does not exist.");
                    return 0; // Return a default value or handle the error as needed.
            }
        }

        public void PlayerJoined()
        {
            JoinTime = DateTime.Now;
        }

        public void PlayerDisconnected()
        {
            if (JoinTime != DateTime.MinValue)
            {
                TimeSpan timeSpent = DateTime.Now - JoinTime;
                TimeSpentOnServerSeconds += (int)timeSpent.TotalSeconds;
            }
        }

        public void LoadDefaults()
        {
            SteamID = 0;
            LastUpdated = DateTime.Now;
            Created = DateTime.Now;
            TimeSpentOnServerSeconds = 0;

            KILLS_ZOMBIES_NORMAL = 0;
            KILLS_PLAYERS = 0;
            FOUND_ITEMS = 0;
            FOUND_RESOURCES = 0;
            FOUND_EXPERIENCE = 0;
            KILLS_ZOMBIES_MEGA = 0;
            DEATHS_PLAYERS = 0;
            KILLS_ANIMALS = 0;
            FOUND_CRAFTS = 0;
            FOUND_FISHES = 0;
            FOUND_PLANTS = 0;
            ACCURACY = 0;
            HEADSHOTS = 0;
            TRAVEL_FOOT = 0;
            TRAVEL_VEHICLE = 0;
            ARENA_WINS = 0;
            FOUND_BUILDABLES = 0;
            FOUND_THROWABLES = 0;

            NONE_Progress = 0;
            KILLS_ZOMBIES_NORMAL_Progress = 0;
            KILLS_PLAYERS_Progress = 0;
            FOUND_ITEMS_Progress = 0;
            FOUND_RESOURCES_Progress = 0;
            FOUND_EXPERIENCE_Progress = 0;
            KILLS_ZOMBIES_MEGA_Progress = 0;
            DEATHS_PLAYERS_Progress = 0;
            KILLS_ANIMALS_Progress = 0;
            FOUND_CRAFTS_Progress = 0;
            FOUND_FISHES_Progress = 0;
            FOUND_PLANTS_Progress = 0;
            ACCURACY_Progress = 0;
            HEADSHOTS_Progress = 0;
            TRAVEL_FOOT_Progress = 0;
            TRAVEL_VEHICLE_Progress = 0;
            ARENA_WINS_Progress = 0;
            FOUND_BUILDABLES_Progress = 0;
            FOUND_THROWABLES_Progress = 0;
        }
    }
}