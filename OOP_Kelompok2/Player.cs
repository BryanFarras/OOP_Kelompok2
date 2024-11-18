using System;

namespace OOP_Kelompok2
{
    public class Player
    {
        public string? Name { get; set; }
        public int Heart { get; set; } // Nyawa dari karakter
        public int Juice { get; set; } // Magic point
        public int Attack { get; set; } // Damage yang diberikan
        public int Defense { get; set; } // Mengurangi damage dari musuh
        public int Speed { get; set; } // Menentukan giliran dalam pertarungan
        public int Luck { get; set; } // Peluang critical hit
        public int HitRate { get; set; } // Kemungkinan serangan berhasil
        
        // Method untuk menampilkan status karakter
        public void DisplayStatus()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Heart: {Heart}");
            Console.WriteLine($"Juice: {Juice}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Luck: {Luck}");
            Console.WriteLine($"Hit Rate: {HitRate}%");
        }
    }

    public class PlayerBuild
    {
        private static PlayerBuild? instance;
        private static readonly object lockObj = new object();

        private Player player = new Player();

        private PlayerBuild() { }

        public static PlayerBuild GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new PlayerBuild();
                    }
                }
            }
            return instance;
        }

        public PlayerBuild AddName(string name)
        {
            player.Name = name;
            return this;
        }

        public PlayerBuild AddHeart(int heart)
        {
            player.Heart = heart;
            return this;
        }

        public PlayerBuild AddJuice(int juice)
        {
            player.Juice = juice;
            return this;
        }

        public PlayerBuild AddAttack(int attack)
        {
            player.Attack = attack;
            return this;
        }

        public PlayerBuild AddDefense(int defense)
        {
            player.Defense = defense;
            return this;
        }

        public PlayerBuild AddSpeed(int speed)
        {
            player.Speed = speed;
            return this;
        }

        public PlayerBuild AddLuck(int luck)
        {
            player.Luck = luck;
            return this;
        }

        public PlayerBuild AddHitRate(int hitRate)
        {
            player.HitRate = hitRate;
            return this;
        }

        public Player Build()
        {
            Player builtPlayer = player;
            player = new Player(); // Reset player instance untuk build berikutnya
            return builtPlayer;
        }
    }
}
