using NUnit.Framework;
using Assets.Scripts.Base;
using Assets.Scripts.Managers;
using Assets.Scripts.Mechanics;
using UnityEngine;

namespace Tests
{
    class CheckerManagerTests
    {
        [Test]
        public void RemoveEnemyBetweenTest()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(3, 0.3f, 7));
            CheckerManager.RemoveEnemyBetween(CheckerManager.BlueCheckers[14].GameObj, FieldManager.BlackFieldsBoard[26].GameObject);

            float position = CheckerManager.BrownCheckers[0].GameObj.transform.position.y;

            GameMechanics.ResetGame();

            Assert.AreEqual(50, position);
        }

        [Test]
        public void RemoveEnemyBetweenTest2()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(3, 0.3f, 7));
            CheckerManager.RemoveEnemyBetween(CheckerManager.BlueCheckers[14].GameObj, FieldManager.BlackFieldsBoard[26].GameObject);
            int state = FieldManager.BlackFieldsBoard[31].State;

            GameMechanics.ResetGame();

            Assert.AreEqual(1, state);
        }

        [Test]
        public void SelectCheckerTest()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BrownCheckers[0];
            CheckerManager.SelectChecker(testObj.GameObj);

            float yPosition = testObj.GameObj.transform.position.y;

            GameMechanics.ResetGame();

            Assert.AreEqual(0.8f, yPosition);
        }

        [Test]
        public void SelectCheckerTest2()
        {
            TurnSystem.InitializeData();

            CheckerManager.DeselectCheckers();
            Checker testObj = CheckerManager.BrownCheckers[0];
            CheckerManager.SelectChecker(testObj.GameObj);
            CheckerManager.SelectChecker(testObj.GameObj);

            float yPosition = testObj.GameObj.transform.position.y;


            GameMechanics.ResetGame();

            Assert.AreEqual(0.3f, yPosition);
        }

        [Test]
        public void DeselectCheckerTest()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BlueCheckers[0];
            CheckerManager.SelectChecker(testObj.GameObj);
            CheckerManager.DeselectCheckers();

            GameMechanics.ResetGame();

            Assert.AreEqual(0.3f, testObj.GameObj.transform.position.y);
        }

        [Test]
        public void LiftCheckerTest()
        {
            TurnSystem.InitializeData();

            CheckerManager.LiftChecker(CheckerManager.BlueCheckers[0].GameObj);
            float yPosition = CheckerManager.BlueCheckers[0].GameObj.transform.position.y;

            GameMechanics.ResetGame();

            Assert.AreEqual(0.8f, yPosition);
        }

        [Test]
        public void LiftCheckerTest2()
        {
            TurnSystem.InitializeData();

            CheckerManager.LiftChecker(CheckerManager.BlueCheckers[0].GameObj);
            CheckerManager.LiftChecker(CheckerManager.BlueCheckers[0].GameObj);
            float yPosition = CheckerManager.BlueCheckers[0].GameObj.transform.position.y;

            GameMechanics.ResetGame();

            Assert.AreEqual(0.8f, yPosition);
        }

        [Test]
        public void DropCheckerTest()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BlueCheckers[0];
            CheckerManager.DropChecker(testObj.GameObj);

            GameMechanics.ResetGame();

            Assert.AreEqual(0.3f, testObj.GameObj.transform.position.y);
        }

        [Test]
        public void DropCheckerTest2()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BlueCheckers[0];
            CheckerManager.DropChecker(testObj.GameObj);
            CheckerManager.DropChecker(testObj.GameObj);

            GameMechanics.ResetGame();

            Assert.AreEqual(0.3f, testObj.GameObj.transform.position.y);
        }

        [Test]
        public void SelectedCheckerTest()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BlueCheckers[0];
            CheckerManager.SelectChecker(testObj.GameObj);
            Checker result = CheckerManager.SelectedChecker();

            GameMechanics.ResetGame();

            Assert.AreEqual(result, testObj);
        }

        [Test]
        public void SelectedCheckerTest2()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BlueCheckers[0];
            Checker testObj2 = CheckerManager.BlueCheckers[1];
            CheckerManager.SelectChecker(testObj.GameObj);
            CheckerManager.DeselectCheckers();
            CheckerManager.SelectChecker(testObj2.GameObj);
            Checker result = CheckerManager.SelectedChecker();

            GameMechanics.ResetGame();

            Assert.AreEqual(result, testObj2);
        }
        
        [Test]
        public void CheckerOnPositionTest()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BlueCheckers[0];

            GameMechanics.ResetGame();

            Assert.AreEqual(CheckerManager.CheckerOnPosition(new Vector3(10, 0.3f, 10)), testObj);
        }

        [Test]
        public void CheckerOnPositionTest2()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BrownCheckers[0];

            GameMechanics.ResetGame();

            Assert.AreEqual(CheckerManager.CheckerOnPosition(testObj.GameObj.transform.position), testObj);
        }

        [Test]
        public void CheckerWithGameObjectTest()
        {
            TurnSystem.InitializeData();

            Checker testObj = CheckerManager.BlueCheckers[0];
            GameObject gameobj = testObj.GameObj;

            GameMechanics.ResetGame();

            Assert.AreEqual(CheckerManager.CheckerWithGameobject(gameobj), testObj);
        }

        [Test]
        public void MakeCheckersArrayTest()
        {
            TurnSystem.InitializeData();

            Assert.AreEqual(GameObject.Find("P1 (1)"), CheckerManager.BrownCheckers[0].GameObj);
        }

        [Test]
        public void MakeCheckersArrayTest2()
        {
            TurnSystem.InitializeData();

            Assert.AreEqual(GameObject.Find("P2 (1)"), CheckerManager.BlueCheckers[0].GameObj);
        }

        [Test]
        public void GetDefaultCheckersPositionTest()
        {
            TurnSystem.InitializeData();

            Assert.AreEqual(CheckerManager.BrownCheckers[0].GameObj.transform.position, CheckerManager.BrownDefaultPositions[0]);
        }

        [Test]
        public void GetDefaultCheckersPositionTest2()
        {
            TurnSystem.InitializeData();

            Assert.AreEqual(new Vector3(1, 0.3f, 1), CheckerManager.BrownDefaultPositions[0]);
        }

        [Test]
        public void ResetCheckersPositionTest()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(5, 0.3f, 5));
            CheckerManager.ResetCheckersPosition();

            GameMechanics.ResetGame();

            Assert.AreEqual(CheckerManager.BrownCheckers[0].GameObj.transform.position, CheckerManager.BrownDefaultPositions[0]);
        }

        [Test]
        public void ResetCheckerStateTest()
        {
            TurnSystem.InitializeData();

            CheckerManager.BrownCheckers[0].IsKing = true;
            CheckerManager.ResetCheckersState();

            GameMechanics.ResetGame();

            Assert.AreEqual(false, CheckerManager.BrownCheckers[0].IsKing);
        }
    }
}
