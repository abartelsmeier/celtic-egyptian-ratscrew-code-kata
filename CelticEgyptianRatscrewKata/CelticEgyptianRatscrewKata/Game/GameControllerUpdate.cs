namespace CelticEgyptianRatscrewKata.Game
{
    public class GameControllerUpdate
    {
        public GameStateUpdate State { get; private set; }
        public IPlayer Player { get; private set; }
        public IPlayer NextPlayer { get; private set; }
        public GameControllerAction Action { get; private set; }

        public GameControllerUpdate(GameStateUpdate state, IPlayer player, IPlayer nextPlayer, GameControllerAction action)
        {
            State = state;
            Player = player;
            NextPlayer = nextPlayer;
            Action = action;
        }
    }

    public enum GameControllerAction
    {
        PlayCardSuccess,
        PlayCardFail,
        AttemptSnapSuccess,
        AttemptSnapFail,
        WinGame
    }

}