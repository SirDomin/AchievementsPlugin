using Rocket.Core.Assets;
using Rocket.Core;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.IO;
using System.Linq;
using Rocket.Core.Logging;
using AchievementsPlugin.Models;

namespace AchievementsPlugin
{
    public class StatsPlayerComponent : UnturnedPlayerComponent
    {
        public XMLFileAsset<Stats> Stats;

        private StatTranslator StatTranslator;

        private bool rewardClaimed;

        public void Start()
        {
            Stats = new XMLFileAsset<Stats>(Path.Combine(AchievementsPlugin.Instance.Directory, "Stats/" + Player.Id + ".xml"));
            Stats.Instance.SetSteamId(Player.SteamProfile.SteamID64);

            StatTranslator = new StatTranslator();

            Player.Events.OnUpdateStat += (UnturnedPlayer player, EPlayerStat stat) =>
            {
                var currentStatValue = Stats.Instance.IncrementStat(stat);

                var achievementConfig = AchievementsPlugin.Instance.Configuration.Instance.RewardStats.FirstOrDefault(x => x.AchievementType == stat);

                Stats.Save();

                if (achievementConfig == null)
                {
                    return;
                }

                if (currentStatValue % achievementConfig.Step == 0)
                {
                    UnturnedChat.Say(player, StatTranslator.Translate(stat, currentStatValue.ToString()), AchievementsPlugin.Instance.Configuration.Instance.AchievementUpdateColor);
                }

                rewardClaimed = false;

                foreach (var reward in achievementConfig.Rewards)
                {
                    if (rewardClaimed == true)
                    {
                        UnturnedChat.Say(player, $"Next reward for {reward.Amount} {StatTranslator.TranslateStat(stat)} is {reward.RewardDescription}", AchievementsPlugin.Instance.Configuration.Instance.NextRewardInfoColor);
                    }

                    if (currentStatValue >= reward.Amount && Stats.Instance.GetProgress(stat.ToString()) < reward.Amount)
                    {
                        ClaimReward(reward, player);

                        rewardClaimed = true;
                        Stats.Instance.SetProgress(stat.ToString(), currentStatValue);

                        UnturnedChat.Say(player, $"reward for {reward.Amount} {StatTranslator.TranslateStat(stat)} ({reward.RewardDescription}) has been claimed", AchievementsPlugin.Instance.Configuration.Instance.RewardClaimColor);
                    }
                    else
                    {
                        rewardClaimed = false;
                    }

                }

                if (achievementConfig.Rewards.Last().Amount <= currentStatValue)
                {
                    if (achievementConfig.RepeatingReward != null)
                    {
                        if (rewardClaimed == true)
                        {
                            UnturnedChat.Say(player, $"Next repeating reward for another {achievementConfig.RepeatingReward.Amount} {StatTranslator.TranslateStat(stat)} is {achievementConfig.RepeatingReward.RewardDescription}", AchievementsPlugin.Instance.Configuration.Instance.NextRewardInfoColor);
                        }

                        if ((currentStatValue - achievementConfig.Rewards.Last().Amount) != 0 && (currentStatValue - achievementConfig.Rewards.Last().Amount) % achievementConfig.RepeatingReward.Amount == 0)
                        {
                            var reward = achievementConfig.RepeatingReward;

                            ClaimReward(reward, player);

                            UnturnedChat.Say(player, $"Repeating reward for {reward.Amount} {StatTranslator.TranslateStat(stat)} ({reward.RewardDescription}) has been claimed", AchievementsPlugin.Instance.Configuration.Instance.RewardClaimColor);
                            UnturnedChat.Say(player, $"Next repeating reward for another {achievementConfig.RepeatingReward.Amount} {StatTranslator.TranslateStat(stat)} is {achievementConfig.RepeatingReward.RewardDescription}", AchievementsPlugin.Instance.Configuration.Instance.NextRewardInfoColor);
                        }
                    }
                }

                Stats.Save();
            };

            U.Events.OnPlayerConnected += (UnturnedPlayer player) =>
            {
                Stats.Instance.PlayerJoined();

                UnturnedChat.Say(player, StatTranslator.Translate(EPlayerStat.KILLS_ZOMBIES_NORMAL, Stats.Instance.GetStatCount(EPlayerStat.KILLS_ZOMBIES_NORMAL).ToString()));

                Stats.Save();
            };

            U.Events.OnPlayerDisconnected += (UnturnedPlayer player) =>
            {
                Stats.Instance.PlayerDisconnected();

                Stats.Save();
            };
        }

        private void ClaimReward(Reward reward, UnturnedPlayer player)
        {
            if (reward.RewardType == "item")
            {
                foreach (var item in reward.Items)
                {
                    player.GiveItem(item, 1);
                }
            }

            if (reward.RewardType == "command")
            {
                var commands = reward.RewardExec;

                foreach (var command in commands)
                {
                    string resultString = command.Replace("{player}", player.SteamName);
                    Logger.Log(resultString);
                    R.Commands.Execute(null, resultString);
                }
            }
        }

        public void OnDisable()
        {
            Stats.Save();
        }
    }
}