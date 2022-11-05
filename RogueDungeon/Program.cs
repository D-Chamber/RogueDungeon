using System;

namespace RogueDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            game.Play();
            game.End();
        }
    }
}
