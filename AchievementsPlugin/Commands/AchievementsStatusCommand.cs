using AchievementsPlugin.Models;
using Rocket.API;
using Rocket.Core.Assets;
using Rocket.Unturned.Chat;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AchievementsPlugin.Commands
{
    public class AchievementsStatusCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "achievements";

        public string Help => "show your achievements progress";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var achievementConfig = AchievementsPlugin.Instance.Configuration.Instance.RewardStats;

            var stats = new XMLFileAsset<Stats>(Path.Combine(AchievementsPlugin.Instance.Directory, "Stats/" + caller.Id + ".xml"));

            foreach (var achievement in achievementConfig)
            {
                var achievementProgress = stats.Instance.GetProgress(achievement.AchievementType.ToString());
                var statCount = stats.Instance.GetStatCount(achievement.AchievementType);

                var translator = new StatTranslator();

                Reward nextReward = GetNextReward(achievement.Rewards, statCount);

                if (nextReward != null)
                {
                    UnturnedChat.Say(caller, $"Current progress for {translator.TranslateStat(achievement.AchievementType)}: {statCount}/{nextReward.Amount}, Reward: [{nextReward.RewardDescription}]", AchievementsPlugin.Instance.Configuration.Instance.NextRewardInfoColor);
                } else
                {
                    if (achievement.RepeatingReward != null)
                    {
                        var nextStat = (statCount - achievement.Rewards.Last().Amount) % achievement.RepeatingReward.Amount;

                        UnturnedChat.Say(caller, $"Repeating reward for {translator.TranslateStat(achievement.AchievementType)}: {nextStat}/{achievement.RepeatingReward.Amount}, Reward: [{achievement.RepeatingReward.RewardDescription}]", AchievementsPlugin.Instance.Configuration.Instance.NextRewardInfoColor);
                    }
                }
            };
        }
        private Reward GetNextReward(Reward[] rewards, int statCount)
        {
            foreach (var reward in rewards)
            {
                if (reward.Amount > statCount)
                {
                    return reward;
                }
            }

            return null;
        }
    }
}
