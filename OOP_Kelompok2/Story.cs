using System;

namespace OOP_Kelompok2
{
    public class Story
    {
        public static void Introduction(Player player)
        {
            Console.WriteLine("\n=== Introduction ===");
            Console.WriteLine("You find yourself in a surreal dreamscape. Shadows flicker, and voices call to you...");
            Console.WriteLine("Choose your reaction:");
            Console.WriteLine("1. Follow the voices.");
            Console.WriteLine("2. Ignore them and explore the dark corners.");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("\nYou follow the voices, feeling a strange sense of comfort.");
                player.EmotionType = Emotion.Happy;
                Console.WriteLine("You feel happy! Current Emotion: " + player.EmotionType);
            }
            else if (choice == 2)
            {
                Console.WriteLine("\nIgnoring the voices, you feel a chill down your spine.");
                player.Heart -= 5;
                Console.WriteLine("Health decreased by -5. Current Health: " + player.Heart);
            }
        }

        public static void StoryPath(Player player)
        {
            Console.WriteLine("\n=== Story Path ===");
            Console.WriteLine("After wandering, you encounter a forked path in the dreamscape.");
            Console.WriteLine("1. Approach the broken clock tower.");
            Console.WriteLine("2. Enter the desolate flower field.");
            Console.WriteLine("3. Cross the foggy bridge.");
            int choice = Convert.ToInt32(Console.ReadLine());

            Enemy enemy = new Enemy();
            switch (choice)
            {
                case 1:
                    enemy = EnemyFactory.CreateEnemy("space ex");
                    Console.WriteLine("\nYou approach the broken clock tower and encounter *Space Ex*!");
                    break;
                case 2:
                    enemy = EnemyFactory.CreateEnemy("lost petal");
                    Console.WriteLine("\nYou enter the desolate flower field and encounter *Lost Petal*!");
                    break;
                case 3:
                    enemy = EnemyFactory.CreateEnemy("haunting shade");
                    Console.WriteLine("\nYou cross the foggy bridge and encounter *Haunting Shade*!");
                    break;
                default:
                    Console.WriteLine("Invalid choice! No enemy encountered.");
                    return;
            }

            StartBattle(player, enemy);
        }

        public static void StartBattle(Player player, Enemy enemy)
        {
            Console.WriteLine($"\n=== Battle Start: {enemy.Name} ===");

            BattleSystem battleSystem = new BattleSystem();
            bool battleOngoing = true;

            while (battleOngoing)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Normal Attack");
                Console.WriteLine("2. Critical Attack");
                Console.WriteLine("3. Use Item from Inventory");
                Console.WriteLine("4. Escape");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 4)
                {
                    Console.WriteLine("You escaped the battle.");
                    return;
                }

                if (choice == 3)
                {
                    Program.UseInventoryItem(); // Gunakan item dari inventaris
                    continue;
                }

                if (choice == 1)
                    battleSystem.SetAttackStrategy(new NormalAttack());
                else if (choice == 2)
                    battleSystem.SetAttackStrategy(new CriticalAttack());

                battleSystem.ExecuteStrategy(player, enemy);

                if (enemy.Heart <= 0)
                {
                    Console.WriteLine($"{enemy.Name} has been defeated!");
                    battleOngoing = false;
                }
                else
                {
                    Console.WriteLine($"{enemy.Name} attacks you!");
                    enemy.Attack(player);
                }

                if (player.Heart <= 0)
                {
                    Console.WriteLine("You have been defeated...");
                    return;
                }

                Console.WriteLine($"\nYour Health: {player.Heart}, Enemy Health: {enemy.Heart}");
            }
        }

        public static void LevelUp(Player player)
        {
            Console.WriteLine("\n=== Level Up ===");
            player.GainExp(30); // EXP untuk naik level
            if (player.Level > 1)
            {
                Console.WriteLine($"You reached Level {player.Level}!");
                Console.WriteLine("New skill unlocked: *Dream Shroud* - Stuns an enemy for 1 turn.");
            }
        }

        public static void FinalBossEncounter(Player player)
        {
            Console.WriteLine("\n=== Boss Encounter ===");
            Console.WriteLine("BOSS ENEMY: *Memento Keeper* emerges from the shadows, wielding painful memories as weapons!");

            Enemy boss = EnemyFactory.CreateEnemy("memento keeper");

            StartBossBattle(player, boss);
        }

        public static void StartBossBattle(Player player, Enemy boss)
        {
            Console.WriteLine($"\n=== Final Battle: {boss.Name} ===");

            BattleSystem battleSystem = new BattleSystem();
            Random random = new Random();
            bool battleOngoing = true;

            while (battleOngoing)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Normal Attack");
                Console.WriteLine("2. Critical Attack");
                Console.WriteLine("3. Use Item from Inventory");
                Console.WriteLine("4. Escape");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 4)
                {
                    Console.WriteLine("You escaped the battle.");
                    return;
                }

                if (choice == 3)
                {
                    Program.UseInventoryItem(); // Gunakan item dari inventaris
                    continue;
                }

                if (choice == 1)
                    battleSystem.SetAttackStrategy(new NormalAttack());
                else if (choice == 2)
                    battleSystem.SetAttackStrategy(new CriticalAttack());

                battleSystem.ExecuteStrategy(player, boss);

                if (boss.Heart <= 0)
                {
                    Console.WriteLine($"{boss.Name} has been defeated! You completed the game!");
                    return;
                }

                if (!boss.IsStunned)
                {
                    Console.WriteLine($"{boss.Name} uses a special attack, reducing your attack power!");
                    player.Attack = Math.Max(player.Attack - 5, 0);
                    boss.Attack(player);
                }

                if (player.Heart <= 0)
                {
                    Console.WriteLine("You have been defeated by the boss...");
                    return;
                }

                Console.WriteLine($"\nYour Health: {player.Heart}, Boss Health: {boss.Heart}");
                boss.IsStunned = false;
            }
        }
    }
}
