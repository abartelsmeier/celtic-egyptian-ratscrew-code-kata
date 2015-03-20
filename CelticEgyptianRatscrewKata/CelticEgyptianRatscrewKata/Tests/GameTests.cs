﻿using NUnit.Framework;
using System;
using Moq;
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

        [Test]
        public void ShouldAddPlayerToGame()
        {
            Game game = new Game();
            var player = new Player();
            game.AddPlayer(player);
            Assert.Pass();
        }
    }
}
