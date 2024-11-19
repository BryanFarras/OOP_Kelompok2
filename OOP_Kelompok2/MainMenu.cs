using System;

namespace OOP_Kelompok2
{
    public class MainMenu
    {
        public static void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== DREAMSCAPE ADVENTURE ヽ(O_O )ﾉ ===");
                Console.WriteLine("1. Play Game");
                Console.WriteLine("2. ReadMe");
                Console.WriteLine("3. Credit");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                
                int option;
                bool validInput = int.TryParse(Console.ReadLine(), out option);

                if (validInput)
                {
                    Console.Clear();
                    switch (option)
                    {
                        case 1:
                            Program.StartGame(); // Memulai permainan
                            break;
                        case 2:
                            ShowReadMe();
                            break;
                        case 3:
                            ShowCredits();
                            break;
                        case 4:
                            exit = true;
                            Console.WriteLine("Exiting the game. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                }
            }
        }

        private static void ShowReadMe()
        {
            Console.WriteLine("=== ReadMe ===");
            Console.WriteLine("Dreamscape Adventure adalah game RPG berbasis teks yang terinspirasi oleh game Omori. Pemain akan menjelajahi dunia mimpi yang penuh teka-teki, bertarung melawan musuh yang mencerminkan emosi dan konflik batin, serta mengalami perubahan emosi yang mempengaruhi kemampuan mereka dalam pertempuran.");
            Console.WriteLine("This is a game where you can play, explore, and have fun!");
        }

        private static void ShowCredits()
        {
            Console.WriteLine("=== Credits ===");
            Console.WriteLine("Developed by Kelompok 2");
             Console.WriteLine("Bryan Jawir");
            Console.WriteLine("Barnabi Semarang");
            Console.WriteLine("Mussy iman");
            Console.WriteLine("Titisan netahayu harahap");
        }
    }
}
