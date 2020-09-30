using static RockPaperScissors.PublicEnums;

namespace RockPaperScissors
{
    public interface IPlayer
    {
        int Lost();
        int Won();
        Options GetChoice();
        int GetCurrentHealth();
        int GetCurrentMagicPotions();
        string GetPlayerName();
        int UsePotion();
        
    }
}