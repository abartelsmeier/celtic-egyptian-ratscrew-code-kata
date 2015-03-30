using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.ActionManagement
{
    public interface IPlayerSnapManager
    {
        PlayerSnapResult AttemptSnap(IPlayer player);
    }
}