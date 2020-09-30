using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissors.PublicEnums;

namespace RockPaperScissors
{
    public class Bot : IBot
    {
        private int _healthPoints;

        public Bot(int healthPoints)
        {
            _healthPoints = healthPoints;
        }

        public Options GetChoice()
        {
            Random rng = new Random();

            Array values = Enum.GetValues(typeof(Options));

            int choice = rng.Next(0, values.Length);

            return (Options)choice;

        }

        public int GetCurrentHealth()
        {
            return _healthPoints;
        }

        public int Lost()
        {
            _healthPoints--;
            return _healthPoints;
        }

        public int Won()
        {
            return _healthPoints;
        }
    }
}
