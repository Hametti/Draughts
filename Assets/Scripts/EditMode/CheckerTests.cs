using NUnit.Framework;
using Assets.Scripts.Base;
using UnityEngine;

namespace Tests
{
    public class CheckerTests
    {
        [Test]
        public void MakingNewChecker()
        {
            Checker checker = new Checker();
            Assert.IsNotNull(checker.GameObj);
        }

        [Test]
        public void MakingNewChecker2()
        {
            Checker checker = new Checker();
            Assert.AreEqual(checker.PlayerColor, "");
        }

        [Test]
        public void MakingNewChecker3()
        {
            Checker checker = new Checker();
            Assert.AreEqual(checker.IsKing, false);
        }

        [Test]
        public void MakingNewChecker4()
        {
            Checker checker = new Checker();
            Assert.AreEqual(checker.Selected, false);
        }

        [Test]
        public void MakingNewCheckerWithConstructor()
        {
            GameObject gameObj = new GameObject();
            Checker checker = new Checker(gameObj, "blue");
            Assert.IsNotNull(checker.GameObj);
        }

        [Test]
        public void MakingNewCheckerWithConstructor2()
        {
            GameObject gameObj = new GameObject();
            Checker checker = new Checker(gameObj, "blue");
            Assert.AreEqual(checker.PlayerColor, "blue");
        }
    }
}
