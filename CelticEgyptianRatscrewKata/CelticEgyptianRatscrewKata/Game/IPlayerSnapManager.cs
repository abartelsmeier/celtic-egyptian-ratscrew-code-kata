namespace CelticEgyptianRatscrewKata.Game
{
    public interface IPlayerSnapManager
    {
        PlayerSnapResult AttemptSnap(IPlayer player);
    }
}