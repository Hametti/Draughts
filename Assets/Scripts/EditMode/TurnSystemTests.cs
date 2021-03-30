using NUnit.Framework;
using Assets.Scripts.Base;
using UnityEngine;
using Assets.Scripts.Managers;
using Assets.Scripts.Mechanics;

namespace Tests
{
    class TurnSystemTests
    {
        [Test]
        public void EndTurnTest()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(2, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[1].GameObj, new Vector3(4, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[2].GameObj, new Vector3(6, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[3].GameObj, new Vector3(8, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[4].GameObj, new Vector3(10, 0, 4));

            GameMechanics.Move(CheckerManager.BlueCheckers[5].GameObj, new Vector3(1, 0, 5));
            GameMechanics.Move(CheckerManager.BlueCheckers[6].GameObj, new Vector3(3, 0, 5));
            GameMechanics.Move(CheckerManager.BlueCheckers[7].GameObj, new Vector3(5, 0, 5));
            GameMechanics.Move(CheckerManager.BlueCheckers[8].GameObj, new Vector3(7, 0, 5));
            GameMechanics.Move(CheckerManager.BlueCheckers[9].GameObj, new Vector3(9, 0, 5));

            TurnSystem.EndTurn();
            string result = GameObject.Find("PlayerWinsText").GetComponent<TMPro.TextMeshPro>().text;

            GameMechanics.ResetGame();

            Assert.AreEqual("Blue player wins", result);
        }

        [Test]
        public void EndTurnTest2()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(1, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[1].GameObj, new Vector3(3, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[2].GameObj, new Vector3(5, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[3].GameObj, new Vector3(7, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[4].GameObj, new Vector3(9, 0, 7));

            GameMechanics.Move(CheckerManager.BrownCheckers[5].GameObj, new Vector3(2, 0, 6));
            GameMechanics.Move(CheckerManager.BrownCheckers[6].GameObj, new Vector3(4, 0, 6));
            GameMechanics.Move(CheckerManager.BrownCheckers[7].GameObj, new Vector3(6, 0, 6));
            GameMechanics.Move(CheckerManager.BrownCheckers[8].GameObj, new Vector3(8, 0, 6));
            GameMechanics.Move(CheckerManager.BrownCheckers[9].GameObj, new Vector3(10, 0, 6));

            TurnSystem.EndTurn();
            string result = GameObject.Find("PlayerWinsText").GetComponent<TMPro.TextMeshPro>().text;

            GameMechanics.ResetGame();

            Assert.AreEqual("Brown player wins", result);
        }

        [Test]
        public void EndTurnTest3()
        {
            TurnSystem.InitializeData();

            TurnSystem.BrownPlayerTurn = true;
            TurnSystem.EndTurn();
            int layer = CheckerManager.BrownCheckers[0].GameObj.layer;

            GameMechanics.ResetGame();

            Assert.AreEqual(0, layer);
        }

        [Test]
        public void EndTurnTest4()
        {
            TurnSystem.InitializeData();

            TurnSystem.BrownPlayerTurn = true;
            TurnSystem.EndTurn();
            TurnSystem.EndTurn();
            int layer = CheckerManager.BrownCheckers[0].GameObj.layer;

            GameMechanics.ResetGame();

            Assert.AreEqual(8, layer);
        }

        [Test]
        public void EndTurnTest5()
        {
            TurnSystem.InitializeData();

            TurnSystem.FirstMove = false;
            TurnSystem.EndTurn();
            bool result = TurnSystem.FirstMove;

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MakeBrownCheckersClickableTest()
        {
            TurnSystem.InitializeData();

            TurnSystem.MakeBrownCheckersClickable();
            int layer = CheckerManager.BrownCheckers[0].GameObj.layer;

            GameMechanics.ResetGame();

            Assert.AreEqual(8, layer);
        }

        [Test]
        public void MakeBrownCheckersClickableTest2()
        {
            TurnSystem.InitializeData();

            TurnSystem.MakeBrownCheckersClickable();
            TurnSystem.MakeBlueCheckersClickable();
            int layer = CheckerManager.BrownCheckers[0].GameObj.layer;

            GameMechanics.ResetGame();

            Assert.AreEqual(0, layer);
        }

        [Test]
        public void MakeBrownCheckersClickableTest3()
        {
            TurnSystem.InitializeData();

            TurnSystem.MakeBrownCheckersClickable();
            TurnSystem.MakeBlueCheckersClickable();
            TurnSystem.MakeBrownCheckersClickable();
            int layer = CheckerManager.BrownCheckers[0].GameObj.layer;

            GameMechanics.ResetGame();

            Assert.AreEqual(8, layer);
        }

        [Test]
        public void MakeBlueCheckersClickableTest()
        {
            TurnSystem.InitializeData();

            TurnSystem.MakeBlueCheckersClickable();
            int layer = CheckerManager.BlueCheckers[0].GameObj.layer;

            GameMechanics.ResetGame();

            Assert.AreEqual(8, layer);
        }

        [Test]
        public void MakeBlueCheckersClickableTest2()
        {
            TurnSystem.InitializeData();

            TurnSystem.MakeBlueCheckersClickable();
            TurnSystem.MakeBrownCheckersClickable();
            int layer = CheckerManager.BlueCheckers[0].GameObj.layer;

            GameMechanics.ResetGame();

            Assert.AreEqual(0, layer);
        }

        [Test]
        public void MakeBlueCheckersClickableTest3()
        {
            TurnSystem.InitializeData();

            TurnSystem.MakeBlueCheckersClickable();
            TurnSystem.MakeBrownCheckersClickable();
            TurnSystem.MakeBlueCheckersClickable();
            int layer = CheckerManager.BlueCheckers[0].GameObj.layer;

            GameMechanics.ResetGame();

            Assert.AreEqual(8, layer);
        }

        [Test]
        public void StartGameTest()
        {
            TurnSystem.InitializeData();

            TurnSystem.StartGame();
            bool result = TurnSystem.BrownPlayerTurn;

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void StartGameTest2()
        {
            TurnSystem.InitializeData();

            TurnSystem.StartGame();
            bool result = TurnSystem.FirstMove;

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }
    }
}
