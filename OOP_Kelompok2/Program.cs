using System;

namespace OOP_Kelompok2
{
    public class Program
    {
        static Player? player1;

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

            Story.Introduction(player1);
        }

        static void Update()
        {
            if (player1 == null)
            {
                Console.WriteLine("Player is not initialized.");
                return;
            }

            Story.StoryPath(player1); 
            Story.FinalBossEncounter(player1); 
        }
    }
}
