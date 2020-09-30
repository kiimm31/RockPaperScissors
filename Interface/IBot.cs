using System;
using static RockPaperScissors.PublicEnums;

namespace RockPaperScissors
{
    public interface IBot
    {
        int Lost();
        int Won();
        Options GetChoice();
        int GetCurrentHealth();
    }
}