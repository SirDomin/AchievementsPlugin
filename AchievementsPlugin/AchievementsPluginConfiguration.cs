using AchievementsPlugin.Models;
using Rocket.API;

namespace AchievementsPlugin
{
    public class AchievementsPluginConfiguration : IRocketPluginConfiguration
    {
        public string LoadMessage { get; set; }

        public RewardStat[] RewardStats { get; set; }

        public UnityEngine.Color RewardClaimColor { get; set; }

        public UnityEngine.Color NextRewardInfoColor { get; set; }

        public UnityEngine.Color AchievementUpdateColor { get; set; }


        public void LoadDefaults()
        {
            LoadMessage = "Achievements Plugin v2";

            RewardClaimColor = UnityEngine.Color.cyan;
            NextRewardInfoColor = UnityEngine.Color.green;
            AchievementUpdateColor = UnityEngine.Color.white;

            RewardStats = new RewardStat[]
            {
                new RewardStat()
                {
                    AchievementType = SDG.Unturned.EPlayerStat.KILLS_ZOMBIES_NORMAL,
                    Step = 1,
                    RepeatingReward = new Reward()
                    {
                        Amount = 2,
                        RewardType = "item",
                        RewardDescription = "REPEATING AMMO :DD",
                        Items = new ushort[]
                        {
                            6,
                        }
                    },
                    Rewards = new Reward[]
                    {
                        new Reward()
                        {
                            Amount = 1,
                            RewardType = "item",
                            RewardDescription = "IDEMS (MAPLESTRIKE + AMMO) :DDD",
                            Items = new ushort[]
                            {
                                363,
                                6,
                                6,
                            }
                        },
                         new Reward()
                        {
                            Amount = 2,
                            RewardType = "item",
                            RewardDescription = "Beans :DD",
                            Items = new ushort[]
                            {
                                13,
                            }
                        },
                        new Reward()
                        {
                            Amount = 3,
                            RewardType = "command",
                            RewardDescription = "gain vip",
                            RewardExec = new string[]
                            {
                                "/p add {player} vip",
                                "/p reload",
                            },
                            Items = new ushort[0]
                        },
                    }

                }
            };
        }
    }
}
