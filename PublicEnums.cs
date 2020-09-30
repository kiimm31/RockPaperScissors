using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class PublicEnums
    {
        public enum Options
        {
            Rock,
            Paper,
            Scissors
        }

        public enum Winner
        {
            Player = 0,
            Bot = 1,
            Tie = 2
        }
    }
}
