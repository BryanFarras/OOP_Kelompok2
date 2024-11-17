using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_Kelompok2
{
    class Program
    {
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Memunculkan form utama
            Application.Run(new MainForm());
        }

        static void Start()
        {
            Player player1 = PlayerBuild.GetInstance()
                                        .AddName("John")
                                        .AddHealth(100)
                                        .Build();
            Console.WriteLine("Name: " + player1.name);
            Console.WriteLine("Health: " + player1.health);
        }

        static void Update()
        {
            Console.WriteLine("Game is running...");
        }
    }
}