using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Kelompok2
{
    public class Player
    {
        public string name{get; set;}
        public float health{get; set;}
        
    }

    public class PlayerBuild
    {
        private Player player = new Player();
        public PlayerBuild addName (string name){
            player.name = name;
            return this;
        }

        public PlayerBuild addHealth(float health){
            player.health = health;
            return this;
        }

        public Player build(){
            return player;
        }
    }
}