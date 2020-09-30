using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissors.PublicEnums;

namespace RockPaperScissors
{

    public class Player : IPlayer
    {
        private readonly string _playerName;
        private int _healthPoints;
        private int _magicPotion;

        public Player(string playerName, int healthPoints, int magicPotion)
        {
            _playerName = playerName;
            _healthPoints = healthPoints;
            _magicPotion = magicPotion;
        }

        public Options GetChoice()
        {
            int playerChoice = 0;
            Options myOption = Options.Paper;
            Array values = Enum.GetValues(typeof(Options));
            while (playerChoice == 0)
            {
                Console.WriteLine("Please Enter your Choice:");

                foreach (Options item in values)
                {
                    Console.WriteLine($"{(int)item} for {item}");
                }

                if (int.TryParse(Console.ReadLine(),out playerChoice) && Enum.TryParse<Options>(playerChoice.ToString(), out myOption))
                {
                    return myOption;
                }
            }

            return myOption; // default choice
        }

        public int GetCurrentHealth()
        {
            return _healthPoints;
        }

        public int GetCurrentMagicPotions()
        {
            return _magicPotion;
        }

        public string GetPlayerName()
        {
            return _playerName;
        }

        public int Lost()
        {
            Random rng = new Random();
            _healthPoints--;

            if (_healthPoints == 0)
            {
                int canUseMagicPotion = rng.Next() % 2;

                if (canUseMagicPotion == 1 && _magicPotion > 0)
                {
                    //i can use
                    UsePotion();
                }
            }

            return _healthPoints;
        }

        public int UsePotion()
        {
            _magicPotion--;
            _healthPoints++;
            return _healthPoints;
        }

        public int Won()
        {
            return _healthPoints;
        }
    }
}
