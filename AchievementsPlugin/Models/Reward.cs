using System.Xml.Serialization;

namespace AchievementsPlugin.Models
{
    public class Reward
    {
        public int Amount { get; set; }

        public string RewardType {  get; set; }

        public string RewardDescription {  get; set; }

        [XmlArrayItem("commands")]
        public string[] RewardExec {  get; set; }

        [XmlArrayItem("items")]
        public ushort[] Items { get; set; }
    }
}
