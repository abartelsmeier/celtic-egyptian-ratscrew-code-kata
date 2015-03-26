using System;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    internal interface IPlayerActions
    {
        void Add(char key, Action<IPlayer> actionMethod, IPlayer player);
        void HandleKey(char key);
    }
}