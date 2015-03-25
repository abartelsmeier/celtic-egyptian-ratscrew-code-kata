namespace CelticEgyptianRatscrewKata.Game
{
    interface IStackController
    {
        Cards Stack();
        void Shuffle();
        void Deal();
        void PlayCard(IPlayer player);
        void TakeStack(IPlayer player);
        IPlayer Winner();
    }
}