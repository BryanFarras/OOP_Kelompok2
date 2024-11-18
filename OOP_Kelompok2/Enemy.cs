using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_Kelompok2
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Heart { get; set; }
        public int AttackPower { get; set; }
        public Emotion EmotionType { get; set; }

        // Method untuk menampilkan status musuh
        public void DisplayStatus()
        {
            Console.WriteLine($"Enemy Name: {Name}");
            Console.WriteLine($"Heart: {Heart}");
            Console.WriteLine($"Attack Power: {AttackPower}");
            Console.WriteLine($"Emotion: {EmotionType}");
        }

        // Method untuk efek emosi pada pertempuran
        public void PerformEmotionEffect()
        {
            switch (EmotionType)
            {
                case Emotion.Angry:
                    Console.WriteLine($"{Name} is Angry! Attack power increased!");
                    AttackPower += 5; // Contoh efek emosi
                    break;
                case Emotion.Sad:
                    Console.WriteLine($"{Name} is Sad. Defense increased but attack reduced.");
                    Heart += 10; // Contoh efek tambahan
                    AttackPower -= 2;
                    break;
                case Emotion.Happy:
                    Console.WriteLine($"{Name} is Happy! Faster speed and higher chance to crit.");
                    // Tambahkan logika sesuai kebutuhan
                    break;
                case Emotion.Neutral:
                    Console.WriteLine($"{Name} is Neutral. No special effects.");
                    break;
            }
        }
    }

    public class EnemyFactory
    {
        public static Enemy CreateEnemy(string enemyType)
        {
            switch (enemyType.ToLower())
            {
                case "goblin":
                    return new Enemy
                    {
                        Name = "Goblin",
                        Heart = 50,
                        AttackPower = 10,
                        EmotionType = Emotion.Angry
                    };
                case "slime":
                    return new Enemy
                    {
                        Name = "Slime",
                        Heart = 30,
                        AttackPower = 5,
                        EmotionType = Emotion.Neutral
                    };
                case "ghost":
                    return new Enemy
                    {
                        Name = "Ghost",
                        Heart = 40,
                        AttackPower = 15,
                        EmotionType = Emotion.Sad
                    };
                case "troll":
                    return new Enemy
                    {
                        Name = "Troll",
                        Heart = 100,
                        AttackPower = 20,
                        EmotionType = Emotion.Happy
                    };
                default:
                    throw new ArgumentException("Unknown enemy type.");
            }
        }
    }
}