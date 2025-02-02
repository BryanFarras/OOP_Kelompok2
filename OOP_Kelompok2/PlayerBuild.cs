namespace OOP_Kelompok2
{
    public class PlayerBuild
    {
        private static PlayerBuild? instance;
        private static readonly object lockObj = new object();

        private Player player = new Player();

        public PlayerBuild() { }

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
            return player;
        }
    }
}
