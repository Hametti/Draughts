using NUnit.Framework;
using Assets.Scripts.Base;
using UnityEngine;
using Assets.Scripts.Managers;
using Assets.Scripts.Mechanics;

namespace Tests
{
    class GameMechanicsTests
    {
        [Test]
        public void SomeoneWinTest()
        {
            TurnSystem.InitializeData();

            Assert.AreEqual(false, GameMechanics.SomeoneWin());

            GameMechanics.ResetGame();
        }

        [Test]
        public void SomeoneWinTest2()
        {
            TurnSystem.InitializeData();

            for (int i = 0; i < CheckerManager.BrownCheckers.Length; i++)
            {
                GameObject gameObj = CheckerManager.BrownCheckers[i].GameObj;
                Vector3 finalPos = gameObj.transform.position;
                finalPos.y = 100;

                gameObj.transform.position = Vector3.Lerp(gameObj.transform.position, finalPos, 100);
            }
            bool result = GameMechanics.SomeoneWin();

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void SomeoneWinTest3()
        {
            TurnSystem.InitializeData();

            for (int i = 0; i < CheckerManager.BlueCheckers.Length; i++)
            {
                GameObject gameObj = CheckerManager.BlueCheckers[i].GameObj;
                Vector3 finalPos = gameObj.transform.position;
                finalPos.y = 100;

                gameObj.transform.position = Vector3.Lerp(gameObj.transform.position, finalPos, 100);
            }
            bool result = GameMechanics.SomeoneWin();

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void CheckWhoWonTest()
        {
            TurnSystem.InitializeData();

            for (int i = 0; i < CheckerManager.BlueCheckers.Length; i++)
            {
                GameObject gameObj = CheckerManager.BlueCheckers[i].GameObj;
                Vector3 finalPos = gameObj.transform.position;
                finalPos.y = 100;

                gameObj.transform.position = Vector3.Lerp(gameObj.transform.position, finalPos, 100);
            }
            string result = GameMechanics.CheckWhoWon();

            GameMechanics.ResetGame();

            Assert.AreEqual("Brown", result);
        }

        [Test]
        public void CheckWhoWonTest2()
        {
            TurnSystem.InitializeData();

            for (int i = 0; i < CheckerManager.BrownCheckers.Length; i++)
            {
                GameObject gameObj = CheckerManager.BrownCheckers[i].GameObj;
                Vector3 finalPos = gameObj.transform.position;
                finalPos.y = 100;
                gameObj.transform.position = Vector3.Lerp(gameObj.transform.position, finalPos, 100);
            }
            string result = GameMechanics.CheckWhoWon();

            GameMechanics.ResetGame();

            Assert.AreEqual("Blue", result);
        }

        [Test]
        public void MoveTest()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(2, 0, 4));
            Vector3 position = CheckerManager.BrownCheckers[0].GameObj.transform.position;

            GameMechanics.ResetGame();

            Assert.AreEqual(new Vector3(2, 0.3f, 4), position);
        }

        [Test]
        public void MoveTest2()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(2, 0, 4));
            int state = FieldManager.FieldUnderChecker(CheckerManager.BrownCheckers[0].GameObj).State;

            GameMechanics.ResetGame();

