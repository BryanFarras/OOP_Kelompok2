namespace OOP_Kelompok2
{
    public class EnemyFactory
    {
        public static Enemy CreateEnemy(string enemyType)
        {
            switch (enemyType.ToLower())
            {
                case "space ex":
                    return new Enemy
                    {
                        Name = "Space Ex",
                        Heart = 60,
                        AttackPower = 15,
                        EmotionType = Emotion.Sad
                    };
                case "lost petal":
                    return new Enemy
                    {
                        Name = "Lost Petal",
                        Heart = 40,
                        AttackPower = 10,
                        EmotionType = Emotion.Happy
                    };
                case "haunting shade":
                    return new Enemy
                    {
                        Name = "Haunting Shade",
                        Heart = 50,
                        AttackPower = 12,
                        EmotionType = Emotion.Angry
                    };
                case "memento keeper":
                    return new Enemy
                    {
                        Name = "Memento Keeper",
                        Heart = 120,
                        AttackPower = 25,
                        EmotionType = Emotion.Neutral
                    };
                default:
                    throw new ArgumentException("Unknown enemy type.");
            }
        }
    }
}
