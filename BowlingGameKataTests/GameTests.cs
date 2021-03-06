﻿using System;
using BowlingGameKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameKataTests
{
    [TestClass]
    public class GameTests
    {
        private Game game = new Game();

        [TestMethod]
        public void CanBowlGutterGame()
        {
            RollMany(20, 0);

            var score = game.Score();

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void CanBowlAllOnes()
        {
            RollMany(20, 1);

            var score = game.Score();

            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void CanBowlSpare()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(2);
            game.Roll(2);
            RollMany(16, 0);

            var score = game.Score();

            Assert.AreEqual(16, score);
        }

        [TestMethod]
        public void CanBowlStrike()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(2);
            game.Roll(2);
            RollMany(15, 0);

            var score = game.Score();

            Assert.AreEqual(26, score);
        }

        [TestMethod]
        public void CanBowlPerfectGame()
        {
            RollMany(12, 10);

            var score = game.Score();

            Assert.AreEqual(300, score);
        }

        private void RollMany(Int32 rolls, Int32 pins)
        {
            for (var roll=0; roll<rolls; roll++)
                game.Roll(pins);
        }
    }
}
