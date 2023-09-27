using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using System.IO;

namespace AchievementsPlugin
{
    public class AchievementsPlugin : RocketPlugin<AchievementsPluginConfiguration>
    {
        public static AchievementsPlugin Instance;

        public int StepNotificationZombie { get; private set; }
        public int StepNotificationMega { get; private set; }

        public Dictionary<int, string> RewardsZombieKills { get; private set; }

        protected override void Load()
        {
            Instance = this;

            StepNotificationZombie = 25;
            StepNotificationMega = 2;

            RewardsZombieKills = new Dictionary<int, string>()
            {
                {30, "test" }
            };

            Logger.Log(Configuration.Instance.LoadMessage);
            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded");
            System.IO.Directory.CreateDirectory(Path.Combine(Directory, "Stats/"));
        }

        public void MessagePlayer(UnturnedPlayer player, string message)
        {
            IRocketPlayer playerPlayer = player as IRocketPlayer;

            UnturnedChat.Say(playerPlayer, message);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "None", "None" },
            { "ZombieKillsNormal", "You have killed {0} Zombies" },
            { "PlayersKills", "You have killed {0} Players" },
            { "ItemsFound", "You have found {0} Items" },
            { "ResourcesFound", "You have found {0} Resources" },
            { "ZombieKillsMega", "You have killed {0} Mega Zombies" },
            { "ExperienceFound", "You have found {0} Experience" },
            { "DeathPlayers", "You have died {0} times" },
            { "AnimalsKills", "You have killed {0} Animals" },
            { "FoundCrafts", "You have found {0} Crafts" },
            { "FoundFishes", "You have found {0} Fishes" },
            { "FoundPlants", "You have found {0} Plants" },
            { "Accuracy", "Your accuracy is {0}%" },
            { "Headshots", "You have scored {0} Headshots" },
            { "TravelFoot", "You have traveled {0} feet on foot" },
            { "TravelVehicle", "You have traveled {0} feet in a vehicle" },
            { "ArenaWins", "You have won {0} Arena matches" },
            { "FoundBuildables", "You have found {0} Buildables" },
            { "FoundThrowables", "You have found {0} Throwables" },

            { "ZombieKillsNormal_plain", "Zombie kills" },
            { "PlayersKills_plain", "Player kils" },
            { "ItemsFound_plain", "Items found" },
            { "ResourcesFound_plain", "Resources found" },
            { "ZombieKillsMega_plain", "Mega Zombie kills" },
            { "ExperienceFound_plain", "Experience found" },
            { "DeathPlayers_plain", "Deaths" },
            { "AnimalsKills_plain", "Animals killed" },
            { "FoundCrafts_plain", "Crafted items" },
            { "FoundFishes_plain", "Fish caught" },
            { "FoundPlants_plain", "Plants harvested" },
            { "Accuracy_plain", "Accuracy" },
            { "Headshots_plain", "Headshots" },
            { "TravelFoot_plain", "Travelled by foot" },
            { "TravelVehicle_plain", "Travelled by vehicle" },
            { "ArenaWins_plain", "Arena wins" },
            { "FoundBuildables_plain", "Buildables found" },
            { "FoundThrowables_plain", "Throwables found" },
        };

        protected override void Unload()
        {
            Logger.Log($"{Name} has been unloaded");
        }

    }
}
