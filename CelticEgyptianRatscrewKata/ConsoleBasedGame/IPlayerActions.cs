using System;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    internal interface IPlayerActions
    {
        void Add(char key, PlayerMethod actionMethod, IPlayer player);
        void HandleKey(char key);
    }
}