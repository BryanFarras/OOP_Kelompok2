using System;

namespace OOP_Kelompok2
{
    public class Program
    {
        static Player? player1;
        static Enemy? goblin;
        static Inventory? inventory;

        [STAThread]
        static void Main(string[] args)
        {
            MainMenu.ShowMenu();
        }

        public static void StartGame()
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
            player1 = new PlayerBuild()
                        .AddName("Dreamer")
                        .AddHeart(100)
                        .AddJuice(50)
                        .AddAttack(20)
                        .AddDefense(15)
                        .AddSpeed(10)
                        .AddLuck(5)
                        .AddHitRate(90)
                        .Build();

            Console.WriteLine("\n=== Player Status ===");
            player1.DisplayStatus();

            Console.Clear();
            Story.Introduction(player1);
        }

        static void Update()
        {
            BattleSystem battleSystem = new BattleSystem();
            goblin = EnemyFactory.CreateEnemy("goblin");

            Console.WriteLine("\n=== Battle Start ===");
            goblin.DisplayStatus();

            bool gameRunning = true;

            while (gameRunning)
            {
                Console.WriteLine("Player is not initialized.");
                return;
            }

            Story.StoryPath(player1); 
            Story.FinalBossEncounter(player1); 
        }

        static void StartingInventory()
        {
            inventory.AddItem(new Potion());
            inventory.AddItem(new AttackBoostDecorator(new Potion()));
            inventory.AddItem(new EmotionChangerDecorator(new HappyCandy(), "Happy"));

            Console.WriteLine("\n=== Player Status ===");
            player1.DisplayStatus();
        }

    }
}
