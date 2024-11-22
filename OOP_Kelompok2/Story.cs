using System;

namespace OOP_Kelompok2
{
    public class Story
    {
        public static void Introduction(Player player)
        {
            //Console.WriteLine("You find yourself in a surreal dreamscape. Shadows flicker, and voices call to you...\n");

            string prompt = "You find yourself in a surreal dreamscape. Shadows flicker, and voices call to you...\nChoose your reaction:";
            string[] options = { 
                "Follow the voices.", 
                "Ignore them and explore the dark corners." 
                };
            Menu dialogue = new Menu(prompt, options);
            int choice = dialogue.Run();
            // Console.WriteLine("\nChoose your reaction:");
            // Console.WriteLine("1. Follow the voices.");
            // Console.WriteLine("2. Ignore them and explore the dark corners.");
            // string? choice = Console.ReadLine();
        
            if (choice == 0)
            {
                Console.WriteLine("\nYou follow the voices, feeling a strange sense of comfort.");
                player.EmotionType = Emotion.Happy;
                Console.WriteLine("You feel happy! Current Emotion: " + player.EmotionType);
            }
            else if (choice == 1)
            {
                Console.WriteLine("\nIgnoring the voices, you feel a chill down your spine.");
                player.Heart -= 5;
                Console.WriteLine("Health decreased by -5. Current Health: " + player.Heart);
            }
        }

        public static void StoryPath(Player player)
        {
            string prompt = "\nAfter wandering, you encounter a forked path in the dreamscape...";
            string[] options = {
                "Approach the broken clock tower.",
                "Enter the desolate flower field.",
                "Cross the foggy bridge."
                };
            Menu dialogue = new Menu(prompt, options);
            int choice = dialogue.Run();

            Enemy enemy;
            if (choice == 0)
            {
                enemy = EnemyFactory.CreateEnemy("space ex");
                Console.WriteLine("A familiar figure appears... It's the *Space Ex*!");
            }
            else if (choice == 1)
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
                string prompt = "\nChoose an action:";
                string[] options = {
                    "Normal Attack",
                    "Critical Attack",
                    "Emotion Attack",
                    "Dream Shroud (Unlocks at level 2)",
                    "Escape"
                    };
                Menu dialogue = new Menu(prompt, options);
                int choice = dialogue.Run();

                switch (choice)
                {
                    case 0:
                        battleSystem.SetAttackStrategy(new NormalAttack());
                        break;
                    case 1:
                        battleSystem.SetAttackStrategy(new CriticalAttack());
                        break;
                    case 2:
                        battleSystem.SetAttackStrategy(new EmotionAttack());
                        break;
                    case 3:
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
                    case 4:
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
                string prompt = "\nChoose an action:";
                string[] options = {
                    "Normal Attack",
                    "Critical Attack",
                    "Emotion Attack",
                    "Dream Shroud (Unlocks at level 2)",
                    "Escape"
                    };
                Menu dialogue = new Menu(prompt, options);
                int choice = dialogue.Run();

                if (choice == 3 && player.Level >= 2)
                {
                    Console.WriteLine($"{player.Name} uses Dream Shroud! {boss.Name} is engulfed in a cloud of memories and stunned.");
                    boss.IsStunned = true;
                }
                else
                {
                    switch (choice)
                    {
                        case 0:
                            battleSystem.SetAttackStrategy(new NormalAttack());
                            break;
                        case 1:
                            battleSystem.SetAttackStrategy(new CriticalAttack());
                            break;
                        case 2:
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
