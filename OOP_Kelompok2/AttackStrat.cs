using System;

namespace OOP_Kelompok2
{
    public interface IAttackStrategy
    {
        void Execute(Player player, Enemy enemy);
    }

    public class NormalAttack : IAttackStrategy
    {
        public void Execute(Player player, Enemy enemy)
        {
            Console.WriteLine($"{player.Name} uses Normal Attack!");
            int damage = player.Attack;
            enemy.Heart -= damage;
            Console.WriteLine($"{enemy.Name} takes {damage} damage. Remaining Heart: {enemy.Heart}");
        }
    }

    public class CriticalAttack : IAttackStrategy
    {
        public void Execute(Player player, Enemy enemy)
        {
            Console.WriteLine($"{player.Name} attempts Critical Attack!");
            Random random = new Random();
            bool isCritical = random.Next(0, 100) < player.Luck; // Peluang critical berdasarkan Luck

            int damage = isCritical ? player.Attack * 2 : player.Attack;
            Console.WriteLine(isCritical
                ? "Critical Hit! Double damage inflicted!"
                : "Normal hit.");
            enemy.Heart -= damage;
            Console.WriteLine($"{enemy.Name} takes {damage} damage. Remaining Heart: {enemy.Heart}");
        }
    }

    public class EmotionAttack : IAttackStrategy
    {
        public void Execute(Player player, Enemy enemy)
        {
            Console.WriteLine($"{player.Name} uses Emotion Attack!");
            enemy.PerformEmotionEffect(); // Memengaruhi emosi musuh
            Console.WriteLine($"{enemy.Name}'s emotion changes to {enemy.EmotionType}!");
        }
    }
}
