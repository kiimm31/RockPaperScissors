using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissors.PublicEnums;

namespace RockPaperScissors
{
    class Program
    {
        private static Game _game { get; set; }

        static void Main(string[] args)
        {
            string playerName = string.Empty;
            while (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Please Enter Your Name:");
                playerName = Console.ReadLine();
            }

            int baseHp = 0;

            while (baseHp == 0)
            {
                Console.WriteLine("Please Enter Base Health Point");
                int.TryParse(Console.ReadLine(), out baseHp);
            }

            int baseMagicPotion = 0;

            while (baseMagicPotion == 0)
            {
                Console.WriteLine("Please Enter Base Magic Potion (Enter -1 for no magic potion)");
                int.TryParse(Console.ReadLine(), out baseMagicPotion);

            }

            IPlayer player = new Player(playerName, baseHp, baseMagicPotion);
            IBot bot = new Bot(baseHp);

            _game = new Game(player, bot);

            _game.StartGame();




            Console.ReadLine();
        }
    }
}
