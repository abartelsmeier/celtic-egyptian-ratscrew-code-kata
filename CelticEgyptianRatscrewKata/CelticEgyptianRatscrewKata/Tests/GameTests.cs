using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Tests
{
    class GameTests
    {
        [Test]
        public void ShouldCreateGame()
        {
            Game game = new Game();
            Assert.That(game, Is.TypeOf(typeof(Game)));
        }
    }
}
