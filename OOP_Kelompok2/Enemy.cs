namespace OOP_Kelompok2
{
    public class Enemy
    {
        public string? Name { get; set; }
        public int Heart { get; set; }
        public int AttackPower { get; set; }
        public Emotion EmotionType { get; set; }
        public bool IsStunned { get; set; } = false;

        public void Attack(Player player)
        {
            Console.WriteLine($"{Name} attacks {player.Name}!");
            player.Heart -= AttackPower;
            Console.WriteLine($"{player.Name} takes {AttackPower} damage. Remaining Health: {player.Heart}");
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Enemy Name: {Name}");
            Console.WriteLine($"Heart: {Heart}");
            Console.WriteLine($"Attack Power: {AttackPower}");
            Console.WriteLine($"Emotion: {EmotionType}");
        }

        public void PerformEmotionEffect()
        {
            switch (EmotionType)
            {
                case Emotion.Angry:
                    Console.WriteLine($"{Name} is Angry! Attack power increased!");
                    AttackPower += 5;
                    break;
                case Emotion.Sad:
                    Console.WriteLine($"{Name} is Sad. Defense increased but attack reduced.");
                    Heart += 10;
                    AttackPower -= 2;
                    break;
                case Emotion.Happy:
                    Console.WriteLine($"{Name} is Happy! Faster speed and higher chance to crit.");
                    break;
                case Emotion.Neutral:
                    Console.WriteLine($"{Name} is Neutral. No special effects.");
                    break;
            }
        }
    }
}
