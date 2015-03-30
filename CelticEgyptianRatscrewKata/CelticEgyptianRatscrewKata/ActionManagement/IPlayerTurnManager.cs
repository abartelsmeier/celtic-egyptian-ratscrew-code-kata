using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.ActionManagement
{
    public interface IPlayerTurnManager
    {
        PlayerTurnResult PlayCard(IPlayer player);
    }
}