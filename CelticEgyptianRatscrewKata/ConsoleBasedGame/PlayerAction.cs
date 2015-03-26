using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    internal delegate void PlayerMethod(IPlayer player);

    internal class PlayerAction
    {
        private readonly PlayerMethod m_Method;
        private readonly IPlayer m_Player;

        public PlayerAction(PlayerMethod method, IPlayer player)
        {
            m_Method = method;
            m_Player = player;
        }

        public void Execute()
        {
            m_Method(m_Player);
        }
    }
}