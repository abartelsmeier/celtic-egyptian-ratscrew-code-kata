namespace CelticEgyptianRatscrewKata.Game
{
    public interface IPlayerTurnManager
    {
        PlayerTurnResult PlayCard(IPlayer player);
    }
}