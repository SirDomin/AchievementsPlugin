using SDG.Unturned;
using System.Collections.Generic;

namespace AchievementsPlugin
{
    public class StatTranslator
    {
        private Dictionary<EPlayerStat, string> statTemplates;

        private Dictionary<EPlayerStat, string> statTranslation;

        public StatTranslator()
        {
            statTemplates = new Dictionary<EPlayerStat, string>
            {
                { EPlayerStat.NONE, AchievementsPlugin.Instance.Translate("None") },
                { EPlayerStat.KILLS_ZOMBIES_NORMAL, AchievementsPlugin.Instance.Translate("ZombieKillsNormal") },
                { EPlayerStat.KILLS_PLAYERS, AchievementsPlugin.Instance.Translate("PlayersKills") },
                { EPlayerStat.FOUND_ITEMS, AchievementsPlugin.Instance.Translate("ItemsFound") },
                { EPlayerStat.FOUND_RESOURCES, AchievementsPlugin.Instance.Translate("ResourcesFound") },
                { EPlayerStat.FOUND_EXPERIENCE, AchievementsPlugin.Instance.Translate("ExperienceFound") },
                { EPlayerStat.KILLS_ZOMBIES_MEGA, AchievementsPlugin.Instance.Translate("ZombieKillsMega") },
                { EPlayerStat.DEATHS_PLAYERS, AchievementsPlugin.Instance.Translate("DeathPlayers") },
                { EPlayerStat.KILLS_ANIMALS, AchievementsPlugin.Instance.Translate("AnimalsKills") },
                { EPlayerStat.FOUND_CRAFTS, AchievementsPlugin.Instance.Translate("FoundCrafts") },
                { EPlayerStat.FOUND_FISHES, AchievementsPlugin.Instance.Translate("FoundFishes") },
                { EPlayerStat.FOUND_PLANTS, AchievementsPlugin.Instance.Translate("FoundPlants") },
                { EPlayerStat.ACCURACY, AchievementsPlugin.Instance.Translate("Accuracy") },
                { EPlayerStat.HEADSHOTS, AchievementsPlugin.Instance.Translate("Headshots") },
                { EPlayerStat.TRAVEL_FOOT, AchievementsPlugin.Instance.Translate("TravelFoot") },
                { EPlayerStat.TRAVEL_VEHICLE, AchievementsPlugin.Instance.Translate("TravelVehicle") },
                { EPlayerStat.ARENA_WINS, AchievementsPlugin.Instance.Translate("ArenaWins") },
                { EPlayerStat.FOUND_BUILDABLES, AchievementsPlugin.Instance.Translate("FoundBuildables") },
                { EPlayerStat.FOUND_THROWABLES, AchievementsPlugin.Instance.Translate("FoundThrowables") }
            };

            statTranslation = new Dictionary<EPlayerStat, string>
            {
                { EPlayerStat.NONE, AchievementsPlugin.Instance.Translate("None") },
                { EPlayerStat.KILLS_ZOMBIES_NORMAL, AchievementsPlugin.Instance.Translate("ZombieKillsNormal_plain") },
                { EPlayerStat.KILLS_PLAYERS, AchievementsPlugin.Instance.Translate("PlayersKills_plain") },
                { EPlayerStat.FOUND_ITEMS, AchievementsPlugin.Instance.Translate("ItemsFound_plain") },
                { EPlayerStat.FOUND_RESOURCES, AchievementsPlugin.Instance.Translate("ResourcesFound_plain") },
                { EPlayerStat.FOUND_EXPERIENCE, AchievementsPlugin.Instance.Translate("ExperienceFound_plain") },
                { EPlayerStat.KILLS_ZOMBIES_MEGA, AchievementsPlugin.Instance.Translate("ZombieKillsMega_plain") },
                { EPlayerStat.DEATHS_PLAYERS, AchievementsPlugin.Instance.Translate("DeathPlayers_plain") },
                { EPlayerStat.KILLS_ANIMALS, AchievementsPlugin.Instance.Translate("AnimalsKills_plain") },
                { EPlayerStat.FOUND_CRAFTS, AchievementsPlugin.Instance.Translate("FoundCrafts_plain") },
                { EPlayerStat.FOUND_FISHES, AchievementsPlugin.Instance.Translate("FoundFishes_plain") },
                { EPlayerStat.FOUND_PLANTS, AchievementsPlugin.Instance.Translate("FoundPlants_plain") },
                { EPlayerStat.ACCURACY, AchievementsPlugin.Instance.Translate("Accuracy_plain") },
                { EPlayerStat.HEADSHOTS, AchievementsPlugin.Instance.Translate("Headshots_plain") },
                { EPlayerStat.TRAVEL_FOOT, AchievementsPlugin.Instance.Translate("TravelFoot_plain") },
                { EPlayerStat.TRAVEL_VEHICLE, AchievementsPlugin.Instance.Translate("TravelVehicle_plain") },
                { EPlayerStat.ARENA_WINS, AchievementsPlugin.Instance.Translate("ArenaWins_plain") },
                { EPlayerStat.FOUND_BUILDABLES, AchievementsPlugin.Instance.Translate("FoundBuildables_plain") },
                { EPlayerStat.FOUND_THROWABLES, AchievementsPlugin.Instance.Translate("FoundThrowables_plain") }
            };
        }

        public string TranslateStat(EPlayerStat stat)
        {
            if (statTranslation.ContainsKey(stat))
            {
                return statTranslation[stat];
            }
            else
            {
                return "Unknown";
            }
        }

        public string Translate(EPlayerStat stat, string value)
        {
            if (statTemplates.ContainsKey(stat))
            {
                return string.Format(statTemplates[stat], value);
            }
            else
            {
                return "Unknown";
            }
        }
    }
}
