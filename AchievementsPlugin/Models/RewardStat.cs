using SDG.Unturned;

namespace AchievementsPlugin.Models
{
    public class RewardStat
    {
        public EPlayerStat AchievementType { get; set; }

        public int Step { get; set; }

        public Reward[] Rewards { get; set; }

        public Reward RepeatingReward { get; set; }

        public int FinishedAchievementStep {  get; set; }
    }
}
