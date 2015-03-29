namespace CelticEgyptianRatscrewKata.Game
{
    public interface IGameControllerListener
    {
        void Notify(GameControllerUpdate update);
    }
}