            Assert.AreEqual(2, state);
        }

        [Test]
        public void MoveTest3()
        {
            TurnSystem.InitializeData();

            Field field = FieldManager.FieldUnderChecker(CheckerManager.BrownCheckers[0].GameObj);
            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(2, 0, 4));
            int state = field.State;

            GameMechanics.ResetGame();

            Assert.AreEqual(1, state);
        }

        [Test]
        public void CanCheckerJumpTest()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.CanCheckerJump(CheckerManager.BrownCheckers[0]);

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void CanCheckerJumpTest2()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.CanCheckerJump(CheckerManager.BlueCheckers[0]);

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void CanCheckerJumpTest3()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(8, 0, 4));
            bool result = GameMechanics.CanCheckerJump(CheckerManager.BrownCheckers[14]);

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void CanCheckerJumpTest4()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(3, 0, 7));
            bool result = GameMechanics.CanCheckerJump(CheckerManager.BlueCheckers[14]);

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void CanCheckerJumpTest5()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(2, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(3, 0, 5));
            bool result = GameMechanics.CanCheckerJump(CheckerManager.BrownCheckers[0]);

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyJumpPossibleTest()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(1, 0, 7));
            bool result = GameMechanics.IsAnyJumpPossible("Blue");

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsAnyJumpPossibleTest2()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(3, 0, 7));
            bool result = GameMechanics.IsAnyJumpPossible("Blue");

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyJumpPossibleTest3()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(10, 0, 4));
            bool result = GameMechanics.IsAnyJumpPossible("Brown");

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsAnyJumpPossibleTest4()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(2, 0, 4));
            bool result = GameMechanics.IsAnyJumpPossible("Brown");

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyJumpPossibleTest5()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsAnyJumpPossible("Brown");

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsAnyCheckerOnPositionTest()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsAnyCheckerOnPosition(new Vector3(1, 0.3f, 1));

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyCheckerOnPositionTest2()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(1, 0, 7));
            bool result = GameMechanics.IsAnyCheckerOnPosition(new Vector3(1, 0.3f, 1));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsAnyCheckerOnPositionTest3()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsAnyCheckerOnPosition(new Vector3(2, 0.3f, 10));

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyCheckerOnPositionTest4()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[4].GameObj, new Vector3(2, 0, 4));
            bool result = GameMechanics.IsAnyCheckerOnPosition(new Vector3(2, 0.3f, 10));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsMovePossibleTest()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsMovePossible(CheckerManager.BrownCheckers[0].GameObj, GameObject.Find("Black (50)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsMovePossibleTest2()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsMovePossible(CheckerManager.BrownCheckers[0].GameObj, GameObject.Find("Black (6)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsMovePossibleTest3()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[5].GameObj, new Vector3(2, 0, 6));
            bool result = GameMechanics.IsMovePossible(CheckerManager.BrownCheckers[0].GameObj, GameObject.Find("Black (6)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsMovePossibleTest4()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsMovePossible(CheckerManager.BlueCheckers[0].GameObj, GameObject.Find("Black (50)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsMovePossibleTest5()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsMovePossible(CheckerManager.BlueCheckers[0].GameObj, GameObject.Find("Black (45)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsMovePossibleTest6()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[5].GameObj, new Vector3(2, 0, 6));
            bool result = GameMechanics.IsMovePossible(CheckerManager.BlueCheckers[0].GameObj, GameObject.Find("Black (45)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsFieldFreeTest()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsFieldFree(GameObject.Find("Black (1)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsFieldFreeTest2()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(2, 0, 6));
            bool result = GameMechanics.IsFieldFree(GameObject.Find("Black (1)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsFieldFreeTest3()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsFieldFree(GameObject.Find("Black (50)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsFieldFreeTest4()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(2, 0, 6));
            bool result = GameMechanics.IsFieldFree(GameObject.Find("Black (50)"));

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void AnyCheckerIsSelectedTest()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.AnyCheckerIsSelected();

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void AnyCheckerIsSelectedTest2()
        {
            TurnSystem.InitializeData();

            CheckerManager.SelectChecker(CheckerManager.BrownCheckers[0].GameObj);
            bool result = GameMechanics.AnyCheckerIsSelected();

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void AnyCheckerIsSelectedTest3()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.AnyCheckerIsSelected();

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void AnyCheckerIsSelectedTest4()
        {
            TurnSystem.InitializeData();

            CheckerManager.SelectChecker(CheckerManager.BlueCheckers[0].GameObj);
            bool result = GameMechanics.AnyCheckerIsSelected();

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void AnyCheckerIsSelectedTest5()
        {
            TurnSystem.InitializeData();

            CheckerManager.SelectChecker(CheckerManager.BlueCheckers[0].GameObj);
            CheckerManager.DeselectCheckers();
            bool result = GameMechanics.AnyCheckerIsSelected();

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsJumpPossibleTest()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsJumpPossible(CheckerManager.BrownCheckers[0].GameObj, FieldManager.BlackFieldsBoard[0].GameObject);

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsJumpPossibleTest2()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsJumpPossible(CheckerManager.BrownCheckers[10].GameObj, FieldManager.BlackFieldsBoard[21].GameObject);

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsJumpPossibleTest3()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(2, 0, 4));
            bool result = GameMechanics.IsJumpPossible(CheckerManager.BrownCheckers[10].GameObj, FieldManager.BlackFieldsBoard[21].GameObject);

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsJumpPossibleTest4()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(5, 0, 7));
            bool result = GameMechanics.IsJumpPossible(CheckerManager.BlueCheckers[13].GameObj, FieldManager.BlackFieldsBoard[27].GameObject);

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyMovePossibleTest()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsAnyMovePossible("Brown");

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyMovePossibleTest2()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(2, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[1].GameObj, new Vector3(4, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[2].GameObj, new Vector3(6, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[3].GameObj, new Vector3(8, 0, 4));
            GameMechanics.Move(CheckerManager.BlueCheckers[4].GameObj, new Vector3(10, 0, 4));
            bool result = GameMechanics.IsAnyMovePossible("Brown");

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyMovePossibleTest3()
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

            bool result = GameMechanics.IsAnyMovePossible("Brown");

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsAnyMovePossibleTest4()
        {
            TurnSystem.InitializeData();

            bool result = GameMechanics.IsAnyMovePossible("Blue");

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyMovePossibleTest5()
        {
            TurnSystem.InitializeData();

            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(1, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[1].GameObj, new Vector3(3, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[2].GameObj, new Vector3(5, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[3].GameObj, new Vector3(7, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[4].GameObj, new Vector3(9, 0, 7));
            bool result = GameMechanics.IsAnyMovePossible("Blue");

            GameMechanics.ResetGame();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAnyMovePossibleTest6()
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

            bool result = GameMechanics.IsAnyMovePossible("Blue");

            GameMechanics.ResetGame();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ResetGameTest()
        {
            TurnSystem.InitializeData();

            CameraManager.Camera = GameObject.Find("Main Camera");
            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(1, 0, 7));

            GameMechanics.ResetGame();

            Assert.AreEqual(new Vector3(1, 0.3f, 1), CheckerManager.BrownCheckers[0].GameObj.transform.position);
        }

        [Test]
        public void ResetGameTest2()
        {
            TurnSystem.InitializeData();

            CameraManager.Camera = GameObject.Find("Main Camera");
            GameMechanics.Move(CheckerManager.BlueCheckers[0].GameObj, new Vector3(1, 0, 7));
            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(10, 0, 10));

            GameMechanics.ResetGame();

            Assert.AreEqual(false, CheckerManager.BrownCheckers[0].IsKing);
        }

        [Test]
        public void ResetGameTest3()
        {
            TurnSystem.InitializeData();

            CameraManager.Camera = GameObject.Find("Main Camera");
            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(1, 0, 7));

            GameMechanics.ResetGame();

            Assert.AreEqual(2, FieldManager.BlackFieldsBoard[0].State);
        }

        [Test]
        public void ResetGameTest4()
        {
            TurnSystem.InitializeData();

            CameraManager.Camera = GameObject.Find("Main Camera");
            GameMechanics.Move(CheckerManager.BrownCheckers[0].GameObj, new Vector3(1, 0, 7));
            int state = FieldManager.BlackFieldsBoard[0].State;

            GameMechanics.ResetGame();

            Assert.AreEqual(1, state);
        }
    }
}
