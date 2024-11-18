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
        }

        static void Start()
        {
            Player player1 = PlayerBuild.GetInstance()
                                        .AddName("Excelcus")
                                        .AddHeart(100)
                                        .AddJuice(50)
                                        .AddAttack(30)
                                        .AddDefense(20)
                                        .AddSpeed(15)
                                        .AddLuck(5)
                                        .AddHitRate(90)
                                        .Build();

            player1.DisplayStatus();
        }

        static void Update()
        {
            Console.WriteLine("Game is running...");
        }
    }
}