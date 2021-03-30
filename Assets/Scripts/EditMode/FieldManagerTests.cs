using NUnit.Framework;
using Assets.Scripts.Base;
using UnityEngine;
using Assets.Scripts.Managers;
using Assets.Scripts.Mechanics;

namespace Tests
{
    class FieldManagerTests
    {
        [Test]
        public void MakingFieldsArrayTest()
        {
            TurnSystem.InitializeData();

            FieldManager.MakeFieldsArray();

            Assert.AreEqual(2, FieldManager.BlackFieldsBoard[0].State);
        }

        [Test]
        public void MakingFieldsArrayTest2()
        {
            TurnSystem.InitializeData();

            FieldManager.MakeFieldsArray();

            Assert.AreEqual(1, FieldManager.BlackFieldsBoard[15].State);
        }

        [Test]
        public void MakingFieldsArrayTest3()
        {
            TurnSystem.InitializeData();

            FieldManager.MakeFieldsArray();

            Assert.AreEqual(3, FieldManager.BlackFieldsBoard[35].State);
        }

        [Test]
        public void MakingFieldsArrayTest4()
        {
            TurnSystem.InitializeData();

            FieldManager.MakeFieldsArray();

            Assert.AreEqual(GameObject.Find("Black (1)"), FieldManager.BlackFieldsBoard[0].GameObject);
        }

        [Test]
        public void GetSurroundingFieldsTest()
        {
            TurnSystem.InitializeData();

            Field[] surroundingFieldsTestArray = FieldManager.GetSurroundingFields(CheckerManager.BrownCheckers[0]);

            GameMechanics.ResetGame();

            Assert.AreEqual(1, surroundingFieldsTestArray.Length);
        }

        [Test]
        public void GetSurroundingFieldsTest2()
        {
            TurnSystem.InitializeData();

            Field[] surroundingFieldsTestArray = FieldManager.GetSurroundingFields(CheckerManager.BlueCheckers[9]);

            GameMechanics.ResetGame();

            Assert.AreEqual(2, surroundingFieldsTestArray.Length);
        }

        [Test]
        public void FieldExistsTest()
        {
            TurnSystem.InitializeData();
            Assert.AreEqual(true, FieldManager.FieldExists(new Vector3(5, 0, 5)));
        }

        [Test]
        public void FieldExistsTest2()
        {
            TurnSystem.InitializeData();
            Assert.AreEqual(true, FieldManager.FieldExists(new Vector3(1, 0, 1)));
        }

        [Test]
        public void FieldExistsTest4()
        {
            TurnSystem.InitializeData();

            Assert.AreEqual(true, FieldManager.FieldExists(new Vector3(10, 0, 10)));
        }

        [Test]
        public void FieldExistsTest5()
        {
            TurnSystem.InitializeData();

            Assert.AreEqual(false, FieldManager.FieldExists(new Vector3(11, 0, 11)));
        }

        [Test]
        public void GetFieldByPositionTest()
        {
            TurnSystem.InitializeData();

            Field field = FieldManager.GetFieldByPosition(new Vector3(1, 0, 1));

            GameMechanics.ResetGame();

            Assert.AreEqual(GameObject.Find("Black (1)"), field.GameObject);
        }

        [Test]
        public void GetFieldByPositionTest2()
        {
            TurnSystem.InitializeData();

            Field field = FieldManager.GetFieldByPosition(new Vector3(10, 0, 10));

            GameMechanics.ResetGame();

            Assert.AreEqual(GameObject.Find("Black (50)"), field.GameObject);
        }

        [Test]
        public void FieldUnderCheckerTest()
        {
            TurnSystem.InitializeData();

            Field field = FieldManager.FieldUnderChecker(CheckerManager.BrownCheckers[0].GameObj);

            GameMechanics.ResetGame();

            Assert.AreEqual(GameObject.Find("Black (1)"), field.GameObject);
        }

        [Test]
        public void FieldUnderCheckerTest2()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[10].GameObj, new Vector3(2, 0, 4));
            Field field = FieldManager.FieldUnderChecker(CheckerManager.BrownCheckers[10].GameObj);
            CheckerManager.ResetCheckersPosition();
            FieldManager.ResetFieldStates();

            GameMechanics.ResetGame();

            Assert.AreEqual(GameObject.Find("Black (16)"), field.GameObject);
        }

        [Test]
        public void FieldWithGameObjectTest()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[10].GameObj, new Vector3(2, 0, 4));
            Field field = FieldManager.FieldUnderChecker(CheckerManager.BrownCheckers[10].GameObj);
            Field field2 = FieldManager.FieldWithGameObject(field.GameObject);
            CheckerManager.ResetCheckersPosition();
            FieldManager.ResetFieldStates();

            GameMechanics.ResetGame();

            Assert.AreEqual(FieldManager.BlackFieldsBoard[15], field2);
        }

        [Test]
        public void ResetFieldStatesTest()
        {
            TurnSystem.InitializeData();

            FieldManager.ModifyFieldStateUnder(CheckerManager.BrownCheckers[0].GameObj, 3);
            FieldManager.ResetFieldStates();
            int state = FieldManager.FieldUnderChecker(CheckerManager.BrownCheckers[0].GameObj).State;

            GameMechanics.ResetGame();

            Assert.AreEqual(2, state);

        }

        [Test]
        public void ModifyFieldStateUnderTest()
        {
            TurnSystem.InitializeData();

            FieldManager.ModifyFieldStateUnder(CheckerManager.BrownCheckers[0].GameObj, 3);
            int state = FieldManager.FieldUnderChecker(CheckerManager.BrownCheckers[0].GameObj).State;
            FieldManager.ResetFieldStates();

            GameMechanics.ResetGame();

            Assert.AreEqual(3, state);
        }

    }
}
