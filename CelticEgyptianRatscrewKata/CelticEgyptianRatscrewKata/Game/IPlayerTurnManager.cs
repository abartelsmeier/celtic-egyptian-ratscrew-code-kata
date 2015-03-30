namespace CelticEgyptianRatscrewKata.Game
{
    public interface IPlayerTurnManager
    {
        PlayCardResult PlayCard(IPlayer player);
    }
}