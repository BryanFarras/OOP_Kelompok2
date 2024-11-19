using System;

namespace OOP_Kelompok2
{
    class Program
    {
        static Player? player1;
        static Enemy? goblin;

        [STAThread]
        static void Main(string[] args)
        {
            Awake();  
            Start();  
            Update(); 
        }

        static void Awake()
        {
            Console.WriteLine("Game is initializing...");
        }

        static void Start()
        {
            // Membuat player
            player1 = PlayerBuild.GetInstance()
                        .AddName("Excelcus")
                        .AddHeart(100)
                        .AddJuice(50)
                        .AddAttack(30)
                        .AddDefense(20)
                        .AddSpeed(15)
                        .AddLuck(5)
                        .AddHitRate(90)
                        .Build();

            Console.WriteLine("\n=== Player Status ===");
            player1.DisplayStatus();

            Story.Intro(player1);

            // Membuat musuh
            goblin = EnemyFactory.CreateEnemy("goblin");
        }

        static void Update()
        {
            BattleSystem battleSystem = new BattleSystem();
            Console.WriteLine("\n=== Battle Start ===");
            goblin.DisplayStatus();

            bool gameRunning = true;

            while (gameRunning)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Normal Attack");
                Console.WriteLine("2. Critical Attack");
                Console.WriteLine("3. Emotion Attack");
                Console.WriteLine("4. Exit Battle");

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
                        Console.WriteLine("Exiting the battle...");
                        gameRunning = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        continue;
                }

                // Eksekusi serangan
                battleSystem.ExecuteStrategy(player1, goblin);

                // Status musuh setelah serangan
                Console.WriteLine("\n=== Enemy Status ===");
                goblin.DisplayStatus();

                // Cek jika musuh kalah
                if (goblin.Heart <= 0)
                {
                    Console.WriteLine($"{goblin.Name} has been defeated!");
                    gameRunning = false;
                }

                // Cek jika pemain kalah (opsional)
                if (player1.Heart <= 0)
                {
                    Console.WriteLine($"{player1.Name} has been defeated! Game Over.");
                    gameRunning = false;
                }
            }
        }
    }
}
