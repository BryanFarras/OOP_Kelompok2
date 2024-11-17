using System;

namespace OOP_Kelompok2
{
    public class Player
    {
        public string name { get; set; }
        public float health { get; set; }
    }

    public class PlayerBuild
    {
        private static PlayerBuild instance;
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
            player.name = name;
            return this;
        }

        public PlayerBuild AddHealth(float health)
        {
            player.health = health;
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
