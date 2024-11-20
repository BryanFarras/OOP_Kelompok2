using System;

namespace OOP_Kelompok2
{
    public class Story
    {
        public static void Introduction(Player player)
        {
            Console.WriteLine("You find yourself in a surreal dreamscape. Shadows flicker, and voices call to you...");
            Console.WriteLine("\nChoose your reaction:");
            Console.WriteLine("1. Follow the voices.");
            Console.WriteLine("2. Ignore them and explore the dark corners.");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nYou follow the voices, feeling a strange sense of comfort.");
                player.EmotionType = Emotion.Happy;
                Console.WriteLine("You feel happy! Current Emotion: " + player.EmotionType);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nIgnoring the voices, you feel a chill down your spine.");
                player.Heart -= 5;
                Console.WriteLine("Health decreased by -5. Current Health: " + player.Heart);
            }
        }

        public static void StoryPath(Player player)
        {
            Console.WriteLine("\nAfter wandering, you encounter a forked path in the dreamscape...");
            Console.WriteLine("1. Approach the broken clock tower.");
            Console.WriteLine("2. Enter the desolate flower field.");
            Console.WriteLine("3. Cross the foggy bridge.");
            string? choice = Console.ReadLine();

            Enemy enemy;
            if (choice == "1")
            {
                enemy = EnemyFactory.CreateEnemy("space ex");
                Console.WriteLine("A familiar figure appears... It's the *Space Ex*!");
            }
            else if (choice == "2")
            {
                enemy = EnemyFactory.CreateEnemy("lost petal");
                Console.WriteLine("A Lost Petal floats towards you, looking hostile!");
            }
            else
            {
                enemy = EnemyFactory.CreateEnemy("haunting shade");
                Console.WriteLine("A Haunting Shade approaches, its form shifting in the mist!");
            }

            StartBattle(player, enemy);
            LevelUp(player); // Pemain mendapatkan kesempatan level up setelah pertempuran
        }

        public static void LevelUp(Player player)
        {
            player.GainExp(15);
            if (player.Level > 1)
            {
                Console.WriteLine("Congratulations! You learned a new skill: *Dream Shroud*.");
                player.DisplayStatus();
            }
        }

        public static void StartBattle(Player player, Enemy enemy)
        {
            BattleSystem battleSystem = new BattleSystem();
            bool battleOngoing = true;

            while (battleOngoing)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Normal Attack");
                Console.WriteLine("2. Critical Attack");
                Console.WriteLine("3. Emotion Attack");
                Console.WriteLine("4. Dream Shroud (Unlocks at level 2)");
                Console.WriteLine("5. Escape");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        battleSystem.SetAttackStrategy(new NormalAttack());
                        break;
                    case "2":
                        battleSystem.SetAttackStrategy(new CriticalAttack());
                        break;
                    case "3":
                        battleSystem.SetAttackStrategy(new EmotionAttack());
                        break;
                    case "4":
                        if (player.Level >= 2)
                        {
                            Console.WriteLine($"{player.Name} uses Dream Shroud! {enemy.Name} is paralyzed in fear.");
                            enemy.IsStunned = true;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Dream Shroud is only available at level 2 or higher.");
                            continue;
                        }
                    case "5":
                        Console.WriteLine("You escape from the battle, the shadows following closely...");
                        battleOngoing = false;
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        continue;
                }

                battleSystem.ExecuteStrategy(player, enemy);

                if (enemy.Heart <= 0)
                {
                    Console.WriteLine($"{enemy.Name} fades into the shadows. You've won this battle!");
                    battleOngoing = false;
                }
                else if (!enemy.IsStunned)
                {
                    enemy.Attack(player);
                }

                Console.WriteLine("\n=== Player Status ===");
                player.DisplayStatus();
                Console.WriteLine("\n=== Enemy Status ===");
                enemy.DisplayStatus();

                if (player.Heart <= 0)
                {
                    Console.WriteLine($"{player.Name} has been defeated... The dream becomes darker.");
                    battleOngoing = false;
                }

                enemy.IsStunned = false;
            }
        }

        public static void FinalBossEncounter(Player player)
        {
            Console.WriteLine("You feel a foreboding presence as you approach the end of the path...");
            Console.WriteLine("BOSS ENEMY: *Memento Keeper* emerges from the shadows, wielding painful memories as weapons!");

            Enemy boss = EnemyFactory.CreateEnemy("memento keeper");
            StartBossBattle(player, boss);
        }

        public static void StartBossBattle(Player player, Enemy boss)
        {
            BattleSystem battleSystem = new BattleSystem();
            Random random = new Random();
            bool battleOngoing = true;

            while (battleOngoing)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Normal Attack");
                Console.WriteLine("2. Critical Attack");
                Console.WriteLine("3. Emotion Attack");
                Console.WriteLine("4. Dream Shroud");

                string? choice = Console.ReadLine();

                if (choice == "4" && player.Level >= 2)
                {
                    Console.WriteLine($"{player.Name} uses Dream Shroud! {boss.Name} is engulfed in a cloud of memories and stunned.");
                    boss.IsStunned = true;
                }
                else
                {
                    switch (choice)
                    {
                        case "1":
                            battleSystem.SetAttackStrategy(new NormalAttack());
                            break;
                        case "2":
                            battleSystem.SetAttackStrategy(new CriticalAttack());
                            break;
                        case "3":
                            battleSystem.SetAttackStrategy(new EmotionAttack());
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            continue;
                    }

                    battleSystem.ExecuteStrategy(player, boss);
                }

                if (boss.Heart <= 0)
                {
                    Console.WriteLine($"{boss.Name} shatters into fragments of forgotten memories. You've defeated the BOSS ENEMY!");
                    player.GainExp(30);
                    battleOngoing = false;
                }
                else if (!boss.IsStunned)
                {
                    int attackType = random.Next(0, 2);
                    if (attackType == 0)
                    {
                        Console.WriteLine($"{boss.Name} attacks with haunting memories!");
                        boss.Attack(player);
                    }
                    else
                    {
                        Console.WriteLine($"{boss.Name} uses a special attack, reducing {player.Name}'s strength by invoking past regrets.");
                        player.Attack = Math.Max(player.Attack - 5, 0);
                        Console.WriteLine($"{player.Name}'s Attack is now {player.Attack}.");
                    }
                }

                if (player.Heart <= 0)
                {
                    Console.WriteLine($"{player.Name} has been overwhelmed... The dream fades to black.");
                    battleOngoing = false;
                }

                boss.IsStunned = false;
            }
        }
    }
}
