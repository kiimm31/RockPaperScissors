using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissors.PublicEnums;

namespace RockPaperScissors
{
    public class Game
    {
        private readonly IPlayer _player;
        private readonly IBot _bot;

        public Game(IPlayer player, IBot bot)
        {
            _player = player;
            _bot = bot;
        }

        public void StartGame()
        {
            Console.WriteLine("Lets Play!");
            NewMatch();
        }

        public void NewMatch()
        {
            if (_player.GetCurrentMagicPotions() > 0)
            {
                Console.WriteLine($"Do you wanna drink your Magic Potion? Instock: {_player.GetCurrentMagicPotions()} --- Y/N");
                string drinkMP = string.Empty;

                while (string.IsNullOrWhiteSpace(drinkMP))
                {
                    drinkMP = Console.ReadLine().ToUpper();

                    if (drinkMP == "Y")
                    {
                        _player.UsePotion();
                    }
                    else if (drinkMP == "N")
                    {
                        Console.WriteLine($"YOU FOOL!!! YOU CANNOT BEAT ME WITHOUT HELP!!! MUAHAHAHAHA");
                    }
                    else
                    {//invalid choice
                        drinkMP = string.Empty;
                    }
                }
            }

            Options playerTurn = _player.GetChoice();
            Options botTurn = _bot.GetChoice();
            Winner winner = GetWinner(playerTurn, botTurn);

            // tabulate result 

            Console.WriteLine($"Your Choice : {playerTurn}");
            Console.WriteLine($"My Choice : {botTurn}");
            EndMatch(winner);
        }

        private void EndMatch(Winner winner)
        {
            switch (winner)
            {
                case Winner.Player:
                    _bot.Lost();
                    Console.WriteLine($"IMPOSSIBLE... {_player.GetPlayerName()}!! HOW CAN YOU BEAT ME!!");
                    break;
                case Winner.Bot:
                    _player.Lost();
                    Console.WriteLine($"You lost.. GGWP... Better luck next time {_player.GetPlayerName()}.. HUEHUEHUE");
                    break;
                case Winner.Tie:
                    Console.WriteLine($"Darn we tied...");
                    break;
            }

            if (_bot.GetCurrentHealth() == 0)
            {
                Console.WriteLine($"You have defeated me... *machine dying sounds* ------------------------");
            }
            else if (_player.GetCurrentHealth() == 0)
            {
                Console.WriteLine($"I HAVE DEFEATED YOU MERE MORTAL!!!!");
            }
            else
            {
                NewMatch();
            }
        }

        private Winner GetWinner(Options player, Options bot)
        {
            if (player == bot)
            {
                return Winner.Tie;
            }

            switch (player)
            {
                case Options.Rock:
                    switch (bot)
                    {
                        case Options.Paper:
                            return Winner.Bot;
                        case Options.Scissors:
                            return Winner.Player;
                    }
                    break;
                case Options.Paper:
                    switch (bot)
                    {
                        case Options.Scissors:
                            return Winner.Bot;
                        case Options.Rock:
                            return Winner.Player;
                    }
                    break;
                case Options.Scissors:
                    switch (bot)
                    {
                        case Options.Rock:
                            return Winner.Bot;
                        case Options.Paper:
                            return Winner.Player;
                    }
                    break;
                default:
                    return Winner.Tie;
            }

            return Winner.Tie;
        }
        
    }
}
